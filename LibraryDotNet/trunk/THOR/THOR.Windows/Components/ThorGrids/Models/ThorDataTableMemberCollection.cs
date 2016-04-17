/*
 * ThorDataTableMemberCollection
 * liuqiang@2015/11/7 8:38:28
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
	public class ThorDataTableMemberCollection<T> : ThorCollection<T>
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public ThorDataTableMemberCollection()
		{
		}

		public ThorDataTableMemberCollection(ThorDataTableMember ownerMember)
		{
			this.OwnerMember = ownerMember;
		}

		#endregion

		#region methods

		protected void UpdateCollectionIndex()
		{
			for (int i = 0; i < List.Count; i++)
			{
				ThorDataTableMember member = (ThorDataTableMember)List[i];

				member.CollectionIndex = i;
			}
		}

		protected override void OnAdd(object item)
		{
			base.OnAdd(item);

			if (item is ThorDataTableMember)
			{
				((ThorDataTableMember)item).OwnerCollection = this;
				((ThorDataTableMember)item).OwnerTable = OwnerTable;

				if (this.OwnerTable != null) this.OwnerTable.Invalidated = true;
			}

			UpdateCollectionIndex();
		}

		protected override void OnRemove(object item)
		{
			base.OnRemove(item);

			if (item is ThorDataTableMember)
			{
				((ThorDataTableMember)item).OwnerCollection = null;
				((ThorDataTableMember)item).OwnerTable = null;

				if (this.OwnerTable != null) this.OwnerTable.Invalidated = true;
			}

			UpdateCollectionIndex();
		}


		#endregion

		#region properties

		protected ThorDataTable _OwnerTable = null;

		/// <summary>
		/// 获取隶属成员
		/// </summary>
		public ThorDataTableMember OwnerMember { get; internal set; }

		/// <summary>
		/// 获取隶属的表
		/// </summary>
		public ThorDataTable OwnerTable
		{
			get
			{
				return _OwnerTable;
			}
			internal set
			{
				if (_OwnerTable == value) return;
				_OwnerTable = value;
				if (_OwnerTable != null) _OwnerTable.Invalidated = true;
			}
		}

		#endregion

		#region events

		#endregion
	}
}
