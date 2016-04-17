using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace THOR.Utils.Files
{
	/// <summary>
	/// 文件对话框（打开，保存）
	/// </summary>
	public class FileDialogs
	{
		protected OpenFileDialog openFileDialog;
		protected SaveFileDialog saveFileDialog;

		/// <summary>
		/// 构造
		/// </summary>
		public FileDialogs()
		{
			openFileDialog = new OpenFileDialog();
			saveFileDialog = new SaveFileDialog();

			OpenDialogTitle = "打开";
			SaveDialogTitle = "保存";
			Filter = "";
			Directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		}

		/// <summary>
		/// 打开文件
		/// </summary>
		/// <returns></returns>
		public string Open()
		{
			openFileDialog.Title = OpenDialogTitle;
			openFileDialog.Filter = this.Filter;
			openFileDialog.InitialDirectory = Directory;

			if (openFileDialog.ShowDialog() == DialogResult.Cancel) return "";
			return openFileDialog.FileName;
		}

		/// <summary>
		/// 保存文件
		/// </summary>
		/// <returns></returns>
		public string Save()
		{
			saveFileDialog.Title = SaveDialogTitle;
			saveFileDialog.Filter = this.Filter;
			saveFileDialog.InitialDirectory = Directory;

			if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return "";
			return saveFileDialog.FileName;
		}


		/// <summary>
		/// 打开文件的对话框标题
		/// </summary>
		public string OpenDialogTitle { get; set; }

		/// <summary>
		/// 保存文件的对话框标题
		/// </summary>
		public string SaveDialogTitle { get; set; }

		/// <summary>
		/// 对话框默认路径
		/// </summary>
		public string DialogPath { get; set; }

		/// <summary>
		/// 文件过滤设置
		/// </summary>
		public string Filter { get; set; }

		/// <summary>
		/// 初始目录
		/// </summary>
		public string Directory { get; set; }

	}
}
