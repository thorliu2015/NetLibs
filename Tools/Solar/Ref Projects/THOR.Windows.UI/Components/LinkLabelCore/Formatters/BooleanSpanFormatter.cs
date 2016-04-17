using System;
using System.Collections.Generic;
using System.Text;

namespace THOR.Windows.UI.Components.LinkLabelCore.Formatters
{
	/// <summary>
	/// 逻辑值格式化
	/// </summary>
	public class BooleanSpanFormatter : ILinkItemSpanFormatter
	{
		public BooleanSpanFormatter()
		{
			TRUE = "TRUE";
			FALSE = "FALSE";
		}

		public void Format(LinkItemSpan span)
		{
			if (span.Value == null || span.Value is bool == false)
			{
				span.Text = NullFormatter.NullText;
			}
			else if (Convert.ToBoolean(span.Value))
			{
				span.Text = TRUE;
			}
			else
			{
				span.Text = FALSE;
			}
		}

		public string TRUE { get; set; }
		public string FALSE { get; set; }
	}
}
