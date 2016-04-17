/*
 * FrmModuleExplorer
 * liuqiang@2015/11/22 11:58:55
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
using THOR.Windows.Languages;


//---- 8< ------------------

namespace THOR.Windows.Editors.Common.Dialogs
{
	public class FrmModuleExplorer : FrmAbstractModule
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public FrmModuleExplorer()
			: base()
		{
		}

		#endregion

		#region methods
		protected override void InitModuleForm()
		{
			base.InitModuleForm();
			//_ThemeColor = ColorTranslator.FromHtml("#DDAA00");
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
