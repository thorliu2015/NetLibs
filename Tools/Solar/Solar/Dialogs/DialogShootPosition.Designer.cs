namespace Solar.Dialogs
{
	partial class DialogShootPosition
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogShootPosition));
			this.tPanel1 = new THOR.Windows.UI.Components.TPanel();
			this.listShootPositions = new THOR.Windows.UI.Components.TListView();
			this.columnIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tToolBar1 = new THOR.Windows.UI.Components.TToolBar();
			this.btnAdd = new System.Windows.Forms.ToolStripButton();
			this.btnRemove = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnUp = new System.Windows.Forms.ToolStripButton();
			this.btnDown = new System.Windows.Forms.ToolStripButton();
			this.btnLeft = new System.Windows.Forms.ToolStripButton();
			this.btnRight = new System.Windows.Forms.ToolStripButton();
			this.tPanel1.SuspendLayout();
			this.tToolBar1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tPanel1
			// 
			this.tPanel1.Controls.Add(this.listShootPositions);
			this.tPanel1.Controls.Add(this.tToolBar1);
			this.tPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tPanel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.tPanel1.Location = new System.Drawing.Point(0, 0);
			this.tPanel1.Name = "tPanel1";
			this.tPanel1.Padding = new System.Windows.Forms.Padding(2, 24, 2, 2);
			this.tPanel1.Size = new System.Drawing.Size(174, 218);
			this.tPanel1.TabIndex = 0;
			this.tPanel1.Title = "枪口";
			this.tPanel1.TitleFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			// 
			// listShootPositions
			// 
			this.listShootPositions.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listShootPositions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnIndex,
            this.columnX,
            this.columnY});
			this.listShootPositions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listShootPositions.FullRowSelect = true;
			this.listShootPositions.GridLines = true;
			this.listShootPositions.HideSelection = false;
			this.listShootPositions.Location = new System.Drawing.Point(2, 51);
			this.listShootPositions.Name = "listShootPositions";
			this.listShootPositions.OwnerDraw = true;
			this.listShootPositions.Size = new System.Drawing.Size(170, 165);
			this.listShootPositions.SortColumnIndex = -1;
			this.listShootPositions.TabIndex = 1;
			this.listShootPositions.UseCompatibleStateImageBehavior = false;
			this.listShootPositions.View = System.Windows.Forms.View.Details;
			// 
			// columnIndex
			// 
			this.columnIndex.Text = "索引";
			this.columnIndex.Width = 40;
			// 
			// columnX
			// 
			this.columnX.Text = "横坐标";
			this.columnX.Width = 50;
			// 
			// columnY
			// 
			this.columnY.Text = "纵坐标";
			this.columnY.Width = 50;
			// 
			// tToolBar1
			// 
			this.tToolBar1.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.tToolBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.tToolBar1.GripMargin = new System.Windows.Forms.Padding(0);
			this.tToolBar1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tToolBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnRemove,
            this.toolStripSeparator1,
            this.btnUp,
            this.btnDown,
            this.btnLeft,
            this.btnRight});
			this.tToolBar1.Location = new System.Drawing.Point(2, 24);
			this.tToolBar1.Name = "tToolBar1";
			this.tToolBar1.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.tToolBar1.Size = new System.Drawing.Size(170, 27);
			this.tToolBar1.TabIndex = 0;
			this.tToolBar1.Text = "tToolBar1";
			// 
			// btnAdd
			// 
			this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
			this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(23, 20);
			this.btnAdd.Text = "toolStripButton1";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
			this.btnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(23, 20);
			this.btnRemove.Text = "toolStripButton2";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
			// 
			// btnUp
			// 
			this.btnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
			this.btnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(23, 20);
			this.btnUp.Text = "toolStripButton3";
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// btnDown
			// 
			this.btnDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
			this.btnDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(23, 20);
			this.btnDown.Text = "toolStripButton4";
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// btnLeft
			// 
			this.btnLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnLeft.Image")));
			this.btnLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnLeft.Name = "btnLeft";
			this.btnLeft.Size = new System.Drawing.Size(23, 20);
			this.btnLeft.Text = "toolStripButton5";
			this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
			// 
			// btnRight
			// 
			this.btnRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnRight.Image = ((System.Drawing.Image)(resources.GetObject("btnRight.Image")));
			this.btnRight.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRight.Name = "btnRight";
			this.btnRight.Size = new System.Drawing.Size(23, 20);
			this.btnRight.Text = "toolStripButton6";
			this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
			// 
			// DialogShootPosition
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(174, 218);
			this.Controls.Add(this.tPanel1);
			this.DoubleBuffered = true;
			this.MinimumSize = new System.Drawing.Size(190, 250);
			this.Name = "DialogShootPosition";
			this.Text = "枪口设定";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DialogShootPosition_FormClosing);
			this.tPanel1.ResumeLayout(false);
			this.tPanel1.PerformLayout();
			this.tToolBar1.ResumeLayout(false);
			this.tToolBar1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private THOR.Windows.UI.Components.TPanel tPanel1;
		private THOR.Windows.UI.Components.TToolBar tToolBar1;
		private System.Windows.Forms.ToolStripButton btnAdd;
		private System.Windows.Forms.ToolStripButton btnRemove;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnUp;
		private System.Windows.Forms.ToolStripButton btnDown;
		private System.Windows.Forms.ToolStripButton btnLeft;
		private System.Windows.Forms.ToolStripButton btnRight;
		private THOR.Windows.UI.Components.TListView listShootPositions;
		private System.Windows.Forms.ColumnHeader columnIndex;
		private System.Windows.Forms.ColumnHeader columnX;
		private System.Windows.Forms.ColumnHeader columnY;
	}
}
