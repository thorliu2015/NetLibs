using Solar;
using Solar.Common;
using Solar.Data;
using Solar.Data.Serialization;
using Solar.Data.Serialization.Xml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarEditor.Common
{
	/// <summary>
	/// 编辑器管理器
	/// </summary>
	public class SolarEditorManager : ICommonToolButtonActions
	{
		/// <summary>
		/// 获取当前实例
		/// </summary>
		static public SolarEditorManager Current { get; private set; }

		/// <summary>
		/// 构造
		/// </summary>
		static SolarEditorManager()
		{
			Current = new SolarEditorManager();
		}

		/// <summary>
		/// 构造
		/// </summary>
		private SolarEditorManager()
		{

			DefaultSerialization = new XmlSModelSerialization();
			Modules = new Dictionary<string, FrmAbstractModule>();

			ImageEditor = new FrmImageEditor();
			Modules["images"] = ImageEditor;

			AnimationEditor = new FrmAnimationEditor();
			Modules["animations"] = AnimationEditor;

			DataEditor = new FrmDataEditor();
			Modules["data"] = DataEditor;

			FrmAbstractModule.IActions = this;
			

			//--加载数据

			SModelManager.Current.Clear();
			foreach (string key in Modules.Keys)
			{
				List<SModel> list = new List<SModel>();
				try
				{
					DefaultSerialization.Deserialize(key, list);

					foreach (SModel model in list)
					{
						SModelManager.Current.Add(model);
					}
				}
				catch
				{
				}
			}
			
		}

		/// <summary>
		/// 尝试关闭模块时
		/// </summary>
		/// <param name="module"></param>
		/// <returns></returns>
		public bool OnModuleClosing(FrmAbstractModule module)
		{
			//判定是否需要保存(如果有修改的话)

			if (module.DataChanged)
			{
				switch (MessageBox.Show("数据已经修改, 是否保存之后关闭 ?", "关闭编辑器模块", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
				{
					case DialogResult.Yes:
						SaveModuleData(module);
						break;

					case DialogResult.No:
						break;

					case DialogResult.Cancel:
						return true;
				}
			}


			//判定是否所有模块已经全部关闭
			bool running = false;

			foreach (FrmAbstractModule m in Modules.Values)
			{
				if (m.IsRunning && m != module)
				{
					running = true;
					break;
				}
			}

			if (!running)
			{
				Application.ExitThread();
			}

			return false;
		}

		/// <summary>
		/// 模块字典
		/// </summary>
		private Dictionary<String, FrmAbstractModule> Modules;

		/// <summary>
		/// 图片编辑模块
		/// </summary>
		public FrmImageEditor ImageEditor { get; private set; }

		/// <summary>
		/// 动画编辑模块
		/// </summary>
		public FrmAnimationEditor AnimationEditor { get; private set; }

		/// <summary>
		/// 数据编辑模块
		/// </summary>
		public FrmDataEditor DataEditor { get; private set; }


		/// <summary>
		/// 默认的序列化方式
		/// </summary>
		public ISModeSerialization DefaultSerialization { get; set; }

	

		//----

		/// <summary>
		/// 获取所有模块信息
		/// </summary>
		/// <returns></returns>
		public List<ModuleButtonInfo> GetModules()
		{
			List<ModuleButtonInfo> result = new List<ModuleButtonInfo>();

			foreach (string key in Modules.Keys)
			{
				ModuleButtonInfo info = new ModuleButtonInfo();
				FrmAbstractModule form = Modules[key];

				info.Image = (Image)SolarEditor.Properties.Resources.ResourceManager.GetObject(form.GetType().Name);
				info.Text = form.ModuleName;
				info.Key = key;
				info.Form = form;

				result.Add(info);
			}

			return result;
		}

		

		/// <summary>
		/// 点击按钮时
		/// </summary>
		/// <param name="form"></param>
		/// <param name="action"></param>
		/// <param name="tag"></param>
		public void onButtonClick(FrmAbstractModule form, CommonToolButtonAction action, object tag)
		{
			switch (action)
			{
				case CommonToolButtonAction.Save:
					{
						SaveModuleData(form);
					}
					break;

				default:
					Debug.WriteLine(String.Format("onButtonClick : {0}", action.ToString()));
					break;
			}
		}


		public string GetModuleKey(FrmAbstractModule module)
		{
			foreach (string key in Modules.Keys)
			{
				if (module == Modules[key]) return key;
			}

			return "";
		}


		protected void SaveModuleData(FrmAbstractModule form)
		{
			List<SModel> models = new List<SModel>();
			SModelManager.Current.GetModels(models, form.ModelTypes);

			DefaultSerialization.Serialize(GetModuleKey(form), models);

			form.DataChanged = false;
			form.UpdateMainUI();
		}
	}
}
