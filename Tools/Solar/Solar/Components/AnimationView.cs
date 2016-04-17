using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.D2D;
using Solar.Animations;
using Solar.Components.D2DRender;
using System.Diagnostics;
using Solar.Components.Drags;

namespace Solar.Components
{
	/// <summary>
	/// 动画视图
	/// </summary>
	public partial class AnimationView : D2DCanvas
	{
		protected ContextMenuStrip contextMenu;
		protected ToolStripMenuItem btnPreviewLight;
		protected ToolStripMenuItem btnPreviewDark;

		protected List<IDragMethod> DragMethods = new List<IDragMethod>();

		/// <summary>
		/// 构造
		/// </summary>
		public AnimationView()
		{
			InitializeComponent();

			//context
			ViewContext = new AnimationViewContext();
			ViewContext.AnimationView = this;

			//menu
			contextMenu = new ContextMenuStrip();
			contextMenu.Opening += contextMenu_Opening;

			AnimationViewStyle light = AnimationViewStyle.Light;

			btnPreviewLight = new ToolStripMenuItem();
			btnPreviewLight.Text = "浅色背景";
			btnPreviewLight.Tag = light;
			ViewContext.ViewStyle = light;
			contextMenu.Items.Add(btnPreviewLight);
			btnPreviewLight.Click += OnStyleMenuClick;

			btnPreviewDark = new ToolStripMenuItem();
			btnPreviewDark.Text = "深色背景";
			btnPreviewDark.Tag = AnimationViewStyle.Dark;
			contextMenu.Items.Add(btnPreviewDark);
			btnPreviewDark.Click += OnStyleMenuClick;

			this.ContextMenuStrip = contextMenu;

			//drag
			DragBeginPosition = new Point();
			DragMethods.Add(
				new DirectionDragMethod(
					AnimationDirectionType.Move,
					DirectionDrawing.CIRCLE_SPACING + DirectionDrawing.CIRCLE_RADIUS,
					DirectionDrawing.CIRCLE_SPACING + DirectionDrawing.CIRCLE_RADIUS));

			DragMethods.Add(
				new DirectionDragMethod(
					AnimationDirectionType.Attack,
					DirectionDrawing.CIRCLE_SPACING * 2 + DirectionDrawing.CIRCLE_RADIUS * 3,
					DirectionDrawing.CIRCLE_SPACING + DirectionDrawing.CIRCLE_RADIUS));
		}

		#region methods

		/// <summary>
		/// 弹出菜单时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void contextMenu_Opening(object sender, CancelEventArgs e)
		{
			btnPreviewLight.Checked = (ViewContext.ViewStyle == btnPreviewLight.Tag);
			btnPreviewDark.Checked = (ViewContext.ViewStyle == btnPreviewDark.Tag);
		}

		/// <summary>
		/// 点击样式菜单时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void OnStyleMenuClick(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem == false) return;

			ToolStripMenuItem menuItem = ((ToolStripMenuItem)sender);
			if (menuItem.Tag is AnimationViewStyle)
			{
				ViewContext.ViewStyle = (AnimationViewStyle)menuItem.Tag;
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			IsDragging = true;

			DragBeginPosition = new Point(e.X, e.Y);
			foreach (IDragMethod drag in DragMethods)
			{
				drag.OnDragBegin(ViewContext, e.X, e.Y);
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			if (!IsDragging) return;
			foreach (IDragMethod drag in DragMethods)
			{
				drag.OnDragMove(ViewContext, e.X, e.Y);
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);

			if (!IsDragging) return;
			foreach (IDragMethod drag in DragMethods)
			{
				drag.OnDragEnd(ViewContext, e.X, e.Y);
			}
			IsDragging = false;
		}

		/// <summary>
		/// 计算注册点位置
		/// </summary>
		/// <returns></returns>
		public Point GetAnchorPoint()
		{
			Point result = new Point();
			result.X = Width / 2;
			result.Y = Height / 2;
			return result;
		}

		/// <summary>
		/// 创建上下文
		/// </summary>
		/// <returns></returns>
		protected AnimationViewContext CreateContext()
		{
			AnimationViewContext context = ViewContext.Clone();

			context.AnimationView = this;
			context.Render = D2D.WindowRenderTarget;
			context.Controller = D2D;

			context.Position = GetAnchorPoint();

			context.FrameIndex = FrameIndex;

			return context;
		}

		/// <summary>
		/// 绘制过程
		/// </summary>
		protected override void Renderendering()
		{
			base.Renderendering();

			AnimationViewContext context = CreateContext();


			DrawBackground(context);
			DrawLowLevel(context);
			DrawNormalLevel(context);
			DrawHighLevel(context);
			DrawUILevel(context);
		}

		/// <summary>
		/// 绘制背景
		/// </summary>
		/// <param name="context"></param>
		protected virtual void DrawBackground(AnimationViewContext context)
		{
			context.Render.Clear(context.Controller.GetColor(context.ViewStyle.Background));
		}

		/// <summary>
		/// 绘制低层
		/// </summary>
		/// <param name="context"></param>
		protected virtual void DrawLowLevel(AnimationViewContext context)
		{
			PlaceDrawing.DrawPlace(context);
		}

		/// <summary>
		/// 绘制默认层
		/// </summary>
		/// <param name="context"></param>
		protected virtual void DrawNormalLevel(AnimationViewContext context)
		{
			LayerDrawing.DrawLayer(CurrentAnimationState, context);
		}

		/// <summary>
		/// 绘制高层
		/// </summary>
		/// <param name="context"></param>
		protected virtual void DrawHighLevel(AnimationViewContext context)
		{
		}

		/// <summary>
		/// 绘制界面层
		/// </summary>
		/// <param name="context"></param>
		protected virtual void DrawUILevel(AnimationViewContext context)
		{
			PointDrawing.DrawZeroPoint(context);
			DirectionDrawing.DrawDirections(context);
		}

		protected override void NextFrame()
		{
			base.NextFrame();

			if (FrameChanged != null) FrameChanged(this, new EventArgs());
		}

		public void ThrowDirectionChangedEvent()
		{
			if (DirectionChanged != null)
			{
				DirectionChanged(this, new EventArgs());
			}
		}

		#endregion

		#region properties

		/// <summary>
		/// 视图上下文
		/// </summary>
		public AnimationViewContext ViewContext { get; set; }

		/// <summary>
		/// 当前动画状态
		/// </summary>
		public SAnimationState CurrentAnimationState { get; set; }

		/// <summary>
		/// 开始拖动时的位置
		/// </summary>
		public Point DragBeginPosition { get; set; }

		/// <summary>
		/// 是否正在拖动
		/// </summary>
		public bool IsDragging { get; set; }

		#endregion

		#region events

		/// <summary>
		/// 方向改变事件
		/// </summary>
		public event EventHandler DirectionChanged;
		/// <summary>
		/// 帧改变事件
		/// </summary>
		public event EventHandler FrameChanged;

		#endregion
	}
}
