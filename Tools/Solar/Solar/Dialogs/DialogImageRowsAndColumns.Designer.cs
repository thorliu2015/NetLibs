namespace Solar.Dialogs
{
	partial class DialogImageRowsAndColumns
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
			this.numRows = new System.Windows.Forms.NumericUpDown();
			this.numColumns = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panelMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numRows)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numColumns)).BeginInit();
			this.SuspendLayout();
			// 
			// panelMain
			// 
			this.panelMain.Controls.Add(this.label2);
			this.panelMain.Controls.Add(this.label1);
			this.panelMain.Controls.Add(this.numColumns);
			this.panelMain.Controls.Add(this.numRows);
			this.panelMain.Size = new System.Drawing.Size(199, 88);
			// 
			// numRows
			// 
			this.numRows.Location = new System.Drawing.Point(63, 22);
			this.numRows.Name = "numRows";
			this.numRows.Size = new System.Drawing.Size(120, 20);
			this.numRows.TabIndex = 0;
			// 
			// numColumns
			// 
			this.numColumns.Location = new System.Drawing.Point(63, 48);
			this.numColumns.Name = "numColumns";
			this.numColumns.Size = new System.Drawing.Size(120, 20);
			this.numColumns.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "行数:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "列数:";
			// 
			// DialogImageRowsAndColumns
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(199, 126);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "DialogImageRowsAndColumns";
			this.Text = "网格设定";
			this.panelMain.ResumeLayout(false);
			this.panelMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numRows)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numColumns)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numColumns;
		private System.Windows.Forms.NumericUpDown numRows;
	}
}
