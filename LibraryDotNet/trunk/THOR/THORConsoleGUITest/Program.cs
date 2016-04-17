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
			
			ConsoleManager.Current.Commands.Add(new ConsoleCommand(null, "copy(复制)  <(type)name(desc)=defaultValue> [(type)name(desc)=defaultValue]"));
			ConsoleManager.Current.Commands.Add(new ConsoleCommand(null, "cls(清屏)  <(type)name(desc)=defaultValue> [(type)name(desc)=defaultValue]"));

			ConsoleManager.Current.Setup();

			//------------

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FrmConsoleGUI());
		}
	}
}
