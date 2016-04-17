using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace THOR.Windows.UI.Forms
{
	public partial class DialogBase : Form
	{
		public DialogBase()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			UpdateButtons();
		}

		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
			UpdateButtons();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			UpdateButtons();
			
		}

		protected void UpdateButtons()
		{
			int buttonMargin = 5;
			btnCancel.Left = panelButtons.Width - btnCancel.Width - buttonMargin;
			btnOK.Left = btnCancel.Left - btnOK.Width - buttonMargin;

			btnCancel.Top = btnOK.Top = buttonMargin;
		}


		protected virtual bool OnButtonOKClick()
		{
			return true;
		}


		private void btnOK_Click(object sender, EventArgs e)
		{
			if (OnButtonOKClick())
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}


		public string ButtonOKTitle
		{
			get
			{
				return btnOK.Text;
			}
			set
			{
				btnOK.Text = value;
			}
		}


		public string ButtonCancelTitle
		{
			get
			{
				return btnCancel.Text;
			}
			set
			{
				btnCancel.Text = value;
			}
		}



	}
}
