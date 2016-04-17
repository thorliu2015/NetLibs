/*
 * ThorButton
 * liuqiang@2015/11/1 22:43:17
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

namespace THOR.Windows.Components.Common
{
	public class ThorButton : Button
	{
		#region constants

		#endregion

		#region variables

		protected bool mouseOver = false;
		protected bool mouseDown = false;
		protected bool focusIn = false;

		#endregion

		#region construct

		public ThorButton()
			: base()
		{
			DoubleBuffered = true;

			UseVisualStyleBackColor = false;

			Width = 80;
			Height = 30;
		}

		#endregion

		#region methods

		protected virtual void DrawButton(PaintEventArgs pevent)
		{
			Rectangle rect = new Rectangle(0, 0, Width, Height);

			if (!Enabled)
			{
				ThorControlPaint.DrawButton(pevent.Graphics, rect, ThorButtonState.Disabled, focusIn, this.FindForm());
			}
			else if (mouseDown)
			{
				ThorControlPaint.DrawButton(pevent.Graphics, rect, ThorButtonState.Pressed, focusIn, this.FindForm());
				rect.Y++;
			}
			else if (mouseOver)
			{
				ThorControlPaint.DrawButton(pevent.Graphics, rect, ThorButtonState.Hover, focusIn, this.FindForm());
			}
			else
			{
				ThorControlPaint.DrawButton(pevent.Graphics, rect, ThorButtonState.Normal, focusIn, this.FindForm());
			}
			TextFormatFlags tf = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;


			Rectangle shad = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
			shad.X++;
			shad.Y++;
			TextRenderer.DrawText(pevent.Graphics, Text, Font, shad, Enabled ? ThorColors.ControlDark : ThorColors.ControlDark, tf);
			TextRenderer.DrawText(pevent.Graphics, Text, Font, rect, Enabled ? ThorColors.ControlText : ThorColors.GrayText, tf);

		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			//base.OnPaint(pevent);
			pevent.Graphics.Clear(ThorColors.Control);
			DrawButton(pevent);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			mouseOver = true;
			this.Invalidate();
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			mouseOver = false;
			this.Invalidate();
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			base.OnMouseDown(mevent);
			mouseDown = true;
			this.Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			base.OnMouseUp(mevent);
			mouseDown = false;
			this.Invalidate();
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			focusIn = true;
			this.Invalidate();
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			focusIn = false;
			this.Invalidate();
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
