using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THOR.Windows.Editors.Common.Core
{
	/// <summary>
	/// 编辑器的读取方法
	/// </summary>
	public interface IEditorLoadMethod
	{
		/// <summary>
		/// 读取数据
		/// </summary>
		/// <param name="module"></param>
		void Load(EditorModule module);
	}
}
