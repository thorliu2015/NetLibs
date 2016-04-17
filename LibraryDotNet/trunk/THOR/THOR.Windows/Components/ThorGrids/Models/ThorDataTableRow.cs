/*
 * ThorDataTableRow
 * liuqiang@2015/11/7 8:06:53
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Common;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.Models
{
	/// <summary>
	/// 表示数据表的行
	/// </summary>
	public class ThorDataTableRow : ThorDataTableMember
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		public ThorDataTableRow()
		{
			Cells = new ThorDataTableMemberCollection<ThorDataTableCell>();
			Cells.OwnerTable = OwnerTable;

			Rows = new ThorDataTableMemberCollection<ThorDataTableRow>(this);
			Rows.OwnerTable = OwnerTable;

			IsExpanded = false;
		}

		#endregion

		#region methods

		public void ExpandToThis()
		{
			ThorDataTableRow row = this;

			while (row != null)
			{
				row.IsExpanded = true;
				row = row.ParentRow;
			}

			OwnerTable.Invalidated = true;
		}

		/// <summary>
		/// 展开所有节点
		/// </summary>
		public void ExpandAll()
		{
			_IsExpanded = true;

			foreach (ThorDataTableRow r in Rows)
			{
				r.ExpandAll();
			}
		}

		/// <summary>
		/// 收起所有节点
		/// </summary>
		public void CollapseAll()
		{
			_IsExpanded = false;

			foreach (ThorDataTableRow r in Rows)
			{
				r.CollapseAll();
			}
		}


		/// <summary>
		/// 获取隶属表格
		/// </summary>
		/// <returns></returns>
		protected override ThorDataTable GetOwnerTable()
		{
			if (_OwnerTable == null)
			{
				if (ParentRow != null)
				{
					return ParentRow.GetOwnerTable();
				}
				else
				{
					return null;
				}
			}
			else
			{
				return base.GetOwnerTable();
			}
		}

		/// <summary>
		/// 获取整个表的下一行
		/// </summary>
		/// <returns></returns>
		public ThorDataTableRow GetNextRow()
		{
			if (Rows.Count > 0)
			{
				//先考虑子级
				return Rows[0];
			}
			else
			{
				//如果有同级的下一节点
				ThorDataTableRow nextRow = this.NextRow;
				if (nextRow != null) return nextRow;
				else
				{
					ThorDataTableRow tmpRow = ParentRow;
					//父级...
					while (tmpRow != null)
					{
						nextRow = tmpRow.NextRow;
						if (nextRow != null)
						{
							return nextRow;
						}
						tmpRow = tmpRow.ParentRow;
					}

					return tmpRow;
				}
			}
		}


		/// <summary>
		/// 检查指定的行是否是当前行的子级或者孙级...
		/// </summary>
		/// <param name="row"></param>
		/// <returns></returns>
		public bool IsChildRow(ThorDataTableRow row)
		{
			if (this == row) return true;
			else if (Rows.Contains(row)) return true;
			else
			{
				foreach (ThorDataTableRow r in Rows)
				{
					if (r.IsChildRow(row)) return true;
				}

				return false;
			}
		}

		/// <summary>
		/// 获取各父级所有行
		/// </summary>
		/// <returns></returns>
		public List<ThorDataTableRow> GetParentRows()
		{
			List<ThorDataTableRow> r = new List<ThorDataTableRow>();

			ThorDataTableRow t = this.ParentRow;

			while (t != null)
			{
				r.Insert(0, t);
				t = t.ParentRow;
			}

			return r;
		}

		/// <summary>
		/// 获取文本信息
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			bool isFirst = true;

			foreach (ThorDataTableCell cell in Cells)
			{
				if (!isFirst)
				{
					sb.Append(",");
				}

				sb.Append(cell.ToString());
				isFirst = false;
			}

			return String.Format("{{{0}}}", sb.ToString());
		}


		/// <summary>
		/// 设置行是否为展开
		/// </summary>
		/// <param name="isExpanded"></param>
		/// <param name="updateNow"></param>
		public void SetIsExpanded(bool isExpanded, bool updateNow = true)
		{
			_IsExpanded = isExpanded;
			if (updateNow)
			{
				if (OwnerTable != null)
				{
					OwnerTable.Invalidated = true;
				}
			}
		}


		#endregion

		#region properties

		protected bool _IsExpanded = false;

		/// <summary>
		/// 获取或设置是否展开
		/// </summary>
		public bool IsExpanded
		{
			get
			{
				return _IsExpanded;
			}
			set
			{
				if (_IsExpanded == value) return;
				_IsExpanded = value;

				if (OwnerTable != null)
				{
					OwnerTable.Invalidated = true;
				}
			}
		}

		/// <summary>
		/// 获取表格单元集合
		/// </summary>
		public ThorDataTableMemberCollection<ThorDataTableCell> Cells { get; protected set; }

		/// <summary>
		/// 获取表格子级行集合
		/// </summary>
		public ThorDataTableMemberCollection<ThorDataTableRow> Rows { get; protected set; }

		/// <summary>
		/// 获取隶属的行
		/// </summary>
		public ThorDataTableRow ParentRow
		{
			get
			{
				if (OwnerCollection is ThorDataTableMemberCollection<ThorDataTableRow>)
				{
					ThorDataTableMemberCollection<ThorDataTableRow> c = ((ThorDataTableMemberCollection<ThorDataTableRow>)OwnerCollection);
					if (c.OwnerMember is ThorDataTableRow)
					{
						return (ThorDataTableRow)c.OwnerMember;
					}
				}

				return null;
			}
		}


		/// <summary>
		/// 是否包含子级行
		/// </summary>
		public bool HasChildRows
		{
			get
			{
				return Rows.Count > 0;
			}
		}


		/// <summary>
		/// 获取第一个子行
		/// </summary>
		public ThorDataTableRow FirstChildRow
		{
			get
			{
				if (Rows.Count > 0)
				{
					return Rows[0];
				}
				return null;
			}
		}

		/// <summary>
		/// 获取最后一个子行
		/// </summary>
		public ThorDataTableRow LastChildRow
		{
			get
			{
				if (Rows.Count > 0)
				{
					return Rows[Rows.Count - 1];
				}
				return null;
			}
		}

		/// <summary>
		/// 获取上一个同级行
		/// </summary>
		public ThorDataTableRow PrevRow
		{
			get
			{
				if (this.OwnerCollection is ThorDataTableMemberCollection<ThorDataTableRow>)
				{
					ThorDataTableMemberCollection<ThorDataTableRow> collection = (ThorDataTableMemberCollection<ThorDataTableRow>)this.OwnerCollection;

					int i = collection.IndexOf(this);
					if (i > 0)
					{
						return collection[i - 1];
					}
				}



				//ThorDataTableRow parent = ParentRow;

				//if (parent != null && parent.Rows.Count > 1)
				//{
				//	int i = parent.Rows.IndexOf(this);
				//	if (i > 0)
				//	{
				//		return parent.Rows[i - 1];
				//	}
				//}
				return null;
			}
		}

		/// <summary>
		/// 获取下一个同级行
		/// </summary>
		public ThorDataTableRow NextRow
		{
			get
			{
				if (this.OwnerCollection is ThorDataTableMemberCollection<ThorDataTableRow>)
				{
					ThorDataTableMemberCollection<ThorDataTableRow> collection = (ThorDataTableMemberCollection<ThorDataTableRow>)this.OwnerCollection;

					int i = collection.IndexOf(this);

					if (i < collection.Count - 1)
					{
						return collection[i + 1];
					}

				}

				//ThorDataTableRow parent = ParentRow;

				////顶级节点
				//if (parent == null)
				//{
				//	if (OwnerTable != null)
				//	{
				//		int i = OwnerTable.Rows.IndexOf(this);
				//		if (i >= 0)
				//		{
				//			if (i < OwnerTable.Rows.Count - 1)
				//			{
				//				return OwnerTable.Rows[i + 1];
				//			}
				//		}
				//	}
				//}

				//if (parent != null && parent.Rows.Count > 1)
				//{
				//	int i = parent.Rows.IndexOf(this);
				//	if (i < parent.Rows.Count - 1)
				//	{
				//		return parent.Rows[i + 1];
				//	}
				//}

				return null;
			}
		}

		/// <summary>
		/// 获取级别
		/// </summary>
		public int Level
		{
			get
			{
				int r = 0;

				ThorDataTableRow t = this.ParentRow;

				while (t != null)
				{
					r++;
					t = t.ParentRow;
				}

				return r;
			}
		}

		/// <summary>
		/// 获取路径
		/// </summary>
		public string Path
		{
			get
			{
				List<ThorDataTableRow> prs = this.GetParentRows();
				prs.Add(this);

				StringBuilder sb = new StringBuilder();
				bool isFirst = true;

				foreach (ThorDataTableRow r in prs)
				{
					if (!isFirst) sb.Append(@"/");
					isFirst = false;

					if (r.Cells.Count == 0) sb.Append("");
					else sb.Append(r.Cells[0].Text);
				}

				return sb.ToString();
			}

		}

		/// <summary>
		/// 显示区域
		/// </summary>
		public Rectangle DisplayBounds { get; set; }

		/// <summary>
		/// 折叠区域
		/// </summary>
		public Rectangle FoldBounds { get; set; }

		/// <summary>
		/// 关闭时的图标
		/// </summary>
		public Image ClosedIcon { get; set; }

		/// <summary>
		/// 打开时的图标
		/// </summary>
		public Image OpenedIcon { get; set; }

		/// <summary>
		/// 附加数据
		/// </summary>
		public object TagData { get; set; }

		#endregion

		#region events

		#endregion
	}
}
