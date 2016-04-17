using Solar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarUIComponentTest
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
			Application.Run(new FrmAbstractModule());
		}


		/*
		 * TODO: 窗体以及线程管理
		 * TODO: 保存提示
		 * TODO: 导入导出管理
		 * 
		 * TODO: 图片管理
		 * TODO: 动画管理
		 * TODO: 数据管理
		 */
	}
}
