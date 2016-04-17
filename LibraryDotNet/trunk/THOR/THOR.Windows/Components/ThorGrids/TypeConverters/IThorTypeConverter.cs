/*
 * IThorTypeConverter
 * liuqiang@2015/11/24 14:40:12
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.TypeConverters
{
	/// <summary>
	/// 类型转换接口
	/// </summary>
	public interface IThorTypeConverter
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		/// <summary>
		/// 是否允许将对象转为文本
		/// </summary>
		/// <param name="data"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		bool AllowGetText(object data, Type type);

		/// <summary>
		/// 将对象转为文本
		/// </summary>
		/// <param name="data"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		string GetText(object data, Type type);

		/// <summary>
		/// 是否允许将文本转为对象
		/// </summary>
		/// <param name="text"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		bool AllowGetObject(string text, Type type);

		/// <summary>
		/// 将文本转为对象
		/// </summary>
		/// <param name="text"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		Object GetObject(string text, Type type);

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
