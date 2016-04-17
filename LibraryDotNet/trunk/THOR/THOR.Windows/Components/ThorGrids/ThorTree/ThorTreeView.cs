/*
 * ThorTreeView
 * liuqiang@2015/11/14 16:02:41
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.Components.Common;
using THOR.Windows.Components.ThorGrids.Core;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.ThorTree
{
	public class ThorTreeView : ThorAbstractGrid
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public ThorTreeView()
			: base()
		{
			InitTreeView();
		}
		#endregion

		#region methods

		/// <summary>
		/// 初始化树形控件
		/// </summary>
		protected virtual void InitTreeView()
		{
			_RowHeight = 20;
			_Render = new ThorTreeViewRender();
		}

		#endregion

		#region properties

		/// <summary>
		/// 缩进
		/// </summary>
		protected int _Indent = 20;

		/// <summary>
		/// 获取或设置树形节点的层级缩进距离
		/// </summary>
		public int Indent
		{
			get
			{
				return _Indent;
			}
			set
			{
				if (_Indent == value) return;
				_Indent = value;
				this.LayoutScrollView();
				this.Invalidate();
			}
		}

		#endregion

		#region events

	

		#endregion
	}
}
