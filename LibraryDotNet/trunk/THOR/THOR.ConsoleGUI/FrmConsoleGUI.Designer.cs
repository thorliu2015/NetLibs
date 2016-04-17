namespace THOR.ConsoleGUI
{
	partial class FrmConsoleGUI
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.consoleInput1 = new THOR.ConsoleGUI.Components.ConsoleInput();
			this.consoleOutput1 = new THOR.ConsoleGUI.Components.ConsoleOutput();
			this.SuspendLayout();
			// 
			// consoleInput1
			// 
			this.consoleInput1.BackColor = System.Drawing.Color.Black;
			this.consoleInput1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.consoleInput1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.consoleInput1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.consoleInput1.Location = new System.Drawing.Point(0, 241);
			this.consoleInput1.Name = "consoleInput1";
			this.consoleInput1.Size = new System.Drawing.Size(284, 24);
			this.consoleInput1.TabIndex = 0;
			// 
			// consoleOutput1
			// 
			this.consoleOutput1.BackColor = System.Drawing.Color.Black;
			this.consoleOutput1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.consoleOutput1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.consoleOutput1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.consoleOutput1.Location = new System.Drawing.Point(0, 0);
			this.consoleOutput1.Name = "consoleOutput1";
			this.consoleOutput1.Size = new System.Drawing.Size(284, 265);
			this.consoleOutput1.TabIndex = 1;
			this.consoleOutput1.TabStop = false;
			// 
			// FrmConsoleGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(284, 265);
			this.Controls.Add(this.consoleInput1);
			this.Controls.Add(this.consoleOutput1);
			this.DoubleBuffered = true;
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.Name = "FrmConsoleGUI";
			this.Text = "FrmConsoleGUI";
			this.ResumeLayout(false);

		}

		#endregion

		private Components.ConsoleOutput consoleOutput1;
		private Components.ConsoleInput consoleInput1;
	}
}