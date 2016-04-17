/*
 * ThorAbstractField
 * liuqiang@2015/11/16 19:37:38
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Windows.Components.Drawing;


//---- 8< ------------------

namespace THOR.Windows.Components.Fields
{
	public class ThorAbstractField : Control
	{
		#region constants

		protected const int THOR_FIELD_BORDER = 1;

		#endregion

		#region variables

		protected bool _FocusIn = false;
		protected bool _noBorder = true;

		#endregion

		#region construct

		public ThorAbstractField()
			: base()
		{
			InitField();
			CreateFieldContent();
			LayoutFieldContent();
		}

		#endregion

		#region methods

		/// <summary>
		/// 初始化
		/// </summary>
		protected virtual void InitField()
		{
			DoubleBuffered = true;
			ResizeRedraw = true;
			this.Padding = new Padding(THOR_FIELD_BORDER);

			TabStop = false;

			Width = 100;
			Height = 24;
		}

		/// <summary>
		/// 创建内容
		/// </summary>
		protected virtual void CreateFieldContent()
		{
		}

		/// <summary>
		/// 布局内容
		/// </summary>
		protected virtual void LayoutFieldContent()
		{
		}

		/// <summary>
		/// 缩放控件时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			LayoutFieldContent();
		}

		///// <summary>
		///// 获得焦点
		///// </summary>
		///// <param name="e"></param>
		//protected override void OnGotFocus(EventArgs e)
		//{
		//	base.OnGotFocus(e);

		//	_FocusIn = true;
		//	OnFocusChanged();
		//	this.Invalidate();
		//}

		///// <summary>
		///// 失去焦点
		///// </summary>
		///// <param name="e"></param>
		//protected override void OnLostFocus(EventArgs e)
		//{
		//	base.OnLostFocus(e);

		//	_FocusIn = false;
		//	OnFocusChanged();
		//	this.Invalidate();
		//}

		/// <summary>
		/// 焦点改变时
		/// </summary>
		protected virtual void OnFocusChanged()
		{
		}

		/// <summary>
		/// 重绘背景
		/// </summary>
		/// <param name="pevent"></param>
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.OnPaintBackground(pevent);

			DrawFieldBackground(pevent);
			DrawFieldForeground(pevent);

			if (!_noBorder) DrawFieldBorder(pevent);
		}


		/// <summary>
		/// 绘制背景
		/// </summary>
		/// <param name="e"></param>
		protected virtual void DrawFieldBackground(PaintEventArgs e)
		{
			e.Graphics.Clear(this.BackColor);
		}

		/// <summary>
		/// 绘制前景
		/// </summary>
		/// <param name="e"></param>
		protected virtual void DrawFieldForeground(PaintEventArgs e)
		{
		}

		/// <summary>
		/// 绘制边框
		/// </summary>
		/// <param name="e"></param>
		protected virtual void DrawFieldBorder(PaintEventArgs e)
		{
			Color theBorderColor = Color.Transparent;

			theBorderColor = _FocusIn ? ThorColors.GetThemeColor(this, ThorColors.Focus) : ThorColors.ControlLight;

			if (theBorderColor == Color.Transparent) return;

			ThorControlPaint.DrawRectangle(e.Graphics, this.Bounds, new Pen(new SolidBrush(theBorderColor)));
		}


		#endregion

		#region properties

		/// <summary>
		/// 获取当前控件是否拥有焦点
		/// </summary>
		public bool FocusIn
		{
			get
			{
				return _FocusIn;
			}
		}

		#endregion

		#region events

		#endregion
	}
}
