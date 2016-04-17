using Solar.Components.D2DRender;
using Solar.Dialogs;
using Solar.Images;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SolarEditor
{
	/// <summary>
	/// 图片编辑
	/// </summary>
	public partial class FrmImageEditor : Solar.FrmAbstractModule
	{
		protected ToolStripLabel labelSize;
		protected ToolStripLabel labelRowAndColumn;
		protected ToolStripLabel labelFrame;
		protected ToolStripSeparator sep1;
		protected ToolStripSeparator sep2;
		protected ToolStripSeparator sep3;

		/// <summary>
		/// 构造
		/// </summary>
		public FrmImageEditor()
		{
			InitializeComponent();

			ModuleName = "图片";
		}

		protected override bool onClosing()
		{
			return SolarEditor.Common.SolarEditorManager.Current.OnModuleClosing(this);
		}

		/// <summary>
		/// 初始化
		/// </summary>
		protected override void Init()
		{
			base.Init();
			ModelTypes.Add(typeof(SImage));
			


			//----

			sep1 = new ToolStripSeparator();
			statusBar.Items.Add(sep1);

			//----

			labelSize = new ToolStripLabel();
			labelSize.Text = "";
			statusBar.Items.Add(labelSize);

			//----

			sep2 = new ToolStripSeparator();
			statusBar.Items.Add(sep2);

			//----

			labelRowAndColumn = new ToolStripLabel();
			labelRowAndColumn.Text = "";
			statusBar.Items.Add(labelRowAndColumn);

			//----

			sep3 = new ToolStripSeparator();
			statusBar.Items.Add(sep3);

			//----

			labelFrame = new ToolStripLabel();
			labelFrame.Text = "";
			statusBar.Items.Add(labelFrame);

			UpdateUI();
		}

		/// <summary>
		/// 更新界面
		/// </summary>
		protected void UpdateUI()
		{
			if (SelectedModel is SImage)
			{
				SImage image = (SImage)SelectedModel;

				labelSize.Text = String.Format("图片: {0} x {1}", image.Width, image.Height);
				labelRowAndColumn.Text = String.Format("{0} 行, {1} 列", image.Rows, image.Columns);
				labelFrame.Text = String.Format("帧: {0} x {1}", image.FrameWidth, image.FrameHeight);

				labelSize.Visible =
					labelRowAndColumn.Visible =
					labelFrame.Visible =
					sep1.Visible =
					sep2.Visible =
					sep3.Visible = true;
			}
			else
			{
				labelSize.Visible =
					labelRowAndColumn.Visible =
					labelFrame.Visible =
					sep1.Visible =
					sep2.Visible =
					sep3.Visible = false;
			}

			btnImageOpen.Enabled = (SelectedModel is SImage);

			//---添加移除行列

			btnImageAddColumn.Enabled =
			btnImageRemoveColumn.Enabled =
			btnImageAddRow.Enabled =
			btnImageRemoveRow.Enabled =
			btnImageRowAndColumn.Enabled =
			btnImageRelayout.Enabled =
				(SelectedModel is SImage && ((SImage)SelectedModel).ImageSource != null);

			//---删除行列
			btnImageDeleteRow.Enabled = (SelectedModel is SImage && ((SImage)SelectedModel).ImageSource != null && ((SImage)SelectedModel).Rows > 1);
			btnImageDeleteColumn.Enabled = (SelectedModel is SImage && ((SImage)SelectedModel).ImageSource != null && ((SImage)SelectedModel).Columns > 1);

			//---偏移行列


			btnImageMoveDown.Enabled =
			(SelectedModel is SImage && ((SImage)SelectedModel).ImageSource != null && ((SImage)SelectedModel).Rows > 1);



			btnImageMoveRight.Enabled =
			(SelectedModel is SImage && ((SImage)SelectedModel).ImageSource != null && ((SImage)SelectedModel).Columns > 1);


			//---导出
			btnImageSave.Enabled =
				btnImageSaveAll.Enabled =
				(SelectedModel is SImage && ((SImage)SelectedModel).ImageSource != null);


			//FIXME relayout 支持

			btnImageRelayout.Visible = false;
		}

		/// <summary>
		/// 选定内容
		/// </summary>
		protected override void onSelectedModelChange()
		{
			base.onSelectedModelChange();

			if (SelectedModel is SImage)
			{
				imageView.CurrentImage = (SImage)SelectedModel;
			}
			else
			{
				imageView.CurrentImage = null;
			}

			UpdateUI();
		}

		/// <summary>
		/// 打开图片
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImageOpen_Click(object sender, EventArgs e)
		{
			if (SelectedModel is SImage == false) return;

			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "PNG file|*.png";
			if (dialog.ShowDialog(this) == DialogResult.Cancel) return;

			if (((SImage)SelectedModel).OpenImage(dialog.FileName))
			{
				imageView.setRedraw(true, true);
				imageView.Invalidate();

				UpdateUI();

				SelectedModel.ChangeType = Solar.Data.DataChangeTypes.DataChanged | Solar.Data.DataChangeTypes.FileChanged;
				DataChanged = true;
				UpdateMainUI();
			}

		}

		/// <summary>
		/// 加行
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImageAddRow_Click(object sender, EventArgs e)
		{
			if (SelectedModel is SImage == false) return;

			SImage image = (SImage)SelectedModel;
			image.Rows++;
			imageView.setRedraw(false, true);
			imageView.Invalidate();
			UpdateUI();

			SelectedModel.ChangeType = Solar.Data.DataChangeTypes.DataChanged;
			DataChanged = true;
			UpdateMainUI();
		}

		/// <summary>
		/// 加列
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImageAddColumn_Click(object sender, EventArgs e)
		{
			if (SelectedModel is SImage == false) return;

			SImage image = (SImage)SelectedModel;
			image.Columns++;
			imageView.setRedraw(false, true);
			imageView.Invalidate();
			UpdateUI();

			SelectedModel.ChangeType = Solar.Data.DataChangeTypes.DataChanged;
			DataChanged = true;
			UpdateMainUI();
		}

		/// <summary>
		/// 减行
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImageRemoveRow_Click(object sender, EventArgs e)
		{
			if (SelectedModel is SImage == false) return;

			SImage image = (SImage)SelectedModel;
			image.Rows--;
			imageView.setRedraw(false, true);
			imageView.Invalidate();
			UpdateUI();

			SelectedModel.ChangeType = Solar.Data.DataChangeTypes.DataChanged;
			DataChanged = true;
			UpdateMainUI();
		}

		/// <summary>
		/// 减列
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImageRemoveColumn_Click(object sender, EventArgs e)
		{
			if (SelectedModel is SImage == false) return;

			SImage image = (SImage)SelectedModel;
			image.Columns--;
			imageView.setRedraw(false, true);
			imageView.Invalidate();
			UpdateUI();

			SelectedModel.ChangeType = Solar.Data.DataChangeTypes.DataChanged;
			DataChanged = true;
			UpdateMainUI();
		}

		/// <summary>
		/// 编辑行列
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImageRowAndColumn_Click(object sender, EventArgs e)
		{
			if (SelectedModel is SImage == false) return;

			SImage image = (SImage)SelectedModel;

			DialogImageRowsAndColumns dialog = new DialogImageRowsAndColumns();
			dialog.CurrentImage = image;
			if (dialog.ShowDialog(this) == DialogResult.Cancel) return;

			imageView.setRedraw(false, true);
			imageView.Invalidate();
			UpdateUI();

			SelectedModel.ChangeType = Solar.Data.DataChangeTypes.DataChanged;
			DataChanged = true;
			UpdateMainUI();
		}

		/// <summary>
		/// 删除行
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImageDeleteRow_Click(object sender, EventArgs e)
		{
			if (LayerDrawing.CheckCacheBitmapsRunning()) return;
			if (SelectedModel is SImage == false) return;

			SImage image = (SImage)SelectedModel;
			image.DeleteRows(imageView.SelectedRow);

			imageView.setRedraw(true, true);
			imageView.Invalidate();
			UpdateUI();

			SelectedModel.ChangeType = Solar.Data.DataChangeTypes.DataChanged | Solar.Data.DataChangeTypes.FileChanged;
			DataChanged = true;
			UpdateMainUI();

		}

		/// <summary>
		/// 删除列
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImageDeleteColumn_Click(object sender, EventArgs e)
		{
			if (LayerDrawing.CheckCacheBitmapsRunning()) return;
			if (SelectedModel is SImage == false) return;

			SImage image = (SImage)SelectedModel;
			image.DeleteColumns(imageView.SelectedColumn);

			imageView.setRedraw(true, true);
			imageView.Invalidate();
			UpdateUI();

			SelectedModel.ChangeType = Solar.Data.DataChangeTypes.DataChanged | Solar.Data.DataChangeTypes.FileChanged;
			DataChanged = true;
			UpdateMainUI();
		}

		/// <summary>
		/// 右移
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImageMoveRight_Click(object sender, EventArgs e)
		{
			if (LayerDrawing.CheckCacheBitmapsRunning()) return;
			if (SelectedModel is SImage == false) return;

			SImage image = (SImage)SelectedModel;
			image.ScrollColumns(1);

			imageView.setRedraw(true, true);
			imageView.Invalidate();
			UpdateUI();

			SelectedModel.ChangeType = Solar.Data.DataChangeTypes.DataChanged | Solar.Data.DataChangeTypes.FileChanged;
			DataChanged = true;
			UpdateMainUI();
		}


		/// <summary>
		/// 下移
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImageMoveDown_Click(object sender, EventArgs e)
		{
			if (LayerDrawing.CheckCacheBitmapsRunning()) return;
			if (SelectedModel is SImage == false) return;

			SImage image = (SImage)SelectedModel;
			image.ScrollRows(1);

			imageView.setRedraw(true, true);
			imageView.Invalidate();
			UpdateUI();

			SelectedModel.ChangeType = Solar.Data.DataChangeTypes.DataChanged | Solar.Data.DataChangeTypes.FileChanged;
			DataChanged = true;
			UpdateMainUI();
		}


		/// <summary>
		/// 重新布局网格
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImageRelayout_Click(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 保存当前帧
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImageSave_Click(object sender, EventArgs e)
		{
			if (SelectedModel is SImage == false) return;

			SImage image = (SImage)SelectedModel;

			FolderBrowserDialog dialog = new FolderBrowserDialog();
			if (dialog.ShowDialog(this) == DialogResult.Cancel) return;

			image.ExportFrame(dialog.SelectedPath, imageView.SelectedRow, imageView.SelectedColumn, image.Id);


		}

		/// <summary>
		/// 保存所有帧
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImageSaveAll_Click(object sender, EventArgs e)
		{
			if (SelectedModel is SImage == false) return;

			SImage image = (SImage)SelectedModel;

			FolderBrowserDialog dialog = new FolderBrowserDialog();
			if (dialog.ShowDialog(this) == DialogResult.Cancel) return;

			image.ExportFrames(dialog.SelectedPath, image.Id);
		}



		/// <summary>
		/// 当前选定图片
		/// </summary>
		public SImage SelectedImage
		{
			get
			{
				if (SelectedModel is SImage)
				{
					return (SImage)SelectedModel;
				}

				return null;
			}
		}

		/// <summary>
		/// 当前选定行
		/// </summary>
		public int SelectedRow
		{
			get
			{
				return imageView.SelectedRow;
			}
		}

		/// <summary>
		/// 当前选定列
		/// </summary>
		public int SelectedColumn
		{
			get
			{
				return imageView.SelectedColumn;
			}
		}
	}
}
