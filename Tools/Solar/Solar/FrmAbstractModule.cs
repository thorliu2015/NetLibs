using Solar.Common;
using Solar.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Solar
{
	/// <summary>
	/// 模块基类
	/// </summary>
	public partial class FrmAbstractModule : THOR.Windows.UI.Forms.FormBase
	{
		static public ICommonToolButtonActions IActions { get; set; }

		/// <summary>
		/// 当前使用的模型类型
		/// </summary>
		protected Type ModelType;

		/// <summary>
		/// 所有支持的模型类型
		/// </summary>
		public List<Type> ModelTypes { get; set; }

		/// <summary>
		/// 当前选定的模型
		/// </summary>
		protected SModel SelectedModel;

		/// <summary>
		/// 当前模块名称
		/// </summary>
		public string ModuleName { get; protected set; }

		/// <summary>
		/// 数据是否已经改变
		/// </summary>
		public bool DataChanged { get; set; }


		/// <summary>
		/// 构造
		/// </summary>
		public FrmAbstractModule()
		{
			InitializeComponent();

			ModelTypes = new List<Type>();

			ModuleName = "Abstract";

		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Init();

			if (ModelTypes.Count == 0) return;

			ModelType = ModelTypes[0];
			SelectedModel = null;
		}



		/// <summary>
		/// 初始化
		/// </summary>
		protected virtual void Init()
		{
		}

		/// <summary>
		/// 选定模型改变时
		/// </summary>
		protected virtual void onSelectedModelChange()
		{

		}


		/// <summary>
		/// 在数据目录导航中选择内容改变时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void modelDataNavigation_AfterModelSelected(object sender, EventArgs e)
		{
			if (SelectedModel == modelDataNavigation.SelectedModel) return;

			SelectedModel = modelDataNavigation.SelectedModel;

			onSelectedModelChange();

			if (SelectedModel == null)
			{
				lblSelected.Text = "";
			}
			else
			{
				lblSelected.Text = String.Format("{3}: {2}/{0} - {1}", SelectedModel.Id, SelectedModel.EditorName, SelectedModel.EditorCategory, SelectedModel.GetNoteName());
			}
		}

		/// <summary>
		/// 尝试关闭窗体时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmAbstractModule_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			if (onClosing()) return;
			this.Hide();
			IsRunning = false;

		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			IsRunning = true;

			if (IActions != null)
			{
				List<ModuleButtonInfo> modules = IActions.GetModules();

				foreach (ModuleButtonInfo info in modules)
				{
					ToolStripButton btnModule = new ToolStripButton();
					btnModule.Image = info.Image;
					btnModule.Text = info.Text;
					btnModule.DisplayStyle = ToolStripItemDisplayStyle.Image;
					btnModule.Tag = info;
					btnModule.Checked = (info.Form == this);
					btnModule.Click += btnModule_Click;
					toolBarMain.Items.Add(btnModule);
				}
			}


			Text = String.Format("{0} - {1} ver {2}", ModuleName, Application.ProductName, Application.ProductVersion);

			modelDataNavigation.FilterType = ModelType;
			modelDataNavigation.SetTypesMenu(ModelTypes);
			modelDataNavigation.LoadModels();

			UpdateMainUI();

			onOpening();
		}

		public void UpdateMainUI()
		{
			btnComSave.Enabled = DataChanged;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns>是否取消关闭</returns>
		protected virtual bool onClosing()
		{
			return false;
		}

		protected virtual void onOpening()
		{
		}

		public bool IsRunning { get; protected set; }


		//events

		private void btnComOptions_Click(object sender, EventArgs e)
		{
			if (IActions != null) IActions.onButtonClick(this, CommonToolButtonAction.Options, null);
		}

		private void btnComSave_Click(object sender, EventArgs e)
		{
			if (IActions != null) IActions.onButtonClick(this, CommonToolButtonAction.Save, null);
		}

		private void btnComBrowse_Click(object sender, EventArgs e)
		{
			if (IActions != null) IActions.onButtonClick(this, CommonToolButtonAction.Browse, null);
		}

		private void btnComExport_Click(object sender, EventArgs e)
		{
			if (IActions != null) IActions.onButtonClick(this, CommonToolButtonAction.Export, null);
		}

		private void btnComExportAll_Click(object sender, EventArgs e)
		{
			if (IActions != null) IActions.onButtonClick(this, CommonToolButtonAction.ExportAll, null);
		}

		private void btnModule_Click(object sender, EventArgs e)
		{
			if (sender is ToolStripButton == false) return;
			ToolStripButton btn = ((ToolStripButton)sender);

			if (btn.Tag is ModuleButtonInfo == false) return;
			ModuleButtonInfo info = (ModuleButtonInfo)btn.Tag;

			if (info.Form != null)
			{
				info.Form.Show();
				info.Form.Focus();
			}
		}
	}
}
