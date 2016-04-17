using Solar.Animations;
using Solar.Animations.Biz;
using Solar.Dialogs;
using Solar.Images;
using SolarEditor.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SolarEditor
{
	/// <summary>
	/// 动画编辑模块
	/// </summary>
	public partial class FrmAnimationEditor : Solar.FrmAbstractModule
	{



		protected SAnimation CurrentAnimation;
		protected SAnimationState CurrentAnimationState;
		protected SAnimationLayer CurrentLayer;
		protected SAnimationDirection CurrentDirection;
		protected SAnimationFrame CurrentFrame;

		/// <summary>
		/// 构造
		/// </summary>
		public FrmAnimationEditor()
		{
			InitializeComponent();

			ModuleName = "动画";


			animationView.FPS = 60;

			try
			{

				uint fps = 60;	// Convert.ToUInt32(System.Configuration.ConfigurationSettings.AppSettings["FPS"]);
				string f = System.Configuration.ConfigurationSettings.AppSettings["FPS"];

				if (uint.TryParse(f, out fps))
				{
					if (fps < 1) fps = 1;
					if (fps > 60) fps = 60;
					animationView.FPS = fps;
				}
			}
			catch { }

			animationView.InitializeDirect2D();
		}

		/// <summary>
		/// 初始化
		/// </summary>
		protected override void Init()
		{
			base.Init();
			ModelTypes.Add(typeof(SAnimation));



			UpdateUI();

		}

		/// <summary>
		/// 关闭
		/// </summary>
		/// <returns></returns>
		protected override bool onClosing()
		{
			return SolarEditor.Common.SolarEditorManager.Current.OnModuleClosing(this);
		}


		/// <summary>
		/// 更新界面显示
		/// </summary>
		public void UpdateUI()
		{
			
			bool bSelectAnimation = CurrentAnimation != null;
			bool bSelectLayer = CurrentLayer != null;
			bool bSelectDirection = CurrentDirection != null;
			bool bSelectFrame = CurrentFrame != null;
			bool bSelectIsState = (CurrentLayer != null && CurrentLayer is SAnimationState);
			bool bSelectIsLayer = (CurrentLayer != null && CurrentLayer is SAnimationState == false && CurrentLayer is SAnimationLayer);


			//工具栏 ----

			//图层
			btnAnimAddState.Enabled = bSelectAnimation;
			btnAnimAddLayer.Enabled = bSelectIsState || bSelectIsLayer;
			btnAnimDelete.Enabled = bSelectLayer;
			btnAnimProperty.Enabled = bSelectLayer;
			btnAnimUp.Enabled = btnAnimDown.Enabled = bSelectIsLayer;

			//时间轴
			btnTimeLineImportFrame.Enabled =
			btnTimelineImportFrames.Enabled = (CurrentDirection != null);
			btnTimelineDeleteFrame.Enabled =
				btnTimelineAddLength.Enabled =
				btnTimelineRemoveLength.Enabled =
				btnTimelineMoveLeft.Enabled =
				btnTimelineMoveRight.Enabled = (CurrentFrame != null);


			timeline.CurrentDirection = CurrentDirection;

			//预览
			btnPreviewPlay.Enabled =
				btnPreviewPause.Enabled =
				btnPreviewTurnLeft.Enabled =
				btnPreviewTurnRight.Enabled =
				btnPreviewFirstFrame.Enabled =
				btnPreviewPrevFrame.Enabled =
				btnPreviewNextFrame.Enabled =
				btnPreviewLastFrame.Enabled =
				btnPreviewZoomIn.Enabled =
				btnPreviewZoomOut.Enabled =
				btnPreviewStyle.Enabled =
					CurrentAnimationState != null;

			animationView.CurrentAnimationState = CurrentAnimationState;

			UpdateMainUI();
		}


		/// <summary>
		/// 选定动画时
		/// </summary>
		protected override void onSelectedModelChange()
		{
			base.onSelectedModelChange();

			if (SelectedModel is SAnimation)
			{
				CurrentAnimation = (SAnimation)SelectedModel;
				if (CurrentAnimation.States.Count > 0)
				{
					CurrentAnimationState = CurrentAnimation.States[0];
				}
			}
			else
			{
				CurrentAnimation = null;
				CurrentAnimationState = null;
			}

			SAnimationLayerBiz.LoadLayers(treeLayers, CurrentAnimation);
			treeLayers_AfterSelect();
			UpdateUI();
			
		}

		/// <summary>
		/// 选定图层时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void treeLayers_AfterSelect(object sender = null, TreeViewEventArgs e =null)
		{
			if (treeLayers.SelectedNode == null || treeLayers.SelectedNode.Tag is SAnimationLayer == false)
			{
				CurrentLayer = null;
				CurrentFrame = null;
				CurrentDirection = null;
				CurrentAnimationState = null;
			}
			else
			{
				CurrentLayer = (SAnimationLayer)treeLayers.SelectedNode.Tag;
				CurrentAnimationState = CurrentLayer.GetState();



				if (CurrentLayer.Directions.Count > 0) CurrentDirection = CurrentLayer.Directions[0];
				else
				{
					CurrentDirection = null;
					CurrentFrame = null;
				}

				if (CurrentDirection != null && CurrentDirection.Frames.Count > 0)
				{
					CurrentFrame = CurrentDirection.Frames[0];
				}
				else
				{
					CurrentFrame = null;
				}
			}

			UpdateUI();
		}


		#region 图层操作

		/// <summary>
		/// 添加状态
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAnimAddState_Click(object sender, EventArgs e)
		{
			SAnimationLayerBiz.AddState(CurrentAnimation, treeLayers);
			DataChanged = true;
			UpdateUI();
		}

		/// <summary>
		/// 添加图层
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAnimAddLayer_Click(object sender, EventArgs e)
		{
			SAnimationLayerBiz.AddLayer(CurrentLayer, treeLayers);
			DataChanged = true;
			UpdateUI();
		}

		/// <summary>
		/// 删除节点
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAnimDelete_Click(object sender, EventArgs e)
		{
			SAnimationLayerBiz.DeleteLayer(treeLayers);
			DataChanged = true;
			treeLayers_AfterSelect();
			UpdateUI();
		}

		/// <summary>
		/// 节点属性
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAnimProperty_Click(object sender, EventArgs e)
		{
			SAnimationLayerBiz.OpenProperty(this, treeLayers);
			DataChanged = true;
			UpdateUI();
		}

		/// <summary>
		/// 上移节点
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAnimUp_Click(object sender, EventArgs e)
		{
			SAnimationLayerBiz.MoveUp(CurrentLayer);
			DataChanged = true;
			UpdateUI();
		}

		/// <summary>
		/// 下移节点
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAnimDown_Click(object sender, EventArgs e)
		{
			SAnimationLayerBiz.MoveDown(CurrentLayer);
			DataChanged = true;
			UpdateUI();
		}

		#endregion

		#region 时间轴操作

		/// <summary>
		/// 导入帧
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTimeLineImportFrame_Click(object sender, EventArgs e)
		{
			if (CurrentDirection == null) return;

			//导入当前帧
			if (!SolarEditorManager.Current.ImageEditor.Visible)
			{
				SolarEditorManager.Current.ImageEditor.Show();
				SolarEditorManager.Current.ImageEditor.Focus();
				SolarEditorManager.Current.ImageEditor.Select();
			}
			else
			{
				SImage image = SolarEditorManager.Current.ImageEditor.SelectedImage;
				int row = SolarEditorManager.Current.ImageEditor.SelectedRow;
				int column = SolarEditorManager.Current.ImageEditor.SelectedColumn;

				SAnimationDirectionBiz.ImportFrame(CurrentDirection, image, row, column);
				timeline.Invalidate();
				UpdateUI();
			}


		}

		/// <summary>
		/// 导入序列帧
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTimelineImportFrames_Click(object sender, EventArgs e)
		{
			if (CurrentLayer == null) return;

			//导入所有帧
			if (!SolarEditorManager.Current.ImageEditor.Visible)
			{
				SolarEditorManager.Current.ImageEditor.Show();
				SolarEditorManager.Current.ImageEditor.Focus();
				SolarEditorManager.Current.ImageEditor.Select();
			}
			else
			{
				SImage image = SolarEditorManager.Current.ImageEditor.SelectedImage;
				SAnimationDirectionBiz.ImportFrames(CurrentLayer, image);
				if (CurrentLayer.Directions.Count > 0)
				{
					CurrentDirection = CurrentLayer.Directions[0];
				}
				else
				{
					CurrentDirection = null;
				}
				timeline.Invalidate();
				UpdateUI();
			}

		}

		/// <summary>
		/// 删除帧
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTimelineDeleteFrame_Click(object sender, EventArgs e)
		{
			SAnimationDirectionBiz.DeleteFrame(CurrentDirection, CurrentFrame);
			timeline.Invalidate();
		}


		/// <summary>
		/// 左移帧
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTimelineMoveLeft_Click(object sender, EventArgs e)
		{
			SAnimationDirectionBiz.MoveFrameLeft(CurrentDirection, CurrentFrame);
			timeline.Invalidate();
		}

		/// <summary>
		/// 右移帧
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTimelineMoveRight_Click(object sender, EventArgs e)
		{
			SAnimationDirectionBiz.MoveFrameRight(CurrentDirection, CurrentFrame);
			timeline.Invalidate();
		}

		/// <summary>
		/// 加长
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTimelineAddLength_Click(object sender, EventArgs e)
		{
			SAnimationDirectionBiz.AddFrameLength(CurrentDirection, CurrentFrame);
			timeline.Invalidate();
		}

		/// <summary>
		/// 减短
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTimelineRemoveLength_Click(object sender, EventArgs e)
		{
			SAnimationDirectionBiz.RemoveFrameLength(CurrentDirection, CurrentFrame);
			timeline.Invalidate();
		}


		#endregion

		#region 预览操作

		/// <summary>
		/// 播放
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPreviewPlay_Click(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 暂停
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPreviewPause_Click(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 左转
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPreviewTurnLeft_Click(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 右转
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPreviewTurnRight_Click(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 第一帧
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPreviewFirstFrame_Click(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 上一帧
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPreviewPrevFrame_Click(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 下一帧
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPreviewNextFrame_Click(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 最后一帧
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPreviewLastFrame_Click(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 缩小
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPreviewZoomIn_Click(object sender, EventArgs e)
		{
			float s = animationView.ViewContext.Scale.X;
			s /= 2;
			if (s < 1) s = 1;
			animationView.ViewContext.Scale = new PointF(s, s);
		}

		/// <summary>
		/// 放大
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPreviewZoomOut_Click(object sender, EventArgs e)
		{
			float s = animationView.ViewContext.Scale.X;
			s *= 2;
			if (s > 8) s = 8;
			animationView.ViewContext.Scale = new PointF(s, s);
		}

		/// <summary>
		/// 样式限定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPreviewStyle_Click(object sender, EventArgs e)
		{

		}
		#endregion

		private void timeline_AfterSelectedChanged(object sender, EventArgs e)
		{
			CurrentFrame = timeline.CurrentFrame;
			propertyGrid.SelectedObject = CurrentFrame;

			//frameindex
			UpdateUI();
		}

		private void animationView_DirectionChanged(object sender, EventArgs e)
		{
			if (treeLayers.SelectedNode == null) return;
			if (treeLayers.SelectedNode.Tag is SAnimationLayer)
			{
				SAnimationLayer layer = (SAnimationLayer)treeLayers.SelectedNode.Tag;
				int i = layer.GetDirection(animationView.ViewContext);
				if (i >= 0 && i < layer.Directions.Count)
				{
					CurrentDirection = layer.Directions[i];
					timeline.SetCurrentDirection(layer.Directions[i]);
				}
				//Debug.WriteLine(String.Format("animationView_DirectionChanged"));
			}
			
		}

		private void animationView_FrameChanged(object sender, EventArgs e)
		{
			timeline.SetCurrentFrameIndex(animationView.FrameIndex);
			//Debug.WriteLine(String.Format("animationView_FrameChanged {0}", animationView.FrameIndex));
		}

		private void btnShootPosition_Click(object sender, EventArgs e)
		{
			if (treeLayers.SelectedNode == null) return;
			if (treeLayers.SelectedNode.Tag is SAnimationLayer)
			{
				SAnimationLayer layer = (SAnimationLayer)treeLayers.SelectedNode.Tag;
				int i = layer.GetDirection(animationView.ViewContext);
				if (i >= 0 && i < layer.Directions.Count)
				{
					DialogShootPosition.Instance.CurrentDirection = layer.Directions[i];
					DialogShootPosition.Instance.Show();
				}
			}
			
		}




	}
}
