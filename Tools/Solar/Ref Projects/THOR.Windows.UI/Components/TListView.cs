using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using THOR.Windows.UI.Renders;
using System.Drawing;
using System.Collections;

namespace THOR.Windows.UI.Components
{
	/// <summary>
	/// 列表视图
	/// </summary>
	public class TListView : ListView
	{

		#region variables
		/// <summary>
		/// 当前排序列索引
		/// </summary>
		protected int sortColumnIndex = -1;

		/// <summary>
		/// 是否正序
		/// </summary>
		protected bool sortASC = true;

		#endregion

		#region construct
		/// <summary>
		/// 构造
		/// </summary>
		public TListView()
		{
			Init();
		}
		#endregion

		/// <summary>
		/// 初始化
		/// </summary>
		protected void Init()
		{
			DoubleBuffered = true;
			this.BorderStyle = BorderStyle.None;
			this.FullRowSelect = true;
			this.View = View.Details;
			this.GridLines = true;
			this.HideSelection = false;


			this.OwnerDraw = true;

			Dock = DockStyle.Fill;
		}

		/// <summary>
		/// 绘制图标
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		protected Image GetIcon(DrawListViewSubItemEventArgs e)
		{
			Image result = null;

			if (e.Item.ImageList != null && e.Item.ImageIndex >= 0 && e.Item.ImageIndex < e.Item.ImageList.Images.Count)
			{
				result = e.Item.ImageList.Images[e.Item.ImageKey];
				if (result == null)
					result = e.Item.ImageList.Images[e.Item.ImageIndex];
			}

			return result;
		}

		/// <summary>
		/// 获取图标范围
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		protected Rectangle GetIconRect(DrawListViewSubItemEventArgs e)
		{
			Rectangle result = new Rectangle();

			result.X = e.Bounds.X;
			result.Y = e.Bounds.Y;
			result.Width = 0;
			result.Height = 0;

			if (e.Item.ImageList != null)
			{
				result.Width = e.Item.ImageList.ImageSize.Width;
				result.Height = e.Item.ImageList.ImageSize.Height;

				result.Y += ((e.Bounds.Height - e.Item.ImageList.ImageSize.Height) / 2);
			}

			return result;
		}

		/// <summary>
		/// 获取文本范围
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		protected Rectangle GetTextRect(DrawListViewSubItemEventArgs e)
		{
			Rectangle result = new Rectangle();

			result.X = e.Bounds.X;
			result.Y = e.Bounds.Y;
			result.Width = e.Bounds.Width;
			result.Height = e.Bounds.Height;

			if (e.Item.ImageList != null && e.SubItem==e.Item.SubItems[0])
			{
				result.X += e.Item.ImageList.ImageSize.Width;
				result.Width -= e.Item.ImageList.ImageSize.Width;
			}

			return result;
		}

		/// <summary>
		/// 获取背景笔刷
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		protected Brush GetBackgroundBrush(DrawListViewSubItemEventArgs e)
		{
			if (!e.Item.Selected || this.SelectedItems.Count == 0)
			{
				return SystemBrushes.Window;
			}
			else
				return SystemBrushes.Highlight;
		}

		/// <summary>
		/// 获取文本颜色
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		protected Color GetTextColor(DrawListViewSubItemEventArgs e)
		{
			if (!e.Item.Selected || this.SelectedItems.Count == 0)
				return this.ForeColor;
			else
				return SystemColors.HighlightText;
		}



		/// <summary>
		/// 绘制项目
		/// </summary>
		/// <param name="e"></param>
		protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
		{
			e.DrawBackground();
			Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
			e.Graphics.FillRectangle(GetBackgroundBrush(e), rect);

			if (GridLines)
			{
				e.Graphics.DrawLine(SystemPens.Control, rect.Left, rect.Bottom - 1, rect.Right, rect.Bottom - 1);

				int p = 0;
				for (int i = 0; i < Columns.Count; i++)
				{
					p += Columns[i].Width;
					e.Graphics.DrawLine(SystemPens.Control, p, e.Bounds.Top, p, e.Bounds.Bottom - 1);
				}
			}


			string strDrawText = e.SubItem.Text;

			Rectangle rectIcon = GetIconRect(e);
			Rectangle rectText = GetTextRect(e);

			Image icon = GetIcon(e);
			if (icon != null && e.Item.SubItems[0] == e.SubItem)
			{
				e.Graphics.DrawImage(icon, rectIcon);
			}

			TextFormatFlags flags = TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter;
			switch (e.Header.TextAlign)
			{
				case HorizontalAlignment.Left:
					flags |= TextFormatFlags.Left;
					break;

				case HorizontalAlignment.Right:
					flags |= TextFormatFlags.Right;
					break;

				case HorizontalAlignment.Center:
					flags |= TextFormatFlags.VerticalCenter;
					break;
			}

			TextRenderer.DrawText(e.Graphics, strDrawText, this.Font, rectText, GetTextColor(e), flags);
		}

		/// <summary>
		/// 绘制表头
		/// </summary>
		/// <param name="e"></param>
		protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
		{
			OnDrawColumnBackground(e);
			OnDrawSortArrow(e);
			OnDrawColumnText(e);
		}

		/// <summary>
		/// 绘制表头背景
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnDrawColumnBackground(DrawListViewColumnHeaderEventArgs e)
		{
			if (this.SortColumnIndex == e.ColumnIndex)
			{
				Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
				rect.Height -= 1;
				e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0xFF, 0xF2, 0xF9, 0xFC)), rect);

				//e1f1f9
				//d8ecf6
				int tHeight = Convert.ToInt32(rect.Height * 0.4);
				rect.Height -= tHeight;
				rect.Y = tHeight;
				UIRender.DrawLinearGradienntRect(e.Graphics, rect, Color.FromArgb(0xe1, 0xf1, 0xf9), Color.FromArgb(0xd8, 0xec, 0xf6), 90);


				//96d9f9
				Pen pen = new Pen(new SolidBrush(Color.FromArgb(0x96, 0xd9, 0xf9)));
				e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Bottom - 2, e.Bounds.Right, e.Bounds.Bottom - 2);
				e.Graphics.DrawLine(pen, e.Bounds.Right - 1, e.Bounds.Top, e.Bounds.Right - 1, e.Bounds.Bottom - 2);
				e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Top, e.Bounds.Left, e.Bounds.Bottom - 2);
			}
			else
			{
				e.DrawBackground();
			}
		}

		/// <summary>
		/// 重绘列标题
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnDrawColumnText(DrawListViewColumnHeaderEventArgs e)
		{
			string strDrawText = this.Columns[e.ColumnIndex].Text;
			TextFormatFlags flags = TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter;
			switch (e.Header.TextAlign)
			{
				case HorizontalAlignment.Left:
					flags |= TextFormatFlags.Left;
					break;

				case HorizontalAlignment.Right:
					flags |= TextFormatFlags.Right;
					break;

				case HorizontalAlignment.Center:
					flags |= TextFormatFlags.VerticalCenter;
					break;
			}

			Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
			TextRenderer.DrawText(e.Graphics, strDrawText, this.Font, rect, ForeColor, flags);
		}

		/// <summary>
		/// 绘制排序箭头
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnDrawSortArrow(DrawListViewColumnHeaderEventArgs e)
		{
			if (e.ColumnIndex == this.SortColumnIndex)
			{
				//当前列是排序列
				Bitmap sortArrow;
				if (this.sortASC)
				{
					//正序
					sortArrow = UIResources.SortAsc;
				}
				else
				{
					//反序
					sortArrow = UIResources.SortDesc;
				}

				int ax = e.Bounds.Left + (e.Bounds.Width - sortArrow.Width) / 2;
				int ay = 1;
				UIRender.DrawBitmap(e.Graphics, sortArrow, ax, ay);
			}
			else
			{
				//当前列不是排序列
			}
		}

		/// <summary>
		/// 点击列头
		/// </summary>
		/// <param name="e"></param>
		protected override void OnColumnClick(ColumnClickEventArgs e)
		{
			if (sortColumnIndex != e.Column)
			{
				this.sortColumnIndex = e.Column;
				this.sortASC = true;
			}
			else
			{
				this.sortASC = !this.sortASC;
			}
			UpdateSort();

			this.Refresh();
		}


		/// <summary>
		/// 更新排序
		/// </summary>
		protected void UpdateSort()
		{
			if (this.sortColumnIndex < 0 || this.sortColumnIndex >= this.Columns.Count)
			{
				this.ListViewItemSorter = null;
				this.Sort();
			}
			else
			{
				this.ListViewItemSorter = new ListViewItemComparer(sortColumnIndex, sortASC);
			}
		}

		/// <summary>
		/// 获取或设置排序的列索引
		/// </summary>
		public int SortColumnIndex
		{
			get
			{
				return sortColumnIndex;
			}
			set
			{
				if (sortColumnIndex == value) return;
				sortColumnIndex = value;
				UpdateSort();
			}
		}

	}

	#region ListViewItemComparer
	public class ListViewItemComparer : IComparer
	{
		public bool sort_b;
		public SortOrder order = SortOrder.Ascending;

		private int col;

		public ListViewItemComparer()
		{
			col = 0;
		}

		public ListViewItemComparer(int column, bool sort)
		{
			col = column;
			sort_b = sort;
		}

		public int Compare(object x, object y)
		{
			ListViewItem xItem = (ListViewItem)x;
			ListViewItem yItem = (ListViewItem)y;

			string xStr = (xItem.SubItems.Count > col) ? xItem.SubItems[col].Text : "";
			string yStr = (yItem.SubItems.Count > col) ? yItem.SubItems[col].Text : "";

			Double xNum = 0;
			Double yNum = 0;

			bool xIsNum = Double.TryParse(xStr, out xNum);
			bool yIsNum = Double.TryParse(yStr, out yNum);

			//-1 <
			//0 =
			//1 >
			if (sort_b)
			{
				if (xIsNum && yIsNum)
				{
					if (xNum == yNum) return 0;
					else if (xNum > yNum) return 1;
					else if (xNum < yNum) return -1;
				}
				return String.Compare(xStr, yStr);
				//return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
			}
			else
			{
				if (xIsNum && yIsNum)
				{
					if (xNum == yNum) return 0;
					else if (xNum > yNum) return -1;
					else if (xNum < yNum) return 1;
				}

				return String.Compare(yStr, xStr);
				//return String.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);
			}
		}
	}
	#endregion
}
