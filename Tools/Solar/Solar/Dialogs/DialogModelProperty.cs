using Solar.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Solar.Dialogs
{
	/// <summary>
	/// 模型属性对话框的操作类型
	/// </summary>
	public enum DialogModelPropertyAction
	{
		Add,
		Modify,
		Clone
	}


	/// <summary>
	/// 模型属性对话框
	/// </summary>
	public partial class DialogModelProperty : THOR.Windows.UI.Forms.DialogBase
	{
		/// <summary>
		/// 构造
		/// </summary>
		public DialogModelProperty()
		{
			InitializeComponent();
			SelectedModel = null;
			SelectedCategory = "";
		}

		/// <summary>
		/// 加载对话框时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			switch (SelectedAction)
			{
					//添加
				case DialogModelPropertyAction.Add:
					SelectedModel = (SModel)System.Activator.CreateInstance(SelectedModelType);
					txtCategory.Text = SelectedCategory;
					Text = "添加";
					SelectedModel.ChangeType = DataChangeTypes.DataChanged | DataChangeTypes.FileChanged;
					break;


					//修改
				case DialogModelPropertyAction.Modify:
					Text = "修改";
					txtId.Text = SelectedModel.Id;
					txtName.Text = SelectedModel.EditorName;
					txtSuffix.Text = SelectedModel.EditorSuffix;
					txtDescription.Text = SelectedModel.EditorDescription;
					txtCategory.Text = SelectedModel.EditorCategory;
					break;


					//克隆
				case DialogModelPropertyAction.Clone:
					Text = "克隆";
					SelectedModel = SelectedModel.Clone();
					SelectedModel.Id = "";
					txtId.Text = SelectedModel.Id;
					txtName.Text = SelectedModel.EditorName;
					txtSuffix.Text = SelectedModel.EditorSuffix;
					txtDescription.Text = SelectedModel.EditorDescription;
					txtCategory.Text = SelectedModel.EditorCategory;
					SelectedModel.ChangeType = DataChangeTypes.DataChanged | DataChangeTypes.FileChanged;
					break;
			}

		}


		/// <summary>
		/// 点击确定按钮时
		/// </summary>
		/// <returns></returns>
		protected override bool OnButtonOKClick()
		{
			if (!SModelManager.Current.VerifyId(txtId.Text.Trim()))
			{
				MessageBox.Show("Id命名不符合标准, 请使用英文, 数字, 下划线, 并且首字符必须是英文或者数字 !", "无效输入", MessageBoxButtons.OK, MessageBoxIcon.Warning);

				txtId.SelectAll();
				txtId.Focus();
				return false;
			}


			SelectedModel.EditorName = txtName.Text.Trim();
			SelectedModel.EditorDescription = txtDescription.Text.Trim();
			SelectedModel.EditorCategory = txtCategory.Text.Trim();
			SelectedModel.EditorSuffix = txtSuffix.Text.Trim();

			try
			{
				if (SelectedAction == DialogModelPropertyAction.Modify && SelectedModel.Id != txtId.Text.Trim())
				{
					SModelManager.Current.Rename(SelectedModel, txtId.Text.Trim());
				}
				else
				{
					SelectedModel.Id = txtId.Text.Trim();
				}

				if (SelectedAction == DialogModelPropertyAction.Add)
				{
					SModelManager.Current.Add(SelectedModel);
				}
				else if (SelectedAction == DialogModelPropertyAction.Clone)
				{
					SModelManager.Current.Add(SelectedModel);
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}


			SelectedModel.ChangeType = DataChangeTypes.DataChanged | DataChangeTypes.FileChanged;
			return true;
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			txtId.Focus();
		}

		/// <summary>
		/// 当前操作类型
		/// </summary>
		public DialogModelPropertyAction SelectedAction { get; set; }

		/// <summary>
		/// 当前数据
		/// </summary>
		public SModel SelectedModel { get; set; }

		/// <summary>
		/// 预选分类
		/// </summary>
		public string SelectedCategory { get; set; }

		/// <summary>
		/// 预选类型
		/// </summary>
		public Type SelectedModelType { get; set; }
	}
}
