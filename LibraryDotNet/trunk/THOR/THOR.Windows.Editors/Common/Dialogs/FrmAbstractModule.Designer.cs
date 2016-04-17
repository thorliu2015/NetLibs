namespace THOR.Windows.Editors.Common.Dialogs
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
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolBarMain = new THOR.Windows.Components.Tools.ThorToolBar();
			this.btnSave = new System.Windows.Forms.ToolStripButton();
			this.btnImport = new System.Windows.Forms.ToolStripButton();
			this.btnExport = new System.Windows.Forms.ToolStripButton();
			this.btnSettings = new System.Windows.Forms.ToolStripButton();
			this.btnAbout = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.statusBar = new THOR.Windows.Components.Tools.ThorStatusBar();
			this.lblCurrentEntityPath = new System.Windows.Forms.ToolStripStatusLabel();
			this.boxNavigation = new THOR.Windows.Components.Common.ThorBox();
			this.thorSplitter = new THOR.Windows.Components.Common.ThorSplitter();
			this.boxMain = new THOR.Windows.Components.Common.ThorBox();
			this.toolBarMain.SuspendLayout();
			this.statusBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Padding = new System.Windows.Forms.Padding(2);
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Margin = new System.Windows.Forms.Padding(0);
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Padding = new System.Windows.Forms.Padding(2);
			this.toolStripButton1.Size = new System.Drawing.Size(40, 40);
			this.toolStripButton1.Text = "toolStripButton1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.AutoSize = false;
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(732, 17);
			this.toolStripStatusLabel1.Spring = true;
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolBarMain
			// 
			this.toolBarMain.CanOverflow = false;
			this.toolBarMain.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.toolBarMain.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.toolBarMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnImport,
            this.btnExport,
            this.btnSettings,
            this.btnAbout,
            this.toolStripSeparator1});
			this.toolBarMain.Location = new System.Drawing.Point(3, 27);
			this.toolBarMain.Name = "toolBarMain";
			this.toolBarMain.Padding = new System.Windows.Forms.Padding(2);
			this.toolBarMain.Size = new System.Drawing.Size(778, 44);
			this.toolBarMain.TabIndex = 0;
			this.toolBarMain.Text = "thorToolBar1";
			// 
			// btnSave
			// 
			this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
			this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSave.Margin = new System.Windows.Forms.Padding(0);
			this.btnSave.Name = "btnSave";
			this.btnSave.Padding = new System.Windows.Forms.Padding(2);
			this.btnSave.Size = new System.Drawing.Size(40, 40);
			this.btnSave.Text = "toolStripButton2";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnImport
			// 
			this.btnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
			this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImport.Margin = new System.Windows.Forms.Padding(0);
			this.btnImport.Name = "btnImport";
			this.btnImport.Padding = new System.Windows.Forms.Padding(2);
			this.btnImport.Size = new System.Drawing.Size(40, 40);
			this.btnImport.Text = "toolStripButton3";
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// btnExport
			// 
			this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
			this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExport.Margin = new System.Windows.Forms.Padding(0);
			this.btnExport.Name = "btnExport";
			this.btnExport.Padding = new System.Windows.Forms.Padding(2);
			this.btnExport.Size = new System.Drawing.Size(40, 40);
			this.btnExport.Text = "toolStripButton4";
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// btnSettings
			// 
			this.btnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
			this.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSettings.Margin = new System.Windows.Forms.Padding(0);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Padding = new System.Windows.Forms.Padding(2);
			this.btnSettings.Size = new System.Drawing.Size(40, 40);
			this.btnSettings.Text = "toolStripButton5";
			this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
			// 
			// btnAbout
			// 
			this.btnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
			this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAbout.Margin = new System.Windows.Forms.Padding(0);
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Padding = new System.Windows.Forms.Padding(2);
			this.btnAbout.Size = new System.Drawing.Size(40, 40);
			this.btnAbout.Text = "toolStripButton2";
			this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Padding = new System.Windows.Forms.Padding(2);
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
			// 
			// statusBar
			// 
			this.statusBar.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCurrentEntityPath});
			this.statusBar.Location = new System.Drawing.Point(3, 540);
			this.statusBar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 2);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(778, 22);
			this.statusBar.SizingGrip = false;
			this.statusBar.TabIndex = 1;
			this.statusBar.Text = "thorStatusBar1";
			// 
			// lblCurrentEntityPath
			// 
			this.lblCurrentEntityPath.Name = "lblCurrentEntityPath";
			this.lblCurrentEntityPath.Size = new System.Drawing.Size(763, 17);
			this.lblCurrentEntityPath.Spring = true;
			this.lblCurrentEntityPath.Text = "${CurrentEntityPath}";
			this.lblCurrentEntityPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// boxNavigation
			// 
			this.boxNavigation.BackColor = System.Drawing.Color.Transparent;
			this.boxNavigation.Dock = System.Windows.Forms.DockStyle.Left;
			this.boxNavigation.Location = new System.Drawing.Point(3, 71);
			this.boxNavigation.Name = "boxNavigation";
			this.boxNavigation.Size = new System.Drawing.Size(200, 469);
			this.boxNavigation.TabIndex = 2;
			// 
			// thorSplitter
			// 
			this.thorSplitter.Location = new System.Drawing.Point(203, 71);
			this.thorSplitter.MinExtra = 200;
			this.thorSplitter.MinSize = 200;
			this.thorSplitter.Name = "thorSplitter";
			this.thorSplitter.Size = new System.Drawing.Size(5, 469);
			this.thorSplitter.TabIndex = 3;
			this.thorSplitter.TabStop = false;
			// 
			// boxMain
			// 
			this.boxMain.BackColor = System.Drawing.Color.Transparent;
			this.boxMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.boxMain.Location = new System.Drawing.Point(208, 71);
			this.boxMain.Name = "boxMain";
			this.boxMain.Size = new System.Drawing.Size(573, 469);
			this.boxMain.TabIndex = 4;
			// 
			// FrmAbstractModule
			// 
			this.ClientSize = new System.Drawing.Size(784, 565);
			this.Controls.Add(this.boxMain);
			this.Controls.Add(this.thorSplitter);
			this.Controls.Add(this.boxNavigation);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.toolBarMain);
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "FrmAbstractModule";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAbstractModule_FormClosing);
			this.toolBarMain.ResumeLayout(false);
			this.toolBarMain.PerformLayout();
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

	
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		protected Windows.Components.Tools.ThorToolBar toolBarMain;
		protected System.Windows.Forms.ToolStripButton btnSave;
		protected System.Windows.Forms.ToolStripButton btnImport;
		protected System.Windows.Forms.ToolStripButton btnExport;
		protected System.Windows.Forms.ToolStripButton btnSettings;
		protected Windows.Components.Common.ThorBox boxNavigation;
		protected Windows.Components.Common.ThorSplitter thorSplitter;
		protected Windows.Components.Common.ThorBox boxMain;
		protected Windows.Components.Tools.ThorStatusBar statusBar;
		private System.Windows.Forms.ToolStripStatusLabel lblCurrentEntityPath;
		private System.Windows.Forms.ToolStripButton btnAbout;
	}
}
