using System;
using System.Collections.Generic;
using System.Text;

namespace THOR.Windows.UI.Components.LinkLabelCore.Formatters
{
	/// <summary>
	/// 有符号整数格式化
	/// </summary>
	public class IntSpanFormatter : ILinkItemSpanFormatter
	{
		public IntSpanFormatter()
		{
			Template = "###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,##0";
		}

		public void Format(LinkItemSpan span)
		{
			try
			{
				span.Text = Convert.ToInt64(span.Value).ToString(Template);
			}
			catch(Exception ex)
			{
				span.Text = NullFormatter.NullText;
			}
			
		}

		public string Template { get; set; }
	}
}
