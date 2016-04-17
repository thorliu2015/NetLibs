namespace THOR.Windows.Dialogs
{
	partial class FlatSplash
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlatSplash));
			this.lblProductName = new System.Windows.Forms.Label();
			this.lblProductCopyright = new System.Windows.Forms.Label();
			this.lblProgressInfo = new System.Windows.Forms.Label();
			this.lblProgressDetail = new System.Windows.Forms.Label();
			this.lblProgressValue = new System.Windows.Forms.Label();
			this.lblProductVersion = new System.Windows.Forms.Label();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.picLoadingAni = new System.Windows.Forms.PictureBox();
			this.timerLoadingAni = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.picLoadingAni)).BeginInit();
			this.SuspendLayout();
			// 
			// lblProductName
			// 
			this.lblProductName.AutoSize = true;
			this.lblProductName.BackColor = System.Drawing.Color.Transparent;
			this.lblProductName.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lblProductName.Location = new System.Drawing.Point(24, 27);
			this.lblProductName.Name = "lblProductName";
			this.lblProductName.Size = new System.Drawing.Size(232, 32);
			this.lblProductName.TabIndex = 0;
			this.lblProductName.Text = "${ProductName}";
			// 
			// lblProductCopyright
			// 
			this.lblProductCopyright.AutoSize = true;
			this.lblProductCopyright.BackColor = System.Drawing.Color.Transparent;
			this.lblProductCopyright.ForeColor = System.Drawing.Color.Silver;
			this.lblProductCopyright.Location = new System.Drawing.Point(24, 338);
			this.lblProductCopyright.Name = "lblProductCopyright";
			this.lblProductCopyright.Size = new System.Drawing.Size(121, 13);
			this.lblProductCopyright.TabIndex = 1;
			this.lblProductCopyright.Text = "${ProductCopyright}";
			// 
			// lblProgressInfo
			// 
			this.lblProgressInfo.AutoSize = true;
			this.lblProgressInfo.BackColor = System.Drawing.Color.Transparent;
			this.lblProgressInfo.ForeColor = System.Drawing.Color.Silver;
			this.lblProgressInfo.Location = new System.Drawing.Point(154, 241);
			this.lblProgressInfo.Name = "lblProgressInfo";
			this.lblProgressInfo.Size = new System.Drawing.Size(97, 13);
			this.lblProgressInfo.TabIndex = 2;
			this.lblProgressInfo.Text = "${ProgressInfo}";
			// 
			// lblProgressDetail
			// 
			this.lblProgressDetail.AutoSize = true;
			this.lblProgressDetail.BackColor = System.Drawing.Color.Transparent;
			this.lblProgressDetail.ForeColor = System.Drawing.Color.Silver;
			this.lblProgressDetail.Location = new System.Drawing.Point(154, 266);
			this.lblProgressDetail.Name = "lblProgressDetail";
			this.lblProgressDetail.Size = new System.Drawing.Size(109, 13);
			this.lblProgressDetail.TabIndex = 3;
			this.lblProgressDetail.Text = "${ProgressDetail}";
			// 
			// lblProgressValue
			// 
			this.lblProgressValue.BackColor = System.Drawing.Color.Transparent;
			this.lblProgressValue.ForeColor = System.Drawing.Color.White;
			this.lblProgressValue.Location = new System.Drawing.Point(49, 241);
			this.lblProgressValue.Name = "lblProgressValue";
			this.lblProgressValue.Size = new System.Drawing.Size(25, 13);
			this.lblProgressValue.TabIndex = 4;
			this.lblProgressValue.Text = "100";
			this.lblProgressValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblProgressValue.Visible = false;
			// 
			// lblProductVersion
			// 
			this.lblProductVersion.AutoSize = true;
			this.lblProductVersion.BackColor = System.Drawing.Color.Transparent;
			this.lblProductVersion.ForeColor = System.Drawing.Color.Silver;
			this.lblProductVersion.Location = new System.Drawing.Point(33, 70);
			this.lblProductVersion.Name = "lblProductVersion";
			this.lblProductVersion.Size = new System.Drawing.Size(109, 13);
			this.lblProductVersion.TabIndex = 5;
			this.lblProductVersion.Text = "${ProductVersion}";
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Spinner Frame 1-100.png");
			this.imageList.Images.SetKeyName(1, "Spinner Frame 2-100.png");
			this.imageList.Images.SetKeyName(2, "Spinner Frame 3-100.png");
			this.imageList.Images.SetKeyName(3, "Spinner Frame 4-100.png");
			this.imageList.Images.SetKeyName(4, "Spinner Frame 5-100.png");
			this.imageList.Images.SetKeyName(5, "Spinner Frame 6-100.png");
			this.imageList.Images.SetKeyName(6, "Spinner Frame 7-100.png");
			this.imageList.Images.SetKeyName(7, "Spinner Frame 8-100.png");
			// 
			// picLoadingAni
			// 
			this.picLoadingAni.BackColor = System.Drawing.Color.Transparent;
			this.picLoadingAni.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.picLoadingAni.Location = new System.Drawing.Point(36, 221);
			this.picLoadingAni.Name = "picLoadingAni";
			this.picLoadingAni.Size = new System.Drawing.Size(100, 100);
			this.picLoadingAni.TabIndex = 6;
			this.picLoadingAni.TabStop = false;
			this.picLoadingAni.Visible = false;
			// 
			// timerLoadingAni
			// 
			this.timerLoadingAni.Tick += new System.EventHandler(this.timerLoadingAni_Tick);
			// 
			// FlatSplash
			// 
			this.ClientSize = new System.Drawing.Size(600, 375);
			this.Controls.Add(this.lblProgressValue);
			this.Controls.Add(this.picLoadingAni);
			this.Controls.Add(this.lblProductVersion);
			this.Controls.Add(this.lblProgressDetail);
			this.Controls.Add(this.lblProgressInfo);
			this.Controls.Add(this.lblProductCopyright);
			this.Controls.Add(this.lblProductName);
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "FlatSplash";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			((System.ComponentModel.ISupportInitialize)(this.picLoadingAni)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblProductName;
		private System.Windows.Forms.Label lblProductCopyright;
		private System.Windows.Forms.Label lblProgressInfo;
		private System.Windows.Forms.Label lblProgressDetail;
		private System.Windows.Forms.Label lblProgressValue;
		private System.Windows.Forms.Label lblProductVersion;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.PictureBox picLoadingAni;
		private System.Windows.Forms.Timer timerLoadingAni;
	}
}
