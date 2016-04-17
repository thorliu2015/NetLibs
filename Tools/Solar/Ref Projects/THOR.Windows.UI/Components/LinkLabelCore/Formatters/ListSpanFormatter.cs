using System;
using System.Collections.Generic;
using System.Text;

namespace THOR.Windows.UI.Components.LinkLabelCore.Formatters
{
	public class ListSpanFormatter : ILinkItemSpanFormatter
	{
		public ListSpanFormatter()
		{
		}

		public void Format(LinkItemSpan span)
		{
			if (span.Value == null) span.Text = NullFormatter.NullText;
			else
			{
				foreach (ListKeyValue item in Items)
				{
					if (Convert.ToInt32(span.Value) == item.Value)
					{
						span.Text = item.Key;
						return;
					}
				}

				span.Text = NullFormatter.NullText;
			}
		}

		public List<ListKeyValue> Items { get; set; }
	}
}
