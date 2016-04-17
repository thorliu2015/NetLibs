/*
 * ThorControlMeasure
 * liuqiang@2015/11/12 18:54:26
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


//---- 8< ------------------

namespace THOR.Windows.Utils
{
	static public class ThorControlMeasure
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#region Rectangle

		static public Rectangle ZoomLeft(this Rectangle rect, int offset)
		{
			int x = rect.Left + offset;
			int y = rect.Top;
			int w = rect.Width - offset;
			int h = rect.Height;

			return new Rectangle(x, y, w, h);
		}

		static public Rectangle ZoomRight(this Rectangle rect, int offset)
		{
			int x = rect.Left;
			int y = rect.Top;
			int w = rect.Width - offset;
			int h = rect.Height;

			return new Rectangle(x, y, w, h);
		}

		static public Rectangle ZoomTop(this Rectangle rect, int offset)
		{
			int x = rect.Left;
			int y = rect.Top + offset;
			int w = rect.Width;
			int h = rect.Height - offset;

			return new Rectangle(x, y, w, h);
		}

		static public Rectangle ZoomBottom(this Rectangle rect, int offset)
		{
			int x = rect.Left;
			int y = rect.Top;
			int w = rect.Width;
			int h = rect.Height - offset;

			return new Rectangle(x, y, w, h);
		}

		static public Rectangle Zoom(this Rectangle rect, int offset)
		{
			int x = rect.Left + offset;
			int y = rect.Top + offset;
			int w = rect.Width - offset * 2;
			int h = rect.Height - offset * 2;

			return new Rectangle(x, y, w, h);
		}
		#endregion

		#region Size

		static public Size Zoom(this Size size, int offsetX, int offsetY)
		{
			int w = size.Width;
			int h = size.Height;

			w -= offsetX;
			h -= offsetY;

			return new Size(w, h);
		}

		#endregion

		#region IconAndText

		

		#endregion


		#endregion

		#region methods

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
