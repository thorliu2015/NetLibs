namespace THOR.Windows.Editors.Common.Dialogs
{
	partial class DialogEntityTypeSelector
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogEntityTypeSelector));
			this.thorBand1 = new THOR.Windows.Components.Common.ThorBand();
			this.txtSearch = new THOR.Windows.Components.Fields.ThorTextField();
			this.treeTypes = new THOR.Windows.Components.ThorGrids.ThorTree.ThorTreeView();
			this.btnSearch = new THOR.Windows.Components.Common.ThorFlatButton();
			this.boxContent.SuspendLayout();
			this.thorBand1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(345, 5);
			// 
			// boxContent
			// 
			this.boxContent.Controls.Add(this.treeTypes);
			this.boxContent.Controls.Add(this.thorBand1);
			this.boxContent.Size = new System.Drawing.Size(494, 330);
			// 
			// thorBand1
			// 
			this.thorBand1.Controls.Add(this.txtSearch);
			this.thorBand1.Controls.Add(this.btnSearch);
			this.thorBand1.Dock = System.Windows.Forms.DockStyle.Top;
			this.thorBand1.Location = new System.Drawing.Point(0, 0);
			this.thorBand1.Name = "thorBand1";
			this.thorBand1.Padding = new System.Windows.Forms.Padding(16, 1, 2, 1);
			this.thorBand1.Size = new System.Drawing.Size(494, 25);
			this.thorBand1.TabIndex = 0;
			// 
			// txtSearch
			// 
			this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txtSearch.Location = new System.Drawing.Point(16, 1);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Padding = new System.Windows.Forms.Padding(1);
			this.txtSearch.Size = new System.Drawing.Size(100, 23);
			this.txtSearch.TabIndex = 0;
			this.txtSearch.TabStop = false;
			this.txtSearch.Text = "thorTextField1";
			// 
			// treeTypes
			// 
			this.treeTypes.DataTable = null;
			this.treeTypes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeTypes.FixedColumns = 1;
			this.treeTypes.FixedRows = 1;
			this.treeTypes.Indent = 20;
			this.treeTypes.Location = new System.Drawing.Point(0, 25);
			this.treeTypes.Name = "treeTypes";
			this.treeTypes.NoFocusBorder = true;
			this.treeTypes.Padding = new System.Windows.Forms.Padding(1);
			this.treeTypes.Render = thorTreeViewRender1;
			this.treeTypes.RowHeight = 20;
			this.treeTypes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.treeTypes.SelectedCell = null;
			this.treeTypes.SelectedRow = null;
			this.treeTypes.Size = new System.Drawing.Size(494, 305);
			this.treeTypes.TabIndex = 1;
			this.treeTypes.Text = "thorTreeView1";
			this.treeTypes.SelectionChanged += new System.EventHandler(this.treeTypes_SelectionChanged);
			// 
			// btnSearch
			// 
			this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
			this.btnSearch.Location = new System.Drawing.Point(117, 1);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(22, 23);
			this.btnSearch.TabIndex = 1;
			this.btnSearch.TabStop = false;
			this.btnSearch.Text = "thorFlatButton1";
			this.btnSearch.UseVisualStyleBackColor = false;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// DialogEntityTypeSelector
			// 
			this.ClientSize = new System.Drawing.Size(500, 400);
			this.Name = "DialogEntityTypeSelector";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.boxContent.ResumeLayout(false);
			this.thorBand1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Windows.Components.Common.ThorBand thorBand1;
		private Windows.Components.Fields.ThorTextField txtSearch;
		private Windows.Components.ThorGrids.ThorTree.ThorTreeView treeTypes;
		private Windows.Components.Common.ThorFlatButton btnSearch;
	}
}
