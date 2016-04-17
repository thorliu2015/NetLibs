/*
 * ThorAbstractPopupField
 * liuqiang@2015/11/17 16:08:11
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.Components.Drawing;
using THOR.Windows.Dialogs;


//---- 8< ------------------

namespace THOR.Windows.Components.Fields
{
	/// <summary>
	/// 抽象的弹出字段
	/// </summary>
	public class ThorAbstractPopupField : ThorTextField
	{
		#region constants

		protected const int THOR_POPUP_FIELD_DROPDOWN_BUTTON_SIZE = 18;

		#endregion

		#region variables

		protected FlatPopuper _Popuper = new FlatPopuper();

		protected bool _FullRegionPopup = false;
		
		#endregion

		#region construct

		public ThorAbstractPopupField()
			: base()
		{
		}

		#endregion

		#region methods

		protected override void CreateFieldContent()
		{
			base.CreateFieldContent();
		}

		protected override void LayoutFieldContent()
		{
			base.LayoutFieldContent();

			if (textBox != null)
			{
				int w = textBox.Width - THOR_POPUP_FIELD_DROPDOWN_BUTTON_SIZE;
				if (w < 0) w = 0;
				textBox.Width = w;
			}
		}

		protected override void DrawFieldForeground(System.Windows.Forms.PaintEventArgs e)
		{
			base.DrawFieldForeground(e);

			Rectangle rect = new Rectangle();

			rect.X = this.Width - THOR_POPUP_FIELD_DROPDOWN_BUTTON_SIZE - THOR_FIELD_BORDER;
			rect.Y = 0;
			rect.Width = THOR_POPUP_FIELD_DROPDOWN_BUTTON_SIZE;
			rect.Height = this.Height;

			ThorControlPaint.DrawArrow(e.Graphics, rect, ThorColors.ControlText, ThorArrowDirection.Down, 7);
		}

		protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
		{
			base.OnMouseClick(e);

			if (e.X > this.Width - THOR_POPUP_FIELD_DROPDOWN_BUTTON_SIZE || _FullRegionPopup)
			{
				DoPopup();
			}
			
		}

		protected virtual void DoPopup()
		{
			_Popuper.Show(this);
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
