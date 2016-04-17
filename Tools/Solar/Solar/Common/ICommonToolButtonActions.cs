using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solar.Common
{

	public enum CommonToolButtonAction
	{
		Options,
		Save,
		Browse,
		Export,
		ExportAll,
		Module
	}

	/// <summary>
	/// 模块按钮信息
	/// </summary>
	public class ModuleButtonInfo
	{
		public ModuleButtonInfo()
		{
		}

		public Image Image { get; set; }
		public string Key { get; set; }
		public string Text { get; set; }
		public FrmAbstractModule Form { get; set; }
	}

	/// <summary>
	/// 公共工具栏指令接口
	/// </summary>
	public interface ICommonToolButtonActions
	{
		void onButtonClick(FrmAbstractModule form, CommonToolButtonAction action, object tag);
		List<ModuleButtonInfo> GetModules();
	}
}
