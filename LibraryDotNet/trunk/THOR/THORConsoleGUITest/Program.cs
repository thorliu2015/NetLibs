using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.ConsoleGUI;
using THOR.ConsoleGUI.Core;

namespace THORConsoleGUITest
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			
		
			ConsoleManager.Current.Setup();

			//------------

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FrmConsoleGUI());
		}
	}
}
