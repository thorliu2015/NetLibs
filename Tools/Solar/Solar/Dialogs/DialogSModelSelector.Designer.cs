namespace Solar.Dialogs
{
	partial class DialogSModelSelector
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
			this.panelPreview = new THOR.Windows.UI.Components.TPanel();
			this.splitter = new THOR.Windows.UI.Components.TSplitter();
			this.panelNavigation = new THOR.Windows.UI.Components.TPanel();
			this.modelDataNavigation = new Solar.Common.ModelDataNavigation();
			this.panelMain.SuspendLayout();
			this.panelNavigation.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelMain
			// 
			this.panelMain.Controls.Add(this.panelNavigation);
			this.panelMain.Controls.Add(this.splitter);
			this.panelMain.Controls.Add(this.panelPreview);
			// 
			// panelPreview
			// 
			this.panelPreview.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelPreview.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panelPreview.Location = new System.Drawing.Point(291, 0);
			this.panelPreview.Name = "panelPreview";
			this.panelPreview.Padding = new System.Windows.Forms.Padding(2, 24, 2, 2);
			this.panelPreview.Size = new System.Drawing.Size(200, 402);
			this.panelPreview.TabIndex = 0;
			this.panelPreview.Title = "预览";
			this.panelPreview.TitleFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			// 
			// splitter
			// 
			this.splitter.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter.Location = new System.Drawing.Point(282, 0);
			this.splitter.Name = "splitter";
			this.splitter.Size = new System.Drawing.Size(9, 402);
			this.splitter.TabIndex = 1;
			this.splitter.TabStop = false;
			// 
			// panelNavigation
			// 
			this.panelNavigation.Controls.Add(this.modelDataNavigation);
			this.panelNavigation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelNavigation.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panelNavigation.Location = new System.Drawing.Point(0, 0);
			this.panelNavigation.Name = "panelNavigation";
			this.panelNavigation.Padding = new System.Windows.Forms.Padding(2, 24, 2, 2);
			this.panelNavigation.Size = new System.Drawing.Size(282, 402);
			this.panelNavigation.TabIndex = 2;
			this.panelNavigation.Title = "目录";
			this.panelNavigation.TitleFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			// 
			// modelDataNavigation
			// 
			this.modelDataNavigation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.modelDataNavigation.FilterType = typeof(Solar.Data.SModel);
			this.modelDataNavigation.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.modelDataNavigation.Location = new System.Drawing.Point(2, 24);
			this.modelDataNavigation.Name = "modelDataNavigation";
			this.modelDataNavigation.ReadOnly = true;
			this.modelDataNavigation.Size = new System.Drawing.Size(278, 376);
			this.modelDataNavigation.TabIndex = 0;
			// 
			// DialogSModelSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(491, 440);
			this.Name = "DialogSModelSelector";
			this.panelMain.ResumeLayout(false);
			this.panelNavigation.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		protected THOR.Windows.UI.Components.TPanel panelPreview;
		protected THOR.Windows.UI.Components.TPanel panelNavigation;
		protected THOR.Windows.UI.Components.TSplitter splitter;
		public Common.ModelDataNavigation modelDataNavigation;

	}
}
