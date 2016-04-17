using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THOR.Windows.Editors.Common.Core
{
	/// <summary>
	/// 编辑器保存方法
	/// </summary>
	public interface IEditorSaveMethod
	{
		/// <summary>
		/// 保存数据
		/// </summary>
		/// <param name="module"></param>
		void Save(EditorModule module);
	}
}
