namespace THOR.Windows.Dialogs
{
	partial class FlatDialog
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
			this.boxButtons = new THOR.Windows.Components.Common.ThorBox();
			this.boxContent = new THOR.Windows.Components.Common.ThorBox();
			this.SuspendLayout();
			// 
			// boxButtons
			// 
			this.boxButtons.BackColor = System.Drawing.Color.Transparent;
			this.boxButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.boxButtons.Location = new System.Drawing.Point(3, 222);
			this.boxButtons.Name = "boxButtons";
			this.boxButtons.Size = new System.Drawing.Size(278, 40);
			this.boxButtons.TabIndex = 0;
			// 
			// boxContent
			// 
			this.boxContent.BackColor = System.Drawing.Color.Transparent;
			this.boxContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.boxContent.Location = new System.Drawing.Point(3, 27);
			this.boxContent.Name = "boxContent";
			this.boxContent.Size = new System.Drawing.Size(278, 195);
			this.boxContent.TabIndex = 1;
			// 
			// FlatDialog
			// 
			this.ClientSize = new System.Drawing.Size(284, 265);
			this.Controls.Add(this.boxContent);
			this.Controls.Add(this.boxButtons);
			this.Location = new System.Drawing.Point(0, 0);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FlatDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FlatDialog";
			this.ResumeLayout(false);

		}

		#endregion

		private Components.Common.ThorBox boxButtons;
		protected Components.Common.ThorBox boxContent;

	}
}
