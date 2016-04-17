namespace Test
{
	partial class FormMain
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.thorMainMenu1 = new THOR.Windows.Components.Tools.ThorMainMenu();
			this.menuDemos = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.thorMainMenu1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.propertyGrid1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(581, 51);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 511);
			this.panel1.TabIndex = 0;
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.propertyGrid1.CanShowVisualStyleGlyphs = false;
			this.propertyGrid1.CategoryForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.propertyGrid1.CategorySplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.propertyGrid1.CommandsBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.propertyGrid1.CommandsDisabledLinkColor = System.Drawing.Color.Silver;
			this.propertyGrid1.CommandsForeColor = System.Drawing.Color.Silver;
			this.propertyGrid1.CommandsLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.propertyGrid1.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid1.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.propertyGrid1.HelpBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.propertyGrid1.HelpForeColor = System.Drawing.Color.Gray;
			this.propertyGrid1.LineColor = System.Drawing.Color.Gray;
			this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.SelectedItemWithFocusForeColor = System.Drawing.Color.Silver;
			this.propertyGrid1.Size = new System.Drawing.Size(200, 511);
			this.propertyGrid1.TabIndex = 0;
			this.propertyGrid1.ToolbarVisible = false;
			this.propertyGrid1.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.propertyGrid1.ViewBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.propertyGrid1.ViewForeColor = System.Drawing.Color.Gray;
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter1.Location = new System.Drawing.Point(578, 51);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 511);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Transparent;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 51);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(5);
			this.panel2.Size = new System.Drawing.Size(575, 511);
			this.panel2.TabIndex = 2;
			// 
			// menuItem1
			// 
			this.menuItem1.Index = -1;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2});
			this.menuItem1.Text = "&File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "&Open";
			// 
			// thorMainMenu1
			// 
			this.thorMainMenu1.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.thorMainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDemos});
			this.thorMainMenu1.Location = new System.Drawing.Point(3, 27);
			this.thorMainMenu1.Name = "thorMainMenu1";
			this.thorMainMenu1.Size = new System.Drawing.Size(778, 24);
			this.thorMainMenu1.TabIndex = 3;
			this.thorMainMenu1.Text = "thorMainMenu1";
			// 
			// menuDemos
			// 
			this.menuDemos.Name = "menuDemos";
			this.menuDemos.Size = new System.Drawing.Size(49, 20);
			this.menuDemos.Text = "&Demos";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 565);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.thorMainMenu1);
			this.Location = new System.Drawing.Point(0, 0);
			this.MainMenuStrip = this.thorMainMenu1;
			this.Name = "FormMain";
			this.Text = "Form1";
			this.panel1.ResumeLayout(false);
			this.thorMainMenu1.ResumeLayout(false);
			this.thorMainMenu1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		public System.Windows.Forms.PropertyGrid propertyGrid1;
		public System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private THOR.Windows.Components.Tools.ThorMainMenu thorMainMenu1;
		private System.Windows.Forms.ToolStripMenuItem menuDemos;
	}
}

