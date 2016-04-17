/*
 * EditorModuleEntityType
 * liuqiang@2015/11/1 20:26:51
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Windows.Editors.Common.Core
{
	/// <summary>
	/// 编辑器模块的数据类型
	/// </summary>
	public class EditorModuleEntityType
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		public EditorModuleEntityType()
		{
			Types = new List<Type>();
			Name = "";
		}

		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="name"></param>
		public EditorModuleEntityType(string name)
		{
			Types = new List<Type>();
			Name = name;
		}

		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="name"></param>
		/// <param name="types"></param>
		public EditorModuleEntityType(string name, params Type[] types)
		{
			Types = new List<Type>();
			Name = name;

			foreach (Type type in types)
			{
				if (Types.Contains(type)) continue;

				Types.Add(type);
			}
		}

		#endregion

		#region methods

		#endregion

		#region properties

		/// <summary>
		/// 获取或设置类型名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 获取或设置类型列表
		/// </summary>
		public List<Type> Types { get; set; }

		#endregion

		#region events

		#endregion
	}
}
