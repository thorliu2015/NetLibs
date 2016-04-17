/*
 * ThorDataTable
 * liuqiang@2015/11/7 8:05:59
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Common;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.Models
{
	/// <summary>
	/// 表示数据表
	/// </summary>
	public class ThorDataTable
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		public ThorDataTable()
		{
			Columns = new ThorDataTableMemberCollection<ThorDataTableColumn>();
			Columns.OwnerTable = this;

			Rows = new ThorDataTableMemberCollection<ThorDataTableRow>();
			Rows.OwnerTable = this;

			Invalidated = true;
		}

		#endregion

		#region methods

		/// <summary>
		/// 展开所有内容
		/// </summary>
		public void ExpandAll()
		{
			foreach (ThorDataTableRow r in Rows)
			{
				r.ExpandAll();
			}

			Invalidated = true;
		}

		/// <summary>
		/// 收起所有内容
		/// </summary>
		public void CollapseAll()
		{
			foreach (ThorDataTableRow r in Rows)
			{
				r.CollapseAll();
			}
			Invalidated = true;
		}

		/// <summary>
		/// 对数据进行排序
		/// </summary>
		public virtual void Sort()
		{
			
		}


		#endregion

		#region properties

		/// <summary>
		/// 获取数据表的列
		/// </summary>
		public ThorDataTableMemberCollection<ThorDataTableColumn> Columns { get; protected set; }

		/// <summary>
		/// 获取数据表的行
		/// </summary>
		public ThorDataTableMemberCollection<ThorDataTableRow> Rows { get; protected set; }

		/// <summary>
		/// 数据是否需要重新整理
		/// </summary>
		public bool Invalidated { get; set; }

		#endregion

		#region events

		#endregion
	}
}
