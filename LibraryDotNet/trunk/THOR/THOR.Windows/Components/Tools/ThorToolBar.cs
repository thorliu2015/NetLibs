/*
 * ThorToolBar
 * liuqiang@2015/11/1 22:44:02
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Windows.Components.Tools.Renders;
using THOR.Windows.Dialogs;


//---- 8< ------------------

namespace THOR.Windows.Components.Tools
{
	public class ThorToolBar : ToolStrip
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public ThorToolBar()
			: base()
		{
			InitRenders();
		}

		#endregion

		#region methods

		/// <summary>
		/// 初始化渲染器
		/// </summary>
		virtual protected void InitRenders()
		{
			DoubleBuffered = true;
			Renderer = new ThorToolStripRender();
			this.Font = ThorToolStripRender.DefaultFont;
			this.Padding = new Padding(2);
			this.Margin = new Padding(0);
			this.CanOverflow = false;
		}

		/// <summary>
		/// 添加成员时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnItemAdded(ToolStripItemEventArgs e)
		{
			base.OnItemAdded(e);
			e.Item.Padding = new Padding(2);
			e.Item.Margin = new Padding(0);
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			Form f = this.FindForm();
			if (f is FlatForm)
			{
				FlatForm ff = (FlatForm)f;
				if (this.Renderer is ThorToolStripRender)
				{
					((ThorToolStripRender)this.Renderer).RenderThemeColor = ff.ThemeColor;
				}
			}
			base.OnPaintBackground(e);
		}

	

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
