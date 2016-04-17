namespace THOR.ConsoleGUI.Components
{
	partial class ConsoleOutput
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
			this.txtOutput = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// txtOutput
			// 
			this.txtOutput.BackColor = System.Drawing.Color.White;
			this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtOutput.ForeColor = System.Drawing.Color.Black;
			this.txtOutput.HideSelection = false;
			this.txtOutput.Location = new System.Drawing.Point(0, 0);
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ReadOnly = true;
			this.txtOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.txtOutput.Size = new System.Drawing.Size(150, 150);
			this.txtOutput.TabIndex = 0;
			this.txtOutput.TabStop = false;
			this.txtOutput.Text = "OUTPUT";
			// 
			// ConsoleOutput
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add(this.txtOutput);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.Name = "ConsoleOutput";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox txtOutput;
	}
}
