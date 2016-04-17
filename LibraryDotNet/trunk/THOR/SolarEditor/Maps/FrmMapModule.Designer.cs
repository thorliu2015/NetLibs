namespace SolarEditor.Maps
{
	partial class FrmMapModule
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMapModule));
			this.panelMap = new THOR.Windows.Components.Common.ThorPanel();
			this.toolbarMap = new THOR.Windows.Components.Tools.ThorToolBar();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.mapView = new THOR.Windows.Components.D2D.ThorDirect2DView();
			this.boxNavigation.SuspendLayout();
			this.boxMain.SuspendLayout();
			this.panelMap.SuspendLayout();
			this.toolbarMap.SuspendLayout();
			this.SuspendLayout();
			// 
			// boxMain
			// 
			this.boxMain.Controls.Add(this.panelMap);
			// 
			// panelMap
			// 
			this.panelMap.Controls.Add(this.mapView);
			this.panelMap.Controls.Add(this.toolbarMap);
			this.panelMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMap.Location = new System.Drawing.Point(0, 0);
			this.panelMap.Name = "panelMap";
			this.panelMap.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
			this.panelMap.Size = new System.Drawing.Size(573, 469);
			this.panelMap.TabIndex = 0;
			this.panelMap.Title = "Untitled";
			// 
			// toolbarMap
			// 
			this.toolbarMap.CanOverflow = false;
			this.toolbarMap.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.toolbarMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
			this.toolbarMap.Location = new System.Drawing.Point(0, 20);
			this.toolbarMap.Name = "toolbarMap";
			this.toolbarMap.Padding = new System.Windows.Forms.Padding(2);
			this.toolbarMap.Size = new System.Drawing.Size(573, 28);
			this.toolbarMap.TabIndex = 0;
			this.toolbarMap.Text = "thorToolBar1";
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
			// mapView
			// 
			this.mapView.Canvas = null;
			this.mapView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mapView.Location = new System.Drawing.Point(0, 48);
			this.mapView.Name = "mapView";
			this.mapView.NoFocusBorder = true;
			this.mapView.Padding = new System.Windows.Forms.Padding(1);
			this.mapView.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.mapView.Size = new System.Drawing.Size(573, 421);
			this.mapView.TabIndex = 1;
			this.mapView.Text = "thorDirect2DView1";
			// 
			// FrmMapModule
			// 
			this.ClientSize = new System.Drawing.Size(784, 565);
			this.Name = "FrmMapModule";
			this.boxNavigation.ResumeLayout(false);
			this.boxMain.ResumeLayout(false);
			this.panelMap.ResumeLayout(false);
			this.panelMap.PerformLayout();
			this.toolbarMap.ResumeLayout(false);
			this.toolbarMap.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private THOR.Windows.Components.Common.ThorPanel panelMap;
		private THOR.Windows.Components.Tools.ThorToolBar toolbarMap;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private THOR.Windows.Components.D2D.ThorDirect2DView mapView;
	}
}
