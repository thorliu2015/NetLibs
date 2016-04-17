using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace THOR.Utils.Files
{
	/// <summary>
	/// 统一的文件状态处理接口
	/// </summary>
	public interface IFileStatusHandler
	{
		/// <summary>
		/// 清理文件内容
		/// </summary>
		void Clear(object context);

		/// <summary>
		/// 保存文件
		/// </summary>
		/// <param name="file">文件名</param>
		/// <param name="context">上下文</param>
		void Load(string file, object context);

		/// <summary>
		/// 加载文件
		/// </summary>
		/// <param name="file">文件名</param>
		/// <param name="context">上下文</param>
		void Save(string file, object context);

		/// <summary>
		/// 询问是否保存文件更改
		/// </summary>
		/// <param name="content"></param>
		DialogResult PromptSave(object context);
	}
}
