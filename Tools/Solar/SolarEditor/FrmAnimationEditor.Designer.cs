namespace SolarEditor
{
	partial class FrmAnimationEditor
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			Solar.Components.D2DRender.AnimationViewContext animationViewContext2 = new Solar.Components.D2DRender.AnimationViewContext();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnimationEditor));
			Solar.Components.AnimationViewStyle animationViewStyle2 = new Solar.Components.AnimationViewStyle();
			this.animationView = new Solar.Components.AnimationView();
			this.panelLayers = new THOR.Windows.UI.Components.TPanel();
			this.treeLayers = new THOR.Windows.UI.Components.TTreeView();
			this.imageListLayers = new System.Windows.Forms.ImageList(this.components);
			this.toolBarLayers = new THOR.Windows.UI.Components.TToolBar();
			this.btnAnimAddState = new System.Windows.Forms.ToolStripButton();
			this.btnAnimAddLayer = new System.Windows.Forms.ToolStripButton();
			this.btnAnimDelete = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnAnimProperty = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.btnAnimUp = new System.Windows.Forms.ToolStripButton();
			this.btnAnimDown = new System.Windows.Forms.ToolStripButton();
			this.tSplitter2 = new THOR.Windows.UI.Components.TSplitter();
			this.panelTimeline = new THOR.Windows.UI.Components.TPanel();
			this.timeline = new Solar.Components.Timeline();
			this.toolBarTimeline = new THOR.Windows.UI.Components.TToolBar();
			this.btnTimeLineImportFrame = new System.Windows.Forms.ToolStripButton();
			this.btnTimelineImportFrames = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.btnTimelineDeleteFrame = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.btnTimelineMoveLeft = new System.Windows.Forms.ToolStripButton();
			this.btnTimelineMoveRight = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.btnTimelineAddLength = new System.Windows.Forms.ToolStripButton();
			this.btnTimelineRemoveLength = new System.Windows.Forms.ToolStripButton();
			this.tSplitter3 = new THOR.Windows.UI.Components.TSplitter();
			this.toolBarPreview = new THOR.Windows.UI.Components.TToolBar();
			this.btnPreviewPlay = new System.Windows.Forms.ToolStripButton();
			this.btnPreviewPause = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnPreviewTurnLeft = new System.Windows.Forms.ToolStripButton();
			this.btnPreviewTurnRight = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnPreviewFirstFrame = new System.Windows.Forms.ToolStripButton();
			this.btnPreviewPrevFrame = new System.Windows.Forms.ToolStripButton();
			this.btnPreviewNextFrame = new System.Windows.Forms.ToolStripButton();
			this.btnPreviewLastFrame = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.btnPreviewZoomOut = new System.Windows.Forms.ToolStripButton();
			this.btnPreviewZoomIn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.btnPreviewStyle = new System.Windows.Forms.ToolStripButton();
			this.panelPreview = new THOR.Windows.UI.Components.TPanel();
			this.panelPropertyGrid = new THOR.Windows.UI.Components.TPanel();
			this.propertyGrid = new System.Windows.Forms.PropertyGrid();
			this.tSplitter4 = new THOR.Windows.UI.Components.TSplitter();
			this.btnShootPosition = new System.Windows.Forms.ToolStripButton();
			this.panelMain.SuspendLayout();
			this.panelLayers.SuspendLayout();
			this.toolBarLayers.SuspendLayout();
			this.panelTimeline.SuspendLayout();
			this.toolBarTimeline.SuspendLayout();
			this.toolBarPreview.SuspendLayout();
			this.panelPreview.SuspendLayout();
			this.panelPropertyGrid.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelMain
			// 
			this.panelMain.Controls.Add(this.panelPreview);
			this.panelMain.Controls.Add(this.tSplitter4);
			this.panelMain.Controls.Add(this.panelPropertyGrid);
			this.panelMain.Controls.Add(this.tSplitter3);
			this.panelMain.Controls.Add(this.panelTimeline);
			this.panelMain.Controls.Add(this.tSplitter2);
			this.panelMain.Controls.Add(this.panelLayers);
			// 
			// animationView
			// 
			this.animationView.BackColor = System.Drawing.SystemColors.Window;
			this.animationView.CurrentAnimationState = null;
			this.animationView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.animationView.DragBeginPosition = new System.Drawing.Point(0, 0);
			this.animationView.ForeColor = System.Drawing.SystemColors.WindowText;
			this.animationView.FPS = ((uint)(0u));
			this.animationView.IsDragging = false;
			this.animationView.Location = new System.Drawing.Point(2, 51);
			this.animationView.Name = "animationView";
			this.animationView.Size = new System.Drawing.Size(173, 301);
			this.animationView.TabIndex = 1;
			animationViewContext2.AnimationView = this.animationView;
			animationViewContext2.AttackAngle = 45F;
			animationViewContext2.Controller = null;
			animationViewContext2.DrawGuide = true;
			animationViewContext2.FrameIndex = ((long)(0));
			animationViewContext2.MoveAngle = 45F;
			animationViewContext2.Position = ((System.Drawing.PointF)(resources.GetObject("animationViewContext2.Position")));
			
			animationViewContext2.Rotation = 0F;
			animationViewContext2.Scale = ((System.Drawing.PointF)(resources.GetObject("animationViewContext2.Scale")));
			animationViewStyle2.Anchor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			animationViewStyle2.Background = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			animationViewStyle2.Grid = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
			animationViewStyle2.Weapon = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
			animationViewContext2.ViewStyle = animationViewStyle2;
			this.animationView.ViewContext = animationViewContext2;
			this.animationView.DirectionChanged += new System.EventHandler(this.animationView_DirectionChanged);
			this.animationView.FrameChanged += new System.EventHandler(this.animationView_FrameChanged);
			// 
			// panelLayers
			// 
			this.panelLayers.Controls.Add(this.treeLayers);
			this.panelLayers.Controls.Add(this.toolBarLayers);
			this.panelLayers.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelLayers.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panelLayers.Location = new System.Drawing.Point(0, 0);
			this.panelLayers.Name = "panelLayers";
			this.panelLayers.Padding = new System.Windows.Forms.Padding(2, 24, 2, 2);
			this.panelLayers.Size = new System.Drawing.Size(180, 513);
			this.panelLayers.TabIndex = 0;
			this.panelLayers.Title = "图层";
			this.panelLayers.TitleFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			// 
			// treeLayers
			// 
			this.treeLayers.AllowDragNode = false;
			this.treeLayers.AllowDrop = true;
			this.treeLayers.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeLayers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeLayers.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.treeLayers.HideSelection = false;
			this.treeLayers.ImageIndex = 0;
			this.treeLayers.ImageList = this.imageListLayers;
			this.treeLayers.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
			this.treeLayers.Location = new System.Drawing.Point(2, 51);
			this.treeLayers.Name = "treeLayers";
			this.treeLayers.SelectedImageIndex = 0;
			this.treeLayers.Size = new System.Drawing.Size(176, 460);
			this.treeLayers.TabIndex = 1;
			this.treeLayers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeLayers_AfterSelect);
			// 
			// imageListLayers
			// 
			this.imageListLayers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLayers.ImageStream")));
			this.imageListLayers.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListLayers.Images.SetKeyName(0, "state.png");
			this.imageListLayers.Images.SetKeyName(1, "layer.png");
			// 
			// toolBarLayers
			// 
			this.toolBarLayers.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.toolBarLayers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.toolBarLayers.GripMargin = new System.Windows.Forms.Padding(0);
			this.toolBarLayers.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolBarLayers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAnimAddState,
            this.btnAnimAddLayer,
            this.btnAnimDelete,
            this.toolStripSeparator1,
            this.btnAnimProperty,
            this.toolStripSeparator6,
            this.btnAnimUp,
            this.btnAnimDown});
			this.toolBarLayers.Location = new System.Drawing.Point(2, 24);
			this.toolBarLayers.Name = "toolBarLayers";
			this.toolBarLayers.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.toolBarLayers.Size = new System.Drawing.Size(176, 27);
			this.toolBarLayers.TabIndex = 0;
			this.toolBarLayers.Text = "tToolBar1";
			// 
			// btnAnimAddState
			// 
			this.btnAnimAddState.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAnimAddState.Enabled = false;
			this.btnAnimAddState.Image = ((System.Drawing.Image)(resources.GetObject("btnAnimAddState.Image")));
			this.btnAnimAddState.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAnimAddState.Name = "btnAnimAddState";
			this.btnAnimAddState.Size = new System.Drawing.Size(23, 20);
			this.btnAnimAddState.Text = "添加状态";
			this.btnAnimAddState.Click += new System.EventHandler(this.btnAnimAddState_Click);
			// 
			// btnAnimAddLayer
			// 
			this.btnAnimAddLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAnimAddLayer.Enabled = false;
			this.btnAnimAddLayer.Image = ((System.Drawing.Image)(resources.GetObject("btnAnimAddLayer.Image")));
			this.btnAnimAddLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAnimAddLayer.Name = "btnAnimAddLayer";
			this.btnAnimAddLayer.Size = new System.Drawing.Size(23, 20);
			this.btnAnimAddLayer.Text = "添加图层";
			this.btnAnimAddLayer.Click += new System.EventHandler(this.btnAnimAddLayer_Click);
			// 
			// btnAnimDelete
			// 
			this.btnAnimDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAnimDelete.Enabled = false;
			this.btnAnimDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnAnimDelete.Image")));
			this.btnAnimDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAnimDelete.Name = "btnAnimDelete";
			this.btnAnimDelete.Size = new System.Drawing.Size(23, 20);
			this.btnAnimDelete.Text = "删除节点";
			this.btnAnimDelete.Click += new System.EventHandler(this.btnAnimDelete_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
			// 
			// btnAnimProperty
			// 
			this.btnAnimProperty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAnimProperty.Enabled = false;
			this.btnAnimProperty.Image = ((System.Drawing.Image)(resources.GetObject("btnAnimProperty.Image")));
			this.btnAnimProperty.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAnimProperty.Name = "btnAnimProperty";
			this.btnAnimProperty.Size = new System.Drawing.Size(23, 20);
			this.btnAnimProperty.Text = "属性";
			this.btnAnimProperty.Click += new System.EventHandler(this.btnAnimProperty_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
			// 
			// btnAnimUp
			// 
			this.btnAnimUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAnimUp.Enabled = false;
			this.btnAnimUp.Image = ((System.Drawing.Image)(resources.GetObject("btnAnimUp.Image")));
			this.btnAnimUp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAnimUp.Name = "btnAnimUp";
			this.btnAnimUp.Size = new System.Drawing.Size(23, 20);
			this.btnAnimUp.Text = "上移";
			this.btnAnimUp.Click += new System.EventHandler(this.btnAnimUp_Click);
			// 
			// btnAnimDown
			// 
			this.btnAnimDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAnimDown.Enabled = false;
			this.btnAnimDown.Image = ((System.Drawing.Image)(resources.GetObject("btnAnimDown.Image")));
			this.btnAnimDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAnimDown.Name = "btnAnimDown";
			this.btnAnimDown.Size = new System.Drawing.Size(23, 20);
			this.btnAnimDown.Text = "下移";
			this.btnAnimDown.Click += new System.EventHandler(this.btnAnimDown_Click);
			// 
			// tSplitter2
			// 
			this.tSplitter2.Location = new System.Drawing.Point(180, 0);
			this.tSplitter2.MinSize = 180;
			this.tSplitter2.Name = "tSplitter2";
			this.tSplitter2.Size = new System.Drawing.Size(9, 513);
			this.tSplitter2.TabIndex = 1;
			this.tSplitter2.TabStop = false;
			// 
			// panelTimeline
			// 
			this.panelTimeline.Controls.Add(this.timeline);
			this.panelTimeline.Controls.Add(this.toolBarTimeline);
			this.panelTimeline.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelTimeline.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panelTimeline.Location = new System.Drawing.Point(189, 363);
			this.panelTimeline.Name = "panelTimeline";
			this.panelTimeline.Padding = new System.Windows.Forms.Padding(2, 24, 2, 2);
			this.panelTimeline.Size = new System.Drawing.Size(336, 150);
			this.panelTimeline.TabIndex = 2;
			this.panelTimeline.Title = "时间轴";
			this.panelTimeline.TitleFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			// 
			// timeline
			// 
			this.timeline.AutoScroll = true;
			this.timeline.BackColor = System.Drawing.SystemColors.Window;
			this.timeline.CurrentDirection = null;
			this.timeline.CurrentFrame = null;
			this.timeline.CurrentFrameIndex = 0;
			this.timeline.Dock = System.Windows.Forms.DockStyle.Fill;
			this.timeline.ForeColor = System.Drawing.SystemColors.WindowText;
			this.timeline.Location = new System.Drawing.Point(2, 51);
			this.timeline.Name = "timeline";
			this.timeline.Size = new System.Drawing.Size(332, 97);
			this.timeline.TabIndex = 1;
			this.timeline.AfterSelectedChanged += new System.EventHandler(this.timeline_AfterSelectedChanged);
			// 
			// toolBarTimeline
			// 
			this.toolBarTimeline.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.toolBarTimeline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.toolBarTimeline.GripMargin = new System.Windows.Forms.Padding(0);
			this.toolBarTimeline.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolBarTimeline.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTimeLineImportFrame,
            this.btnTimelineImportFrames,
            this.toolStripSeparator5,
            this.btnTimelineDeleteFrame,
            this.toolStripSeparator8,
            this.btnTimelineMoveLeft,
            this.btnTimelineMoveRight,
            this.toolStripSeparator9,
            this.btnTimelineAddLength,
            this.btnTimelineRemoveLength});
			this.toolBarTimeline.Location = new System.Drawing.Point(2, 24);
			this.toolBarTimeline.Name = "toolBarTimeline";
			this.toolBarTimeline.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.toolBarTimeline.Size = new System.Drawing.Size(332, 27);
			this.toolBarTimeline.TabIndex = 0;
			this.toolBarTimeline.Text = "tToolBar2";
			// 
			// btnTimeLineImportFrame
			// 
			this.btnTimeLineImportFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnTimeLineImportFrame.Enabled = false;
			this.btnTimeLineImportFrame.Image = ((System.Drawing.Image)(resources.GetObject("btnTimeLineImportFrame.Image")));
			this.btnTimeLineImportFrame.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnTimeLineImportFrame.Name = "btnTimeLineImportFrame";
			this.btnTimeLineImportFrame.Size = new System.Drawing.Size(23, 20);
			this.btnTimeLineImportFrame.Text = "导入帧";
			this.btnTimeLineImportFrame.Click += new System.EventHandler(this.btnTimeLineImportFrame_Click);
			// 
			// btnTimelineImportFrames
			// 
			this.btnTimelineImportFrames.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnTimelineImportFrames.Enabled = false;
			this.btnTimelineImportFrames.Image = ((System.Drawing.Image)(resources.GetObject("btnTimelineImportFrames.Image")));
			this.btnTimelineImportFrames.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnTimelineImportFrames.Name = "btnTimelineImportFrames";
			this.btnTimelineImportFrames.Size = new System.Drawing.Size(23, 20);
			this.btnTimelineImportFrames.Text = "导入图片集";
			this.btnTimelineImportFrames.Click += new System.EventHandler(this.btnTimelineImportFrames_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
			// 
			// btnTimelineDeleteFrame
			// 
			this.btnTimelineDeleteFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnTimelineDeleteFrame.Enabled = false;
			this.btnTimelineDeleteFrame.Image = ((System.Drawing.Image)(resources.GetObject("btnTimelineDeleteFrame.Image")));
			this.btnTimelineDeleteFrame.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnTimelineDeleteFrame.Name = "btnTimelineDeleteFrame";
			this.btnTimelineDeleteFrame.Size = new System.Drawing.Size(23, 20);
			this.btnTimelineDeleteFrame.Text = "删除帧";
			this.btnTimelineDeleteFrame.Click += new System.EventHandler(this.btnTimelineDeleteFrame_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 23);
			// 
			// btnTimelineMoveLeft
			// 
			this.btnTimelineMoveLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnTimelineMoveLeft.Enabled = false;
			this.btnTimelineMoveLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnTimelineMoveLeft.Image")));
			this.btnTimelineMoveLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnTimelineMoveLeft.Name = "btnTimelineMoveLeft";
			this.btnTimelineMoveLeft.Size = new System.Drawing.Size(23, 20);
			this.btnTimelineMoveLeft.Text = "左移";
			this.btnTimelineMoveLeft.Click += new System.EventHandler(this.btnTimelineMoveLeft_Click);
			// 
			// btnTimelineMoveRight
			// 
			this.btnTimelineMoveRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnTimelineMoveRight.Enabled = false;
			this.btnTimelineMoveRight.Image = ((System.Drawing.Image)(resources.GetObject("btnTimelineMoveRight.Image")));
			this.btnTimelineMoveRight.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnTimelineMoveRight.Name = "btnTimelineMoveRight";
			this.btnTimelineMoveRight.Size = new System.Drawing.Size(23, 20);
			this.btnTimelineMoveRight.Text = "右移";
			this.btnTimelineMoveRight.Click += new System.EventHandler(this.btnTimelineMoveRight_Click);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 23);
			// 
			// btnTimelineAddLength
			// 
			this.btnTimelineAddLength.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnTimelineAddLength.Enabled = false;
			this.btnTimelineAddLength.Image = ((System.Drawing.Image)(resources.GetObject("btnTimelineAddLength.Image")));
			this.btnTimelineAddLength.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnTimelineAddLength.Name = "btnTimelineAddLength";
			this.btnTimelineAddLength.Size = new System.Drawing.Size(23, 20);
			this.btnTimelineAddLength.Text = "增加长度";
			this.btnTimelineAddLength.Click += new System.EventHandler(this.btnTimelineAddLength_Click);
			// 
			// btnTimelineRemoveLength
			// 
			this.btnTimelineRemoveLength.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnTimelineRemoveLength.Enabled = false;
			this.btnTimelineRemoveLength.Image = ((System.Drawing.Image)(resources.GetObject("btnTimelineRemoveLength.Image")));
			this.btnTimelineRemoveLength.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnTimelineRemoveLength.Name = "btnTimelineRemoveLength";
			this.btnTimelineRemoveLength.Size = new System.Drawing.Size(23, 20);
			this.btnTimelineRemoveLength.Text = "减少长度";
			this.btnTimelineRemoveLength.Click += new System.EventHandler(this.btnTimelineRemoveLength_Click);
			// 
			// tSplitter3
			// 
			this.tSplitter3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tSplitter3.Location = new System.Drawing.Point(189, 354);
			this.tSplitter3.MinSize = 150;
			this.tSplitter3.Name = "tSplitter3";
			this.tSplitter3.Size = new System.Drawing.Size(336, 9);
			this.tSplitter3.TabIndex = 3;
			this.tSplitter3.TabStop = false;
			// 
			// toolBarPreview
			// 
			this.toolBarPreview.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.toolBarPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.toolBarPreview.GripMargin = new System.Windows.Forms.Padding(0);
			this.toolBarPreview.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolBarPreview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPreviewPlay,
            this.btnPreviewPause,
            this.toolStripSeparator2,
            this.btnPreviewTurnLeft,
            this.btnPreviewTurnRight,
            this.toolStripSeparator3,
            this.btnPreviewFirstFrame,
            this.btnPreviewPrevFrame,
            this.btnPreviewNextFrame,
            this.btnPreviewLastFrame,
            this.toolStripSeparator4,
            this.btnPreviewZoomOut,
            this.btnPreviewZoomIn,
            this.toolStripSeparator7,
            this.btnPreviewStyle,
            this.btnShootPosition});
			this.toolBarPreview.Location = new System.Drawing.Point(2, 24);
			this.toolBarPreview.Name = "toolBarPreview";
			this.toolBarPreview.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.toolBarPreview.Size = new System.Drawing.Size(173, 27);
			this.toolBarPreview.TabIndex = 0;
			this.toolBarPreview.Text = "tToolBar3";
			// 
			// btnPreviewPlay
			// 
			this.btnPreviewPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPreviewPlay.Enabled = false;
			this.btnPreviewPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviewPlay.Image")));
			this.btnPreviewPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPreviewPlay.Name = "btnPreviewPlay";
			this.btnPreviewPlay.Size = new System.Drawing.Size(23, 20);
			this.btnPreviewPlay.Text = "播放";
			this.btnPreviewPlay.Click += new System.EventHandler(this.btnPreviewPlay_Click);
			// 
			// btnPreviewPause
			// 
			this.btnPreviewPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPreviewPause.Enabled = false;
			this.btnPreviewPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviewPause.Image")));
			this.btnPreviewPause.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPreviewPause.Name = "btnPreviewPause";
			this.btnPreviewPause.Size = new System.Drawing.Size(23, 20);
			this.btnPreviewPause.Text = "暂停";
			this.btnPreviewPause.Click += new System.EventHandler(this.btnPreviewPause_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
			// 
			// btnPreviewTurnLeft
			// 
			this.btnPreviewTurnLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPreviewTurnLeft.Enabled = false;
			this.btnPreviewTurnLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviewTurnLeft.Image")));
			this.btnPreviewTurnLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPreviewTurnLeft.Name = "btnPreviewTurnLeft";
			this.btnPreviewTurnLeft.Size = new System.Drawing.Size(23, 20);
			this.btnPreviewTurnLeft.Text = "左转";
			this.btnPreviewTurnLeft.Click += new System.EventHandler(this.btnPreviewTurnLeft_Click);
			// 
			// btnPreviewTurnRight
			// 
			this.btnPreviewTurnRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPreviewTurnRight.Enabled = false;
			this.btnPreviewTurnRight.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviewTurnRight.Image")));
			this.btnPreviewTurnRight.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPreviewTurnRight.Name = "btnPreviewTurnRight";
			this.btnPreviewTurnRight.Size = new System.Drawing.Size(23, 20);
			this.btnPreviewTurnRight.Text = "右转";
			this.btnPreviewTurnRight.Click += new System.EventHandler(this.btnPreviewTurnRight_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
			// 
			// btnPreviewFirstFrame
			// 
			this.btnPreviewFirstFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPreviewFirstFrame.Enabled = false;
			this.btnPreviewFirstFrame.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviewFirstFrame.Image")));
			this.btnPreviewFirstFrame.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPreviewFirstFrame.Name = "btnPreviewFirstFrame";
			this.btnPreviewFirstFrame.Size = new System.Drawing.Size(23, 20);
			this.btnPreviewFirstFrame.Text = "第一帧";
			this.btnPreviewFirstFrame.Click += new System.EventHandler(this.btnPreviewFirstFrame_Click);
			// 
			// btnPreviewPrevFrame
			// 
			this.btnPreviewPrevFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPreviewPrevFrame.Enabled = false;
			this.btnPreviewPrevFrame.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviewPrevFrame.Image")));
			this.btnPreviewPrevFrame.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPreviewPrevFrame.Name = "btnPreviewPrevFrame";
			this.btnPreviewPrevFrame.Size = new System.Drawing.Size(23, 20);
			this.btnPreviewPrevFrame.Text = "上一帧";
			this.btnPreviewPrevFrame.Click += new System.EventHandler(this.btnPreviewPrevFrame_Click);
			// 
			// btnPreviewNextFrame
			// 
			this.btnPreviewNextFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPreviewNextFrame.Enabled = false;
			this.btnPreviewNextFrame.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviewNextFrame.Image")));
			this.btnPreviewNextFrame.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPreviewNextFrame.Name = "btnPreviewNextFrame";
			this.btnPreviewNextFrame.Size = new System.Drawing.Size(23, 20);
			this.btnPreviewNextFrame.Text = "下一帧";
			this.btnPreviewNextFrame.Click += new System.EventHandler(this.btnPreviewNextFrame_Click);
			// 
			// btnPreviewLastFrame
			// 
			this.btnPreviewLastFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPreviewLastFrame.Enabled = false;
			this.btnPreviewLastFrame.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviewLastFrame.Image")));
			this.btnPreviewLastFrame.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPreviewLastFrame.Name = "btnPreviewLastFrame";
			this.btnPreviewLastFrame.Size = new System.Drawing.Size(23, 20);
			this.btnPreviewLastFrame.Text = "最后一帧";
			this.btnPreviewLastFrame.Click += new System.EventHandler(this.btnPreviewLastFrame_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
			// 
			// btnPreviewZoomOut
			// 
			this.btnPreviewZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPreviewZoomOut.Enabled = false;
			this.btnPreviewZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviewZoomOut.Image")));
			this.btnPreviewZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPreviewZoomOut.Name = "btnPreviewZoomOut";
			this.btnPreviewZoomOut.Size = new System.Drawing.Size(23, 20);
			this.btnPreviewZoomOut.Text = "放大";
			this.btnPreviewZoomOut.Click += new System.EventHandler(this.btnPreviewZoomOut_Click);
			// 
			// btnPreviewZoomIn
			// 
			this.btnPreviewZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPreviewZoomIn.Enabled = false;
			this.btnPreviewZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviewZoomIn.Image")));
			this.btnPreviewZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPreviewZoomIn.Name = "btnPreviewZoomIn";
			this.btnPreviewZoomIn.Size = new System.Drawing.Size(23, 20);
			this.btnPreviewZoomIn.Text = "缩小";
			this.btnPreviewZoomIn.Click += new System.EventHandler(this.btnPreviewZoomIn_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
			// 
			// btnPreviewStyle
			// 
			this.btnPreviewStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPreviewStyle.Enabled = false;
			this.btnPreviewStyle.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviewStyle.Image")));
			this.btnPreviewStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPreviewStyle.Name = "btnPreviewStyle";
			this.btnPreviewStyle.Size = new System.Drawing.Size(23, 20);
			this.btnPreviewStyle.Text = "样式限定";
			this.btnPreviewStyle.Click += new System.EventHandler(this.btnPreviewStyle_Click);
			// 
			// panelPreview
			// 
			this.panelPreview.Controls.Add(this.animationView);
			this.panelPreview.Controls.Add(this.toolBarPreview);
			this.panelPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelPreview.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panelPreview.Location = new System.Drawing.Point(189, 0);
			this.panelPreview.Name = "panelPreview";
			this.panelPreview.Padding = new System.Windows.Forms.Padding(2, 24, 2, 2);
			this.panelPreview.Size = new System.Drawing.Size(177, 354);
			this.panelPreview.TabIndex = 4;
			this.panelPreview.Title = "预览";
			this.panelPreview.TitleFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			// 
			// panelPropertyGrid
			// 
			this.panelPropertyGrid.Controls.Add(this.propertyGrid);
			this.panelPropertyGrid.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelPropertyGrid.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panelPropertyGrid.Location = new System.Drawing.Point(375, 0);
			this.panelPropertyGrid.Name = "panelPropertyGrid";
			this.panelPropertyGrid.Padding = new System.Windows.Forms.Padding(2, 24, 2, 2);
			this.panelPropertyGrid.Size = new System.Drawing.Size(150, 354);
			this.panelPropertyGrid.TabIndex = 5;
			this.panelPropertyGrid.Title = "属性";
			this.panelPropertyGrid.TitleFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			// 
			// propertyGrid
			// 
			this.propertyGrid.CanShowVisualStyleGlyphs = false;
			this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid.HelpBackColor = System.Drawing.SystemColors.Info;
			this.propertyGrid.HelpBorderColor = System.Drawing.SystemColors.Info;
			this.propertyGrid.HelpForeColor = System.Drawing.SystemColors.InfoText;
			this.propertyGrid.Location = new System.Drawing.Point(2, 24);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.Size = new System.Drawing.Size(146, 328);
			this.propertyGrid.TabIndex = 2;
			this.propertyGrid.ToolbarVisible = false;
			this.propertyGrid.ViewBorderColor = System.Drawing.SystemColors.Window;
			// 
			// tSplitter4
			// 
			this.tSplitter4.Dock = System.Windows.Forms.DockStyle.Right;
			this.tSplitter4.Location = new System.Drawing.Point(366, 0);
			this.tSplitter4.MinSize = 100;
			this.tSplitter4.Name = "tSplitter4";
			this.tSplitter4.Size = new System.Drawing.Size(9, 354);
			this.tSplitter4.TabIndex = 6;
			this.tSplitter4.TabStop = false;
			// 
			// btnShootPosition
			// 
			this.btnShootPosition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnShootPosition.Image = ((System.Drawing.Image)(resources.GetObject("btnShootPosition.Image")));
			this.btnShootPosition.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnShootPosition.Name = "btnShootPosition";
			this.btnShootPosition.Size = new System.Drawing.Size(23, 20);
			this.btnShootPosition.Text = "枪口";
			this.btnShootPosition.Click += new System.EventHandler(this.btnShootPosition_Click);
			// 
			// FrmAnimationEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmAnimationEditor";
			this.Text = "Abstract - Microsoft® Visual Studio® 2012 ver 11.0.50727.1";
			this.panelMain.ResumeLayout(false);
			this.panelLayers.ResumeLayout(false);
			this.panelLayers.PerformLayout();
			this.toolBarLayers.ResumeLayout(false);
			this.toolBarLayers.PerformLayout();
			this.panelTimeline.ResumeLayout(false);
			this.panelTimeline.PerformLayout();
			this.toolBarTimeline.ResumeLayout(false);
			this.toolBarTimeline.PerformLayout();
			this.toolBarPreview.ResumeLayout(false);
			this.toolBarPreview.PerformLayout();
			this.panelPreview.ResumeLayout(false);
			this.panelPreview.PerformLayout();
			this.panelPropertyGrid.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private THOR.Windows.UI.Components.TPanel panelLayers;
		private THOR.Windows.UI.Components.TSplitter tSplitter2;
		private THOR.Windows.UI.Components.TToolBar toolBarLayers;
		private THOR.Windows.UI.Components.TSplitter tSplitter3;
		private THOR.Windows.UI.Components.TPanel panelTimeline;
		private THOR.Windows.UI.Components.TToolBar toolBarTimeline;
		private System.Windows.Forms.ToolStripButton btnAnimAddState;
		private System.Windows.Forms.ToolStripButton btnAnimAddLayer;
		private System.Windows.Forms.ToolStripButton btnAnimDelete;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnAnimProperty;
		private System.Windows.Forms.ToolStripButton btnTimeLineImportFrame;
		private System.Windows.Forms.ToolStripButton btnTimelineImportFrames;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton btnTimelineDeleteFrame;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripButton btnAnimUp;
		private System.Windows.Forms.ToolStripButton btnAnimDown;
		private THOR.Windows.UI.Components.TTreeView treeLayers;
		private System.Windows.Forms.ImageList imageListLayers;
		private Solar.Components.Timeline timeline;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripButton btnTimelineMoveLeft;
		private System.Windows.Forms.ToolStripButton btnTimelineMoveRight;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripButton btnTimelineAddLength;
		private System.Windows.Forms.ToolStripButton btnTimelineRemoveLength;
		private THOR.Windows.UI.Components.TPanel panelPreview;
		private THOR.Windows.UI.Components.TToolBar toolBarPreview;
		private System.Windows.Forms.ToolStripButton btnPreviewPlay;
		private System.Windows.Forms.ToolStripButton btnPreviewPause;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnPreviewTurnLeft;
		private System.Windows.Forms.ToolStripButton btnPreviewTurnRight;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton btnPreviewFirstFrame;
		private System.Windows.Forms.ToolStripButton btnPreviewPrevFrame;
		private System.Windows.Forms.ToolStripButton btnPreviewNextFrame;
		private System.Windows.Forms.ToolStripButton btnPreviewLastFrame;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton btnPreviewZoomOut;
		private System.Windows.Forms.ToolStripButton btnPreviewZoomIn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripButton btnPreviewStyle;
		private THOR.Windows.UI.Components.TPanel panelPropertyGrid;
		private THOR.Windows.UI.Components.TSplitter tSplitter4;
		private System.Windows.Forms.PropertyGrid propertyGrid;
		private Solar.Components.AnimationView animationView;
		private System.Windows.Forms.ToolStripButton btnShootPosition;
	}
}
