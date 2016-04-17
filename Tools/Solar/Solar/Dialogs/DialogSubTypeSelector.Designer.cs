namespace Solar.Dialogs
{
	partial class DialogSubTypeSelector
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogSubTypeSelector));
			this.panel = new THOR.Windows.UI.Components.TPanel();
			this.treeTypes = new THOR.Windows.UI.Components.TTreeView();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.panelMain.SuspendLayout();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelMain
			// 
			this.panelMain.Controls.Add(this.panel);
			this.panelMain.Size = new System.Drawing.Size(297, 387);
			// 
			// panel
			// 
			this.panel.Controls.Add(this.treeTypes);
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Padding = new System.Windows.Forms.Padding(2, 24, 2, 2);
			this.panel.Size = new System.Drawing.Size(297, 387);
			this.panel.TabIndex = 0;
			this.panel.Title = "类型";
			this.panel.TitleFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			// 
			// treeTypes
			// 
			this.treeTypes.AllowDragNode = false;
			this.treeTypes.AllowDrop = true;
			this.treeTypes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeTypes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeTypes.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.treeTypes.HideSelection = false;
			this.treeTypes.ImageIndex = 0;
			this.treeTypes.ImageList = this.imageList;
			this.treeTypes.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
			this.treeTypes.Location = new System.Drawing.Point(2, 24);
			this.treeTypes.Name = "treeTypes";
			this.treeTypes.SelectedImageIndex = 0;
			this.treeTypes.ShowNodeToolTips = true;
			this.treeTypes.Size = new System.Drawing.Size(293, 361);
			this.treeTypes.TabIndex = 0;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "category.png");
			this.imageList.Images.SetKeyName(1, "item.png");
			// 
			// DialogSubTypeSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(297, 425);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "DialogSubTypeSelector";
			this.Text = "选择数据类型";
			this.panelMain.ResumeLayout(false);
			this.panel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private THOR.Windows.UI.Components.TPanel panel;
		private THOR.Windows.UI.Components.TTreeView treeTypes;
		private System.Windows.Forms.ImageList imageList;
	}
}
