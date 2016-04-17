using System;
using System.Collections.Generic;
using System.Text;

namespace THOR.Windows.UI.Components.LinkLabelCore.Formatters
{
	public class EnumSpanFormatter : ILinkItemSpanFormatter
	{
		public EnumSpanFormatter()
		{
			Spec = ",";
		}

		public void Format(LinkItemSpan span)
		{
			if (span.Value == null) span.Text = NullFormatter.NullText;
			else
			{
				try
				{
					List<String> es = new List<string>();
					UInt32 u = Convert.ToUInt32(span.Value);

					foreach (EnumKeyValue item in Items)
					{
						if (Convert.ToUInt32(u & item.Value) == item.Value)
						{
							es.Add(item.Key);
						}
					}

					string result = "";

					foreach (string e in es)
					{
						if (result != "") result += Spec;
						result += e;
					}

					span.Text = result;
				}
				catch
				{
					span.Text = NullFormatter.NullText;
				}

			}
		}

		public List<EnumKeyValue> Items { get; set; }

		public string Spec { get; set; }
	}
}
