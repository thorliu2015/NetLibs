using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Data
{
	/// <summary>
	/// 数据更改类型
	/// </summary>
	public enum DataChangeTypes
	{
		/// <summary>
		/// 没有改变
		/// </summary>
		None,

		/// <summary>
		/// 数据改变
		/// </summary>
		DataChanged,

		/// <summary>
		/// 文件改变
		/// </summary>
		FileChanged
	}
}
