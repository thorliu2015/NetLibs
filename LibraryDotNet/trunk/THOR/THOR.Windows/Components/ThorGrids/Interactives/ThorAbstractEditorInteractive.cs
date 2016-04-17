/*
 * ThorAbstractEditorInteractive
 * liuqiang@2015/11/24 14:37:40
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.Components.ThorGrids.Core;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.Interactives
{
	public class ThorAbstractEditorInteractive : IEditorInteractive
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public ThorAbstractEditorInteractive()
			: base()
		{
		}

		#endregion

		#region methods

		#region 文本编辑

		public bool AllowEditText(ThorGrid grid)
		{
			return true;
		}

		public void OpenEditText(ThorGrid grid)
		{

		}

		public void EnterEditText(ThorGridCellEditArgs e)
		{

		}

		public void LeaveEditText(ThorGridCellEditArgs e)
		{

		} 

		#endregion

		#region 下拉

		public bool AllowDropDown(ThorGrid grid)
		{
			if (grid.SelectedRow != null && grid.SelectedCell != null)
			{
				if (grid.SelectedCell.DataType != null)
				{
					//枚举
					if (grid.SelectedCell.DataType.IsEnum) return true;

					//逻辑
					if (grid.SelectedCell.DataType == typeof(System.Boolean)) return true;
				}
			}
			return false;
		}

		public void OpenDropDown(ThorGrid grid)
		{

		}

		public void EnterDropDown(ThorGridCellEditArgs e)
		{

		}

		public void LeaveDropDown(ThorGridCellEditArgs e)
		{

		} 

		#endregion

		#region 对话框

		public bool AllowModalDialog(ThorGrid grid)
		{
			if (grid.SelectedRow != null && grid.SelectedCell != null)
			{
				if (grid.SelectedCell.DataType != null)
				{
					//字体
					if (grid.SelectedCell.DataType == typeof(System.Drawing.Font)) return true;
					//颜色
					if (grid.SelectedCell.DataType == typeof(System.Drawing.Color)) return true;
				}
			}
			return false;
		}

		public void OpenModalDialog(ThorGrid grid)
		{

		}

		public void EnterModalDialog(ThorGridCellEditArgs e)
		{

		}

		public void LeaveModalDialog(ThorGridCellEditArgs e)
		{

		} 
		#endregion

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
		
	}
}
