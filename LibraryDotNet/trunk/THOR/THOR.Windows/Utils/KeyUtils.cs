/*
 * KeyUtils
 * liuqiang@2016/4/4 21:37:13
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//---- 8< ------------------

namespace THOR.Windows.Utils
{
	public class KeyUtils
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		static public bool IsHotKey(KeyEventArgs e, bool Ctrl, bool Shift, bool Alt, Keys key)
		{
			if (e.Control == Ctrl)
			{
				if (e.Alt == Alt)
				{
					if (e.Shift == Shift)
					{
						return e.KeyCode == key;
					}
				}
			}
			return false;
		}

		static public bool IsCtrlKey(KeyEventArgs e, Keys key)
		{
			return IsHotKey(e, true, false, false, key);
		}

		static public bool IsAltKey(KeyEventArgs e, Keys key)
		{
			return IsHotKey(e, false, false, true, key);
		}

		static public bool IsShiftKey(KeyEventArgs e, Keys key)
		{
			return IsHotKey(e, false, true, false, key);
		}

		static public bool IsKey(KeyEventArgs e, Keys key)
		{
			return IsHotKey(e, false, false, false, key);
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
