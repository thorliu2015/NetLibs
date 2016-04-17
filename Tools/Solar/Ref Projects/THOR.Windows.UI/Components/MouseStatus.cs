using System;
using System.Collections.Generic;
using System.Text;

namespace THOR.Windows.UI.Components
{
	/// <summary>
	/// 鼠标状态
	/// </summary>
	public class MouseStatus
	{
		protected bool isPressed = false;
		protected bool isHoved = false;
		protected bool isChecked = false;

		/// <summary>
		/// 构造
		/// </summary>
		public MouseStatus()
			: base()
		{
		}

		/// <summary>
		/// 是否已经按下
		/// </summary>
		public bool IsPressed
		{
			get
			{
				return isPressed;
			}
			set
			{
				isPressed = value;
			}
		}

		/// <summary>
		/// 是否已经指向
		/// </summary>
		public bool IsHoved
		{
			get
			{
				return isHoved;
			}
			set
			{
				isHoved = value;
			}
		}

		/// <summary>
		/// 是否已经选中
		/// </summary>
		public bool IsChecked
		{
			get
			{
				return isChecked;
			}
			set
			{
				isChecked = value;
			}
		}
	}
}
