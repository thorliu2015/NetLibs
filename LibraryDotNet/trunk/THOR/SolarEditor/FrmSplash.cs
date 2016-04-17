/*
 * FrmSplash
 * liuqiang@2015/11/22 11:54:22
 * ---- 8< ------------------
 * NOTE
 */


using SolarEditor.Images;
using SolarEditor.Images.Data;
using SolarEditor.Maps;
using SolarEditor.Maps.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Serialization;
using THOR.Windows.Components.Drawing;
using THOR.Windows.Dialogs;
using THOR.Windows.Editors.Common.Core;
using THOR.Windows.Editors.Common.Data;
using THOR.Windows.Editors.Common.Dialogs;
using THOR.Windows.Editors.UI.Dialogs;


//---- 8< ------------------

namespace SolarEditor
{
	public class FrmSplash : FlatSplash
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public FrmSplash()
			: base()
		{
			
		}

		#endregion

		#region methods

		protected override void InitSplashForm()
		{
			base.InitSplashForm();
			ThorEditorManager.Current.SplashForm = this;
			ThorComponentTheme.Current = ThorComponentTheme.Dark();
		}

		/// <summary>
		/// 加载模块
		/// </summary>
		protected override void Loading()
		{
			InitModules();

			MainProgressCurrent = 0;
			MainProgressTotal = ThorEditorManager.Current.Modules.Count;

			SerialicationTypes.Current.AddApplicationDomain(AppDomain.CurrentDomain);

			foreach (EditorModule module in ThorEditorManager.Current.Modules)
			{
				MainProgressCurrent++;
				if (module.LoadMethod != null)
				{
					module.LoadMethod.Load(module);
				}
			}
		}

		/// <summary>
		/// 初始化模块
		/// </summary>
		protected virtual void InitModules()
		{
			//#region Explorer

			//EditorModule moduleExplorer = new EditorModule();
			//moduleExplorer.Key = "Explorer";
			//moduleExplorer.ModuleForm = new FrmModuleExplorer();
			//moduleExplorer.Types.Add(new EditorModuleEntityType("Language", typeof(CEntity)));
			//moduleExplorer.Types.Add(new EditorModuleEntityType("Audio", typeof(CEntity)));
			//moduleExplorer.Types.Add(new EditorModuleEntityType("Unit", typeof(CEntity)));
			//moduleExplorer.Types.Add(new EditorModuleEntityType("Ability", typeof(CEntity)));
			//moduleExplorer.Types.Add(new EditorModuleEntityType("Weapon", typeof(CEntity)));
			////moduleExplorer.ModuleForm.ThemeColor = ColorTranslator.FromHtml("#DDAA00");
			//moduleExplorer.ReadOnly = true;
			//ThorEditorManager.Current.Modules.Add(moduleExplorer);

			//#endregion

			#region Images

			//EditorModule moduleImage = new EditorModule();
			//moduleImage.Key = "Images";
			//moduleImage.ModuleForm = new FrmImageModule();
			//moduleImage.Types.Add(new EditorModuleEntityType("Images", typeof(CImage)));
			//moduleImage.LoadMethod = new XmlLoadMethod();
			//moduleImage.SaveMethod = new XmlSaveMethod();
			//moduleImage.ImportMethod = new ImageImportMethod();
			////moduleImage.ExportMethod = new XmlSaveMethod();
			//ThorEditorManager.Current.Modules.Add(moduleImage);

			#endregion

			#region Terrains

			//EditorModule moduleTerrain = new EditorModule();
			//moduleTerrain.Key = "Terrains";
			//moduleTerrain.ModuleForm = new FrmTerrainModule();
			//moduleTerrain.Types.Add(new EditorModuleEntityType("Terrains", typeof(CTerrain)));
			//moduleTerrain.LoadMethod = new XmlLoadMethod();
			//moduleTerrain.SaveMethod = new XmlSaveMethod();
			////moduleTerrain.ImportMethod = new XmlLoadMethod();
			////moduleTerrain.ExportMethod = new XmlSaveMethod();
			//ThorEditorManager.Current.Modules.Add(moduleTerrain);

			#endregion

			#region Map
			//EditorModule moduleMap = new EditorModule();
			//moduleMap.Key = "Maps";
			//moduleMap.ModuleForm = new FrmMapModule();
			//moduleMap.Types.Add(new EditorModuleEntityType("Terrains", typeof(CTerrain)));
			//moduleMap.LoadMethod = new XmlLoadMethod();
			//moduleMap.SaveMethod = new XmlSaveMethod();
			//ThorEditorManager.Current.Modules.Add(moduleMap);

			#endregion

			#region UI

			EditorModule moduleUI = new EditorModule();
			moduleUI.Key = "UI";
			moduleUI.ModuleForm = new FrmUIModule();
			moduleUI.Types.Add(new EditorModuleEntityType("UI", typeof(CEntity)));
			moduleUI.LoadMethod = new XmlLoadMethod();
			moduleUI.SaveMethod = new XmlSaveMethod();
			ThorEditorManager.Current.Modules.Add(moduleUI);

			#endregion
		}

		/// <summary>
		/// 启动模块
		/// </summary>
		protected override void Startup()
		{
			if (ThorEditorManager.Current.Modules.Count > 0)
			{
				ThorEditorManager.Current.Modules[0].Open();
			}
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
