namespace Solar
{
	partial class FrmAbstractModule
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbstractModule));
			this.toolBarMain = new THOR.Windows.UI.Components.TToolBar();
			this.btnComOptions = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnComSave = new System.Windows.Forms.ToolStripButton();
			this.btnComBrowse = new System.Windows.Forms.ToolStripButton();
			this.btnComExport = new System.Windows.Forms.ToolStripButton();
			this.btnComExportAll = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.statusBar = new THOR.Windows.UI.Components.TStatusBar();
			this.lblSelected = new System.Windows.Forms.ToolStripStatusLabel();
			this.panelDataNavigation = new THOR.Windows.UI.Components.TPanel();
			this.modelDataNavigation = new Solar.Common.ModelDataNavigation();
			this.tSplitter1 = new THOR.Windows.UI.Components.TSplitter();
			this.panelMain = new System.Windows.Forms.Panel();
			this.toolBarMain.SuspendLayout();
			this.statusBar.SuspendLayout();
			this.panelDataNavigation.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolBarMain
			// 
			this.toolBarMain.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.toolBarMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.toolBarMain.GripMargin = new System.Windows.Forms.Padding(0);
			this.toolBarMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolBarMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnComOptions,
            this.toolStripSeparator2,
            this.btnComSave,
            this.btnComBrowse,
            this.btnComExport,
            this.btnComExportAll,
            this.toolStripSeparator1});
			this.toolBarMain.Location = new System.Drawing.Point(0, 0);
			this.toolBarMain.Name = "toolBarMain";
			this.toolBarMain.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.toolBarMain.Size = new System.Drawing.Size(784, 27);
			this.toolBarMain.TabIndex = 0;
			this.toolBarMain.Text = "tToolBar1";
			// 
			// btnComOptions
			// 
			this.btnComOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnComOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnComOptions.Image")));
			this.btnComOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnComOptions.Name = "btnComOptions";
			this.btnComOptions.Size = new System.Drawing.Size(23, 20);
			this.btnComOptions.Text = "选项";
			this.btnComOptions.Click += new System.EventHandler(this.btnComOptions_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
			// 
			// btnComSave
			// 
			this.btnComSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnComSave.Image = ((System.Drawing.Image)(resources.GetObject("btnComSave.Image")));
			this.btnComSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnComSave.Name = "btnComSave";
			this.btnComSave.Size = new System.Drawing.Size(23, 20);
			this.btnComSave.Text = "保存";
			this.btnComSave.Click += new System.EventHandler(this.btnComSave_Click);
			// 
			// btnComBrowse
			// 
			this.btnComBrowse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnComBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnComBrowse.Image")));
			this.btnComBrowse.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnComBrowse.Name = "btnComBrowse";
			this.btnComBrowse.Size = new System.Drawing.Size(23, 20);
			this.btnComBrowse.Text = "浏览";
			this.btnComBrowse.Click += new System.EventHandler(this.btnComBrowse_Click);
			// 
			// btnComExport
			// 
			this.btnComExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnComExport.Image = ((System.Drawing.Image)(resources.GetObject("btnComExport.Image")));
			this.btnComExport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnComExport.Name = "btnComExport";
			this.btnComExport.Size = new System.Drawing.Size(23, 20);
			this.btnComExport.Text = "导出";
			this.btnComExport.Click += new System.EventHandler(this.btnComExport_Click);
			// 
			// btnComExportAll
			// 
			this.btnComExportAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnComExportAll.Image = ((System.Drawing.Image)(resources.GetObject("btnComExportAll.Image")));
			this.btnComExportAll.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnComExportAll.Name = "btnComExportAll";
			this.btnComExportAll.Size = new System.Drawing.Size(23, 20);
			this.btnComExportAll.Text = "导出所有";
			this.btnComExportAll.Click += new System.EventHandler(this.btnComExportAll_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
			// 
			// statusBar
			// 
			this.statusBar.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.statusBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.statusBar.GripMargin = new System.Windows.Forms.Padding(0);
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSelected});
			this.statusBar.Location = new System.Drawing.Point(0, 540);
			this.statusBar.Name = "statusBar";
			this.statusBar.ShowItemToolTips = true;
			this.statusBar.Size = new System.Drawing.Size(784, 22);
			this.statusBar.SizingGrip = false;
			this.statusBar.TabIndex = 1;
			this.statusBar.Text = "tStatusBar1";
			// 
			// lblSelected
			// 
			this.lblSelected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblSelected.Name = "lblSelected";
			this.lblSelected.Size = new System.Drawing.Size(769, 17);
			this.lblSelected.Spring = true;
			this.lblSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panelDataNavigation
			// 
			this.panelDataNavigation.Controls.Add(this.modelDataNavigation);
			this.panelDataNavigation.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelDataNavigation.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panelDataNavigation.Location = new System.Drawing.Point(0, 27);
			this.panelDataNavigation.Name = "panelDataNavigation";
			this.panelDataNavigation.Padding = new System.Windows.Forms.Padding(2, 24, 2, 2);
			this.panelDataNavigation.Size = new System.Drawing.Size(250, 513);
			this.panelDataNavigation.TabIndex = 2;
			this.panelDataNavigation.Title = "目录";
			this.panelDataNavigation.TitleFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			// 
			// modelDataNavigation
			// 
			this.modelDataNavigation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.modelDataNavigation.FilterType = typeof(Solar.Data.SModel);
			this.modelDataNavigation.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.modelDataNavigation.Location = new System.Drawing.Point(2, 24);
			this.modelDataNavigation.Name = "modelDataNavigation";
			this.modelDataNavigation.ReadOnly = false;
			this.modelDataNavigation.Size = new System.Drawing.Size(246, 487);
			this.modelDataNavigation.TabIndex = 0;
			this.modelDataNavigation.AfterModelSelected += new System.EventHandler(this.modelDataNavigation_AfterModelSelected);
			// 
			// tSplitter1
			// 
			this.tSplitter1.Location = new System.Drawing.Point(250, 27);
			this.tSplitter1.MinExtra = 250;
			this.tSplitter1.MinSize = 250;
			this.tSplitter1.Name = "tSplitter1";
			this.tSplitter1.Size = new System.Drawing.Size(9, 513);
			this.tSplitter1.TabIndex = 3;
			this.tSplitter1.TabStop = false;
			// 
			// panelMain
			// 
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.Location = new System.Drawing.Point(259, 27);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(525, 513);
			this.panelMain.TabIndex = 4;
			// 
			// FrmAbstractModule
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.panelMain);
			this.Controls.Add(this.tSplitter1);
			this.Controls.Add(this.panelDataNavigation);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.toolBarMain);
			this.Name = "FrmAbstractModule";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAbstractModule_FormClosing);
			this.toolBarMain.ResumeLayout(false);
			this.toolBarMain.PerformLayout();
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.panelDataNavigation.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private THOR.Windows.UI.Components.TToolBar toolBarMain;
		private Common.ModelDataNavigation modelDataNavigation;
		protected THOR.Windows.UI.Components.TPanel panelDataNavigation;
		private THOR.Windows.UI.Components.TSplitter tSplitter1;
		private System.Windows.Forms.ToolStripButton btnComSave;
		private System.Windows.Forms.ToolStripButton btnComBrowse;
		private System.Windows.Forms.ToolStripButton btnComExport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		protected System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.ToolStripStatusLabel lblSelected;
		protected THOR.Windows.UI.Components.TStatusBar statusBar;
		private System.Windows.Forms.ToolStripButton btnComExportAll;
		private System.Windows.Forms.ToolStripButton btnComOptions;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	}
}
