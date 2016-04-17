namespace SolarEditor
{
	partial class FrmDataEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataEditor));
			this.panelProperty = new THOR.Windows.UI.Components.TPanel();
			this.propertyGrid = new System.Windows.Forms.PropertyGrid();
			this.toolBarProperty = new THOR.Windows.UI.Components.TToolBar();
			this.tSplitter2 = new THOR.Windows.UI.Components.TSplitter();
			this.panelStruct = new THOR.Windows.UI.Components.TPanel();
			this.toolBarStruct = new THOR.Windows.UI.Components.TToolBar();
			this.panelMain.SuspendLayout();
			this.panelProperty.SuspendLayout();
			this.panelStruct.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelMain
			// 
			this.panelMain.Controls.Add(this.panelStruct);
			this.panelMain.Controls.Add(this.tSplitter2);
			this.panelMain.Controls.Add(this.panelProperty);
			// 
			// panelProperty
			// 
			this.panelProperty.Controls.Add(this.propertyGrid);
			this.panelProperty.Controls.Add(this.toolBarProperty);
			this.panelProperty.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelProperty.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panelProperty.Location = new System.Drawing.Point(325, 0);
			this.panelProperty.Name = "panelProperty";
			this.panelProperty.Padding = new System.Windows.Forms.Padding(2, 24, 2, 2);
			this.panelProperty.Size = new System.Drawing.Size(200, 513);
			this.panelProperty.TabIndex = 0;
			this.panelProperty.Title = "属性";
			this.panelProperty.TitleFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			// 
			// propertyGrid
			// 
			this.propertyGrid.CanShowVisualStyleGlyphs = false;
			this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid.HelpBackColor = System.Drawing.SystemColors.Info;
			this.propertyGrid.HelpBorderColor = System.Drawing.SystemColors.Info;
			this.propertyGrid.HelpForeColor = System.Drawing.SystemColors.InfoText;
			this.propertyGrid.Location = new System.Drawing.Point(2, 49);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.Size = new System.Drawing.Size(196, 462);
			this.propertyGrid.TabIndex = 1;
			this.propertyGrid.ToolbarVisible = false;
			this.propertyGrid.ViewBorderColor = System.Drawing.SystemColors.Window;
			// 
			// toolBarProperty
			// 
			this.toolBarProperty.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.toolBarProperty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.toolBarProperty.GripMargin = new System.Windows.Forms.Padding(0);
			this.toolBarProperty.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolBarProperty.Location = new System.Drawing.Point(2, 24);
			this.toolBarProperty.Name = "toolBarProperty";
			this.toolBarProperty.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.toolBarProperty.Size = new System.Drawing.Size(196, 25);
			this.toolBarProperty.TabIndex = 0;
			this.toolBarProperty.Text = "tToolBar2";
			// 
			// tSplitter2
			// 
			this.tSplitter2.Dock = System.Windows.Forms.DockStyle.Right;
			this.tSplitter2.Location = new System.Drawing.Point(316, 0);
			this.tSplitter2.MinSize = 200;
			this.tSplitter2.Name = "tSplitter2";
			this.tSplitter2.Size = new System.Drawing.Size(9, 513);
			this.tSplitter2.TabIndex = 1;
			this.tSplitter2.TabStop = false;
			// 
			// panelStruct
			// 
			this.panelStruct.Controls.Add(this.toolBarStruct);
			this.panelStruct.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelStruct.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panelStruct.Location = new System.Drawing.Point(0, 0);
			this.panelStruct.Name = "panelStruct";
			this.panelStruct.Padding = new System.Windows.Forms.Padding(2, 24, 2, 2);
			this.panelStruct.Size = new System.Drawing.Size(316, 513);
			this.panelStruct.TabIndex = 2;
			this.panelStruct.Title = "结构";
			this.panelStruct.TitleFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			// 
			// toolBarStruct
			// 
			this.toolBarStruct.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.toolBarStruct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.toolBarStruct.GripMargin = new System.Windows.Forms.Padding(0);
			this.toolBarStruct.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolBarStruct.Location = new System.Drawing.Point(2, 24);
			this.toolBarStruct.Name = "toolBarStruct";
			this.toolBarStruct.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.toolBarStruct.Size = new System.Drawing.Size(312, 25);
			this.toolBarStruct.TabIndex = 0;
			this.toolBarStruct.Text = "tToolBar1";
			// 
			// FrmDataEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmDataEditor";
			this.Text = "Abstract - Microsoft® Visual Studio® 2012 ver 11.0.50727.1";
			this.panelMain.ResumeLayout(false);
			this.panelProperty.ResumeLayout(false);
			this.panelProperty.PerformLayout();
			this.panelStruct.ResumeLayout(false);
			this.panelStruct.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private THOR.Windows.UI.Components.TPanel panelProperty;
		private THOR.Windows.UI.Components.TSplitter tSplitter2;
		private THOR.Windows.UI.Components.TPanel panelStruct;
		private THOR.Windows.UI.Components.TToolBar toolBarStruct;
		private System.Windows.Forms.PropertyGrid propertyGrid;
		private THOR.Windows.UI.Components.TToolBar toolBarProperty;
	}
}
