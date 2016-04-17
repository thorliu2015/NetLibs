/*
 * ThorTextField
 * liuqiang@2015/11/17 13:34:58
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Windows.Components.Drawing;


//---- 8< ------------------

namespace THOR.Windows.Components.Fields
{
	/// <summary>
	/// 文本字段
	/// </summary>
	public class ThorTextField : ThorAbstractField
	{
		#region constants

		#endregion

		#region variables

		protected TextBox textBox;
		protected int TextBoxHPadding = 2;

		#endregion

		#region construct

		#endregion

		#region methods

		protected override void CreateFieldContent()
		{
			base.CreateFieldContent();

			_FocusIn = false;
			_noBorder = false;
			this.BackColor = ThorColors.Window;

			textBox = new TextBox();

			textBox.ForeColor = ThorColors.WindowText;
			textBox.BackColor = ThorColors.Window;
			textBox.BorderStyle = BorderStyle.None;
			Controls.Add(textBox);

			textBox.GotFocus += textBox_GotFocus;
			textBox.LostFocus += textBox_LostFocus;
		}

		protected void textBox_LostFocus(object sender, EventArgs e)
		{
			_FocusIn = false;
			this.Invalidate();
			OnFocusChanged();
		}

		protected void textBox_GotFocus(object sender, EventArgs e)
		{
			_FocusIn = true;
			this.Invalidate();
			OnFocusChanged();
		}

		protected override void LayoutFieldContent()
		{
			if (textBox == null) return;


			System.Drawing.Size s = TextRenderer.MeasureText(" ", this.Font);

			int offsetY = (this.Height - s.Height) / 2;

			textBox.Width = this.Width - this.Padding.Left - this.Padding.Right - TextBoxHPadding * 2;

			textBox.Location = new System.Drawing.Point(
				this.Padding.Left + TextBoxHPadding,
				offsetY);
		}

		#endregion

		#region properties

		/// <summary>
		/// 获取文本框
		/// </summary>
		public TextBox TextBox { get { return textBox; } }

		#endregion

		#region events

		#endregion
	}
}
