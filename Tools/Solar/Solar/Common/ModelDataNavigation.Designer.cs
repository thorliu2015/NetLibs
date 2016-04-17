namespace Solar.Common
{
	partial class ModelDataNavigation
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

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelDataNavigation));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.treeDataNavigation = new THOR.Windows.UI.Components.TTreeView();
			this.toolBar = new THOR.Windows.UI.Components.TToolBar();
			this.btnTypes = new System.Windows.Forms.ToolStripDropDownButton();
			this.btnAdd = new System.Windows.Forms.ToolStripButton();
			this.btnRemove = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnProperty = new System.Windows.Forms.ToolStripButton();
			this.btnClone = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
			this.btnSearch = new System.Windows.Forms.ToolStripButton();
			this.toolBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "category.png");
			this.imageList.Images.SetKeyName(1, "item.png");
			// 
			// treeDataNavigation
			// 
			this.treeDataNavigation.AllowDragNode = true;
			this.treeDataNavigation.AllowDrop = true;
			this.treeDataNavigation.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeDataNavigation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeDataNavigation.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.treeDataNavigation.HideSelection = false;
			this.treeDataNavigation.ImageIndex = 0;
			this.treeDataNavigation.ImageList = this.imageList;
			this.treeDataNavigation.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
			this.treeDataNavigation.Location = new System.Drawing.Point(0, 27);
			this.treeDataNavigation.Name = "treeDataNavigation";
			this.treeDataNavigation.SelectedImageIndex = 0;
			this.treeDataNavigation.ShowNodeToolTips = true;
			this.treeDataNavigation.Size = new System.Drawing.Size(250, 123);
			this.treeDataNavigation.TabIndex = 1;
			this.treeDataNavigation.NodeDragDrop += new THOR.Windows.UI.Components.TTreeView.NodeDragDropEventHandler(this.treeDataNavigation_NodeDragDrop);
			this.treeDataNavigation.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDataNavigation_AfterSelect);
			// 
			// toolBar
			// 
			this.toolBar.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.toolBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.toolBar.GripMargin = new System.Windows.Forms.Padding(0);
			this.toolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTypes,
            this.btnAdd,
            this.btnRemove,
            this.toolStripSeparator1,
            this.btnProperty,
            this.btnClone,
            this.toolStripSeparator2,
            this.txtSearch,
            this.btnSearch});
			this.toolBar.Location = new System.Drawing.Point(0, 0);
			this.toolBar.Name = "toolBar";
			this.toolBar.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.toolBar.Size = new System.Drawing.Size(250, 27);
			this.toolBar.TabIndex = 0;
			this.toolBar.Text = "tToolBar1";
			// 
			// btnTypes
			// 
			this.btnTypes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnTypes.Image = ((System.Drawing.Image)(resources.GetObject("btnTypes.Image")));
			this.btnTypes.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnTypes.Name = "btnTypes";
			this.btnTypes.Size = new System.Drawing.Size(29, 20);
			this.btnTypes.Text = "toolStripDropDownButton1";
			this.btnTypes.ToolTipText = "类型";
			this.btnTypes.DropDownOpening += new System.EventHandler(this.btnTypes_DropDownOpening);
			// 
			// btnAdd
			// 
			this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
			this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(23, 20);
			this.btnAdd.Text = "添加";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnRemove.Enabled = false;
			this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
			this.btnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(23, 20);
			this.btnRemove.Text = "移除";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
			// 
			// btnProperty
			// 
			this.btnProperty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnProperty.Enabled = false;
			this.btnProperty.Image = ((System.Drawing.Image)(resources.GetObject("btnProperty.Image")));
			this.btnProperty.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnProperty.Name = "btnProperty";
			this.btnProperty.Size = new System.Drawing.Size(23, 20);
			this.btnProperty.Text = "属性";
			this.btnProperty.Click += new System.EventHandler(this.btnProperty_Click);
			// 
			// btnClone
			// 
			this.btnClone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnClone.Enabled = false;
			this.btnClone.Image = ((System.Drawing.Image)(resources.GetObject("btnClone.Image")));
			this.btnClone.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnClone.Name = "btnClone";
			this.btnClone.Size = new System.Drawing.Size(23, 20);
			this.btnClone.Text = "克隆";
			this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
			// 
			// txtSearch
			// 
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(80, 23);
			// 
			// btnSearch
			// 
			this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
			this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(23, 20);
			this.btnSearch.Text = "搜索";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// ModelDataNavigation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.treeDataNavigation);
			this.Controls.Add(this.toolBar);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "ModelDataNavigation";
			this.Size = new System.Drawing.Size(250, 150);
			this.toolBar.ResumeLayout(false);
			this.toolBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private THOR.Windows.UI.Components.TToolBar toolBar;
		private THOR.Windows.UI.Components.TTreeView treeDataNavigation;
		private System.Windows.Forms.ToolStripButton btnAdd;
		private System.Windows.Forms.ToolStripButton btnRemove;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnProperty;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripTextBox txtSearch;
		private System.Windows.Forms.ToolStripButton btnSearch;
		private System.Windows.Forms.ToolStripButton btnClone;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolStripDropDownButton btnTypes;
	}
}
