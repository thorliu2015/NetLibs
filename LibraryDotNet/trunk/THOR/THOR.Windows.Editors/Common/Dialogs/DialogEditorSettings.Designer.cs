namespace THOR.Windows.Editors.Common.Dialogs
{
	partial class DialogEditorSettings
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
			this.thorPropertyGrid = new THOR.Windows.Components.ThorGrids.ThorPropertyGrid.ThorPropertyGrid();
			this.boxContent.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(445, 5);
			// 
			// boxContent
			// 
			this.boxContent.Controls.Add(this.thorPropertyGrid);
			this.boxContent.Size = new System.Drawing.Size(594, 330);
			// 
			// thorPropertyGrid
			// 
			this.thorPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.thorPropertyGrid.Location = new System.Drawing.Point(0, 0);
			this.thorPropertyGrid.Name = "thorPropertyGrid";
			this.thorPropertyGrid.SelectedObject = null;
			this.thorPropertyGrid.Size = new System.Drawing.Size(594, 330);
			this.thorPropertyGrid.TabIndex = 0;
			this.thorPropertyGrid.Text = "thorPropertyGrid1";
			// 
			// DialogEditorSettings
			// 
			this.ClientSize = new System.Drawing.Size(600, 400);
			this.Name = "DialogEditorSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.boxContent.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Windows.Components.ThorGrids.ThorPropertyGrid.ThorPropertyGrid thorPropertyGrid;
	}
}
