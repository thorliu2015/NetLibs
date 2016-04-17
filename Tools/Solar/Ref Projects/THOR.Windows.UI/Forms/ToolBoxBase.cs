﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THOR.Windows.UI.Forms
{
	public partial class ToolBoxBase : Form
	{
		

		public ToolBoxBase()
		{
			InitializeComponent();
		}

		public void Show(Form form, bool modal = false)
		{
			if (modal)
			{
				this.StartPosition = FormStartPosition.CenterParent;
				ShowDialog(form);
			}
			else
			{
				this.StartPosition = FormStartPosition.WindowsDefaultLocation;
				Show();
			}
		}

	

	}
}
