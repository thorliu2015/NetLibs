/*
 * ThorDataTableMember
 * liuqiang@2015/11/7 8:40:12
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.Models
{
	public class ThorDataTableMember
	{
		#region constants

		#endregion

		#region variables

		protected ThorDataTable _OwnerTable = null;

		#endregion

		#region construct

		#endregion

		#region methods

		protected virtual ThorDataTable GetOwnerTable()
		{
			return _OwnerTable;
		}

		#endregion

		#region properties

		public int CollectionIndex { get; internal set; }
		public CollectionBase OwnerCollection { get; internal set; }
		public ThorDataTable OwnerTable
		{
			get
			{
				return GetOwnerTable();
			}
			internal set
			{
				_OwnerTable = value;
			}
		}

		#endregion

		#region events

		#endregion
	}
}
