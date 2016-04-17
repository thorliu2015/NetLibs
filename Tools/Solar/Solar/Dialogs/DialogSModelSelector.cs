using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Solar.Dialogs
{
	public partial class DialogSModelSelector : THOR.Windows.UI.Forms.DialogBase
	{
		public DialogSModelSelector()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (!panelPreview.HasChildren)
			{
				splitter.Visible = panelPreview.Visible = false;
			}
		}

		protected override bool OnButtonOKClick()
		{
			if (modelDataNavigation.SelectedModel == null)
			{
				MessageBox.Show("你没选择任何内容 !", "错误操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			return true;
		}
	}
}
