/*
 * SkinForm
 * liuqiang@2015/11/15 10:27:12
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Windows.Components.Common;
using THOR.Windows.Components.Drawing;
using THOR.Windows.Properties;


//---- 8< ------------------

namespace THOR.Windows.Dialogs
{
	public class SkinForm : Form
	{
		#region constants

		public const int SKIN_FORM_BLOW_SIZE = 5;
		public const int SKIN_FORM_BACK_LIGHT = 20;

		#endregion

		#region variables

		private FlatForm Main;

		#endregion

		#region construct

		public SkinForm(FlatForm main)
		{
			this.Main = main;
			Main.BringToFront();
			ShowInTaskbar = false;
			FormBorderStyle = FormBorderStyle.None;
			this.Location = new Point(Main.Location.X - SKIN_FORM_BLOW_SIZE, Main.Location.Y - SKIN_FORM_BLOW_SIZE);
			this.Icon = Main.Icon;
			this.ShowIcon = Main.ShowIcon;

			Width = Main.Width + SKIN_FORM_BLOW_SIZE * 2;
			Height = Main.Height + SKIN_FORM_BLOW_SIZE * 2;

			Text = Main.Text;

			Main.LocationChanged += Main_LocationChanged;
			Main.SizeChanged += Main_SizeChanged;
			Main.VisibleChanged += Main_VisibleChanged;


			SetBits();
			CanPenetrate();
		}



		#endregion

		#region methods

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cParms = base.CreateParams;
				cParms.ExStyle |= 0x00080000; // WS_EX_LAYERED
				return cParms;
			}
		}

		public void Main_VisibleChanged(object sender, EventArgs e)
		{

			this.Visible = Main.Visible;
		}

		public void Main_SizeChanged(object sender, EventArgs e)
		{
			Width = Main.Width + SKIN_FORM_BLOW_SIZE * 2;
			Height = Main.Height + SKIN_FORM_BLOW_SIZE * 2;

			SetBits();
		}

		public void Main_LocationChanged(object sender, EventArgs e)
		{
			Location = new Point(Main.Left - SKIN_FORM_BLOW_SIZE, Main.Top - SKIN_FORM_BLOW_SIZE);

		}

		/// <summary>
		/// 使窗口有鼠标穿透功能
		/// </summary>
		private void CanPenetrate()
		{
			int intExTemp = Win32.GetWindowLong(this.Handle, Win32.GWL_EXSTYLE);
			int oldGWLEx = Win32.SetWindowLong(this.Handle, Win32.GWL_EXSTYLE, Win32.WS_EX_TRANSPARENT | Win32.WS_EX_LAYERED);
		}

		

		public void SetBits()
		{
			try
			{
				Location = new Point(Main.Left - SKIN_FORM_BLOW_SIZE, Main.Top - SKIN_FORM_BLOW_SIZE);

				Bitmap bitmap = new Bitmap(Main.Width + SKIN_FORM_BLOW_SIZE * 2, Main.Height + SKIN_FORM_BLOW_SIZE * 2);
				Rectangle _BacklightLTRB = new Rectangle(SKIN_FORM_BACK_LIGHT, SKIN_FORM_BACK_LIGHT, SKIN_FORM_BACK_LIGHT, SKIN_FORM_BACK_LIGHT);
				Graphics g = Graphics.FromImage(bitmap);
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;

				DrawSkinForm(g);


				if (!Bitmap.IsCanonicalPixelFormat(bitmap.PixelFormat)
					|| !Bitmap.IsAlphaPixelFormat(bitmap.PixelFormat))
				{
					throw new ApplicationException("图片必须是32位带Alhpa通道的图片。");
				}

				IntPtr oldBits = IntPtr.Zero;
				IntPtr screenDC = Win32.GetDC(IntPtr.Zero);
				IntPtr hBitmap = IntPtr.Zero;

				IntPtr memDc = Win32.CreateCompatibleDC(screenDC);

				try
				{
					Win32.Point topLoc = new Win32.Point(Left, Top);
					Win32.Size bitMapSize = new Win32.Size(Width, Height);
					Win32.BLENDFUNCTION blendFunc = new Win32.BLENDFUNCTION();
					Win32.Point srcLoc = new Win32.Point(0, 0);

					hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
					oldBits = Win32.SelectObject(memDc, hBitmap);

					blendFunc.BlendOp = Win32.AC_SRC_OVER;
					blendFunc.SourceConstantAlpha = byte.Parse("255");
					blendFunc.AlphaFormat = Win32.AC_SRC_ALPHA;
					blendFunc.BlendFlags = 0;

					Win32.UpdateLayeredWindow(Handle, screenDC, ref topLoc, ref bitMapSize, memDc, ref srcLoc, 0, ref blendFunc, Win32.ULW_ALPHA);
				}
				finally
				{
					if (hBitmap != IntPtr.Zero)
					{
						Win32.SelectObject(memDc, oldBits);
						Win32.DeleteObject(hBitmap);
					}

					Win32.ReleaseDC(IntPtr.Zero, screenDC);
					Win32.DeleteDC(memDc);
				}

			}
			catch
			{
			}
		}

		//-------------------------------

		protected Image glowImage = null;
		protected Image glowImageNoFocus = null;

		protected Image GetGlowImage(bool focusIn = true)
		{
			if (glowImage != null)
			{
				if (focusIn)
					return glowImage;
				else
					return glowImageNoFocus;
			}
			Bitmap img = Resources.FormGlow;
			Bitmap bmp = new Bitmap(img.Width, img.Height);

			Color themeColor = GetThemeColor();
			for (int x = 0; x < img.Width; x++)
			{
				for (int y = 0; y < img.Height; y++)
				{
					Color cSource = img.GetPixel(x, y);
					Color cTarget = Color.FromArgb(cSource.A, themeColor.R, themeColor.G, themeColor.B);

					bmp.SetPixel(x, y, cTarget);
				}
			}

			glowImage = bmp;
			glowImageNoFocus = img;


			if (focusIn)
				return glowImage;
			else
				return glowImageNoFocus;
		}

		protected virtual Color GetThemeColor()
		{
			if (Main is FlatForm)
			{
				if (Main.ThemeColor != Color.Transparent)
				{
					return Main.ThemeColor;
				}
			}

			return ThorColors.Focus;
		}

		protected virtual void DrawSkinForm(Graphics g)
		{
			Rectangle rectSkin = new Rectangle(Main.Bounds.X, Main.Bounds.Y, Main.Bounds.Width, Main.Bounds.Height);
			rectSkin.X -= SKIN_FORM_BLOW_SIZE;
			rectSkin.Y -= SKIN_FORM_BLOW_SIZE;
			rectSkin.Width += SKIN_FORM_BLOW_SIZE * 2;
			rectSkin.Height += SKIN_FORM_BLOW_SIZE * 2;

			#region 绘制外观

			//g.Clear(Color.FromArgb(0x80, Color.Red));
			Image glow = GetGlowImage(Main.FocusIn);
			if (glow != null)
			{
				Rectangle glowScale9GridRect = new Rectangle(5, 5, 10, 10);
				rectSkin.X = 0;
				rectSkin.Y = 0;

				//g.FillRectangle(new SolidBrush(Color.FromArgb(0x80, Color.Red)), rectSkin);
				ThorScale9GridPaint.Draw(g, rectSkin, glow, glowScale9GridRect);
			}

			#endregion
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
