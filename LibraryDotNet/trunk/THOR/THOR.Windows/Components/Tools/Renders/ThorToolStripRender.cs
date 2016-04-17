/*
 * ThorToolStripRender
 * liuqiang@2015/11/8 17:14:24
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Windows.Components.Drawing;
using THOR.Windows.Dialogs;


//---- 8< ------------------

namespace THOR.Windows.Components.Tools.Renders
{
	public class ThorToolStripRender : ToolStripProfessionalRenderer
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		static ThorToolStripRender()
		{
			ThorToolStripRender.DefaultFont = new Font("Consolas", 8.25f);
		}

		public ThorToolStripRender()
			: base()
		{
			RenderThemeColor = Color.Transparent;
		}

		#endregion

		#region methods

		/// <summary>
		/// 绘制带区
		/// </summary>
		/// <param name="e"></param>
		protected override void OnRenderGrip(ToolStripGripRenderEventArgs e)
		{
			int m = 4;
			int c = 0;
			int s = 2;

			Pen p = ThorPens.BandDot;
			p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

			if (e.ToolStrip.Dock == DockStyle.Left || e.ToolStrip.Dock == DockStyle.Right)
			{
				c = (e.GripBounds.Width - m * 2) / s;

				for (int i = 0; i < c; i++)
				{
					e.Graphics.DrawLine(p,
						m + e.GripBounds.Left,
						i * s,
						e.GripBounds.Width - m,
						i * s);

				}
			}
			else if (e.ToolStrip.Dock == DockStyle.Top || e.ToolStrip.Dock == DockStyle.Bottom)
			{
				c = (e.GripBounds.Height - m * 2) / s;

				for (int i = 0; i < c; i++)
				{
					e.Graphics.DrawLine(p,
						i * s,
						m + e.GripBounds.Top,
						i * s,
						e.GripBounds.Height - m);

				}
			}
		}

		/// <summary>
		/// 绘制箭头
		/// </summary>
		/// <param name="e"></param>
		protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
		{
			if (e.Item.Selected)
			{
				e.ArrowColor = ThorColors.HighLightText;
			}
			else
			{
				e.ArrowColor = ThorColors.ControlText;
			}
			
			base.OnRenderArrow(e);
		}

		/// <summary>
		/// 绘制分隔线
		/// </summary>
		/// <param name="e"></param>
		protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
		{
			int m = 4;
			int c = 0;
			int s = 2;

			Pen p = ThorPens.BandDot;
			p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
			Rectangle rect = e.Item.Bounds;

			if (!e.Vertical)
			{
				c = 1;

				for (int i = 0; i < c; i++)
				{
					e.Graphics.DrawLine(p,
						m + rect.Top,
						i * s + rect.Height / 2,
						rect.Height - m,
						i * s + rect.Height / 2);

				}
			}
			else
			{
				c = 1;

				for (int i = 0; i < c; i++)
				{
					e.Graphics.DrawLine(p,
						i * s + rect.Width / 2,
						m + rect.Top,
						i * s + rect.Width / 2,
						rect.Height - m);

				}
			}
		}

		/// <summary>
		/// 菜单左边的图标区域
		/// </summary>
		/// <param name="e"></param>
		protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
		{
			//base.OnRenderImageMargin(e);
			//Rectangle rect = new Rectangle(0,0,e.AffectedBounds.Width, e.AffectedBounds.Height);
			//rect.X++;
			//rect.Y++;
			//rect.Width -= 2;
			//rect.Height -= 2;
			//e.Graphics.FillRectangle(ThorBrushs.Control, rect);
		}

		/// <summary>
		/// 绘制菜单项背景
		/// </summary>
		/// <param name="e"></param>
		protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
		{
			ToolStrip toolStrip = e.ToolStrip;
			ToolStripMenuItem button = (ToolStripMenuItem)e.Item;

			bool isSelected = button.Selected;
			bool isPressed = button.Pressed;
			bool isChecked = button.Checked;

			SolidBrush brush;
			Pen pen;

			Rectangle rect = new Rectangle(0, 0, button.Bounds.Width, button.Bounds.Height);

			if (isPressed)
			{
				brush = new SolidBrush(ColorPressFill);
				pen = new Pen(new SolidBrush(ColorPressBorder));
			}
			else if (isSelected)
			{
				brush = new SolidBrush(ColorHoverFill);
				pen = new Pen(new SolidBrush(ColorHoverBorder));
			}
			//else if (isChecked)
			//{
			//	brush = new SolidBrush(ColorCheckFill);
			//	pen = new Pen(new SolidBrush(ColorCheckBorder));
			//}
			else
			{
				return;
			}

			Form f = GetForm(e.ToolStrip);

			CheckBrushColor(f, brush);
			CheckPenColor(f, pen);

			if (brush != null)
			{
				e.Graphics.FillRectangle(brush, rect);
			}

			if (pen != null)
			{
				rect.Width--;
				rect.Height--;
				e.Graphics.DrawRectangle(pen, rect);
			}
		}



		/// <summary>
		/// 绘制分隔按钮
		/// </summary>
		/// <param name="e"></param>
		protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
		{
			ToolStrip toolStrip = e.ToolStrip;
			ToolStripSplitButton button = (ToolStripSplitButton)e.Item;

			bool isSelectedButton = button.ButtonSelected;
			bool isSelectedDrop = button.DropDownButtonSelected;

			bool isPressedButton = button.ButtonPressed;
			bool isPressedDrop = button.DropDownButtonPressed;



			SolidBrush brushButton = null;
			SolidBrush brushDrop = null;
			Pen pen = null;

			if (isSelectedDrop || isSelectedButton)
			{
				brushButton = new SolidBrush(ColorCheckFill);
				brushDrop = new SolidBrush(ColorCheckFill);
				pen = new Pen(new SolidBrush(ColorHoverBorder));
			}

			if (isPressedDrop || isPressedButton)
			{
				pen = new Pen(new SolidBrush(ColorPressBorder));
			}

			if (isPressedButton)
			{
				brushButton = new SolidBrush(ColorPressFill);
			}
			else if (isSelectedButton)
			{
				brushButton = new SolidBrush(ColorHoverFill);
			}

			if (isPressedDrop)
			{
				brushDrop = new SolidBrush(ColorPressFill);
			}
			else if (isSelectedDrop)
			{
				brushDrop = new SolidBrush(ColorHoverFill);
			}


			CheckBrushColor(e.ToolStrip.FindForm(), brushButton);
			CheckBrushColor(e.ToolStrip.FindForm(), brushDrop);
			CheckPenColor(e.ToolStrip.FindForm(), pen);

			if (brushButton != null)
			{
				e.Graphics.FillRectangle(brushButton, button.ButtonBounds);
			}
			if (brushDrop != null)
			{
				e.Graphics.FillRectangle(brushDrop, button.DropDownButtonBounds);
			}



			if (pen != null)
			{
				Rectangle rect = new Rectangle(0, 0, button.Bounds.Width, button.Bounds.Height);
				rect.Width--;
				rect.Height--;
				e.Graphics.DrawRectangle(pen, rect);

				rect.X += button.ButtonBounds.Width;

				e.Graphics.DrawLine(pen,
					rect.X,
					rect.Top,
					rect.X,
					rect.Bottom);
			}

			Rectangle rectArrow = new Rectangle(button.DropDownButtonBounds.X, button.DropDownButtonBounds.Y, button.DropDownButtonBounds.Width, button.DropDownButtonBounds.Height);

			int offsetArrow = 1;
			rectArrow.Y += offsetArrow;
			rectArrow.Height -= offsetArrow;
			ThorControlPaint.DrawArrow(e.Graphics, rectArrow, ThorColors.HighLightText);
		}

		/// <summary>
		/// 绘制下拉按钮背景
		/// </summary>
		/// <param name="e"></param>
		protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
		{
			ToolStrip toolStrip = e.ToolStrip;
			ToolStripDropDownButton button = (ToolStripDropDownButton)e.Item;

			bool isSelected = button.Selected;
			bool isPressed = button.Pressed;
			bool isChecked = false;

			SolidBrush brush;
			Pen pen;

			Rectangle rect = new Rectangle(0, 0, button.Bounds.Width, button.Bounds.Height);

			if (isPressed)
			{
				brush = new SolidBrush(ColorPressFill);
				pen = new Pen(new SolidBrush(ColorPressBorder));
			}
			else if (isSelected)
			{
				brush = new SolidBrush(ColorHoverFill);
				pen = new Pen(new SolidBrush(ColorHoverBorder));
			}
			else if (isChecked)
			{
				brush = new SolidBrush(ColorCheckFill);
				pen = new Pen(new SolidBrush(ColorCheckBorder));
			}
			else
			{
				return;
			}


			CheckBrushColor(e.ToolStrip.FindForm(), brush);
			CheckPenColor(e.ToolStrip.FindForm(), pen);

			if (brush != null)
			{
				e.Graphics.FillRectangle(brush, rect);
			}

			if (pen != null)
			{
				rect.Width--;
				rect.Height--;
				e.Graphics.DrawRectangle(pen, rect);
			}
		}



		/// <summary>
		/// 绘制项目背景
		/// </summary>
		/// <param name="e"></param>
		protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
		{
			base.OnRenderItemBackground(e);
		}

		/// <summary>
		/// 绘制边框
		/// </summary>
		/// <param name="e"></param>
		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
		{
		}

		/// <summary>
		/// 绘制工具栏背景
		/// </summary>
		/// <param name="e"></param>
		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
		{
			e.Graphics.Clear(ThorColors.Control);

			if (e.ToolStrip is ContextMenuStrip
				|| e.ToolStrip is ToolStripDropDown)
			{
				Form f = GetForm(e.ToolStrip);

				Rectangle rect = new Rectangle(0, 0, e.ToolStrip.Width, e.ToolStrip.Height);

				e.Graphics.FillRectangle(ThorBrushs.MenuBackground, rect);

				Pen p = ThorPens.HighLight;
				CheckPenColor(f, p);
				ThorControlPaint.DrawRectangle(e.Graphics, rect, p, false);
			}
		}

		protected Form GetForm(ToolStrip ts)
		{
			if (ts == null) return null;

			Form f = null;
			if (ts is ContextMenuStrip)
			{
				ContextMenuStrip cms = (ContextMenuStrip)ts;
				if (cms.SourceControl != null)
				{
					f = cms.SourceControl.FindForm();
				}
			}
			else if (ts is ToolStripDropDown)
			{
				ToolStripDropDown d = (ToolStripDropDown)ts;
				f = d.OwnerItem.Owner.FindForm();
			}

			if (f == null)
			{
				f = ts.FindForm();
			}


			if (f == null)
			{
				if (ts is ToolStripDropDownMenu)
				{
					ToolStripDropDownMenu tsdd = (ToolStripDropDownMenu)ts;
					if (tsdd.OwnerItem != null)
					{
						if (tsdd.OwnerItem.Owner != null)
						{
							return GetForm(tsdd.OwnerItem.Owner);
						}
					}
				}
				return f;
			}

			return f;
		}

		protected override void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
		{
			//base.OnRenderStatusStripSizingGrip(e);
		}

		/// <summary>
		/// 绘制按钮背景
		/// </summary>
		/// <param name="e"></param>
		protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
		{
			ToolStrip toolStrip = e.ToolStrip;
			ToolStripButton button = (ToolStripButton)e.Item;

			bool isSelected = button.Selected;
			bool isPressed = button.Pressed;
			bool isChecked = button.Checked;

			SolidBrush brush;
			Pen pen;

			Rectangle rect = new Rectangle(0, 0, button.Bounds.Width, button.Bounds.Height);

			if (isPressed)
			{
				brush = new SolidBrush(ColorPressFill);
				pen = new Pen(new SolidBrush(ColorPressBorder));
			}
			else if (isSelected)
			{
				brush = new SolidBrush(ColorHoverFill);
				pen = new Pen(new SolidBrush(ColorHoverBorder));
			}
			else if (isChecked)
			{
				brush = new SolidBrush(ColorCheckFill);
				pen = new Pen(new SolidBrush(ColorCheckBorder));
			}
			else
			{
				return;
			}

			CheckBrushColor(e.ToolStrip.FindForm(), brush);
			CheckPenColor(e.ToolStrip.FindForm(), pen);

			if (brush != null)
			{

				e.Graphics.FillRectangle(brush, rect);
			}

			if (pen != null)
			{

				rect.Width--;
				rect.Height--;
				e.Graphics.DrawRectangle(pen, rect);
			}
		}

		/// <summary>
		/// 绘制项目文本
		/// </summary>
		/// <param name="e"></param>
		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
		{
			Color textColor = ThorColors.ControlText;
			if (!e.Item.Enabled)
			{
				textColor = ThorColors.GrayText;
			}
			else
			{
				if (e.Item.Selected || e.Item.Pressed)
				{
					textColor = ThorColors.HighLightText;
				}
			}

			TextRenderer.DrawText(e.Graphics,
				e.Text,
				e.TextFont,
				e.TextRectangle,
				textColor,
				e.TextFormat);
		}



		virtual protected void CheckBrushColor(Form form, Brush brush)
		{
			if (brush is SolidBrush == false) return;
			if (form is FlatForm)
			{
				FlatForm ff = (FlatForm)form;
				if (ff.ThemeColor != Color.Transparent)
				{
					SolidBrush b = (SolidBrush)brush;
					b.Color = Color.FromArgb(b.Color.A, ff.ThemeColor.R, ff.ThemeColor.G, ff.ThemeColor.B);
					return;
				}
			}

			{
				if (RenderThemeColor != Color.Transparent)
				{
					SolidBrush b = (SolidBrush)brush;
					b.Color = Color.FromArgb(b.Color.A, RenderThemeColor.R, RenderThemeColor.G, RenderThemeColor.B);
				}
			}
		}

		virtual protected void CheckPenColor(Form form, Pen pen)
		{
			if (pen == null) return;
			if (form is FlatForm)
			{
				FlatForm ff = (FlatForm)form;
				if (ff.ThemeColor != Color.Transparent)
				{
					pen.Color = Color.FromArgb(pen.Color.A, ff.ThemeColor.R, ff.ThemeColor.G, ff.ThemeColor.B);
					return;
				}
			}

			{
				if (RenderThemeColor != Color.Transparent)
				{
					pen.Color = Color.FromArgb(pen.Color.A, RenderThemeColor.R, RenderThemeColor.G, RenderThemeColor.B);
				}
			}
		}

		/// <summary>
		/// 绘制复选项
		/// </summary>
		/// <param name="e"></param>
		protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
		{
			if (e.Item.Image == null)
			{
				int s = 5;

				Rectangle rect = new Rectangle();
				rect.Width = s;
				rect.Height = s;
				rect.Y = (e.ImageRectangle.Height - s) / 2;
				rect.X = rect.Y;

				rect.X += e.ImageRectangle.X + 2;
				rect.Y += e.ImageRectangle.Y - 2;


				Form f = GetForm(e.ToolStrip);
				SolidBrush brush = new SolidBrush(ColorPressBorder);

				CheckBrushColor(f, brush);


				e.Graphics.FillRectangle(brush, rect);
			}
			else
			{
				Debug.WriteLine("?");
			}
		}

		protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
		{
			if (e.Item is ToolStripMenuItem)
			{
				//菜单项的
				//ThorControlPaint.DrawIcon(e.Graphics, e.ImageRectangle, e.Image);
				Rectangle rect = new Rectangle(e.ImageRectangle.X, e.ImageRectangle.Y, e.ImageRectangle.Width, e.ImageRectangle.Height);
				rect.X--;
				rect.Y--;
				rect.Width += 2;
				rect.Height += 2;

				Form f = GetForm(e.ToolStrip);
				Pen p = new Pen(new SolidBrush(ColorHoverBorder));

				CheckPenColor(f, p);

				ThorControlPaint.DrawRectangle(e.Graphics, rect, p, false);
			}

			int a = e.Item.Enabled ? 0xFF : 0x30;
			ThorControlPaint.DrawIcon(e.Graphics, e.ImageRectangle, e.Image, a);
		}

		#endregion

		#region properties

		public Color RenderThemeColor { get; set; }

		static public Font DefaultFont { get; private set; }

		//复选

		public Color ColorCheckFill
		{
			get
			{
				return Color.FromArgb(0x20, ThorColors.HighLight);
			}
		}

		public Color ColorCheckBorder
		{
			get
			{
				return Color.FromArgb(0x40, ThorColors.HighLight);
			}
		}

		//默认 - 指向

		public Color ColorHoverFill
		{
			get
			{
				return Color.FromArgb(0x40, ThorColors.HighLight);
			}
		}

		public Color ColorHoverBorder
		{
			get
			{
				return Color.FromArgb(0x80, ThorColors.HighLight);
			}
		}

		//默认 - 按下

		public Color ColorPressFill
		{
			get
			{
				return Color.FromArgb(0x80, ThorColors.HighLight);
			}
		}

		public Color ColorPressBorder
		{
			get
			{
				return Color.FromArgb(0xFF, ThorColors.HighLight);
			}
		}

		#endregion

		#region events

		#endregion
	}
}
