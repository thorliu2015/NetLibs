using System;
using System.Collections.Generic;
using System.Text;

namespace THOR.Utils.Files
{
	/// <summary>
	/// 统一的文件状态显示接口
	/// </summary>
	public interface IFileStatusUI
	{
		/// <summary>
		/// 更新文件状态界面显示
		/// </summary>
		/// <param name="fileStatus">文件状态</param>
		void UpdateFileStatus(FileStatus fileStatus);
	}
}
