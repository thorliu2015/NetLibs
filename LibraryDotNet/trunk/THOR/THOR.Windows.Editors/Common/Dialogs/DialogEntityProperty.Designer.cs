namespace THOR.Windows.Editors.Common.Dialogs
{
	partial class DialogEntityProperty
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
			this.lblID = new THOR.Windows.Components.Common.ThorLabel();
			this.txtID = new THOR.Windows.Components.Fields.ThorTextField();
			this.txtName = new THOR.Windows.Components.Fields.ThorTextField();
			this.lblName = new THOR.Windows.Components.Common.ThorLabel();
			this.txtPrefix = new THOR.Windows.Components.Fields.ThorTextField();
			this.lblPrefix = new THOR.Windows.Components.Common.ThorLabel();
			this.txtSuffix = new THOR.Windows.Components.Fields.ThorTextField();
			this.lblSuffix = new THOR.Windows.Components.Common.ThorLabel();
			this.txtCategory = new THOR.Windows.Components.Fields.ThorTextField();
			this.lblCategory = new THOR.Windows.Components.Common.ThorLabel();
			this.txtDescription = new THOR.Windows.Components.Fields.ThorTextField();
			this.lblDescription = new THOR.Windows.Components.Common.ThorLabel();
			this.boxContent.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(245, 5);
			// 
			// boxContent
			// 
			this.boxContent.Controls.Add(this.txtDescription);
			this.boxContent.Controls.Add(this.lblDescription);
			this.boxContent.Controls.Add(this.txtCategory);
			this.boxContent.Controls.Add(this.lblCategory);
			this.boxContent.Controls.Add(this.txtSuffix);
			this.boxContent.Controls.Add(this.lblSuffix);
			this.boxContent.Controls.Add(this.txtPrefix);
			this.boxContent.Controls.Add(this.lblPrefix);
			this.boxContent.Controls.Add(this.txtName);
			this.boxContent.Controls.Add(this.lblName);
			this.boxContent.Controls.Add(this.txtID);
			this.boxContent.Controls.Add(this.lblID);
			this.boxContent.Size = new System.Drawing.Size(394, 195);
			// 
			// lblID
			// 
			this.lblID.BackColor = System.Drawing.Color.Transparent;
			this.lblID.Location = new System.Drawing.Point(12, 3);
			this.lblID.Name = "lblID";
			this.lblID.Size = new System.Drawing.Size(57, 24);
			this.lblID.TabIndex = 0;
			this.lblID.Text = "ID:";
			this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtID
			// 
			this.txtID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txtID.Location = new System.Drawing.Point(75, 3);
			this.txtID.Name = "txtID";
			this.txtID.Padding = new System.Windows.Forms.Padding(1);
			this.txtID.Size = new System.Drawing.Size(150, 24);
			this.txtID.TabIndex = 1;
			this.txtID.TabStop = false;
			this.txtID.Text = "thorTextField1";
			// 
			// txtName
			// 
			this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txtName.Location = new System.Drawing.Point(75, 33);
			this.txtName.Name = "txtName";
			this.txtName.Padding = new System.Windows.Forms.Padding(1);
			this.txtName.Size = new System.Drawing.Size(250, 24);
			this.txtName.TabIndex = 3;
			this.txtName.TabStop = false;
			this.txtName.Text = "thorTextField2";
			// 
			// lblName
			// 
			this.lblName.BackColor = System.Drawing.Color.Transparent;
			this.lblName.Location = new System.Drawing.Point(12, 33);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(57, 24);
			this.lblName.TabIndex = 2;
			this.lblName.Text = "NAME:";
			this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPrefix
			// 
			this.txtPrefix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txtPrefix.Location = new System.Drawing.Point(75, 63);
			this.txtPrefix.Name = "txtPrefix";
			this.txtPrefix.Padding = new System.Windows.Forms.Padding(1);
			this.txtPrefix.Size = new System.Drawing.Size(150, 24);
			this.txtPrefix.TabIndex = 5;
			this.txtPrefix.TabStop = false;
			this.txtPrefix.Text = "thorTextField3";
			// 
			// lblPrefix
			// 
			this.lblPrefix.BackColor = System.Drawing.Color.Transparent;
			this.lblPrefix.Location = new System.Drawing.Point(12, 63);
			this.lblPrefix.Name = "lblPrefix";
			this.lblPrefix.Size = new System.Drawing.Size(57, 24);
			this.lblPrefix.TabIndex = 4;
			this.lblPrefix.Text = "PREFIX:";
			this.lblPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtSuffix
			// 
			this.txtSuffix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txtSuffix.Location = new System.Drawing.Point(75, 93);
			this.txtSuffix.Name = "txtSuffix";
			this.txtSuffix.Padding = new System.Windows.Forms.Padding(1);
			this.txtSuffix.Size = new System.Drawing.Size(150, 24);
			this.txtSuffix.TabIndex = 7;
			this.txtSuffix.TabStop = false;
			this.txtSuffix.Text = "thorTextField4";
			// 
			// lblSuffix
			// 
			this.lblSuffix.BackColor = System.Drawing.Color.Transparent;
			this.lblSuffix.Location = new System.Drawing.Point(12, 93);
			this.lblSuffix.Name = "lblSuffix";
			this.lblSuffix.Size = new System.Drawing.Size(57, 24);
			this.lblSuffix.TabIndex = 6;
			this.lblSuffix.Text = "SUFFIX:";
			this.lblSuffix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCategory
			// 
			this.txtCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txtCategory.Location = new System.Drawing.Point(75, 123);
			this.txtCategory.Name = "txtCategory";
			this.txtCategory.Padding = new System.Windows.Forms.Padding(1);
			this.txtCategory.Size = new System.Drawing.Size(250, 24);
			this.txtCategory.TabIndex = 9;
			this.txtCategory.TabStop = false;
			this.txtCategory.Text = "thorTextField5";
			// 
			// lblCategory
			// 
			this.lblCategory.BackColor = System.Drawing.Color.Transparent;
			this.lblCategory.Location = new System.Drawing.Point(12, 123);
			this.lblCategory.Name = "lblCategory";
			this.lblCategory.Size = new System.Drawing.Size(57, 24);
			this.lblCategory.TabIndex = 8;
			this.lblCategory.Text = "CATE:";
			this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDescription
			// 
			this.txtDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txtDescription.Location = new System.Drawing.Point(75, 153);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Padding = new System.Windows.Forms.Padding(1);
			this.txtDescription.Size = new System.Drawing.Size(300, 24);
			this.txtDescription.TabIndex = 11;
			this.txtDescription.TabStop = false;
			this.txtDescription.Text = "thorTextField6";
			// 
			// lblDescription
			// 
			this.lblDescription.BackColor = System.Drawing.Color.Transparent;
			this.lblDescription.Location = new System.Drawing.Point(12, 153);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(57, 24);
			this.lblDescription.TabIndex = 10;
			this.lblDescription.Text = "DESC:";
			this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DialogEntityProperty
			// 
			this.ClientSize = new System.Drawing.Size(400, 265);
			this.Name = "DialogEntityProperty";
			this.boxContent.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Windows.Components.Fields.ThorTextField txtID;
		private Windows.Components.Common.ThorLabel lblID;
		private Windows.Components.Fields.ThorTextField txtCategory;
		private Windows.Components.Common.ThorLabel lblCategory;
		private Windows.Components.Fields.ThorTextField txtSuffix;
		private Windows.Components.Common.ThorLabel lblSuffix;
		private Windows.Components.Fields.ThorTextField txtPrefix;
		private Windows.Components.Common.ThorLabel lblPrefix;
		private Windows.Components.Fields.ThorTextField txtName;
		private Windows.Components.Common.ThorLabel lblName;
		private Windows.Components.Fields.ThorTextField txtDescription;
		private Windows.Components.Common.ThorLabel lblDescription;
	}
}
