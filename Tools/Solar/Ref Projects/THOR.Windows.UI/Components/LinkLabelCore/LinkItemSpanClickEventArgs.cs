using System;
using System.Collections.Generic;
using System.Text;

namespace THOR.Windows.UI.Components.LinkLabelCore
{
	public class LinkItemSpanClickEventArgs : EventArgs
	{
		public LinkItemSpan Span { get; protected set; }

		public LinkItemSpanClickEventArgs(LinkItemSpan span)
		{
			Span = span;
		}
	}
}
