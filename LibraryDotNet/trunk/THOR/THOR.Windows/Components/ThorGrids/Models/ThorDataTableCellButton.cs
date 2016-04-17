/*
 * ThorDataTableCellButton
 * liuqiang@2015/11/28 9:47:08
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.Models
{
	public enum ThorDataTableCellButtonType
	{
		DropDown = 1,
		ModalDialog = 2,
		Other = 3
	}

	/// <summary>
	/// 单元格的附加按钮信息
	/// </summary>
	public class ThorDataTableCellButton
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public ThorDataTableCellButton()
		{
			Bounds = new Rectangle();
			ButtonType = ThorDataTableCellButtonType.Other;
		}
		#endregion

		#region methods

		#endregion

		#region properties

		public Rectangle Bounds { get; set; }
		public Object Tag { get; set; }
		public ThorDataTableCellButtonType ButtonType { get; set; }
		#endregion

		#region events

		#endregion
	}
}
