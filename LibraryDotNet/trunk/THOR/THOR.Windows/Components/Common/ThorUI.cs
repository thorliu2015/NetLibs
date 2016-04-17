/*
 * ThorUI
 * liuqiang@2015/11/12 10:14:04
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Windows.Dialogs;

//---- 8< ------------------

namespace THOR.Windows.Components.Common
{
	public class ThorUI
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		static ThorUI()
		{
		}

		private ThorUI()
		{
		}

		#endregion

		#region methods

		#region 消息框


		static public DialogResult ShowMessageBox(string prompt, Control ctrl = null)
		{
			return ShowMessageBox("", prompt, MessageBoxButtons.OK, MessageBoxIcon.None, ctrl);
		}

		static public DialogResult ShowMessageBox(string prompt, MessageBoxButtons buttons, Control ctrl = null)
		{
			return ShowMessageBox("", prompt, buttons, MessageBoxIcon.Information, ctrl);
		}

		static public DialogResult ShowMessageBox(string prompt, MessageBoxButtons buttons, MessageBoxIcon icon, Control ctrl = null)
		{
			return ShowMessageBox("", prompt, buttons, icon, ctrl);
		}

		static public DialogResult ShowMessageBox(string title, string prompt, MessageBoxButtons buttons, MessageBoxIcon icon, Control ctrl = null)
		{
			FlatMessageBox dialog = new FlatMessageBox();

			dialog.Text = title;
			dialog.MessageBoxPrompt = prompt;
			dialog.MessageBoxButtons = buttons;
			dialog.MessageBoxIcon = icon;

			if (ctrl != null)
			{
				if (ctrl is FlatForm)
				{
					dialog.ThemeColor = ((FlatForm)ctrl).ThemeColor;
				}
				else if (ctrl.FindForm() is FlatForm)
				{
					dialog.ThemeColor = ((FlatForm)ctrl.FindForm()).ThemeColor;
				}

				return dialog.ShowDialog(ctrl);
			}
			else
				return dialog.ShowDialog();
		} 

		#endregion

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
