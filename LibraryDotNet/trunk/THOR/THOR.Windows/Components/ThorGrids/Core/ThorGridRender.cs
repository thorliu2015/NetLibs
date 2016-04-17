/*
 * ThorGridRender
 * liuqiang@2015/11/19 14:44:37
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
using THOR.Windows.Components.ThorGrids.Interactives;
using THOR.Windows.Components.ThorGrids.Models;
using THOR.Windows.Components.ThorGrids.TypeConverters;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.Core
{
	public class ThorGridRender : ThorAbstractGridRender
	{
		#region constants

		protected const int CELL_BUTTON_DROPDOWN = 1;
		protected const int CELL_BUTTON_DIALOG = 2;

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		/// <summary>
		/// 绘制单元
		/// </summary>
		/// <param name="e"></param>
		public virtual void DrawCell(ThorGridCellRenderArgs e)
		{
			if (e.Grid is ThorGrid == false) return;
			if (e.Grid.DataTable == null) return;
			ThorGrid g = (ThorGrid)e.Grid;

			if (e.Row.Rows.Count > 0)
			{
				if (e.ColumnIndex > 0) return;

				e.Bounds = new Rectangle(0, e.Bounds.Y, g.Width, e.Bounds.Height);
			}


			e.Cell.CellBounds = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
			DrawCellBackground(e, g);
			DrawCellForeground(e, g);
		}


		/// <summary>
		/// 绘制单元前景
		/// </summary>
		/// <param name="e"></param>
		/// <param name="g"></param>
		public virtual void DrawCellForeground(ThorGridCellRenderArgs e, ThorGrid g)
		{
			//改成正式的外观绘制
			Rectangle rectText = new Rectangle();
			rectText.X = e.Bounds.X;
			rectText.Y = e.Bounds.Y;
			rectText.Width = e.Bounds.Width;
			rectText.Height = e.Bounds.Height;

			int normalPadding = 4;

			//折叠图标
			int foldPadding = 12;
			if (e.ColumnIndex == 0)
			{
				if (e.Row.Rows.Count > 0)
				{
					Rectangle rectFold = new Rectangle(e.Bounds.X + normalPadding, e.Bounds.Y, foldPadding, e.Bounds.Height);
					e.Row.FoldBounds = rectFold;
					ThorControlPaint.DrawFold(e.Graphics, rectFold, e.Row.IsExpanded, ThorColors.GridGroupFoldFore, Color.Transparent, ThorColors.GridGroupFoldBorder);
				}
			}


			//内容
			rectText.X += normalPadding;
			rectText.Width -= normalPadding;
			if (e.ColumnIndex == 0)
			{
				rectText.X += foldPadding;
				rectText.Width -= foldPadding;
			}

			//下拉按钮和弹出按钮
			rectText = DrawCellButtons(e, g, rectText);

			//绘制文本
			DrawCellText(e, g, rectText);
		}

		/// <summary>
		/// 绘制下拉和弹出按钮
		/// </summary>
		/// <param name="e"></param>
		/// <param name="g"></param>
		/// <param name="rect"></param>
		/// <returns></returns>
		public virtual Rectangle DrawCellButtons(ThorGridCellRenderArgs e, ThorGrid g, Rectangle rect)
		{

			Rectangle ret = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
			if (g.SelectedRow == null) return ret;
			if (g.SelectedRow.Rows.Count > 0) return ret;
			if (e.Cell == g.SelectedCell)
			{
				IEditorInteractive editor = g.GetEditor(e.Cell);
				if (editor != null)
				{
					bool canDropDown = editor.AllowDropDown(g);
					bool canModalDialog = editor.AllowModalDialog(g);

					if (!canDropDown && !canModalDialog) return ret;

					List<int> btns = new List<int>();
					if (canModalDialog) btns.Add(CELL_BUTTON_DIALOG);
					if (canDropDown) btns.Add(CELL_BUTTON_DROPDOWN);

					//从右向左画按钮
					Rectangle rectButton = new Rectangle();
					rectButton.Width = 14;	//按钮宽度
					rectButton.Height = g.RowHeight;
					rectButton.X = rect.Right - rectButton.Width;
					rectButton.Y = rect.Top;

					for (int i = 0; i < btns.Count; i++)
					{
						ThorDataTableCellButton buttonInfo = new ThorDataTableCellButton();
						
						buttonInfo.Bounds = new Rectangle(rectButton.X, rectButton.Y, rectButton.Width, rectButton.Height);

						//....
						switch (btns[i])
						{
							case CELL_BUTTON_DROPDOWN:
								buttonInfo.ButtonType = ThorDataTableCellButtonType.DropDown;
								ThorControlPaint.DrawArrow(e.Graphics, rectButton, ThorColors.GridFocusForeground);
								break;

							case CELL_BUTTON_DIALOG:
								buttonInfo.ButtonType = ThorDataTableCellButtonType.ModalDialog;
								ThorControlPaint.DrawDotDotDot(e.Graphics, rectButton, ThorColors.GridFocusForeground);
								break;
						}

						e.Cell.Buttons.Add(buttonInfo);

						rectButton.X -= rectButton.Width;
						ret.Width -= rectButton.Width;

					
					}
				}
			}

			return ret;
		}

		/// <summary>
		/// 绘制文本
		/// </summary>
		/// <param name="e"></param>
		/// <param name="g"></param>
		/// <param name="rect"></param>
		public virtual void DrawCellText(ThorGridCellRenderArgs e, ThorGrid g, Rectangle rect)
		{
			IThorTypeConverter converter = g.GetConverter(e.Cell);
			if (converter == null) return;

			object cellData = e.Cell.Data;
			Type cellType = e.Cell.DataType;

			if (cellType == null)
			{
				cellType = typeof(string);
				cellData = e.Cell.Text;
			}

			if (!converter.AllowGetText(cellData, cellType)) return;
			string cellText = converter.GetText(cellData, cellType);

			TextFormatFlags tf = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine;
			Color tc = ThorColors.GridNormalForeground;


			if (e.RowIndex < e.GridControl.FixedRows)// || e.ColumnIndex < e.GridControl.FixedColumns)
			{
				tc = ThorColors.GridFixedRowForeground;
			}
			else if (e.Row.Rows.Count > 0)
			{
				tc = ThorColors.GridGroupForeground;
			}
			else if (g.SelectedRow == e.Row)
			{
				tc = ThorColors.GridFocusForeground;
			}

			e.Cell.TextBounds = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);

			TextRenderer.DrawText(e.Graphics, cellText, e.Grid.Font, rect, tc, tf);
		}

		/// <summary>
		/// 绘制单元背景
		/// </summary>
		/// <param name="e"></param>
		/// <param name="g"></param>
		public virtual void DrawCellBackground(ThorGridCellRenderArgs e, ThorGrid g)
		{
			Color colorBg = ThorColors.GridNormalBackground;
			Color colorRightLine = ThorColors.GridNormalGrid;
			Color colorBottomLine = ThorColors.GridNormalGrid;

			//----

			if (e.RowIndex < g.FixedRows)
			{
				colorBg = ThorColors.GridFixedRowBackground;
				colorRightLine = ThorColors.GridFixedRowGrid;
				colorBottomLine = ThorColors.GridFixedRowGrid;
			}
			else if (e.Row.Rows.Count > 0)
			{
				colorBg = ThorColors.GridGroupBackground;
				colorRightLine = ThorColors.GridGroupGrid;
				colorBottomLine = ThorColors.GridGroupGrid;
			}
			else if (e.ColumnIndex < g.FixedColumns)
			{
				colorRightLine = ThorColors.GridFixedColumnGrid;

				if (g.SelectedRow == e.Row)
				{
					colorBg = ThorColors.GridFixedColumnFocusBackground;
				}
				else
				{
					colorBg = ThorColors.GridFixedColumnBackground;
				}
			}
			else if (g.SelectedRow == e.Row)
			{
				//if (e.GridControl.FocusIn)
				//{
				//	colorBg = Color.FromArgb(0x40, e.ThemeColor);
				//}
				//else
				{
					colorBg = ThorColors.GridFocusBackground;
				}
				colorRightLine = ThorColors.GridNormalGrid;
			}

			//----

			SolidBrush brushBg = new SolidBrush(colorBg);
			Pen penRightLine = new Pen(new SolidBrush(colorRightLine));
			Pen penBottomLine = new Pen(new SolidBrush(colorBottomLine));


			e.Graphics.FillRectangle(brushBg, e.Bounds);

			e.Graphics.DrawLine(penRightLine, e.Bounds.Right, e.Bounds.Top, e.Bounds.Right, e.Bounds.Bottom);		//right
			e.Graphics.DrawLine(penBottomLine, e.Bounds.Left, e.Bounds.Bottom, e.Bounds.Right, e.Bounds.Bottom);	//bottom
		}

		/// <summary>
		/// 绘制选定的单元
		/// </summary>
		/// <param name="e"></param>
		public virtual void DrawSelectedCell(ThorGridCellRenderArgs e)
		{
			if (e.Row.Rows.Count > 0) return;
			if (e.RowIndex < e.GridControl.FixedRows) return;
			if (e.ColumnIndex < e.GridControl.FixedColumns) return;

			//if (e.GridControl.FocusIn)
			//{
				e.Graphics.DrawRectangle(new Pen(new SolidBrush(e.ThemeColor)), e.Bounds);
			//}
			//else
			//{
			//	e.Graphics.DrawRectangle(ThorPens.GridFocusGrid, e.Bounds);
			//}
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
