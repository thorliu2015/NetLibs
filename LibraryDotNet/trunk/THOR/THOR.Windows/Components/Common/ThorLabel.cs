/*
 * ThorLabel
 * liuqiang@2015/11/22 21:41:25
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
	public class ThorLabel : Label
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public ThorLabel()
			: base()
		{
			this.DoubleBuffered = true;
			this.BackColor = Color.Transparent;
			//this.AutoSize = true;
			//this.TextAlign = ContentAlignment.MiddleLeft;
		}

		#endregion

		#region methods

		protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle rect = new Rectangle(0, 0, Width, Height);
			TextFormatFlags tf = TextFormatFlags.EndEllipsis;

			switch (this.TextAlign)
			{
				case ContentAlignment.BottomCenter:
					tf |= TextFormatFlags.Bottom;
					tf |= TextFormatFlags.HorizontalCenter;
					break;

				case ContentAlignment.BottomLeft:
					tf |= TextFormatFlags.Bottom;
					tf |= TextFormatFlags.Left;
					break;

				case ContentAlignment.BottomRight:
					tf |= TextFormatFlags.Bottom;
					tf |= TextFormatFlags.Right;
					break;

				case ContentAlignment.MiddleCenter:
					tf |= TextFormatFlags.HorizontalCenter;
					tf |= TextFormatFlags.VerticalCenter;
					break;

				case ContentAlignment.MiddleLeft:
					tf |= TextFormatFlags.VerticalCenter;
					tf |= TextFormatFlags.Left;
					break;

				case ContentAlignment.MiddleRight:
					tf |= TextFormatFlags.HorizontalCenter;
					tf |= TextFormatFlags.Right;
					break;

				case ContentAlignment.TopCenter:
					tf |= TextFormatFlags.Top;
					tf |= TextFormatFlags.HorizontalCenter;
					break;

				case ContentAlignment.TopLeft:
					tf |= TextFormatFlags.Top;
					tf |= TextFormatFlags.Left;
					break;

				case ContentAlignment.TopRight:
					tf |= TextFormatFlags.Top;
					tf |= TextFormatFlags.Right;
					break;
			}

			TextRenderer.DrawText(e.Graphics, Text, Font, rect, ThorColors.ControlText, tf);
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
