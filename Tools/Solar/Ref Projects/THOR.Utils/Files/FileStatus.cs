using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace THOR.Utils.Files
{
	/// <summary>
	/// 文件状态
	/// </summary>
	public class FileStatus
	{
		/// <summary>
		/// 文件是否已经更改
		/// </summary>
		protected bool _changed;

		/// <summary>
		/// 构造
		/// </summary>
		public FileStatus()
		{
			Filename = "";
		}

		/// <summary>
		/// 新建
		/// </summary>
		public void New()
		{
			if (FileStatusHandler != null)
			{
				if (Changed)
				{
					switch (FileStatusHandler.PromptSave(Context))
					{
						case DialogResult.Yes:
							Save();
							break;

						case DialogResult.No:
							break;

						case DialogResult.Cancel:
							return;
					}
				}

				FileStatusHandler.Clear(Context);
				Filename = "";

				_changed = false;
				if (FileStatusUI != null) FileStatusUI.UpdateFileStatus(this);
			}
		}

		/// <summary>
		/// 打开
		/// </summary>
		public void Open()
		{
			if (Changed)
			{
				switch (FileStatusHandler.PromptSave(Context))
				{
					case DialogResult.Yes:
						Save();
						break;

					case DialogResult.No:
						break;

					case DialogResult.Cancel:
						return;
				}
			}

			string newFile = FileDialogs.Open();
			if (newFile == "") return;

			FileStatusHandler.Load(newFile, Context);

			Filename = newFile;
			_changed = false;
			FileStatusUI.UpdateFileStatus(this);
		}

		/// <summary>
		/// 打开
		/// </summary>
		/// <param name="newFile">文件</param>
		public void Open(string newFile)
		{
			if (Changed)
			{
				switch (FileStatusHandler.PromptSave(Context))
				{
					case DialogResult.Yes:
						Save();
						break;

					case DialogResult.No:
						break;

					case DialogResult.Cancel:
						return;
				}
			}

			FileStatusHandler.Load(newFile, Context);

			Filename = newFile;
			_changed = false;
			FileStatusUI.UpdateFileStatus(this);
		}

		/// <summary>
		/// 保存
		/// </summary>
		public void Save()
		{
			if (Filename == "")
			{
				string newFile = FileDialogs.Save();
				if (newFile == "") return;

				Filename = newFile;
			}

			FileStatusHandler.Save(Filename, Context);

			_changed = false;
			FileStatusUI.UpdateFileStatus(this);
		}

		/// <summary>
		/// 另存为
		/// </summary>
		public void SaveAs()
		{
			string newFile = FileDialogs.Save();
			if (newFile == "") return;

			FileStatusHandler.Save(newFile, Context);
			Filename = newFile;
			_changed = false;
			FileStatusUI.UpdateFileStatus(this);
		}

		/// <summary>
		/// 获取或设置文件名
		/// </summary>
		public string Filename { get; protected set; }

		/// <summary>
		/// 文件是否已经更改
		/// </summary>
		public bool Changed
		{
			get
			{
				return _changed;
			}
			set
			{
				//if (_changed == value) return;
				_changed = value;

				if (FileStatusUI != null)
					FileStatusUI.UpdateFileStatus(this);
			}
		}

		/// <summary>
		/// 文件状态处理
		/// </summary>
		public IFileStatusHandler FileStatusHandler { get; set; }

		/// <summary>
		/// 文件状态显示
		/// </summary>
		public IFileStatusUI FileStatusUI { get; set; }

		/// <summary>
		/// 文件对话框
		/// </summary>
		public FileDialogs FileDialogs { get; set; }

		/// <summary>
		/// 上下文
		/// </summary>
		public object Context { get; set; }
	}
}
