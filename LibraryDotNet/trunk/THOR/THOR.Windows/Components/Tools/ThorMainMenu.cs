/*
 * ThorMainMenu
 * liuqiang@2015/11/1 22:44:33
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Windows.Components.Tools.Renders;
using THOR.Windows.Dialogs;

//---- 8< ------------------

namespace THOR.Windows.Components.Tools
{
	public class ThorMainMenu : MenuStrip
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public ThorMainMenu()
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
			this.CanOverflow = false;
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
