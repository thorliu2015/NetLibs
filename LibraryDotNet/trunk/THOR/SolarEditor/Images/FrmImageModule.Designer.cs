namespace SolarEditor.Images
{
	partial class FrmImageModule
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImageModule));
			this.thorPanel1 = new THOR.Windows.Components.Common.ThorPanel();
			this.thorToolBar1 = new THOR.Windows.Components.Tools.ThorToolBar();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.thorImageView = new SolarEditor.Images.Components.ThorImageView();
			this.boxNavigation.SuspendLayout();
			this.boxMain.SuspendLayout();
			this.thorPanel1.SuspendLayout();
			this.thorToolBar1.SuspendLayout();
			this.SuspendLayout();
			// 
			// boxMain
			// 
			this.boxMain.Controls.Add(this.thorPanel1);
			// 
			// thorPanel1
			// 
			this.thorPanel1.Controls.Add(this.thorImageView);
			this.thorPanel1.Controls.Add(this.thorToolBar1);
			this.thorPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.thorPanel1.Location = new System.Drawing.Point(0, 0);
			this.thorPanel1.Name = "thorPanel1";
			this.thorPanel1.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
			this.thorPanel1.Size = new System.Drawing.Size(573, 469);
			this.thorPanel1.TabIndex = 0;
			this.thorPanel1.Title = "Untitled";
			// 
			// thorToolBar1
			// 
			this.thorToolBar1.CanOverflow = false;
			this.thorToolBar1.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.thorToolBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
			this.thorToolBar1.Location = new System.Drawing.Point(0, 20);
			this.thorToolBar1.Name = "thorToolBar1";
			this.thorToolBar1.Padding = new System.Windows.Forms.Padding(2);
			this.thorToolBar1.Size = new System.Drawing.Size(573, 28);
			this.thorToolBar1.TabIndex = 0;
			this.thorToolBar1.Text = "thorToolBar1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Margin = new System.Windows.Forms.Padding(0);
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Padding = new System.Windows.Forms.Padding(2);
			this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
			this.toolStripButton1.Text = "toolStripButton1";
			// 
			// thorImageView
			// 
			this.thorImageView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.thorImageView.Location = new System.Drawing.Point(0, 48);
			this.thorImageView.Name = "thorImageView";
			this.thorImageView.NoFocusBorder = true;
			this.thorImageView.Padding = new System.Windows.Forms.Padding(1);
			this.thorImageView.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.thorImageView.Size = new System.Drawing.Size(573, 421);
			this.thorImageView.TabIndex = 1;
			this.thorImageView.Text = "thorImageView1";
			// 
			// FrmImageModule
			// 
			this.ClientSize = new System.Drawing.Size(784, 565);
			this.Name = "FrmImageModule";
			this.boxNavigation.ResumeLayout(false);
			this.boxMain.ResumeLayout(false);
			this.thorPanel1.ResumeLayout(false);
			this.thorPanel1.PerformLayout();
			this.thorToolBar1.ResumeLayout(false);
			this.thorToolBar1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private THOR.Windows.Components.Common.ThorPanel thorPanel1;
		private THOR.Windows.Components.Tools.ThorToolBar thorToolBar1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private Components.ThorImageView thorImageView;
	}
}
