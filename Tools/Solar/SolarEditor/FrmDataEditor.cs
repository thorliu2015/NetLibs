using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SolarEditor
{
	public partial class FrmDataEditor : Solar.FrmAbstractModule
	{
		public FrmDataEditor()
		{
			InitializeComponent();

			ModuleName = "数据";

			propertyGrid.SelectedObject = this;
		}


		protected override bool onClosing()
		{
			return SolarEditor.Common.SolarEditorManager.Current.OnModuleClosing(this);
		}
	}
}
