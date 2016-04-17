using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Windows.Components.Drawing;

namespace Test
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			ThorComponentTheme.Current = ThorComponentTheme.Dark();
			//ThorComponentTheme.Current = ThorComponentTheme.Light();
			Application.Run(new FormMain());
		}
	}
}
