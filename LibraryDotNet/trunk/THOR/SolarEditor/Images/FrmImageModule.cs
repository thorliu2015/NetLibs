using SolarEditor.Images.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using THOR.Windows.Editors.Common.Data;

namespace SolarEditor.Images
{
	public partial class FrmImageModule : THOR.Windows.Editors.Common.Dialogs.FrmAbstractModule
	{
		public FrmImageModule()
		{
			InitializeComponent();
		}

		protected override void OnEntitySelectionChanged(CEntity entity)
		{
			base.OnEntitySelectionChanged(entity);

			if (entity is CImage)
			{
				thorImageView.CurrentImage = (CImage)entity;
			}
		}
	}
}
