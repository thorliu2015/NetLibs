using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.ConsoleGUI.Core;

namespace THOR.ConsoleGUI
{
	public partial class FrmConsoleGUI : Form
	{
		public FrmConsoleGUI()
		{
			InitializeComponent();

			ConsoleManager.Current.Output = consoleOutput1;
		}
	}
}
