/*
 * ThorControlPaint
 * liuqiang@2015/11/7 12:16:39
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Windows.Dialogs;


//---- 8< ------------------

namespace THOR.Windows.Components.Drawing
{
	/// <summary>
	/// 按钮状态
	/// </summary>
	public enum ThorButtonState
	{
		/// <summary>
		/// 默认
		/// </summary>
		Normal,

		/// <summary>
		/// 禁用
		/// </summary>
		Disabled,

		/// <summary>
		/// 鼠标指向
		/// </summary>
		Hover,

		/// <summary>
		/// 按下
		/// </summary>
		Pressed
	}

	public enum ThorArrowDirection
	{
		Up,
		Down,
		Left,
		Right
	}


	public class ThorControlPaint
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods


		/// <summary>
		/// 绘制矩形边框
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rect"></param>
		/// <param name="pen"></param>
		/// <param name="zero"></param>
		static public void DrawRectangle(Graphics g, Rectangle rect, Pen pen, bool zero = true)
		{
			g.DrawRectangle(pen, zero ? 0 : rect.Left, zero ? 0 : rect.Top, rect.Width - 1, rect.Height - 1);
		}



		static public Pen GetFocusPen(Form f)
		{
			if (f is FlatForm)
			{
				FlatForm ff = (FlatForm)f;
				if (ff.ThemeColor != Color.Transparent)
				{
					return new Pen(new SolidBrush(ff.ThemeColor));
				}
			}

			return ThorPens.Focus;
		}

		#region Icons

		/// <summary>
		/// 绘制图标
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rect"></param>
		/// <param name="icon"></param>
		static public void DrawIcon(Graphics g, Rectangle rect, Image icon, int alpha = 0xFF)
		{
			if (icon == null) return;

			Rectangle rectSrc = new Rectangle(0, 0, icon.Width, icon.Height);
			Rectangle rectTarget = new Rectangle(rect.X, rect.Y, icon.Width, icon.Height);

			rectTarget.X += (rect.Width - icon.Width) / 2;
			rectTarget.Y += (rect.Height - icon.Height) / 2;

			if (alpha == 0xFF)
			{
				g.DrawImage(icon, rectTarget, rectSrc, GraphicsUnit.Pixel);
			}
			else
			{
				float a = (alpha * 1f) / (0xFF * 1f);

				float[][] ptsArray = { 
										new float[] {1, 0, 0, 0, 0},
										new float[] {0, 1, 0, 0, 0},
										new float[] {0, 0, 1, 0, 0},
										new float[] {0, 0, 0, a, 0},
										new float[] {0, 0, 0, 0, 1}};

				ColorMatrix clrMartrix = new ColorMatrix(ptsArray);
				ImageAttributes imgAttributes = new ImageAttributes();
				imgAttributes.SetColorMatrix(clrMartrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
				Bitmap iconBmp = (Bitmap)icon;
				g.DrawImage(icon, rectTarget, 0, 0, iconBmp.Width, iconBmp.Height, GraphicsUnit.Pixel, imgAttributes);
			}
		}

		/// <summary>
		/// 绘制三角箭头
		/// </summary>
		static public void DrawArrow(Graphics g, Rectangle rect, Color color, ThorArrowDirection direction = ThorArrowDirection.Down, int size = 5)
		{


			/*
			 *		  +
			 *		 +++
			 *		+++++
			 *		
			 *		  ++
			 *		 ++++
			 *		++++++
			 */



			Pen pen = new Pen(new SolidBrush(color));

			bool isDouble = (((size / 2) * 2) == size);

			int lines = size / 2;
			if (!isDouble) lines++;

			int length = size;
			Point p1 = new Point();
			Point p2 = new Point();
			Point po = new Point();

			if (direction == ThorArrowDirection.Left || direction == ThorArrowDirection.Right)
			{
				po.X = (rect.Width - lines) / 2;
				po.Y = (rect.Height - size) / 2;
			}
			else
			{
				po.X = (rect.Width - size) / 2;
				po.Y = (rect.Height - lines) / 2;
			}

			//g.FillRectangle(new SolidBrush(Color.Red), po.X, po.Y, size, size);

			po.X += rect.Left;
			po.Y += rect.Top;



			for (int i = 0; i < lines; i++)
			{
				switch (direction)
				{
					case ThorArrowDirection.Up:
						{
							p1.X = i;
							p2.X = size - i - 1;
							p1.Y = p2.Y = size - i;
						}
						break;

					case ThorArrowDirection.Down:
						{
							p1.X = i;
							p2.X = size - i - 1;
							p1.Y = p2.Y = i;
						}
						break;

					case ThorArrowDirection.Left:
						{
							p1.Y = i;
							p2.Y = size - i - 1;
							p1.X = p2.X = size - i;

						}
						break;

					case ThorArrowDirection.Right:
						{
							p1.Y = i;
							p2.Y = size - i - 1;
							p1.X = p2.X = i;
						}
						break;
				}

				if (i >= lines - 1 && !isDouble)
				{
					g.FillRectangle(pen.Brush, new Rectangle(p1.X + po.X, p1.Y + po.Y, 1, 1));
				}
				else
				{
					g.DrawLine(pen, p1.X + po.X, p1.Y + po.Y, p2.X + po.X, p2.Y + po.Y);
				}


				length -= 2;
			}

		}

		/// <summary>
		/// 绘制...
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rect"></param>
		/// <param name="color"></param>
		/// <param name="size"></param>
		static public void DrawDotDotDot(Graphics g, Rectangle rect, Color color, int size = 5)
		{
			int x1 = ((rect.Width - size) / 2) + rect.Left;
			int x2 = x1 + size;
			int y = (rect.Height / 2) + rect.Top;

			Pen pen = new Pen(new SolidBrush(color));
			pen.DashStyle = DashStyle.Dot;

			g.DrawLine(pen, x1, y, x2, y);
		}

		/// <summary>
		/// 绘制一个折叠图示
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rect"></param>
		static public void DrawFold(Graphics g, Rectangle rect, bool expanded, Color foreColor, Color backColor, Color borderColor)
		{
			int lineLength = 5;
			int lineMargin = 2;

			Point po = new Point();
			po.X = (rect.Width - lineLength - lineMargin * 2) / 2;
			po.Y = (rect.Height - lineLength - lineMargin * 2) / 2;
			po.Y++;

			if (backColor != Color.Transparent)
			{
				g.FillRectangle(new SolidBrush(backColor), po.X + rect.Left, po.Y + rect.Top, lineLength + lineMargin * 2, lineLength + lineMargin * 2);
			}

			if (foreColor != Color.Transparent)
			{
				Pen pen = new Pen(new SolidBrush(borderColor));
				g.DrawRectangle(pen, po.X + rect.Left, po.Y + rect.Top, lineLength + lineMargin * 2 - 1, lineLength + lineMargin * 2 - 1);

				pen = new Pen(new SolidBrush(foreColor));

				//h
				g.DrawLine(pen,
					po.X + rect.Left + lineMargin,
					po.Y + rect.Top + lineMargin + lineLength / 2,
					po.X + rect.Left + lineMargin + lineLength - 1,
					po.Y + rect.Top + lineMargin + lineLength / 2);

				if (!expanded)
				{
					//v
					g.DrawLine(pen,
						po.X + rect.Left + lineMargin + lineLength / 2,
						po.Y + rect.Top + lineMargin,
						po.X + rect.Left + lineMargin + lineLength / 2,
						po.Y + rect.Top + lineMargin + lineLength - 1);
				}
			}
		}

		#endregion

		#region Controls

		/// <summary>
		/// 绘制窗体
		/// </summary>
		static public void DrawForm(Graphics g, Rectangle rect, bool focused, Form f = null, bool noBorder = false)
		{
			g.Clear(ThorColors.WindowBackground);

			if (noBorder) return;

			if (focused)
			{
				if (f is FlatForm)
				{
					FlatForm ff = (FlatForm)f;
					if (ff.ThemeColor != Color.Transparent)
					{
						DrawRectangle(g, rect, new Pen(new SolidBrush(ff.ThemeColor)));
						return;
					}
				}
				DrawRectangle(g, rect, ThorPens.Focus);
			}
			else
			{
				DrawRectangle(g, rect, ThorPens.WindowFrame);
			}
		}

		/// <summary>
		/// 绘制按钮
		/// </summary>
		static public void DrawButton(Graphics g, Rectangle rect, ThorButtonState state, bool focused, Form f = null)
		{
			int margin = 1;
			Rectangle btnRect = new Rectangle(rect.X + margin, rect.Y + margin, rect.Width - margin * 2, rect.Height - margin * 2);

			Pen leftPen = ThorPens.Control;
			Pen topPen = ThorPens.Control;
			Pen rightPen = ThorPens.Control;
			Pen bottomPen = ThorPens.Control;

			Color g1 = ThorColors.Control;
			Color g2 = ThorColors.Control;

			Pen border = ThorPens.ControlDark;

			switch (state)
			{
				//默认
				case ThorButtonState.Normal:
				case ThorButtonState.Hover:
					leftPen = topPen = ThorPens.ControlLightLight;
					rightPen = bottomPen = ThorPens.Control;
					g1 = ThorColors.ControlLight;
					g2 = ThorColors.Control;
					border = ThorPens.ControlDarkDark;
					break;


				//按下
				case ThorButtonState.Pressed:
					leftPen = topPen = ThorPens.Control;
					rightPen = bottomPen = ThorPens.ControlLightLight;
					g1 = ThorColors.Control;
					g2 = ThorColors.ControlLight;
					border = ThorPens.ControlDarkDark;
					break;

			}

			LinearGradientBrush b = new LinearGradientBrush(btnRect, g1, g2, 90f);
			g.FillRectangle(b, btnRect);

			if (focused && state != ThorButtonState.Disabled)
			{
				DrawRectangle(g, rect, focused ? GetFocusPen(f) : ThorPens.Control, false);
			}


			g.DrawLine(rightPen, btnRect.Right - 2, btnRect.Top + 1, btnRect.Right - 2, btnRect.Bottom - 2);
			g.DrawLine(bottomPen, btnRect.Left + 1, btnRect.Bottom - 2, btnRect.Right - 2, btnRect.Bottom - 2);
			g.DrawLine(leftPen, btnRect.Left + 1, btnRect.Top + 1, btnRect.Left + 1, btnRect.Bottom - 2);
			g.DrawLine(topPen, btnRect.Left + 1, btnRect.Top + 1, btnRect.Right - 2, btnRect.Top + 1);

			DrawRectangle(g, btnRect, border, false);


		}

		/// <summary>
		/// 绘制窗口
		/// </summary>
		static public void DrawWindow(Graphics g, Rectangle rect, bool focused, Form f = null)
		{
			g.FillRectangle(ThorBrushs.Window, rect);

			if (focused)
			{
				DrawRectangle(g, rect, GetFocusPen(f), false);
			}
			else
			{
				DrawRectangle(g, rect, ThorPens.ControlLight, false);
			}
		}

		/// <summary>
		/// 绘制平面按钮
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rect"></param>
		/// <param name="state"></param>
		/// <param name="focused"></param>
		static public void DrawFlatButton(Graphics g, Rectangle rect, ThorButtonState state, bool drawBg, bool focused)
		{
			int margin = 1;
			if (!drawBg) return;
			Rectangle btnRect = new Rectangle(rect.X + margin, rect.Y + margin, rect.Width - margin * 2, rect.Height - margin * 2);

			switch (state)
			{
				case ThorButtonState.Normal:
					g.FillRectangle(ThorBrushs.WindowBackground, btnRect);
					break;

				case ThorButtonState.Hover:
					g.FillRectangle(ThorBrushs.WindowButtonHover, btnRect);
					break;

				case ThorButtonState.Pressed:
					g.FillRectangle(ThorBrushs.WindowButtonPressed, btnRect);
					break;
			}
		}


		/// <summary>
		/// 绘制多选框
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rect"></param>
		/// <param name="selected"></param>
		static public void DrawCheckBox(Graphics g, Rectangle rect, bool selected)
		{
			int s = 14;
			int m = 3;

			Rectangle r = new Rectangle();
			r.X = rect.X;
			r.Y = rect.Y;
			r.Width = rect.Width;
			r.Height = rect.Height;

			if (r.Width > s) r.Width = s;
			if (r.Height > s) r.Height = s;

			r.X += (rect.Width - r.Width) / 2;
			r.Y += (rect.Height - r.Height) / 2;

			g.FillRectangle(ThorBrushs.Window, r);
			g.DrawRectangle(ThorPens.ControlLight, r);

			if (selected)
			{
				Rectangle fillRect = new Rectangle(r.X + m, r.Y + m, r.Width - m * 2 + 1, r.Height - m * 2 + 1);
				g.FillRectangle(ThorBrushs.Focus, fillRect);
			}
		}

		/// <summary>
		/// 绘制单选框
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rect"></param>
		/// <param name="selected"></param>
		static public void DrawRadioBox(Graphics g, Rectangle rect, bool selected)
		{
			int s = 14;
			int m = 3;

			Rectangle r = new Rectangle();
			r.X = rect.X;
			r.Y = rect.Y;
			r.Width = rect.Width;
			r.Height = rect.Height;

			if (r.Width > s) r.Width = s;
			if (r.Height > s) r.Height = s;

			r.X += (rect.Width - r.Width) / 2;
			r.Y += (rect.Height - r.Height) / 2;

			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.FillEllipse(ThorBrushs.Window, r);
			g.DrawEllipse(ThorPens.ControlLight, r);

			if (selected)
			{
				Rectangle fillRect = new Rectangle(r.X + m, r.Y + m, r.Width - m * 2, r.Height - m * 2);
				g.FillEllipse(ThorBrushs.Focus, fillRect);
			}

			g.SmoothingMode = SmoothingMode.HighSpeed;
		}

		/// <summary>
		/// 绘制带区
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rect"></param>
		/// <param name="isHorizontablDirection"></param>
		static public void DrawBand(Graphics g, Rectangle rect, bool isHorizontablDirection, int grips = 3, bool noFill = false)
		{
			Rectangle r = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
			if (!noFill)
			{
				g.FillRectangle(ThorBrushs.Control, r);
			}
			int s = 2;
			int c = 0;
			int m = 4;
			int l = 3;


			Pen p1 = ThorPens.BandDot;
			//Pen p2 = ThorPens.ControlDark;

			p1.DashStyle = DashStyle.Dot;

			for (int i = 0; i < grips; i++)
			{
				if (isHorizontablDirection)
				{
					g.DrawLine(p1, rect.Left + m + s * i, rect.Top + m, rect.Left + m + s * i, rect.Bottom - m);
				}
				else
				{
					g.DrawLine(p1, rect.Left + m, rect.Top + m + s * i, rect.Right - m, rect.Top + m + s * i);
				}
			}

		}

		/// <summary>
		/// 绘制标题条
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rect"></param>
		/// <param name="isHorizontablDirection"></param>
		static public void DrawTitleBar(Graphics g, Rectangle rect, bool isHorizontablDirection)
		{
		}


		#endregion

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}


/*
 * //绘制半透明图标
13     Graphics g = this.CreateGraphics();
14     g.Clear(this.BackColor);
15     DrawPerson();
16     Bitmap bitmap = new Bitmap(@"e:\photo.jpg");
17     float[][] ptsArray ={ 
18     new float[] {1, 0, 0, 0, 0},
19     new float[] {0, 1, 0, 0, 0},
20     new float[] {0, 0, 1, 0, 0},
21     new float[] {0, 0, 0, 0.5f, 0}, //注意：此处为0.5f，图像为半透明
22     new float[] {0, 0, 0, 0, 1}};
23     ColorMatrix clrMatrix = new ColorMatrix(ptsArray);
24     ImageAttributes imgAttributes = new ImageAttributes();
25     //设置图像的颜色属性
26     imgAttributes.SetColorMatrix(clrMatrix, ColorMatrixFlag.Default,
27     ColorAdjustType.Bitmap);
28     //画图像
29     g.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height),
30         0, 0, bitmap.Width, bitmap.Height,
31         GraphicsUnit.Pixel, imgAttributes);
32     g.Dispose();
*/