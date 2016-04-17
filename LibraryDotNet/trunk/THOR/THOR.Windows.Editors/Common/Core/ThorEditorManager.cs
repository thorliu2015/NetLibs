/*
 * ThorEditorManager
 * liuqiang@2015/11/22 15:14:33
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.Dialogs;


//---- 8< ------------------

namespace THOR.Windows.Editors.Common.Core
{
	public class ThorEditorManager
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		static public ThorEditorManager Current { get; private set; }

		static ThorEditorManager()
		{
			Current = new ThorEditorManager();
		}

		private ThorEditorManager()
		{
			Modules = new List<EditorModule>();
		}

		#endregion

		#region methods

		#endregion

		#region properties

		public List<EditorModule> Modules { get; private set; }

		public FlatSplash SplashForm { get; set; }

		#endregion

		#region events

		#endregion
	}
}
