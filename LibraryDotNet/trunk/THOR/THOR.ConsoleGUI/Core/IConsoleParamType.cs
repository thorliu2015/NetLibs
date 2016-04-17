/*
 * IConsoleParamType
 * liuqiang@2016/4/9 13:52:35
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.ConsoleGUI.Core
{
	public interface IConsoleParamType
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		/// <summary>
		/// 获取数据的文本
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		string GetString(object obj);

		/// <summary>
		/// 获取文本的数据
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		object GetObject(string str);

		/// <summary>
		/// 匹配文本
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		string Match(string input);

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
