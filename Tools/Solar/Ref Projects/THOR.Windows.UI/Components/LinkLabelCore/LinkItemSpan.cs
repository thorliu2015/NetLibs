using System;
using System.Collections.Generic;
using System.Text;

namespace THOR.Windows.UI.Components.LinkLabelCore
{
	/// <summary>
	/// 表示链接项目的链接片断
	/// </summary>
	public class LinkItemSpan
	{
		/// <summary>
		/// 构造
		/// </summary>
		public LinkItemSpan()
		{
		}

		/// <summary>
		/// 标识
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// 显示文本
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// 片断的值
		/// </summary>
		public object Value { get; set; }

		/// <summary>
		/// 占位符号
		/// </summary>
		public string PlaceHolder { get; set; }

		/// <summary>
		/// 索引位置
		/// </summary>
		public int Index { get; set; }

		
	}
}
