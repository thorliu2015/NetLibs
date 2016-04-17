namespace Solar.Components
{
	partial class ImageView
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
			this.tContextMenu1 = new THOR.Windows.UI.Components.TContextMenu();
			this.btnStyleLight = new System.Windows.Forms.ToolStripMenuItem();
			this.btnStyleDark = new System.Windows.Forms.ToolStripMenuItem();
			this.tContextMenu1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tContextMenu1
			// 
			this.tContextMenu1.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.tContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStyleLight,
            this.btnStyleDark});
			this.tContextMenu1.Name = "tContextMenu1";
			this.tContextMenu1.Size = new System.Drawing.Size(141, 48);
			// 
			// btnStyleLight
			// 
			this.btnStyleLight.Checked = true;
			this.btnStyleLight.CheckState = System.Windows.Forms.CheckState.Checked;
			this.btnStyleLight.Name = "btnStyleLight";
			this.btnStyleLight.Size = new System.Drawing.Size(140, 22);
			this.btnStyleLight.Text = "浅色背景(&L)";
			this.btnStyleLight.Click += new System.EventHandler(this.btnStyleLight_Click);
			// 
			// btnStyleDark
			// 
			this.btnStyleDark.Name = "btnStyleDark";
			this.btnStyleDark.Size = new System.Drawing.Size(140, 22);
			this.btnStyleDark.Text = "深色背景(&D)";
			this.btnStyleDark.Click += new System.EventHandler(this.btnStyleDark_Click);
			// 
			// ImageView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ContextMenuStrip = this.tContextMenu1;
			this.DoubleBuffered = true;
			this.Name = "ImageView";
			this.tContextMenu1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private THOR.Windows.UI.Components.TContextMenu tContextMenu1;
		private System.Windows.Forms.ToolStripMenuItem btnStyleLight;
		private System.Windows.Forms.ToolStripMenuItem btnStyleDark;
	}
}
