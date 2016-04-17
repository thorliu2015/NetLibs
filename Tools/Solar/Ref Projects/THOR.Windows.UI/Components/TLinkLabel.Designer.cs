namespace THOR.Windows.UI.Components
{
	partial class TLinkLabel
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.linkLabel = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// linkLabel
			// 
			this.linkLabel.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.linkLabel.Location = new System.Drawing.Point(22, 0);
			this.linkLabel.Name = "linkLabel";
			this.linkLabel.Size = new System.Drawing.Size(78, 24);
			this.linkLabel.TabIndex = 0;
			this.linkLabel.TabStop = true;
			this.linkLabel.Text = "link";
			this.linkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TLinkLabel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.linkLabel);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Name = "TLinkLabel";
			this.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
			this.Size = new System.Drawing.Size(100, 24);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.LinkLabel linkLabel;

	}
}
