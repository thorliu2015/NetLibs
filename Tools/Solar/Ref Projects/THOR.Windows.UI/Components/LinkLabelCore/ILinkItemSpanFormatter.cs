using System;
using System.Collections.Generic;
using System.Text;

namespace THOR.Windows.UI.Components.LinkLabelCore
{
	/// <summary>
	/// 统一的链接项目片断格式化接口
	/// </summary>
	public interface ILinkItemSpanFormatter
	{
		/// <summary>
		/// 格式化链接项目片断
		/// </summary>
		/// <param name="span">链接项目片断</param>
		void Format(LinkItemSpan span);
	}
}
