namespace Solar.Dialogs
{
	partial class DialogModelProperty
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
			this.txtId = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtSuffix = new System.Windows.Forms.TextBox();
			this.txtCategory = new System.Windows.Forms.TextBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.panelMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelMain
			// 
			this.panelMain.Controls.Add(this.label5);
			this.panelMain.Controls.Add(this.label4);
			this.panelMain.Controls.Add(this.label3);
			this.panelMain.Controls.Add(this.label2);
			this.panelMain.Controls.Add(this.label1);
			this.panelMain.Controls.Add(this.txtDescription);
			this.panelMain.Controls.Add(this.txtCategory);
			this.panelMain.Controls.Add(this.txtSuffix);
			this.panelMain.Controls.Add(this.txtName);
			this.panelMain.Controls.Add(this.txtId);
			this.panelMain.Size = new System.Drawing.Size(433, 234);
			// 
			// txtId
			// 
			this.txtId.Location = new System.Drawing.Point(82, 12);
			this.txtId.Name = "txtId";
			this.txtId.Size = new System.Drawing.Size(157, 20);
			this.txtId.TabIndex = 0;
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(82, 38);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(237, 20);
			this.txtName.TabIndex = 1;
			// 
			// txtSuffix
			// 
			this.txtSuffix.Location = new System.Drawing.Point(82, 64);
			this.txtSuffix.Name = "txtSuffix";
			this.txtSuffix.Size = new System.Drawing.Size(100, 20);
			this.txtSuffix.TabIndex = 2;
			// 
			// txtCategory
			// 
			this.txtCategory.Location = new System.Drawing.Point(82, 90);
			this.txtCategory.Name = "txtCategory";
			this.txtCategory.Size = new System.Drawing.Size(339, 20);
			this.txtCategory.TabIndex = 3;
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(82, 116);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescription.Size = new System.Drawing.Size(339, 106);
			this.txtDescription.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(25, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "ID:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "名称:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "后缀:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 93);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "分类:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 119);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(37, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "备注:";
			// 
			// DialogModelProperty
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(433, 267);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "DialogModelProperty";
			this.panelMain.ResumeLayout(false);
			this.panelMain.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.TextBox txtCategory;
		private System.Windows.Forms.TextBox txtSuffix;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtId;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}
