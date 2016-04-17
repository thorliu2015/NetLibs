/*
 * ThorContextMenu
 * liuqiang@2015/11/1 22:44:44
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
	public class ThorContextMenu : ContextMenuStrip
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public ThorContextMenu()
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

		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			Form f = this.GetForm();
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

		protected Form GetForm()
		{
			if (this.FindForm() != null) return this.FindForm();
			if(this.SourceControl!=null) return this.SourceControl.FindForm();
			
			if (this.OwnerItem != null)
			{
				return GetFormEx(this.OwnerItem);
			}

			return null;
		}

		protected Form GetFormEx(ToolStripItem item)
		{
			return null;
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
