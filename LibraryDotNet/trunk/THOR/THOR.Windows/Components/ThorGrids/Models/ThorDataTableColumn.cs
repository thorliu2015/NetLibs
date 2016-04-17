/*
 * ThorDataTableColumn
 * liuqiang@2015/11/7 8:06:31
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Common;
using THOR.Windows.Components.ThorGrids.Interactives;
using THOR.Windows.Components.ThorGrids.TypeConverters;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.Models
{
	/// <summary>
	/// 表示数据表的列
	/// </summary>
	public class ThorDataTableColumn : ThorDataTableMember
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public ThorDataTableColumn()
			: base()
		{
			Position = 0;
		}

		#endregion

		#region methods

		#endregion

		#region properties

		protected int _Width = 100;

		public int Position { get; set; }
		public int Width
		{
			get
			{
				return _Width;
			}
			set
			{
				if (_Width == value || value < 0) return;
				_Width = value;
				if (OwnerTable != null) OwnerTable.Invalidated = true;
			}
		}


		/// <summary>
		/// 编辑器接口
		/// </summary>
		public IEditorInteractive Editor { get; set; }

		/// <summary>
		/// 类型转换接口
		/// </summary>
		public IThorTypeConverter TypeConverter { get; set; }

		#endregion

		#region events

		#endregion
	}
}
