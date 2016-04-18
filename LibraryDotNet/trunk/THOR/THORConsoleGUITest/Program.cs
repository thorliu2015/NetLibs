using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.ConsoleGUI;
using THOR.ConsoleGUI.Core;
using THOR.Utils;

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
            Byte[] bytes = new byte[250];

            for(int i = 0; i <bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(i);
            }

            string szBytes = ByteFormater.Format(bytes);
		
			ConsoleManager.Current.Setup();

			//------------

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FrmConsoleGUI());
		}
	}
}
