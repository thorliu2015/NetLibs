using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using THOR.Windows.Languages;

namespace THOR.Windows.Editors.Common.Dialogs
{
	public partial class DialogEditorSettings : THOR.Windows.Dialogs.FlatDialog
	{
		public DialogEditorSettings()
		{
			InitializeComponent();

			this.Text = ThorLanguages.Current.GetText("/language/dialogs/settings/title", "Settings");
		}
	}
}
