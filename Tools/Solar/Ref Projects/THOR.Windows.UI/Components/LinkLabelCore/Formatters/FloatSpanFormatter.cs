using System;
using System.Collections.Generic;
using System.Text;

namespace THOR.Windows.UI.Components.LinkLabelCore.Formatters
{
	public class FloatSpanFormatter: ILinkItemSpanFormatter
	{
		

		public void Format(LinkItemSpan span)
		{
			try
			{
				span.Text = Convert.ToDouble(span.Value).ToString();
			}
			catch(Exception ex)
			{
				span.Text = NullFormatter.NullText;
			}
		}


		
	}
}
