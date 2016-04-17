namespace TexturePackerExport
{
	partial class FrmMain
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
			this.lblTextureFile = new THOR.Windows.Components.Common.ThorLabel();
			this.txtTextureFile = new THOR.Windows.Components.Fields.ThorTextField();
			this.txtPListFile = new THOR.Windows.Components.Fields.ThorTextField();
			this.thorLabel2 = new THOR.Windows.Components.Common.ThorLabel();
			this.btnExport = new THOR.Windows.Components.Common.ThorButton();
			this.btnBrowseTextureFile = new THOR.Windows.Components.Common.ThorFlatButton();
			this.btnBrowsePListFile = new THOR.Windows.Components.Common.ThorFlatButton();
			this.SuspendLayout();
			// 
			// lblTextureFile
			// 
			this.lblTextureFile.AutoSize = true;
			this.lblTextureFile.BackColor = System.Drawing.Color.Transparent;
			this.lblTextureFile.Location = new System.Drawing.Point(16, 41);
			this.lblTextureFile.Name = "lblTextureFile";
			this.lblTextureFile.Size = new System.Drawing.Size(55, 13);
			this.lblTextureFile.TabIndex = 0;
			this.lblTextureFile.Text = "Texture:";
			this.lblTextureFile.Visible = false;
			// 
			// txtTextureFile
			// 
			this.txtTextureFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txtTextureFile.Location = new System.Drawing.Point(105, 35);
			this.txtTextureFile.Name = "txtTextureFile";
			this.txtTextureFile.Padding = new System.Windows.Forms.Padding(1);
			this.txtTextureFile.Size = new System.Drawing.Size(370, 24);
			this.txtTextureFile.TabIndex = 1;
			this.txtTextureFile.TabStop = false;
			this.txtTextureFile.Text = "thorTextField1";
			this.txtTextureFile.Visible = false;
			// 
			// txtPListFile
			// 
			this.txtPListFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txtPListFile.Location = new System.Drawing.Point(105, 70);
			this.txtPListFile.Name = "txtPListFile";
			this.txtPListFile.Padding = new System.Windows.Forms.Padding(1);
			this.txtPListFile.Size = new System.Drawing.Size(370, 24);
			this.txtPListFile.TabIndex = 2;
			this.txtPListFile.TabStop = false;
			this.txtPListFile.Text = "thorTextField2";
			// 
			// thorLabel2
			// 
			this.thorLabel2.AutoSize = true;
			this.thorLabel2.BackColor = System.Drawing.Color.Transparent;
			this.thorLabel2.Location = new System.Drawing.Point(16, 76);
			this.thorLabel2.Name = "thorLabel2";
			this.thorLabel2.Size = new System.Drawing.Size(43, 13);
			this.thorLabel2.TabIndex = 3;
			this.thorLabel2.Text = "PList:";
			// 
			// btnExport
			// 
			this.btnExport.Location = new System.Drawing.Point(222, 111);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(80, 30);
			this.btnExport.TabIndex = 4;
			this.btnExport.Text = "Export";
			this.btnExport.UseVisualStyleBackColor = false;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// btnBrowseTextureFile
			// 
			this.btnBrowseTextureFile.Location = new System.Drawing.Point(481, 37);
			this.btnBrowseTextureFile.Name = "btnBrowseTextureFile";
			this.btnBrowseTextureFile.Size = new System.Drawing.Size(22, 22);
			this.btnBrowseTextureFile.TabIndex = 5;
			this.btnBrowseTextureFile.TabStop = false;
			this.btnBrowseTextureFile.Text = "thorFlatButton1";
			this.btnBrowseTextureFile.UseVisualStyleBackColor = false;
			this.btnBrowseTextureFile.Visible = false;
			this.btnBrowseTextureFile.Click += new System.EventHandler(this.btnBrowseTextureFile_Click);
			// 
			// btnBrowsePListFile
			// 
			this.btnBrowsePListFile.Location = new System.Drawing.Point(481, 72);
			this.btnBrowsePListFile.Name = "btnBrowsePListFile";
			this.btnBrowsePListFile.Size = new System.Drawing.Size(22, 22);
			this.btnBrowsePListFile.TabIndex = 6;
			this.btnBrowsePListFile.TabStop = false;
			this.btnBrowsePListFile.Text = "thorFlatButton2";
			this.btnBrowsePListFile.UseVisualStyleBackColor = false;
			this.btnBrowsePListFile.Click += new System.EventHandler(this.btnBrowsePListFile_Click);
			// 
			// FrmMain
			// 
			this.ClientSize = new System.Drawing.Size(526, 156);
			this.Controls.Add(this.btnBrowsePListFile);
			this.Controls.Add(this.btnBrowseTextureFile);
			this.Controls.Add(this.btnExport);
			this.Controls.Add(this.thorLabel2);
			this.Controls.Add(this.txtPListFile);
			this.Controls.Add(this.txtTextureFile);
			this.Controls.Add(this.lblTextureFile);
			this.Location = new System.Drawing.Point(0, 0);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmMain";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private THOR.Windows.Components.Common.ThorLabel lblTextureFile;
		private THOR.Windows.Components.Fields.ThorTextField txtTextureFile;
		private THOR.Windows.Components.Fields.ThorTextField txtPListFile;
		private THOR.Windows.Components.Common.ThorLabel thorLabel2;
		private THOR.Windows.Components.Common.ThorButton btnExport;
		private THOR.Windows.Components.Common.ThorFlatButton btnBrowseTextureFile;
		private THOR.Windows.Components.Common.ThorFlatButton btnBrowsePListFile;
	}
}
