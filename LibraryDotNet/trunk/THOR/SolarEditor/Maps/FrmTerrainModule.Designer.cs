namespace SolarEditor.Maps
{
	partial class FrmTerrainModule
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
			THOR.Windows.Components.ThorGrids.ThorTree.ThorTreeViewRender thorTreeViewRender2 = new THOR.Windows.Components.ThorGrids.ThorTree.ThorTreeViewRender();
			THOR.Windows.Components.ThorGrids.ThorTree.ThorTreeViewRender thorTreeViewRender1 = new THOR.Windows.Components.ThorGrids.ThorTree.ThorTreeViewRender();
			this.thorBox1 = new THOR.Windows.Components.Common.ThorBox();
			this.thorSplitter1 = new THOR.Windows.Components.Common.ThorSplitter();
			this.panelImage = new THOR.Windows.Components.Common.ThorPanel();
			this.toolBarImage = new THOR.Windows.Components.Tools.ThorToolBar();
			this.thorTreeView1 = new THOR.Windows.Components.ThorGrids.ThorTree.ThorTreeView();
			this.thorSplitter2 = new THOR.Windows.Components.Common.ThorSplitter();
			this.panelTerrain = new THOR.Windows.Components.Common.ThorPanel();
			this.toolBarTerrain = new THOR.Windows.Components.Tools.ThorToolBar();
			this.treeTerrain = new THOR.Windows.Components.ThorGrids.ThorTree.ThorTreeView();
			this.imageView = new SolarEditor.Images.Components.ThorImageView();
			this.boxNavigation.SuspendLayout();
			this.boxMain.SuspendLayout();
			this.thorBox1.SuspendLayout();
			this.panelImage.SuspendLayout();
			this.panelTerrain.SuspendLayout();
			this.SuspendLayout();
			// 
			// boxMain
			// 
			this.boxMain.Controls.Add(this.panelTerrain);
			this.boxMain.Controls.Add(this.thorSplitter2);
			this.boxMain.Controls.Add(this.thorBox1);
			// 
			// thorBox1
			// 
			this.thorBox1.BackColor = System.Drawing.Color.Transparent;
			this.thorBox1.Controls.Add(this.panelImage);
			this.thorBox1.Controls.Add(this.thorSplitter1);
			this.thorBox1.Controls.Add(this.imageView);
			this.thorBox1.Dock = System.Windows.Forms.DockStyle.Right;
			this.thorBox1.Location = new System.Drawing.Point(373, 0);
			this.thorBox1.Name = "thorBox1";
			this.thorBox1.Size = new System.Drawing.Size(200, 469);
			this.thorBox1.TabIndex = 0;
			// 
			// thorSplitter1
			// 
			this.thorSplitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.thorSplitter1.Location = new System.Drawing.Point(0, 364);
			this.thorSplitter1.Name = "thorSplitter1";
			this.thorSplitter1.Size = new System.Drawing.Size(200, 5);
			this.thorSplitter1.TabIndex = 1;
			this.thorSplitter1.TabStop = false;
			// 
			// panelImage
			// 
			this.panelImage.Controls.Add(this.thorTreeView1);
			this.panelImage.Controls.Add(this.toolBarImage);
			this.panelImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelImage.Location = new System.Drawing.Point(0, 0);
			this.panelImage.Name = "panelImage";
			this.panelImage.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
			this.panelImage.Size = new System.Drawing.Size(200, 364);
			this.panelImage.TabIndex = 2;
			this.panelImage.Title = "Untitled";
			// 
			// toolBarImage
			// 
			this.toolBarImage.CanOverflow = false;
			this.toolBarImage.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.toolBarImage.Location = new System.Drawing.Point(0, 20);
			this.toolBarImage.Name = "toolBarImage";
			this.toolBarImage.Padding = new System.Windows.Forms.Padding(2);
			this.toolBarImage.Size = new System.Drawing.Size(200, 25);
			this.toolBarImage.TabIndex = 0;
			this.toolBarImage.Text = "thorToolBar1";
			// 
			// thorTreeView1
			// 
			this.thorTreeView1.DataTable = null;
			this.thorTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.thorTreeView1.FixedColumns = 1;
			this.thorTreeView1.FixedRows = 1;
			this.thorTreeView1.Indent = 20;
			this.thorTreeView1.Location = new System.Drawing.Point(0, 45);
			this.thorTreeView1.Name = "thorTreeView1";
			this.thorTreeView1.NoFocusBorder = true;
			this.thorTreeView1.Padding = new System.Windows.Forms.Padding(1);
			this.thorTreeView1.Render = thorTreeViewRender2;
			this.thorTreeView1.RowHeight = 20;
			this.thorTreeView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.thorTreeView1.SelectedCell = null;
			this.thorTreeView1.SelectedRow = null;
			this.thorTreeView1.Size = new System.Drawing.Size(200, 319);
			this.thorTreeView1.TabIndex = 1;
			this.thorTreeView1.Text = "thorTreeView1";
			// 
			// thorSplitter2
			// 
			this.thorSplitter2.Dock = System.Windows.Forms.DockStyle.Right;
			this.thorSplitter2.Location = new System.Drawing.Point(368, 0);
			this.thorSplitter2.Name = "thorSplitter2";
			this.thorSplitter2.Size = new System.Drawing.Size(5, 469);
			this.thorSplitter2.TabIndex = 1;
			this.thorSplitter2.TabStop = false;
			// 
			// panelTerrain
			// 
			this.panelTerrain.Controls.Add(this.treeTerrain);
			this.panelTerrain.Controls.Add(this.toolBarTerrain);
			this.panelTerrain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelTerrain.Location = new System.Drawing.Point(0, 0);
			this.panelTerrain.Name = "panelTerrain";
			this.panelTerrain.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
			this.panelTerrain.Size = new System.Drawing.Size(368, 469);
			this.panelTerrain.TabIndex = 2;
			this.panelTerrain.Title = "Untitled";
			// 
			// toolBarTerrain
			// 
			this.toolBarTerrain.CanOverflow = false;
			this.toolBarTerrain.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.toolBarTerrain.Location = new System.Drawing.Point(0, 20);
			this.toolBarTerrain.Name = "toolBarTerrain";
			this.toolBarTerrain.Padding = new System.Windows.Forms.Padding(2);
			this.toolBarTerrain.Size = new System.Drawing.Size(368, 25);
			this.toolBarTerrain.TabIndex = 0;
			this.toolBarTerrain.Text = "thorToolBar2";
			// 
			// treeTerrain
			// 
			this.treeTerrain.DataTable = null;
			this.treeTerrain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeTerrain.FixedColumns = 1;
			this.treeTerrain.FixedRows = 1;
			this.treeTerrain.Indent = 20;
			this.treeTerrain.Location = new System.Drawing.Point(0, 45);
			this.treeTerrain.Name = "treeTerrain";
			this.treeTerrain.NoFocusBorder = true;
			this.treeTerrain.Padding = new System.Windows.Forms.Padding(1);
			this.treeTerrain.Render = thorTreeViewRender1;
			this.treeTerrain.RowHeight = 20;
			this.treeTerrain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.treeTerrain.SelectedCell = null;
			this.treeTerrain.SelectedRow = null;
			this.treeTerrain.Size = new System.Drawing.Size(368, 424);
			this.treeTerrain.TabIndex = 1;
			this.treeTerrain.Text = "thorTreeView2";
			// 
			// imageView
			// 
			this.imageView.CurrentImage = null;
			this.imageView.CurrentScale = 1F;
			this.imageView.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.imageView.Location = new System.Drawing.Point(0, 369);
			this.imageView.Name = "imageView";
			this.imageView.NoFocusBorder = true;
			this.imageView.Padding = new System.Windows.Forms.Padding(1);
			this.imageView.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.imageView.Size = new System.Drawing.Size(200, 100);
			this.imageView.TabIndex = 0;
			this.imageView.Text = "thorImageView1";
			// 
			// FrmTerrainModule
			// 
			this.ClientSize = new System.Drawing.Size(784, 565);
			this.Name = "FrmTerrainModule";
			this.boxNavigation.ResumeLayout(false);
			this.boxMain.ResumeLayout(false);
			this.thorBox1.ResumeLayout(false);
			this.panelImage.ResumeLayout(false);
			this.panelImage.PerformLayout();
			this.panelTerrain.ResumeLayout(false);
			this.panelTerrain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private THOR.Windows.Components.Common.ThorBox thorBox1;
		private THOR.Windows.Components.Common.ThorPanel panelImage;
		private THOR.Windows.Components.ThorGrids.ThorTree.ThorTreeView thorTreeView1;
		private THOR.Windows.Components.Tools.ThorToolBar toolBarImage;
		private THOR.Windows.Components.Common.ThorSplitter thorSplitter1;
		private Images.Components.ThorImageView imageView;
		private THOR.Windows.Components.Common.ThorSplitter thorSplitter2;
		private THOR.Windows.Components.Common.ThorPanel panelTerrain;
		private THOR.Windows.Components.ThorGrids.ThorTree.ThorTreeView treeTerrain;
		private THOR.Windows.Components.Tools.ThorToolBar toolBarTerrain;



	}
}
