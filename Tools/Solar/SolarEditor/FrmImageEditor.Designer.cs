namespace SolarEditor
{
	partial class FrmImageEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImageEditor));
			this.panelImage = new THOR.Windows.UI.Components.TPanel();
			this.imageView = new Solar.Components.ImageView();
			this.toolBar = new THOR.Windows.UI.Components.TToolBar();
			this.btnImageOpen = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnImageAddRow = new System.Windows.Forms.ToolStripButton();
			this.btnImageAddColumn = new System.Windows.Forms.ToolStripButton();
			this.btnImageRemoveRow = new System.Windows.Forms.ToolStripButton();
			this.btnImageRemoveColumn = new System.Windows.Forms.ToolStripButton();
			this.btnImageRowAndColumn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnImageDeleteRow = new System.Windows.Forms.ToolStripButton();
			this.btnImageDeleteColumn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnImageMoveRight = new System.Windows.Forms.ToolStripButton();
			this.btnImageMoveDown = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.btnImageRelayout = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.btnImageSave = new System.Windows.Forms.ToolStripButton();
			this.btnImageSaveAll = new System.Windows.Forms.ToolStripButton();
			this.panelMain.SuspendLayout();
			this.panelImage.SuspendLayout();
			this.toolBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelMain
			// 
			this.panelMain.Controls.Add(this.panelImage);
			// 
			// panelImage
			// 
			this.panelImage.Controls.Add(this.imageView);
			this.panelImage.Controls.Add(this.toolBar);
			this.panelImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelImage.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panelImage.Location = new System.Drawing.Point(0, 0);
			this.panelImage.Name = "panelImage";
			this.panelImage.Padding = new System.Windows.Forms.Padding(2, 24, 2, 2);
			this.panelImage.Size = new System.Drawing.Size(525, 513);
			this.panelImage.TabIndex = 0;
			this.panelImage.Title = "图片";
			this.panelImage.TitleFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			// 
			// imageView
			// 
			this.imageView.BackColor = System.Drawing.Color.White;
			this.imageView.CurrentImage = null;
			this.imageView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imageView.Location = new System.Drawing.Point(2, 51);
			this.imageView.Name = "imageView";
			this.imageView.Size = new System.Drawing.Size(521, 460);
			this.imageView.TabIndex = 1;
			// 
			// toolBar
			// 
			this.toolBar.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.toolBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.toolBar.GripMargin = new System.Windows.Forms.Padding(0);
			this.toolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImageOpen,
            this.toolStripSeparator1,
            this.btnImageAddRow,
            this.btnImageAddColumn,
            this.btnImageRemoveRow,
            this.btnImageRemoveColumn,
            this.btnImageRowAndColumn,
            this.toolStripSeparator2,
            this.btnImageDeleteRow,
            this.btnImageDeleteColumn,
            this.toolStripSeparator3,
            this.btnImageMoveRight,
            this.btnImageMoveDown,
            this.toolStripSeparator4,
            this.btnImageRelayout,
            this.toolStripSeparator5,
            this.btnImageSave,
            this.btnImageSaveAll});
			this.toolBar.Location = new System.Drawing.Point(2, 24);
			this.toolBar.Name = "toolBar";
			this.toolBar.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.toolBar.Size = new System.Drawing.Size(521, 27);
			this.toolBar.TabIndex = 0;
			this.toolBar.Text = "tToolBar1";
			// 
			// btnImageOpen
			// 
			this.btnImageOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnImageOpen.Enabled = false;
			this.btnImageOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnImageOpen.Image")));
			this.btnImageOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImageOpen.Name = "btnImageOpen";
			this.btnImageOpen.Size = new System.Drawing.Size(23, 20);
			this.btnImageOpen.Text = "打开图片";
			this.btnImageOpen.Click += new System.EventHandler(this.btnImageOpen_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
			// 
			// btnImageAddRow
			// 
			this.btnImageAddRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnImageAddRow.Enabled = false;
			this.btnImageAddRow.Image = ((System.Drawing.Image)(resources.GetObject("btnImageAddRow.Image")));
			this.btnImageAddRow.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImageAddRow.Name = "btnImageAddRow";
			this.btnImageAddRow.Size = new System.Drawing.Size(23, 20);
			this.btnImageAddRow.Text = "添加行";
			this.btnImageAddRow.Click += new System.EventHandler(this.btnImageAddRow_Click);
			// 
			// btnImageAddColumn
			// 
			this.btnImageAddColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnImageAddColumn.Enabled = false;
			this.btnImageAddColumn.Image = ((System.Drawing.Image)(resources.GetObject("btnImageAddColumn.Image")));
			this.btnImageAddColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImageAddColumn.Name = "btnImageAddColumn";
			this.btnImageAddColumn.Size = new System.Drawing.Size(23, 20);
			this.btnImageAddColumn.Text = "添加列";
			this.btnImageAddColumn.Click += new System.EventHandler(this.btnImageAddColumn_Click);
			// 
			// btnImageRemoveRow
			// 
			this.btnImageRemoveRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnImageRemoveRow.Enabled = false;
			this.btnImageRemoveRow.Image = ((System.Drawing.Image)(resources.GetObject("btnImageRemoveRow.Image")));
			this.btnImageRemoveRow.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImageRemoveRow.Name = "btnImageRemoveRow";
			this.btnImageRemoveRow.Size = new System.Drawing.Size(23, 20);
			this.btnImageRemoveRow.Text = "减少行";
			this.btnImageRemoveRow.Click += new System.EventHandler(this.btnImageRemoveRow_Click);
			// 
			// btnImageRemoveColumn
			// 
			this.btnImageRemoveColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnImageRemoveColumn.Enabled = false;
			this.btnImageRemoveColumn.Image = ((System.Drawing.Image)(resources.GetObject("btnImageRemoveColumn.Image")));
			this.btnImageRemoveColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImageRemoveColumn.Name = "btnImageRemoveColumn";
			this.btnImageRemoveColumn.Size = new System.Drawing.Size(23, 20);
			this.btnImageRemoveColumn.Text = "减少列";
			this.btnImageRemoveColumn.Click += new System.EventHandler(this.btnImageRemoveColumn_Click);
			// 
			// btnImageRowAndColumn
			// 
			this.btnImageRowAndColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnImageRowAndColumn.Enabled = false;
			this.btnImageRowAndColumn.Image = ((System.Drawing.Image)(resources.GetObject("btnImageRowAndColumn.Image")));
			this.btnImageRowAndColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImageRowAndColumn.Name = "btnImageRowAndColumn";
			this.btnImageRowAndColumn.Size = new System.Drawing.Size(23, 20);
			this.btnImageRowAndColumn.Text = "修改行列数";
			this.btnImageRowAndColumn.Click += new System.EventHandler(this.btnImageRowAndColumn_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
			// 
			// btnImageDeleteRow
			// 
			this.btnImageDeleteRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnImageDeleteRow.Enabled = false;
			this.btnImageDeleteRow.Image = ((System.Drawing.Image)(resources.GetObject("btnImageDeleteRow.Image")));
			this.btnImageDeleteRow.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImageDeleteRow.Name = "btnImageDeleteRow";
			this.btnImageDeleteRow.Size = new System.Drawing.Size(23, 20);
			this.btnImageDeleteRow.Text = "删除行";
			this.btnImageDeleteRow.Click += new System.EventHandler(this.btnImageDeleteRow_Click);
			// 
			// btnImageDeleteColumn
			// 
			this.btnImageDeleteColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnImageDeleteColumn.Enabled = false;
			this.btnImageDeleteColumn.Image = ((System.Drawing.Image)(resources.GetObject("btnImageDeleteColumn.Image")));
			this.btnImageDeleteColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImageDeleteColumn.Name = "btnImageDeleteColumn";
			this.btnImageDeleteColumn.Size = new System.Drawing.Size(23, 20);
			this.btnImageDeleteColumn.Text = "删除列";
			this.btnImageDeleteColumn.Click += new System.EventHandler(this.btnImageDeleteColumn_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
			// 
			// btnImageMoveRight
			// 
			this.btnImageMoveRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnImageMoveRight.Enabled = false;
			this.btnImageMoveRight.Image = ((System.Drawing.Image)(resources.GetObject("btnImageMoveRight.Image")));
			this.btnImageMoveRight.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImageMoveRight.Name = "btnImageMoveRight";
			this.btnImageMoveRight.Size = new System.Drawing.Size(23, 20);
			this.btnImageMoveRight.Text = "向右偏移";
			this.btnImageMoveRight.Click += new System.EventHandler(this.btnImageMoveRight_Click);
			// 
			// btnImageMoveDown
			// 
			this.btnImageMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnImageMoveDown.Enabled = false;
			this.btnImageMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("btnImageMoveDown.Image")));
			this.btnImageMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImageMoveDown.Name = "btnImageMoveDown";
			this.btnImageMoveDown.Size = new System.Drawing.Size(23, 20);
			this.btnImageMoveDown.Text = "向下偏移";
			this.btnImageMoveDown.Click += new System.EventHandler(this.btnImageMoveDown_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
			// 
			// btnImageRelayout
			// 
			this.btnImageRelayout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnImageRelayout.Enabled = false;
			this.btnImageRelayout.Image = ((System.Drawing.Image)(resources.GetObject("btnImageRelayout.Image")));
			this.btnImageRelayout.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImageRelayout.Name = "btnImageRelayout";
			this.btnImageRelayout.Size = new System.Drawing.Size(23, 20);
			this.btnImageRelayout.Text = "重新布局网格";
			this.btnImageRelayout.Click += new System.EventHandler(this.btnImageRelayout_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
			// 
			// btnImageSave
			// 
			this.btnImageSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnImageSave.Enabled = false;
			this.btnImageSave.Image = ((System.Drawing.Image)(resources.GetObject("btnImageSave.Image")));
			this.btnImageSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImageSave.Name = "btnImageSave";
			this.btnImageSave.Size = new System.Drawing.Size(23, 20);
			this.btnImageSave.Text = "导出当前帧";
			this.btnImageSave.Click += new System.EventHandler(this.btnImageSave_Click);
			// 
			// btnImageSaveAll
			// 
			this.btnImageSaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnImageSaveAll.Enabled = false;
			this.btnImageSaveAll.Image = ((System.Drawing.Image)(resources.GetObject("btnImageSaveAll.Image")));
			this.btnImageSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImageSaveAll.Name = "btnImageSaveAll";
			this.btnImageSaveAll.Size = new System.Drawing.Size(23, 20);
			this.btnImageSaveAll.Text = "导出所有帧";
			this.btnImageSaveAll.Click += new System.EventHandler(this.btnImageSaveAll_Click);
			// 
			// FrmImageEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmImageEditor";
			this.Text = "Abstract - Microsoft® Visual Studio® 2012 ver 11.0.50727.1";
			this.panelMain.ResumeLayout(false);
			this.panelImage.ResumeLayout(false);
			this.panelImage.PerformLayout();
			this.toolBar.ResumeLayout(false);
			this.toolBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private THOR.Windows.UI.Components.TPanel panelImage;
		private THOR.Windows.UI.Components.TToolBar toolBar;
		private System.Windows.Forms.ToolStripButton btnImageOpen;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnImageAddRow;
		private System.Windows.Forms.ToolStripButton btnImageAddColumn;
		private System.Windows.Forms.ToolStripButton btnImageRemoveRow;
		private System.Windows.Forms.ToolStripButton btnImageRemoveColumn;
		private System.Windows.Forms.ToolStripButton btnImageRowAndColumn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private Solar.Components.ImageView imageView;
		private System.Windows.Forms.ToolStripButton btnImageDeleteRow;
		private System.Windows.Forms.ToolStripButton btnImageDeleteColumn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton btnImageMoveRight;
		private System.Windows.Forms.ToolStripButton btnImageMoveDown;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton btnImageRelayout;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton btnImageSave;
		private System.Windows.Forms.ToolStripButton btnImageSaveAll;
	}
}
