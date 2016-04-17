namespace THOR.Windows.Editors.Common.Components
{
	partial class ThorModelsNavigation
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
			THOR.Windows.Components.ThorGrids.ThorTree.ThorTreeViewRender thorTreeViewRender1 = new THOR.Windows.Components.ThorGrids.ThorTree.ThorTreeViewRender();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThorModelsNavigation));
			this.thorPanel = new THOR.Windows.Components.Common.ThorPanel();
			this.treeModels = new THOR.Windows.Components.ThorGrids.ThorTree.ThorTreeView();
			this.bandBrowse = new THOR.Windows.Components.Common.ThorBand();
			this.btnBack = new THOR.Windows.Components.Common.ThorFlatButton();
			this.btnNext = new THOR.Windows.Components.Common.ThorFlatButton();
			this.txtSearch = new THOR.Windows.Components.Fields.ThorTextField();
			this.btnSearch = new THOR.Windows.Components.Common.ThorFlatButton();
			this.toolBarModify = new THOR.Windows.Components.Tools.ThorToolBar();
			this.menuTypes = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripSeparatorTypes = new System.Windows.Forms.ToolStripSeparator();
			this.btnCreate = new System.Windows.Forms.ToolStripButton();
			this.btnDelete = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnModify = new System.Windows.Forms.ToolStripButton();
			this.btnClone = new System.Windows.Forms.ToolStripButton();
			this.thorPanel.SuspendLayout();
			this.bandBrowse.SuspendLayout();
			this.toolBarModify.SuspendLayout();
			this.SuspendLayout();
			// 
			// thorPanel
			// 
			this.thorPanel.Controls.Add(this.treeModels);
			this.thorPanel.Controls.Add(this.bandBrowse);
			this.thorPanel.Controls.Add(this.toolBarModify);
			this.thorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.thorPanel.Location = new System.Drawing.Point(0, 0);
			this.thorPanel.Name = "thorPanel";
			this.thorPanel.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
			this.thorPanel.Size = new System.Drawing.Size(250, 300);
			this.thorPanel.TabIndex = 0;
			this.thorPanel.Title = "Untitled";
			// 
			// treeModels
			// 
			this.treeModels.DataTable = null;
			this.treeModels.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeModels.FixedColumns = 1;
			this.treeModels.FixedRows = 1;
			this.treeModels.Indent = 20;
			this.treeModels.Location = new System.Drawing.Point(0, 73);
			this.treeModels.Name = "treeModels";
			this.treeModels.NoFocusBorder = false;
			this.treeModels.Padding = new System.Windows.Forms.Padding(1);
			this.treeModels.Render = thorTreeViewRender1;
			this.treeModels.RowHeight = 20;
			this.treeModels.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.treeModels.SelectedCell = null;
			this.treeModels.SelectedRow = null;
			this.treeModels.Size = new System.Drawing.Size(250, 227);
			this.treeModels.TabIndex = 2;
			this.treeModels.Text = "thorTreeView1";
			this.treeModels.SelectionChanged += new System.EventHandler(this.treeModels_SelectionChanged);
			// 
			// bandBrowse
			// 
			this.bandBrowse.Controls.Add(this.btnBack);
			this.bandBrowse.Controls.Add(this.btnNext);
			this.bandBrowse.Controls.Add(this.txtSearch);
			this.bandBrowse.Controls.Add(this.btnSearch);
			this.bandBrowse.Dock = System.Windows.Forms.DockStyle.Top;
			this.bandBrowse.Location = new System.Drawing.Point(0, 48);
			this.bandBrowse.Name = "bandBrowse";
			this.bandBrowse.Padding = new System.Windows.Forms.Padding(16, 1, 2, 1);
			this.bandBrowse.Size = new System.Drawing.Size(250, 25);
			this.bandBrowse.TabIndex = 1;
			// 
			// btnBack
			// 
			this.btnBack.Enabled = false;
			this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
			this.btnBack.Location = new System.Drawing.Point(16, 1);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(22, 23);
			this.btnBack.TabIndex = 0;
			this.btnBack.TabStop = false;
			this.btnBack.Text = "thorFlatButton1";
			this.btnBack.UseVisualStyleBackColor = false;
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// btnNext
			// 
			this.btnNext.Enabled = false;
			this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
			this.btnNext.Location = new System.Drawing.Point(39, 1);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(22, 23);
			this.btnNext.TabIndex = 3;
			this.btnNext.TabStop = false;
			this.btnNext.Text = "thorFlatButton3";
			this.btnNext.UseVisualStyleBackColor = false;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txtSearch.Location = new System.Drawing.Point(62, 1);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Padding = new System.Windows.Forms.Padding(1);
			this.txtSearch.Size = new System.Drawing.Size(100, 23);
			this.txtSearch.TabIndex = 2;
			this.txtSearch.TabStop = false;
			this.txtSearch.Text = "thorTextField1";
			// 
			// btnSearch
			// 
			this.btnSearch.Enabled = false;
			this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
			this.btnSearch.Location = new System.Drawing.Point(163, 1);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(22, 23);
			this.btnSearch.TabIndex = 1;
			this.btnSearch.TabStop = false;
			this.btnSearch.Text = "thorFlatButton2";
			this.btnSearch.UseVisualStyleBackColor = false;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// toolBarModify
			// 
			this.toolBarModify.CanOverflow = false;
			this.toolBarModify.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.toolBarModify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTypes,
            this.toolStripSeparatorTypes,
            this.btnCreate,
            this.btnDelete,
            this.toolStripSeparator2,
            this.btnModify,
            this.btnClone});
			this.toolBarModify.Location = new System.Drawing.Point(0, 20);
			this.toolBarModify.Name = "toolBarModify";
			this.toolBarModify.Padding = new System.Windows.Forms.Padding(2);
			this.toolBarModify.Size = new System.Drawing.Size(250, 28);
			this.toolBarModify.TabIndex = 0;
			this.toolBarModify.Text = "thorToolBar1";
			// 
			// menuTypes
			// 
			this.menuTypes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.menuTypes.Image = ((System.Drawing.Image)(resources.GetObject("menuTypes.Image")));
			this.menuTypes.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.menuTypes.Margin = new System.Windows.Forms.Padding(0);
			this.menuTypes.Name = "menuTypes";
			this.menuTypes.Padding = new System.Windows.Forms.Padding(2);
			this.menuTypes.Size = new System.Drawing.Size(33, 24);
			this.menuTypes.Text = "toolStripDropDownButton1";
			// 
			// toolStripSeparatorTypes
			// 
			this.toolStripSeparatorTypes.Name = "toolStripSeparatorTypes";
			this.toolStripSeparatorTypes.Padding = new System.Windows.Forms.Padding(2);
			this.toolStripSeparatorTypes.Size = new System.Drawing.Size(6, 24);
			// 
			// btnCreate
			// 
			this.btnCreate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.Image")));
			this.btnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCreate.Margin = new System.Windows.Forms.Padding(0);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Padding = new System.Windows.Forms.Padding(2);
			this.btnCreate.Size = new System.Drawing.Size(24, 24);
			this.btnCreate.Text = "toolStripButton1";
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnDelete.Enabled = false;
			this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
			this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Padding = new System.Windows.Forms.Padding(2);
			this.btnDelete.Size = new System.Drawing.Size(24, 24);
			this.btnDelete.Text = "toolStripButton2";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Padding = new System.Windows.Forms.Padding(2);
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 24);
			// 
			// btnModify
			// 
			this.btnModify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnModify.Enabled = false;
			this.btnModify.Image = ((System.Drawing.Image)(resources.GetObject("btnModify.Image")));
			this.btnModify.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnModify.Margin = new System.Windows.Forms.Padding(0);
			this.btnModify.Name = "btnModify";
			this.btnModify.Padding = new System.Windows.Forms.Padding(2);
			this.btnModify.Size = new System.Drawing.Size(24, 24);
			this.btnModify.Text = "toolStripButton3";
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			// 
			// btnClone
			// 
			this.btnClone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnClone.Enabled = false;
			this.btnClone.Image = ((System.Drawing.Image)(resources.GetObject("btnClone.Image")));
			this.btnClone.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnClone.Margin = new System.Windows.Forms.Padding(0);
			this.btnClone.Name = "btnClone";
			this.btnClone.Padding = new System.Windows.Forms.Padding(2);
			this.btnClone.Size = new System.Drawing.Size(24, 24);
			this.btnClone.Text = "toolStripButton4";
			this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
			// 
			// ThorModelsNavigation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Controls.Add(this.thorPanel);
			this.Name = "ThorModelsNavigation";
			this.Size = new System.Drawing.Size(250, 300);
			this.thorPanel.ResumeLayout(false);
			this.thorPanel.PerformLayout();
			this.bandBrowse.ResumeLayout(false);
			this.toolBarModify.ResumeLayout(false);
			this.toolBarModify.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private Windows.Components.Common.ThorPanel thorPanel;
		private Windows.Components.Tools.ThorToolBar toolBarModify;
		private Windows.Components.Common.ThorBand bandBrowse;
		private Windows.Components.ThorGrids.ThorTree.ThorTreeView treeModels;
		private System.Windows.Forms.ToolStripDropDownButton menuTypes;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparatorTypes;
		private System.Windows.Forms.ToolStripButton btnCreate;
		private System.Windows.Forms.ToolStripButton btnDelete;
		private System.Windows.Forms.ToolStripButton btnModify;
		private System.Windows.Forms.ToolStripButton btnClone;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private Windows.Components.Common.ThorFlatButton btnBack;
		private Windows.Components.Common.ThorFlatButton btnNext;
		private Windows.Components.Fields.ThorTextField txtSearch;
		private Windows.Components.Common.ThorFlatButton btnSearch;
	}
}
