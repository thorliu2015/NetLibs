namespace Solar.Dialogs
{
	partial class DialogObjectProperty
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
			this.panelMain = new THOR.Windows.UI.Components.TPanel();
			this.propertyGrid = new System.Windows.Forms.PropertyGrid();
			this.panelMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelMain
			// 
			this.panelMain.Controls.Add(this.propertyGrid);
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panelMain.Location = new System.Drawing.Point(0, 0);
			this.panelMain.Name = "panelMain";
			this.panelMain.Padding = new System.Windows.Forms.Padding(2, 24, 2, 2);
			this.panelMain.Size = new System.Drawing.Size(284, 265);
			this.panelMain.TabIndex = 0;
			this.panelMain.Title = "Untitled";
			this.panelMain.TitleFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
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
			this.propertyGrid.Size = new System.Drawing.Size(280, 239);
			this.propertyGrid.TabIndex = 3;
			this.propertyGrid.ToolbarVisible = false;
			this.propertyGrid.ViewBorderColor = System.Drawing.SystemColors.Window;
			// 
			// DialogObjectProperty
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(284, 265);
			this.Controls.Add(this.panelMain);
			this.Name = "DialogObjectProperty";
			this.panelMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private THOR.Windows.UI.Components.TPanel panelMain;
		private System.Windows.Forms.PropertyGrid propertyGrid;

	}
}
