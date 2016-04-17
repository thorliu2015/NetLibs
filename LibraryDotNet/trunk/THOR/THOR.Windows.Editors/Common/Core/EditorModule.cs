/*
 * EditorModule
 * liuqiang@2015/11/1 19:26:30
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Windows.Components.Common;
using THOR.Windows.Editors.Common.Dialogs;

//---- 8< ------------------

namespace THOR.Windows.Editors.Common.Core
{
	/// <summary>
	/// 编辑器模块
	/// </summary>
	public class EditorModule
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		public EditorModule()
		{
			Init();
		}

		#endregion

		#region methods

		/// <summary>
		/// 初始化
		/// </summary>
		protected virtual void Init()
		{
			Types = new List<EditorModuleEntityType>();
		}

		/// <summary>
		/// 打开模块
		/// </summary>
		public virtual void Open()
		{
			if (this.ModuleForm.Visible)
			{
				this.ModuleForm.Select();
				return;
			}
			this.ModuleForm.SetEditorModule(this);
			this.ModuleForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ModuleForm.Show();
			this.ModuleForm.Select();
		}

		/// <summary>
		/// 打开模块
		/// </summary>
		/// <param name="id"></param>
		public virtual void Open(string id)
		{
			Open();

			//TODO: open entity by id
		}

		/// <summary>
		/// 关闭模块
		/// </summary>
		/// <returns></returns>
		public virtual bool Close()
		{
			if (ThorUI.ShowMessageBox("close ?", System.Windows.Forms.MessageBoxButtons.YesNoCancel, ModuleForm) == DialogResult.Cancel)
			{
				return true;
			}

			bool needExitThread = true;
			foreach (EditorModule mod in ThorEditorManager.Current.Modules)
			{
				if (mod.ModuleForm.Visible && mod != this)
				{
					needExitThread = false;
					break;
				}
			}

			if (needExitThread)
			{
				Application.ExitThread();
			}
			return false;
		}

		#endregion

		#region properties

		/// <summary>
		/// 模块标识
		/// </summary>
		public string Key { get; set; }


		/// <summary>
		/// 获取或设置读取方法
		/// </summary>
		public IEditorLoadMethod LoadMethod { get; set; }

		/// <summary>
		/// 获取或设置保存方法
		/// </summary>
		public IEditorSaveMethod SaveMethod { get; set; }


		/// <summary>
		/// 获取或设置导入方法
		/// </summary>
		public IEditorLoadMethod ImportMethod { get; set; }

		/// <summary>
		/// 获取或设置导出方法
		/// </summary>
		public IEditorSaveMethod ExportMethod { get; set; }


		/// <summary>
		/// 获取模块数据类型
		/// </summary>
		public List<EditorModuleEntityType> Types { get; protected set; }

		/// <summary>
		/// 获取或设置模块窗体
		/// </summary>
		public FrmAbstractModule ModuleForm { get; set; }

		/// <summary>
		/// 获取或设置数据模块是否为只读
		/// </summary>
		public bool ReadOnly { get; set; }

	
		#endregion

		#region events

		#endregion
	}
}
