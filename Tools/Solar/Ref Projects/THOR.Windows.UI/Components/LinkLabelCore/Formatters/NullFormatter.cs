using System;
using System.Collections.Generic;
using System.Text;

namespace THOR.Windows.UI.Components.LinkLabelCore.Formatters
{
	/// <summary>
	/// 空值格式化
	/// </summary>
	public class NullFormatter
	{
		static NullFormatter()
		{
			NullText = "<NULL>";
		}

		static public string NullText { get; set; }
	}
}
