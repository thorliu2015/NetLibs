/*
 * FlatToolBox
 * liuqiang@2015/11/8 15:31:59
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
using THOR.Windows.Components.Drawing;


//---- 8< ------------------

namespace THOR.Windows.Dialogs
{
	public class FlatToolBox : FlatForm
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods


	

		protected override void Init()
		{
			base.Init();
			Width = Height = 200;
			TopMost = true;
			MaximizeBox = false;
			MinimizeBox = false;
			Text = "FlatToolBox";
			MinimumSize = new Size(60, 60);
		}

		protected override void DrawTitleText(System.Windows.Forms.PaintEventArgs e)
		{
			//base.DrawTitleText(e);

			Rectangle rect = new Rectangle(1, FLAT_FORM_BORDER, Width - 2 - (MeasureFormButtonCount() * FLAT_FORM_BUTTON_WIDTH), FLAT_FORM_TITLE);
			ThorControlPaint.DrawBand(e.Graphics, rect, true);



			string szTitle = Text;
			int indent = 16;
			rect.X += indent;
			rect.Width -= indent;
			TextFormatFlags tf = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;
			TextRenderer.DrawText(e.Graphics, szTitle, Font, rect, ThorColors.ControlDark, tf);

			rect.X--;
			rect.Y--;
			TextRenderer.DrawText(e.Graphics, szTitle, Font, rect, ThorColors.ControlText, tf);

		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			e.Cancel = true;
			Hide();
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion


	}
}
