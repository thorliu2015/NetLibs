using Solar.Images;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Solar.Dialogs
{
	public partial class DialogImageRowsAndColumns : THOR.Windows.UI.Forms.DialogBase
	{
		public DialogImageRowsAndColumns()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (CurrentImage == null)
			{
				numColumns.Enabled = numRows.Enabled = false;
			}
			else
			{
				numColumns.Minimum = numRows.Minimum = 1;
				numColumns.Maximum = CurrentImage.Width / 2;
				numRows.Maximum = CurrentImage.Height / 2;

				numRows.Value = CurrentImage.Rows;
				numColumns.Value = CurrentImage.Columns;
			}
		}

		protected override bool OnButtonOKClick()
		{

			if (CurrentImage != null)
			{
				CurrentImage.Rows = Convert.ToInt32(numRows.Value);
				CurrentImage.Columns = Convert.ToInt32(numColumns.Value);
			}

			return true;
		}

		public SImage CurrentImage { get; set; }

	}
}
