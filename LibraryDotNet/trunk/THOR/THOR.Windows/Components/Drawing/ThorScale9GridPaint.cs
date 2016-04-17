/*
 * ThorScale9GridPaint
 * liuqiang@2015/11/15 11:07:44
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Windows.Components.Drawing
{
	public class ThorScale9GridPaint
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		static public void Draw(Graphics g, Rectangle rect, Image scale9gridImage, Rectangle scale9GridRect, bool noCenterArea = true)
		{
			int[] sWidths = new int[3];
			int[] sHeights = new int[3];

			sWidths[0] = scale9GridRect.Left;
			sWidths[1] = scale9GridRect.Width;
			sWidths[2] = scale9gridImage.Width - scale9GridRect.Width - scale9GridRect.Left;

			sHeights[0] = scale9GridRect.Top;
			sHeights[1] = scale9GridRect.Height;
			sHeights[2] = scale9gridImage.Height - scale9GridRect.Height - scale9GridRect.Top;

			Rectangle rectSrc = new Rectangle();
			Rectangle rectDst = new Rectangle();

			/*
			 *	
			 *		7		8		9
			 *		4		5		6
			 *		1		2		3
			 *		
			 */

			SolidBrush brush = new SolidBrush(Color.FromArgb(0x80, Color.Red));

			#region 1

			rectSrc.X = 0;
			rectSrc.Y = sHeights[0] + sHeights[1];
			rectSrc.Width = sWidths[0];
			rectSrc.Height = sHeights[2];

			rectDst.Width = rectSrc.Width;
			rectDst.Height = rectSrc.Height;
			rectDst.X = 0;
			rectDst.Y = rect.Bottom - rectDst.Height;


			//g.FillRectangle(brush, rectDst);
			g.DrawImage(scale9gridImage, rectDst, rectSrc, GraphicsUnit.Pixel);
			#endregion

			#region 2
			rectSrc.X = sWidths[0];
			rectSrc.Width = sWidths[1];
			rectSrc.Y = sHeights[0] + sHeights[1];
			rectSrc.Height = sHeights[2];

			rectDst.Width = rect.Width - sWidths[0] - sWidths[2];
			rectDst.Height = rectSrc.Height;
			rectDst.X = rect.Left + sWidths[0];
			rectDst.Y = rect.Bottom - sHeights[2];

			//g.FillRectangle(brush, rectDst);
			g.DrawImage(scale9gridImage, rectDst, rectSrc, GraphicsUnit.Pixel);
			#endregion

			#region 3

			rectSrc.X = sWidths[0] + sWidths[1];
			rectSrc.Y = sHeights[0] + sHeights[1];
			rectSrc.Width = sWidths[2];
			rectSrc.Height = sHeights[2];

			rectDst.Width = rectSrc.Width;
			rectDst.Height = rectSrc.Height;
			rectDst.X = rect.Right - sWidths[2];
			rectDst.Y = rect.Bottom - rectDst.Height;
			//g.FillRectangle(brush, rectDst);
			g.DrawImage(scale9gridImage, rectDst, rectSrc, GraphicsUnit.Pixel);

			#endregion

			#region 4
			rectSrc.X = 0;
			rectSrc.Width = sWidths[0];
			rectSrc.Y = sHeights[0];
			rectSrc.Height = sHeights[1];

			rectDst.X = rect.Left;
			rectDst.Width = sWidths[0];
			rectDst.Y = sHeights[0];
			rectDst.Height = rect.Height - sHeights[0] - sHeights[2];

			//g.FillRectangle(brush, rectDst);
			g.DrawImage(scale9gridImage, rectDst, rectSrc, GraphicsUnit.Pixel);
			#endregion

			#region 5

			//if (!noCenterArea)
			{
			}

			#endregion

			#region 6

			rectSrc.X = scale9gridImage.Width - sWidths[2];
			rectSrc.Width = sWidths[2];
			rectSrc.Y = sHeights[0];
			rectSrc.Height = sHeights[1];

			rectDst.X = rect.Right - sWidths[2];
			rectDst.Width = sWidths[2];
			rectDst.Y = sHeights[0];
			rectDst.Height = rect.Height - sHeights[0] - sHeights[2];

			//g.FillRectangle(brush, rectDst);
			g.DrawImage(scale9gridImage, rectDst, rectSrc, GraphicsUnit.Pixel);
			#endregion

			#region 7
			rectSrc.X = 0;
			rectSrc.Y = 0;
			rectSrc.Width = sWidths[0];
			rectSrc.Height = sHeights[0];

			rectDst.Width = rectSrc.Width;
			rectDst.Height = rectSrc.Height;
			rectDst.X = 0;
			rectDst.Y = rect.Left;


			//g.FillRectangle(brush, rectDst);
			g.DrawImage(scale9gridImage, rectDst, rectSrc, GraphicsUnit.Pixel);
			#endregion

			#region 8


			rectSrc.X = sWidths[0];
			rectSrc.Width = sWidths[1];
			rectSrc.Y = 0;
			rectSrc.Height = sHeights[0];

			rectDst.Width = rect.Width - sWidths[0] - sWidths[2];
			rectDst.Height = rectSrc.Height;
			rectDst.X = rect.Left + sWidths[0];
			rectDst.Y = rect.Top;

			//g.FillRectangle(brush, rectDst);
			g.DrawImage(scale9gridImage, rectDst, rectSrc, GraphicsUnit.Pixel);
			#endregion

			#region 9
			rectSrc.X = sWidths[0] + sWidths[1];
			rectSrc.Y = 0;
			rectSrc.Width = sWidths[2];
			rectSrc.Height = sHeights[0];

			rectDst.Width = rectSrc.Width;
			rectDst.Height = rectSrc.Height;
			rectDst.X = rect.Right-rectSrc.Width;
			rectDst.Y = rect.Left;


			//g.FillRectangle(brush, rectDst);
			g.DrawImage(scale9gridImage, rectDst, rectSrc, GraphicsUnit.Pixel);
			#endregion
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
