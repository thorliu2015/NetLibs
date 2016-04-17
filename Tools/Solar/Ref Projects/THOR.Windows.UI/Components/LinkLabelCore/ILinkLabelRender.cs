using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace THOR.Windows.UI.Components.LinkLabelCore
{
	/// <summary>
	/// 统一的链接项目渲染接口
	/// </summary>
	public interface ILinkLabelRender
	{
		/// <summary>
		/// 更新链接控件外观
		/// </summary>
		/// <param name="label">新链接控件</param>
		void Update(TLinkLabel label);
	}
}
