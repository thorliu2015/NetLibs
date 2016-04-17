namespace SolarUIComponentTest
{
	partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.tMenuBar1 = new THOR.Windows.UI.Components.TMenuBar();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tToolBar1 = new THOR.Windows.UI.Components.TToolBar();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tStatusBar1 = new THOR.Windows.UI.Components.TStatusBar();
			this.tPanel1 = new THOR.Windows.UI.Components.TPanel();
			this.tSplitter1 = new THOR.Windows.UI.Components.TSplitter();
			this.tPanel2 = new THOR.Windows.UI.Components.TPanel();
			this.tSplitter2 = new THOR.Windows.UI.Components.TSplitter();
			this.modelDataNavigation1 = new Solar.Common.ModelDataNavigation();
			this.tMenuBar1.SuspendLayout();
			this.tToolBar1.SuspendLayout();
			this.tPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tMenuBar1
			// 
			this.tMenuBar1.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.tMenuBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.tMenuBar1.GripMargin = new System.Windows.Forms.Padding(0);
			this.tMenuBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
			this.tMenuBar1.Location = new System.Drawing.Point(0, 0);
			this.tMenuBar1.Name = "tMenuBar1";
			this.tMenuBar1.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.tMenuBar1.ShowItemToolTips = true;
			this.tMenuBar1.Size = new System.Drawing.Size(560, 24);
			this.tMenuBar1.TabIndex = 0;
			this.tMenuBar1.Text = "tMenuBar1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.openToolStripMenuItem.Text = "Open";
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// tToolBar1
			// 
			this.tToolBar1.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.tToolBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.tToolBar1.GripMargin = new System.Windows.Forms.Padding(0);
			this.tToolBar1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tToolBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1});
			this.tToolBar1.Location = new System.Drawing.Point(0, 24);
			this.tToolBar1.Name = "tToolBar1";
			this.tToolBar1.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.tToolBar1.Size = new System.Drawing.Size(560, 27);
			this.tToolBar1.TabIndex = 1;
			this.tToolBar1.Text = "tToolBar1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 20);
			this.toolStripButton1.Text = "toolStripButton1";
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 20);
			this.toolStripButton2.Text = "toolStripButton2";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
			// 
			// tStatusBar1
			// 
			this.tStatusBar1.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.tStatusBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.tStatusBar1.GripMargin = new System.Windows.Forms.Padding(0);
			this.tStatusBar1.Location = new System.Drawing.Point(0, 394);
			this.tStatusBar1.Name = "tStatusBar1";
			this.tStatusBar1.ShowItemToolTips = true;
			this.tStatusBar1.Size = new System.Drawing.Size(560, 22);
			this.tStatusBar1.SizingGrip = false;
			this.tStatusBar1.TabIndex = 2;
			this.tStatusBar1.Text = "tStatusBar1";
			// 
			// tPanel1
			// 
			this.tPanel1.Controls.Add(this.modelDataNavigation1);
			this.tPanel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.tPanel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.tPanel1.Location = new System.Drawing.Point(0, 51);
			this.tPanel1.Name = "tPanel1";
			this.tPanel1.Padding = new System.Windows.Forms.Padding(2, 24, 2, 2);
			this.tPanel1.Size = new System.Drawing.Size(200, 343);
			this.tPanel1.TabIndex = 3;
			this.tPanel1.Title = "Untitled";
			this.tPanel1.TitleFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			// 
			// tSplitter1
			// 
			this.tSplitter1.Location = new System.Drawing.Point(200, 51);
			this.tSplitter1.Name = "tSplitter1";
			this.tSplitter1.Size = new System.Drawing.Size(9, 343);
			this.tSplitter1.TabIndex = 4;
			this.tSplitter1.TabStop = false;
			// 
			// tPanel2
			// 
			this.tPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tPanel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.tPanel2.Location = new System.Drawing.Point(209, 294);
			this.tPanel2.Name = "tPanel2";
			this.tPanel2.Padding = new System.Windows.Forms.Padding(2, 24, 2, 2);
			this.tPanel2.Size = new System.Drawing.Size(351, 100);
			this.tPanel2.TabIndex = 5;
			this.tPanel2.Title = "Untitled";
			this.tPanel2.TitleFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			// 
			// tSplitter2
			// 
			this.tSplitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tSplitter2.Location = new System.Drawing.Point(209, 285);
			this.tSplitter2.Name = "tSplitter2";
			this.tSplitter2.Size = new System.Drawing.Size(351, 9);
			this.tSplitter2.TabIndex = 6;
			this.tSplitter2.TabStop = false;
			// 
			// modelDataNavigation1
			// 
			this.modelDataNavigation1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.modelDataNavigation1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.modelDataNavigation1.Location = new System.Drawing.Point(2, 24);
			this.modelDataNavigation1.Name = "modelDataNavigation1";
			this.modelDataNavigation1.Size = new System.Drawing.Size(196, 317);
			this.modelDataNavigation1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(560, 416);
			this.Controls.Add(this.tSplitter2);
			this.Controls.Add(this.tPanel2);
			this.Controls.Add(this.tSplitter1);
			this.Controls.Add(this.tPanel1);
			this.Controls.Add(this.tStatusBar1);
			this.Controls.Add(this.tToolBar1);
			this.Controls.Add(this.tMenuBar1);
			this.MainMenuStrip = this.tMenuBar1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.tMenuBar1.ResumeLayout(false);
			this.tMenuBar1.PerformLayout();
			this.tToolBar1.ResumeLayout(false);
			this.tToolBar1.PerformLayout();
			this.tPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private THOR.Windows.UI.Components.TMenuBar tMenuBar1;
		private THOR.Windows.UI.Components.TToolBar tToolBar1;
		private THOR.Windows.UI.Components.TStatusBar tStatusBar1;
		private THOR.Windows.UI.Components.TPanel tPanel1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private THOR.Windows.UI.Components.TSplitter tSplitter1;
		private THOR.Windows.UI.Components.TPanel tPanel2;
		private THOR.Windows.UI.Components.TSplitter tSplitter2;
		private Solar.Common.ModelDataNavigation modelDataNavigation1;
	}
}

