using System;
using System.Collections.Generic;
using System.Text;

namespace THOR.Windows.UI.Components.LinkLabelCore
{
	/// <summary>
	/// 表示链接项目
	/// </summary>
	public class LinkItem
	{
		/// <summary>
		/// 构造
		/// </summary>
		public LinkItem()
		{
		}


		/// <summary>
		/// 链接显示模板
		/// </summary>
		public string Template { get; set; }

		/// <summary>
		/// 链接片断
		/// </summary>
		public List<LinkItemSpan> Spans { get; set; }
	}
}
