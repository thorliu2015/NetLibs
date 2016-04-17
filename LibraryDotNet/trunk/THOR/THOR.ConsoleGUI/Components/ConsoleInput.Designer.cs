namespace THOR.ConsoleGUI.Components
{
	partial class ConsoleInput
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
			this.txtInput = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtInput
			// 
			this.txtInput.AcceptsReturn = true;
			this.txtInput.AcceptsTab = true;
			this.txtInput.BackColor = System.Drawing.Color.Gainsboro;
			this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtInput.ForeColor = System.Drawing.Color.Green;
			this.txtInput.HideSelection = false;
			this.txtInput.Location = new System.Drawing.Point(0, 0);
			this.txtInput.Name = "txtInput";
			this.txtInput.Size = new System.Drawing.Size(100, 13);
			this.txtInput.TabIndex = 0;
			this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
			this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
			this.txtInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInput_KeyPress);
			// 
			// ConsoleInput
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.Controls.Add(this.txtInput);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.Name = "ConsoleInput";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtInput;
	}
}
