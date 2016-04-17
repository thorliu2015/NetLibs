using SolarEditor.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarEditor
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

			Application.Run(SolarEditorManager.Current.ImageEditor);
		}
	}
}

/*
 * TODO LIST:
 *	
 * 1.	保存动画数据
 * 2.	定义动画PROTO
 * 3.	C++动画实现
 * 4.	动画节点的嵌套关系(位置,缩放,旋转)
 * 5.	动画界面的方向控制
 * 6.	动画界面的播放,暂停,左转,右转,第一帧,上一帧,下一帧,最后一帧
 * 7.	动画节点的可视化配置
 * 8.	枪口向量
 * 9.	粒子向量
 * 10.	BUG: 数据在删除时,界面作出正确的处理
 * 
 */