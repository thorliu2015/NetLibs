namespace THOR.Windows.Editors.UI.Dialogs
{
	partial class FrmUIModule
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
			this.thorPanel1 = new THOR.Windows.Components.Common.ThorPanel();
			this.thorSplitter1 = new THOR.Windows.Components.Common.ThorSplitter();
			this.thorPanel2 = new THOR.Windows.Components.Common.ThorPanel();
			this.thorSplitter2 = new THOR.Windows.Components.Common.ThorSplitter();
			this.thorPanel3 = new THOR.Windows.Components.Common.ThorPanel();
			this.thorSplitter3 = new THOR.Windows.Components.Common.ThorSplitter();
			this.thorPanel4 = new THOR.Windows.Components.Common.ThorPanel();
			this.thorToolBar1 = new THOR.Windows.Components.Tools.ThorToolBar();
			this.uiScene1 = new THOR.Windows.Editors.UI.Controls.UIScene();
			this.thorPropertyGrid1 = new THOR.Windows.Components.ThorGrids.ThorPropertyGrid.ThorPropertyGrid();
			this.boxNavigation.SuspendLayout();
			this.boxMain.SuspendLayout();
			this.thorPanel2.SuspendLayout();
			this.thorPanel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// boxMain
			// 
			this.boxMain.Controls.Add(this.thorPanel4);
			this.boxMain.Controls.Add(this.thorSplitter3);
			this.boxMain.Controls.Add(this.thorPanel3);
			this.boxMain.Controls.Add(this.thorSplitter2);
			this.boxMain.Controls.Add(this.thorPanel2);
			this.boxMain.Controls.Add(this.thorSplitter1);
			this.boxMain.Controls.Add(this.thorPanel1);
			// 
			// thorPanel1
			// 
			this.thorPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.thorPanel1.Location = new System.Drawing.Point(0, 369);
			this.thorPanel1.Name = "thorPanel1";
			this.thorPanel1.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
			this.thorPanel1.Size = new System.Drawing.Size(573, 100);
			this.thorPanel1.TabIndex = 0;
			this.thorPanel1.Title = "Untitled";
			// 
			// thorSplitter1
			// 
			this.thorSplitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.thorSplitter1.Location = new System.Drawing.Point(0, 364);
			this.thorSplitter1.Name = "thorSplitter1";
			this.thorSplitter1.Size = new System.Drawing.Size(573, 5);
			this.thorSplitter1.TabIndex = 1;
			this.thorSplitter1.TabStop = false;
			// 
			// thorPanel2
			// 
			this.thorPanel2.Controls.Add(this.thorPropertyGrid1);
			this.thorPanel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.thorPanel2.Location = new System.Drawing.Point(373, 0);
			this.thorPanel2.Name = "thorPanel2";
			this.thorPanel2.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
			this.thorPanel2.Size = new System.Drawing.Size(200, 364);
			this.thorPanel2.TabIndex = 2;
			this.thorPanel2.Title = "Untitled";
			// 
			// thorSplitter2
			// 
			this.thorSplitter2.Dock = System.Windows.Forms.DockStyle.Right;
			this.thorSplitter2.Location = new System.Drawing.Point(368, 0);
			this.thorSplitter2.Name = "thorSplitter2";
			this.thorSplitter2.Size = new System.Drawing.Size(5, 364);
			this.thorSplitter2.TabIndex = 3;
			this.thorSplitter2.TabStop = false;
			// 
			// thorPanel3
			// 
			this.thorPanel3.Dock = System.Windows.Forms.DockStyle.Left;
			this.thorPanel3.Location = new System.Drawing.Point(0, 0);
			this.thorPanel3.Name = "thorPanel3";
			this.thorPanel3.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
			this.thorPanel3.Size = new System.Drawing.Size(200, 364);
			this.thorPanel3.TabIndex = 4;
			this.thorPanel3.Title = "Untitled";
			// 
			// thorSplitter3
			// 
			this.thorSplitter3.Location = new System.Drawing.Point(200, 0);
			this.thorSplitter3.Name = "thorSplitter3";
			this.thorSplitter3.Size = new System.Drawing.Size(5, 364);
			this.thorSplitter3.TabIndex = 5;
			this.thorSplitter3.TabStop = false;
			// 
			// thorPanel4
			// 
			this.thorPanel4.Controls.Add(this.uiScene1);
			this.thorPanel4.Controls.Add(this.thorToolBar1);
			this.thorPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.thorPanel4.Location = new System.Drawing.Point(205, 0);
			this.thorPanel4.Name = "thorPanel4";
			this.thorPanel4.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
			this.thorPanel4.Size = new System.Drawing.Size(163, 364);
			this.thorPanel4.TabIndex = 6;
			this.thorPanel4.Title = "Untitled";
			// 
			// thorToolBar1
			// 
			this.thorToolBar1.CanOverflow = false;
			this.thorToolBar1.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.thorToolBar1.Location = new System.Drawing.Point(0, 20);
			this.thorToolBar1.Name = "thorToolBar1";
			this.thorToolBar1.Padding = new System.Windows.Forms.Padding(2);
			this.thorToolBar1.Size = new System.Drawing.Size(163, 25);
			this.thorToolBar1.TabIndex = 0;
			this.thorToolBar1.Text = "thorToolBar1";
			// 
			// uiScene1
			// 
			this.uiScene1.Canvas = null;
			this.uiScene1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uiScene1.Location = new System.Drawing.Point(0, 45);
			this.uiScene1.Name = "uiScene1";
			this.uiScene1.NoFocusBorder = true;
			this.uiScene1.Padding = new System.Windows.Forms.Padding(1);
			this.uiScene1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.uiScene1.Size = new System.Drawing.Size(163, 319);
			this.uiScene1.TabIndex = 1;
			this.uiScene1.Text = "uiScene1";
			// 
			// thorPropertyGrid1
			// 
			this.thorPropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.thorPropertyGrid1.Location = new System.Drawing.Point(0, 20);
			this.thorPropertyGrid1.Name = "thorPropertyGrid1";
			this.thorPropertyGrid1.SelectedObject = null;
			this.thorPropertyGrid1.Size = new System.Drawing.Size(200, 344);
			this.thorPropertyGrid1.TabIndex = 0;
			this.thorPropertyGrid1.Text = "thorPropertyGrid1";
			// 
			// FrmUIModule
			// 
			this.ClientSize = new System.Drawing.Size(784, 565);
			this.Name = "FrmUIModule";
			this.boxNavigation.ResumeLayout(false);
			this.boxMain.ResumeLayout(false);
			this.thorPanel2.ResumeLayout(false);
			this.thorPanel4.ResumeLayout(false);
			this.thorPanel4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Components.Common.ThorPanel thorPanel1;
		private Components.Common.ThorPanel thorPanel4;
		private Controls.UIScene uiScene1;
		private Components.Tools.ThorToolBar thorToolBar1;
		private Components.Common.ThorSplitter thorSplitter3;
		private Components.Common.ThorPanel thorPanel3;
		private Components.Common.ThorSplitter thorSplitter2;
		private Components.Common.ThorPanel thorPanel2;
		private Components.Common.ThorSplitter thorSplitter1;
		private Components.ThorGrids.ThorPropertyGrid.ThorPropertyGrid thorPropertyGrid1;

	}
}
