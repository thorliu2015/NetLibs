/*
 * ThorListBox
 * liuqiang@2015/11/13 11:13:31
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Windows.Components.Common;
using THOR.Windows.Components.Drawing;
using THOR.Windows.Dialogs;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.ThorList
{
	/// <summary>
	/// 简单列表框
	/// </summary>
	public class ThorListBox : ThorScrollView
	{
		#region constants

		#endregion

		#region variables

		protected int _selectedListIndex = -1;

		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		public ThorListBox()
			: base()
		{
			InitListBox();
		}

		#endregion

		#region methods

		/// <summary>
		/// 初始化列表框
		/// </summary>
		virtual protected void InitListBox()
		{
			ListItemSize = 24;
			ListItemPadding = new Padding(2);
			SelectedObjects = new List<object>();

		}

		/// <summary>
		/// 初始化滚动条数据
		/// </summary>
		protected override void InitScrollBars()
		{
			base.InitScrollBars();

			this.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		}

		/// <summary>
		/// 布局滚动条
		/// </summary>
		protected override void LayoutScrollView()
		{
			base.LayoutScrollView();

			if (hScrollBar.Visible)
			{
				hScrollBar.SuspendLayout();
				hScrollBar.SmallChange = ListItemSize / 2;
				hScrollBar.ResumeLayout();
			}
			if (vScrollBar.Visible)
			{
				vScrollBar.SuspendLayout();
				vScrollBar.SmallChange = ListItemSize;
				vScrollBar.Maximum = MeasureItemCount() * ListItemSize;
				vScrollBar.ResumeLayout();
			}
		}



		/// <summary>
		/// 绘制滚动内容
		/// </summary>
		/// <param name="e"></param>
		protected override void DrawScrollContent(PaintEventArgs e)
		{
			//e.Graphics.SetClip(new Rectangle(borderSize, borderSize, Width - borderSize * 2, Height - borderSize * 2));

			if (_ListItems == null) return;

			int offsetIndex = vScrollBar.Value;
			if (offsetIndex < 0) offsetIndex = 0;

			int firstIndex = MeasureFirstIndex();
			int totalCount = MeasureItemCount();

			Rectangle rectItem = new Rectangle();

			rectItem.Height = ListItemSize;
			rectItem.Width = Width - borderSize * 2;
			if (vScrollBar.Visible)
			{
				rectItem.Width -= vScrollBar.Width;
			}
			rectItem.X = borderSize;

			int i = 0;

			IEnumerator iter = _ListItems.GetEnumerator();

			while (iter.MoveNext())
			{
				if (i >= firstIndex)
				{
					object listItemObject = iter.Current;

					rectItem.Y = borderSize + i * ListItemSize - offsetIndex;

					if (rectItem.Top > Bounds.Bottom) break;
					if (rectItem.Bottom < 0)
					{
						i++;
						continue;
					}
					DrawListItem(e.Graphics, i, listItemObject, rectItem);
				}

				i++;
			}
		}

		/// <summary>
		/// 绘制项目
		/// </summary>
		/// <param name="g"></param>
		/// <param name="index"></param>
		/// <param name="rect"></param>
		virtual protected void DrawListItem(Graphics g, int index, object data, Rectangle rect)
		{
			//Debug.WriteLine(String.Format("DrawListItem : {0}", index));
			Color foreColor = ThorColors.WindowText;
			Color backColor = ThorColors.Window;

			bool selected = SelectedObjects.Contains(data);
			if (selected)
			{
				foreColor = ThorColors.HighLightText;
				backColor = ThorColors.HighLight;

				Form f = this.FindForm();
				if (f is FlatForm)
				{
					FlatForm ff = (FlatForm)f;
					if (ff.ThemeColor != Color.Transparent)
					{
						backColor = Color.FromArgb(0x40, ff.ThemeColor);
					}
				}

				if (!focusIn)
				{
					backColor = ThorColors.Control;
				}
			}

			DrawListItemBackground(g, index, rect, data, backColor, selected);
			DrawListItemForeground(g, index, rect, data, foreColor);
		}

		protected virtual Color GetThemeColor()
		{
			Form f = this.FindForm();
			if (f is FlatForm)
			{
				FlatForm ff = (FlatForm)f;
				if (ff.ThemeColor != Color.Transparent)
				{
					return ff.ThemeColor;
				}
			}
			return ThorColors.Focus;
		}

		/// <summary>
		/// 绘制项目背景
		/// </summary>
		/// <param name="g"></param>
		/// <param name="index"></param>
		/// <param name="rect"></param>
		/// <param name="foreColor"></param>
		/// <param name="backColor"></param>
		protected virtual void DrawListItemBackground(Graphics g, int index, Rectangle rect, object data, Color backColor, bool selected = false)
		{
			Rectangle rectBorder = new Rectangle();
			rectBorder.X = rect.X;// +1;
			rectBorder.Y = rect.Y;
			rectBorder.Width = rect.Width;// -2;
			rectBorder.Height = rect.Height;

			g.FillRectangle(new SolidBrush(backColor), rectBorder);
			if (selected)
			{
				ThorControlPaint.DrawRectangle(g, rectBorder, new Pen(new SolidBrush(GetThemeColor())), false);
			}
		}

		/// <summary>
		/// 绘制项目前景
		/// </summary>
		/// <param name="g"></param>
		/// <param name="index"></param>
		/// <param name="rect"></param>
		/// <param name="foreColor"></param>
		/// <param name="backColor"></param>
		protected virtual void DrawListItemForeground(Graphics g, int index, Rectangle rect, object data, Color foreColor)
		{

			TextFormatFlags tf = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine;

			Rectangle rectText = DrawListItemIcons(g, index, rect);
			string itemText = "";

			if (data != null)
			{
				if (ListItemDisplayName.Trim().Length == 0)
				{
					itemText = data.ToString();
				}
				else
				{
					Type type = data.GetType();
					PropertyInfo p = type.GetProperty(ListItemDisplayName);
					if (p == null)
					{
						itemText = data.ToString();
					}
					else
					{
						itemText = p.GetValue(data).ToString();
					}
				}
			}
			//String.Format("(TEST) Item {0}", index + 1);
			TextRenderer.DrawText(g, itemText, Font, rectText, foreColor, tf);
		}

		/// <summary>
		/// 绘制项目图标
		/// </summary>
		/// <param name="g"></param>
		/// <param name="index"></param>
		/// <param name="rect"></param>
		/// <returns></returns>
		protected Rectangle DrawListItemIcons(Graphics g, int index, Rectangle rect)
		{

			Rectangle r = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);

			//r.X += ListItemSize;
			//rect.Width -= ListItemSize;

			return r;
		}

		/// <summary>
		/// 点击
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);
			SelectListItem(e.X, e.Y);
		}

		/// <summary>
		/// 选择指定位置的项目
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		virtual protected void SelectListItem(int x, int y)
		{
			x -= borderSize;
			y -= borderSize;

			y += vScrollBar.Value;

			int i = y / ListItemSize;

			_selectedListIndex = i;

			Object o = GetListItem(i);
			if (o == null) return;

			if (multiSelection)
			{
				if (SelectedObjects.Contains(o))
				{
					SelectedObjects.Remove(o);
				}
				else
				{
					SelectedObjects.Add(o);
				}
			}
			else
			{
				if (SelectedObjects.Contains(o)) return;
				SelectedObjects.Clear();
				SelectedObjects.Add(o);
			}

			this.Invalidate();
			if (SelectionChanged != null)
			{
				SelectionChanged(this, new EventArgs());
			}
		}

		/// <summary>
		/// 获取项目
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		virtual public Object GetListItem(int index)
		{
			if (ListItems == null || ListItems.Count == 0) return null;
			if (index < 0 || index > ListItems.Count - 1) return null;
			int i = 0;

			IEnumerator it = ListItems.GetEnumerator();

			while (it.MoveNext())
			{
				if (i == index) return it.Current;
				i++;
			}

			return null;
		}



		/// <summary>
		/// 计算第一个项目的索引
		/// </summary>
		/// <returns></returns>
		virtual protected int MeasureFirstIndex()
		{
			int result = vScrollBar.Value / ListItemSize;

			if (result * ListItemSize < vScrollBar.Value)
			{
				result--;
			}

			if (result < 0) result = 0;

			return result;
		}

		/// <summary>
		/// 计算项目数量
		/// </summary>
		/// <returns></returns>
		virtual protected int MeasureItemCount()
		{
			if (ListItems != null)
			{
				return _ListItems.Count;
			}
			return 0;
		}

		/// <summary>
		/// 选择对象
		/// </summary>
		/// <param name="items"></param>
		virtual public void SelectObjects(bool clean, params object[] items)
		{
			if (ListItems == null || ListItems.Count == 0) return;

			if (clean) SelectedObjects.Clear();

			foreach (Object item in items)
			{
				bool found = false;
				foreach (Object listItem in ListItems)
				{
					if (ListItems == item)
					{
						found = true;
						break;
					}
				}
				if (found)
				{
					SelectedObjects.Add(item);
				}

			}

			this.Invalidate();
			if (SelectionChanged != null) SelectionChanged(this, new EventArgs());
		}

		#endregion

		#region properties

		/// <summary>
		/// 获取或设置列表项的尺寸(通常是高度)
		/// </summary>
		public int ListItemSize { get; set; }

		/// <summary>
		/// 获取或设置列表项的内边距设置
		/// </summary>
		public Padding ListItemPadding { get; set; }

		#region Data

		protected ICollection _ListItems = null;
		protected string _ListItemDisplayName = "";
		protected bool multiSelection = false;


		/// <summary>
		/// 获取或设置列表项数据集
		/// </summary>
		public ICollection ListItems
		{
			get
			{
				return _ListItems;
			}
			set
			{
				_ListItems = value;
				this.LayoutScrollView();
				this.Invalidate();
			}
		}

		/// <summary>
		/// 获取或设置数据显示成员名称
		/// </summary>
		public string ListItemDisplayName
		{
			get
			{
				return _ListItemDisplayName;
			}
			set
			{
				_ListItemDisplayName = value;
				this.Invalidate();
			}
		}

		/// <summary>
		/// 选定的所有对象
		/// </summary>
		public List<Object> SelectedObjects { get; protected set; }

		/// <summary>
		/// 选定对象
		/// </summary>
		public Object SelectedObject
		{
			get
			{
				if (SelectedObjects.Count > 0)
				{
					return SelectedObjects[0];
				}
				return null;
			}
			set
			{
				SelectedObjects.Clear();
				if (value != null)
				{
					SelectedObjects.Add(value);
				}
			}
		}

		/// <summary>
		/// 获取或设置是否允许多选
		/// </summary>
		public bool MultiSelection
		{
			get
			{
				return multiSelection;
			}
			set
			{
				if (multiSelection == value) return;
				multiSelection = value;
				if (!multiSelection && SelectedObjects.Count > 1)
				{
					SelectedObjects.RemoveRange(1, SelectedObjects.Count - 1);
					this.Invalidate();
				}
			}
		}

		#endregion

		#endregion

		#region events

		public event EventHandler SelectionChanged;

		#endregion
	}
}
