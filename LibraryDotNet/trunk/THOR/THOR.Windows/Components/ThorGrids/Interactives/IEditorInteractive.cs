/*
 * IEditorInteractive
 * liuqiang@2015/11/24 14:12:15
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.Components.ThorGrids.Core;
using THOR.Windows.Components.ThorGrids.Models;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.Interactives
{
	/// <summary>
	/// 网格单元的编辑接口
	/// </summary>
	public interface IEditorInteractive
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		#region 文本编辑
		/// <summary>
		/// 是否允许编辑文本
		/// </summary>
		/// <returns></returns>
		bool AllowEditText(ThorGrid grid);

		/// <summary>
		/// 打开文本编辑
		/// </summary>
		void OpenEditText(ThorGrid grid);
		
		/// <summary>
		/// 进入文本编辑时
		/// </summary>
		/// <param name="e"></param>
		void EnterEditText(ThorGridCellEditArgs e);

		/// <summary>
		/// 离开文本编辑时
		/// </summary>
		/// <param name="e"></param>
		void LeaveEditText(ThorGridCellEditArgs e); 

		#endregion

		#region 下拉选择

		/// <summary>
		/// 是否允许下拉选择
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		bool AllowDropDown(ThorGrid grid);
		
		/// <summary>
		/// 打开下拉选择
		/// </summary>
		void OpenDropDown(ThorGrid grid);
		
		/// <summary>
		/// 进入下拉选择时
		/// </summary>
		/// <param name="e"></param>
		void EnterDropDown(ThorGridCellEditArgs e);
		
		/// <summary>
		/// 离开下拉选择时
		/// </summary>
		/// <param name="e"></param>
		void LeaveDropDown(ThorGridCellEditArgs e); 
		
		#endregion

		#region 对话框
		
		/// <summary>
		/// 是否允许对话框
		/// </summary>
		/// <returns></returns>
		bool AllowModalDialog(ThorGrid grid);
		
		/// <summary>
		/// 打开对话框
		/// </summary>
		void OpenModalDialog(ThorGrid grid);

		/// <summary>
		/// 打开对话框时
		/// </summary>
		/// <param name="e"></param>
		void EnterModalDialog(ThorGridCellEditArgs e);
		
		/// <summary>
		/// 关闭对话框时
		/// </summary>
		/// <param name="e"></param>
		void LeaveModalDialog(ThorGridCellEditArgs e); 

		#endregion

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
