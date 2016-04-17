using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using THOR.Windows.Components.Common;
using THOR.Windows.Editors.Common.Components;
using THOR.Windows.Editors.Common.Core;
using THOR.Windows.Editors.Common.Data;
using THOR.Windows.Languages;

namespace THOR.Windows.Editors.Common.Dialogs
{
	/// <summary>
	/// 模块窗体基类
	/// </summary>
	public partial class FrmAbstractModule : THOR.Windows.Dialogs.FlatForm
	{
		/// <summary>
		/// 数据导航控件
		/// </summary>
		protected ThorModelsNavigation modelsNavigation;

		/// <summary>
		/// 构造
		/// </summary>
		public FrmAbstractModule()
		{
			InitializeComponent();

			InitModuleForm();
			InitMainToolBar();
			InitStatusBar();
			InitModelsNavigation();
			InitModuleContent();
		}

		/// <summary>
		/// 初始化窗体
		/// </summary>
		protected virtual void InitModuleForm()
		{

		}

		/// <summary>
		/// 初始化主工具栏
		/// </summary>
		protected virtual void InitMainToolBar()
		{
			btnSave.Text = btnSave.ToolTipText = ThorLanguages.Current.GetText("/language/main.toolbar/save", "Save");
			btnImport.Text = btnImport.ToolTipText = ThorLanguages.Current.GetText("/language/main.toolbar/import", "Import");
			btnExport.Text = btnExport.ToolTipText = ThorLanguages.Current.GetText("/language/main.toolbar/export", "Export");
			btnSettings.Text = btnSettings.ToolTipText = ThorLanguages.Current.GetText("/language/main.toolbar/settings", "Settings");
			btnAbout.Text = btnAbout.ToolTipText = ThorLanguages.Current.GetText("/language/main.toolbar/about", "About");
		}

		/// <summary>
		/// 初始化状态行
		/// </summary>
		protected virtual void InitStatusBar()
		{
			lblCurrentEntityPath.Text = "";
		}

		/// <summary>
		/// 初始化导航栏
		/// </summary>
		protected virtual void InitModelsNavigation()
		{
			modelsNavigation = new ThorModelsNavigation();

			modelsNavigation.Dock = DockStyle.Fill;
			modelsNavigation.SelectionChanged += modelsNavigation_SelectionChanged;
			boxNavigation.Controls.Add(modelsNavigation);
		}



		/// <summary>
		/// 初始化模块内容
		/// </summary>
		protected virtual void InitModuleContent()
		{
		}

		/// <summary>
		/// 获取模块名称
		/// </summary>
		/// <returns></returns>
		protected virtual string GetModuleName()
		{
			if (Module != null)
			{
				string szText = ThorLanguages.Current.GetText(String.Format(@"/language/modules/{0}/name", Module.Key), Module.Key);
				return szText;
			}
			return "";
		}

		/// <summary>
		/// 设置模块
		/// </summary>
		/// <param name="module"></param>
		public virtual void SetEditorModule(EditorModule module)
		{
			if (Module != null) return;

			this.Module = module;
			this.Text = String.Format("{0} - {1} {2}", GetModuleName(), Application.ProductName, Application.ProductVersion);

			btnExport.Visible = (module.ExportMethod != null);
			btnImport.Visible = (module.ImportMethod != null);
			btnSave.Visible = (module.SaveMethod != null);

			modelsNavigation.SetModule(module);

			foreach (EditorModule mod in ThorEditorManager.Current.Modules)
			{
				string szText = ThorLanguages.Current.GetText(String.Format(@"/language/modules/{0}/name", mod.Key), mod.Key);
				string szIcon = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), String.Format(@"Resources\Modules\{0}.png", mod.Key));

				ToolStripButton btnModule = new ToolStripButton();
				btnModule.Text = btnModule.ToolTipText = szText;
				if (File.Exists(szIcon))
				{
					btnModule.Image = Image.FromFile(szIcon);
				}
				btnModule.DisplayStyle = ToolStripItemDisplayStyle.Image;
				btnModule.Checked = (module == mod);
				btnModule.Tag = mod;
				toolBarMain.Items.Add(btnModule);
				btnModule.Click += btnModule_Click;
			}
		}

		/// <summary>
		/// 点击模块
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnModule_Click(object sender, EventArgs e)
		{
			if (sender is ToolStripButton)
			{
				ToolStripButton btnModule = (ToolStripButton)sender;
				if (btnModule.Tag is EditorModule)
				{
					EditorModule mod = (EditorModule)btnModule.Tag;
					mod.Open();
				}
			}
		}

		/// <summary>
		/// 尝试关闭窗体时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmAbstractModule_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Module != null)
			{
				e.Cancel = true;
				if (Module.Close()) return;
				this.Hide();
			}
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (modelsNavigation != null && !DesignMode)
			{
				modelsNavigation.LoadEntitiesTree();
			}
		}

		#region 交互

		/// <summary>
		/// 保存
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSave_Click(object sender, EventArgs e)
		{
			if (Module != null && Module.SaveMethod != null)
			{
				Module.SaveMethod.Save(Module);
			}
		}

		/// <summary>
		/// 导入
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImport_Click(object sender, EventArgs e)
		{
			if (Module != null && Module.ImportMethod != null)
			{
				Module.ImportMethod.Load(Module);
			}
		}

		/// <summary>
		/// 导出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnExport_Click(object sender, EventArgs e)
		{
			if (Module != null && Module.ExportMethod != null)
			{
				Module.ExportMethod.Save(Module);
			}
		}

		/// <summary>
		/// 设置
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSettings_Click(object sender, EventArgs e)
		{
			DialogEditorSettings dialog = new DialogEditorSettings();

			dialog.ThemeColor = this.ThemeColor;

			dialog.ShowDialog();
		}

		/// <summary>
		/// 关于
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAbout_Click(object sender, EventArgs e)
		{
			ThorUI.ShowMessageBox(
				ThorLanguages.Current.GetText("/language/dialogs/about/title", "About"),
				ThorLanguages.Current.GetText("/language/dialogs/about/description", "..."), MessageBoxButtons.OK, MessageBoxIcon.Information, this);
		}


		/// <summary>
		/// 选定数据改变时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void modelsNavigation_SelectionChanged(object sender, EventArgs e)
		{
			OnEntitySelectionChanged(modelsNavigation.SelectedEntity);

			string entityPath = "";
			if (modelsNavigation.SelectedEntity != null)
			{
				if (modelsNavigation.SelectedEntity.EditorCategory.Trim().Length == 0)
				{
					entityPath = modelsNavigation.SelectedEntity.GetFullID();
				}
				else
				{
					entityPath = String.Format("{0}/{1}", modelsNavigation.SelectedEntity.EditorCategory, modelsNavigation.SelectedEntity.GetFullID());
				}

				entityPath = String.Format("{0}://{1}", Module.Key, entityPath);
			}

			lblCurrentEntityPath.Text = entityPath;
		}

		/// <summary>
		/// 选定的数据改变时
		/// </summary>
		/// <param name="entity"></param>
		protected virtual void OnEntitySelectionChanged(CEntity entity)
		{
			Debug.WriteLine(String.Format("OnEntitySelectionChanged: {0}", entity != null ? entity.GetFullID() : "NULL"));
		}

		#endregion


		/// <summary>
		/// 获取或设置隶属的模块
		/// </summary>
		public EditorModule Module { get; private set; }




	}
}
