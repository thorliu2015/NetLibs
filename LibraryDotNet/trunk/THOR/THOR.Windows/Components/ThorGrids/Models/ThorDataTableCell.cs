/*
 * ThorDataTableCell
 * liuqiang@2015/11/7 8:07:08
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using THOR.Attributes.Notes;
using THOR.Common;
using THOR.Windows.Components.ThorGrids.Interactives;
using THOR.Windows.Components.ThorGrids.TypeConverters;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.Models
{
	public class ThorDataTableCell : ThorDataTableMember
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public ThorDataTableCell()
		{
			Buttons = new List<ThorDataTableCellButton>();
			TextBounds = new Rectangle();
			CellBounds = new Rectangle();
		}

		#endregion

		#region methods

		public override string ToString()
		{
			return String.Format("{{{0}}}",Text);
		}

		public ThorDataTableRow GetRow()
		{
			if (this.OwnerCollection != null)
			{
				ThorDataTableMemberCollection<ThorDataTableRow> rows = (ThorDataTableMemberCollection<ThorDataTableRow>)OwnerCollection;
				if (rows.OwnerMember is ThorDataTableRow)
				{
					return (ThorDataTableRow)rows.OwnerMember;
				}
			}

			return null;
		}

		public ThorDataTableColumn GetColumn()
		{
			int index = CollectionIndex;

			if (OwnerTable != null)
			{
				if (index >= 0 && index < OwnerTable.Columns.Count)
				{
					return OwnerTable.Columns[index];
				}
			}
			return null;
		}

		#endregion

		#region properties

		protected string _Text = "";

		/// <summary>
		/// 获取或设置单元文本
		/// </summary>
		public string Text
		{
			get
			{
				return _Text;
			}
			set
			{
				if (_Text == value) return;
				_Text = value;
				if (this.OwnerTable != null) this.OwnerTable.Invalidated = true;
			}
		}

		/// <summary>
		/// 获取或设置单元的按钮
		/// </summary>
		public List<ThorDataTableCellButton> Buttons { get; set; }

		/// <summary>
		/// 获取或设置单元的文本范围
		/// </summary>
		public Rectangle TextBounds { get; set; }

		/// <summary>
		/// 获取或设置单元的矩形范围
		/// </summary>
		public Rectangle CellBounds { get; set; }

		/// <summary>
		/// 获取或设置单元绑定的属性信息
		/// </summary>
		public PropertyInfo CellBindPropertyInfo { get; set; }

		/// <summary>
		/// 获取或设置单元绑定的属性对象
		/// </summary>
		public Object CellBindPropertyObject { get; set; }

		#region 接口属性

		/// <summary>
		/// 编辑器接口
		/// </summary>
		public IEditorInteractive Editor { get; set; }

		/// <summary>
		/// 类型转换接口
		/// </summary>
		public IThorTypeConverter TypeConverter { get; set; }

		/// <summary>
		/// 数据类型
		/// </summary>
		public Type DataType { get; set; }

		/// <summary>
		/// 数据
		/// </summary>
		public object Data { get; set; }

		#endregion

		#endregion

		#region events

		#endregion

		
	}
}
