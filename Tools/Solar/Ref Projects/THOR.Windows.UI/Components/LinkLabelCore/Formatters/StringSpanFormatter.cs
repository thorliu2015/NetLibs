using System;
using System.Collections.Generic;
using System.Text;

namespace THOR.Windows.UI.Components.LinkLabelCore.Formatters
{
	/// <summary>
	/// 字符串类型的片断值格式化
	/// </summary>
	public class StringSpanFormatter : ILinkItemSpanFormatter
	{
		public void Format(LinkItemSpan span)
		{
			if (span.Value is string == false) span.Text = NullFormatter.NullText;
			else span.Text = "\"" + span.Value.ToString() + "\"";
		}
	}
}
