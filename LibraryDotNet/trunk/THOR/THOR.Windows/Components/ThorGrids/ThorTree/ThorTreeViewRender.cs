/*
 * ThorTreeViewRender
 * liuqiang@2015/11/14 19:43:22
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
using THOR.Windows.Components.ThorGrids.Core;
using THOR.Windows.Components.ThorGrids.Models;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.ThorTree
{
	public class ThorTreeViewRender : ThorAbstractGridRender
	{
		#region constants

		public const int THOR_TREE_VIEW_FOLD_BAR_SIZE_MINI = 18;
		public const int THOR_TREE_VIEW_TEXT_BACKGROUND_MARGIN = 1;

		#endregion

		#region variables

		#endregion

		#region construct

		public ThorTreeViewRender()
			: base()
		{
		}

		#endregion

		#region methods

		public override void DrawRowBackground(ThorGridRowRenderArgs e)
		{
			//base.DrawRowBackground(e);
		}

		public override void DrawRowForeground(ThorGridRowRenderArgs e)
		{
			if (e.Grid is ThorTreeView == false) return;
			ThorTreeView tree = (ThorTreeView)e.Grid;

			//整行范围
			Rectangle rectRow = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);

			//折叠
			Rectangle rectIndent = MeasureIndent(rectRow, tree, e.Row);
			Rectangle rectFold = new Rectangle(rectIndent.Right - THOR_TREE_VIEW_FOLD_BAR_SIZE_MINI, rectIndent.Y, THOR_TREE_VIEW_FOLD_BAR_SIZE_MINI, rectIndent.Height);
			e.Row.FoldBounds = rectFold;
			DrawIndent(e, rectFold, tree);

			//图标和内容
			DrawRowContent(e, rectRow, tree);
		}


		/// <summary>
		/// 绘制折叠图标和线
		/// </summary>
		/// <param name="e"></param>
		/// <param name="rectFold"></param>
		protected virtual void DrawIndent(ThorGridRowRenderArgs e, Rectangle rectFold, ThorTreeView tree)
		{
			//if (e.Row == null || e.Row.ParentRow == null) return;

			Point hPt1 = new Point();
			Point hPt2 = new Point();
			Point vPt1 = new Point();
			Point vPt2 = new Point();

			bool drawX = true;
			bool drawY = true;

			ThorDataTableRow row = e.Row;

			Pen penLine = ThorPens.Control;
			//penLine.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

			while (row != null)
			{
				drawX = true; drawY = true;

				int rowLevel = row.Level;

				//竖线
				vPt1.X = vPt2.X = rowLevel * tree.Indent + THOR_TREE_VIEW_FOLD_BAR_SIZE_MINI / 2;
				vPt1.Y = rectFold.Top;
				vPt2.Y = rectFold.Bottom;

				if (tree.Indent > 0)
				{
					if (rowLevel == 0)
					{
						if (row.PrevRow == null && row == e.Row)
						{
							vPt1.Y += rectFold.Height / 2;
						}
					}

					if (row.NextRow == null)
					{
						vPt2.Y -= rectFold.Height / 2;
						if (row != e.Row)
						{
							drawY = false;
						}
					}
				}

				if (drawY) e.Graphics.DrawLine(penLine, vPt1, vPt2);

				//横线
				if (row == e.Row)
				{
					hPt1.X = vPt1.X;
					hPt2.X = hPt1.X + THOR_TREE_VIEW_FOLD_BAR_SIZE_MINI / 2;
					hPt1.Y = rectFold.Top + rectFold.Height / 2;
					hPt2.Y = hPt1.Y;

					if (tree.Indent == 0 && row.NextRow != null)
					{
						drawX = false;
					}

					if (drawX) e.Graphics.DrawLine(penLine, hPt1, hPt2);
				}


				//---
				row = row.ParentRow;
			}

			if (e.Row.Rows.Count == 0) return;
			ThorControlPaint.DrawFold(e.Graphics, rectFold, e.Row.IsExpanded, ThorColors.ControlText, ThorColors.Window, ThorColors.ControlLight);


		}

		protected virtual void DrawRowContent(ThorGridRowRenderArgs e, Rectangle rectRow, ThorTreeView tree)
		{
			//图标
			Rectangle rectIcon = MeasureIcon(rectRow, tree, e.Row);
			if (rectIcon.Width > 0 && rectIcon.Height > 0)
			{
				//e.Graphics.FillRectangle(ThorBrushs.ControlDark, rectIcon);

				if (e.Row.IsExpanded)
				{
					if (e.Row.OpenedIcon != null)
					{
						ThorControlPaint.DrawIcon(e.Graphics, rectIcon, e.Row.OpenedIcon);
					}
				}
				else
				{
					if (e.Row.ClosedIcon != null)
					{
						ThorControlPaint.DrawIcon(e.Graphics, rectIcon, e.Row.ClosedIcon);
					}
				}
				
			}

			//绘制文本
			Rectangle rectText = MeasureText(rectRow, tree, e.Row);
			TextFormatFlags tf = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;
			e.Row.DisplayBounds = new Rectangle(rectText.X, rectRow.Y, rectText.Width, rectRow.Height);

			if (e.Row == tree.SelectedRow)
			{
				e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0x20, e.ThemeColor)),
					rectText.X + THOR_TREE_VIEW_TEXT_BACKGROUND_MARGIN,
					rectText.Y + THOR_TREE_VIEW_TEXT_BACKGROUND_MARGIN,
					rectText.Width - THOR_TREE_VIEW_TEXT_BACKGROUND_MARGIN * 2,
					rectText.Height - THOR_TREE_VIEW_TEXT_BACKGROUND_MARGIN * 2
					);

				e.Graphics.DrawRectangle(new Pen(new SolidBrush(e.ThemeColor)), rectText.X + THOR_TREE_VIEW_TEXT_BACKGROUND_MARGIN,
					rectText.Y + THOR_TREE_VIEW_TEXT_BACKGROUND_MARGIN,
					rectText.Width - THOR_TREE_VIEW_TEXT_BACKGROUND_MARGIN * 2,
					rectText.Height - THOR_TREE_VIEW_TEXT_BACKGROUND_MARGIN * 2);
			}
			TextRenderer.DrawText(e.Graphics, e.Row.Cells[0].Text, e.Grid.Font, rectText,
				(e.Row == tree.SelectedRow) ? ThorColors.HighLightText : ThorColors.WindowText, tf);
		}



		/// <summary>
		/// 计算图标区域
		/// </summary>
		/// <param name="rect"></param>
		/// <param name="tree"></param>
		/// <param name="row"></param>
		/// <returns></returns>
		protected virtual Rectangle MeasureIcon(Rectangle rect, ThorTreeView tree, ThorDataTableRow row)
		{
			Rectangle r = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);

			Rectangle rectIndent = MeasureIndent(rect, tree, row);

			int iconSize = r.Height;

			if (row.ClosedIcon == null) iconSize = 0;

			r.X = rectIndent.Right;
			r.Width = iconSize;
			if (r.Width < 0) r.Width = 0;

			return r;
		}

		/// <summary>
		/// 计算文本区域
		/// </summary>
		/// <param name="rect"></param>
		/// <param name="tree"></param>
		/// <param name="row"></param>
		/// <returns></returns>
		protected virtual Rectangle MeasureText(Rectangle rect, ThorTreeView tree, ThorDataTableRow row)
		{
			Rectangle r = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);

			Rectangle rectIcon = MeasureIcon(rect, tree, row);

			r.X = rectIcon.Right;
			r.Width = rect.Width - r.X;


			r = MeasureTextContent(r, tree, row);

			if (r.Width < 0) r.Width = 0;


			return r;
		}

		protected virtual Rectangle MeasureTextContent(Rectangle rect, ThorTreeView tree, ThorDataTableRow row)
		{
			Rectangle r = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);

			string rowText = "";

			if (row != null && row.Cells.Count > 0)
			{
				ThorDataTableCell cell = row.Cells[0];
				rowText = cell.Text.Trim();

				Size s = TextRenderer.MeasureText(rowText, tree.Font);

				r.Width = s.Width;

			}

			return r;
		}

		/// <summary>
		/// 计算缩进区域
		/// </summary>
		/// <param name="rect"></param>
		/// <param name="tree"></param>
		/// <param name="row"></param>
		/// <returns></returns>
		protected virtual Rectangle MeasureIndent(Rectangle rect, ThorTreeView tree, ThorDataTableRow row)
		{
			Rectangle r = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
			int indent = tree.Indent;
			if (indent < 0) indent = 0;

			r.Width = row.Level * indent;
			r.Width += THOR_TREE_VIEW_FOLD_BAR_SIZE_MINI;

			return r;
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
