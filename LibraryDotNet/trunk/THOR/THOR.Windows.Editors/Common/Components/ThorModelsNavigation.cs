using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using THOR.Windows.Components.Common;
using THOR.Windows.Components.ThorGrids.Models;
using THOR.Windows.Components.ThorGrids.Utils;
using THOR.Windows.Editors.Common.Core;
using THOR.Windows.Editors.Common.Data;
using THOR.Windows.Editors.Common.Dialogs;
using THOR.Windows.Languages;

namespace THOR.Windows.Editors.Common.Components
{
	/// <summary>
	/// 数据导航面板
	/// </summary>
	public partial class ThorModelsNavigation : THOR.Windows.Components.Common.ThorUserControl
	{
		#region variables
		protected bool ReadOnly = false;
		protected EditorModule Module;
		protected ThorDataTable table = new ThorDataTable();

		protected List<Type> listTypes;
		#endregion

		#region construct
		/// <summary>
		/// 构造
		/// </summary>
		public ThorModelsNavigation()
		{
			InitializeComponent();

			InitLanguage();
			UpdateUI();

			txtSearch.TextBox.TextChanged += TextBox_TextChanged;
			txtSearch.TextBox.KeyDown += TextBox_KeyDown;
		}
		#endregion



		/// <summary>
		/// 初始化语言
		/// </summary>
		protected virtual void InitLanguage()
		{
			thorPanel.Title = ThorLanguages.Current.GetText("/language/models.navigation/title", "Directories");
			menuTypes.Text = menuTypes.ToolTipText = ThorLanguages.Current.GetText("/language/models.navigation/types", "Types");
			btnCreate.Text = btnCreate.ToolTipText = ThorLanguages.Current.GetText("/language/models.navigation/create", "Create");
			btnDelete.Text = btnDelete.ToolTipText = ThorLanguages.Current.GetText("/language/models.navigation/delete", "Delete");
			btnModify.Text = btnModify.ToolTipText = ThorLanguages.Current.GetText("/language/models.navigation/modify", "Modify");
			btnClone.Text = btnClone.ToolTipText = ThorLanguages.Current.GetText("/language/models.navigation/clone", "Clone");
		}

		/// <summary>
		/// 设置只读
		/// </summary>
		/// <param name="isreadonly"></param>
		public virtual void SetReadOnly(bool isreadonly)
		{
			ReadOnly = isreadonly;
			UpdateUI();
		}

		/// <summary>
		/// 缩放控件时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			txtSearch.Width = Width - txtSearch.Left - btnSearch.Width - 2;
		}

		/// <summary>
		/// 设置模块
		/// </summary>
		/// <param name="module"></param>
		public virtual void SetModule(EditorModule module)
		{
			Module = module;
			SetReadOnly(module.ReadOnly);
			SetModuleTypes(module);
		}

		/// <summary>
		/// 设置模块类型
		/// </summary>
		/// <param name="module"></param>
		protected virtual void SetModuleTypes(EditorModule module)
		{
			if (module == null) return;
			List<Type> allTypes = new List<Type>();
			foreach (EditorModuleEntityType ts in module.Types)
			{
				foreach (Type t in ts.Types)
				{
					if (allTypes.Contains(t)) continue;
					allTypes.Add(t);
				}

				ToolStripMenuItem menuType = new ToolStripMenuItem();
				menuType.Text = ThorLanguages.Current.GetText(String.Format("/language/models.navigation/categories/{0}", ts.Name), ts.Name);
				menuType.Tag = ts.Types;
				menuType.Click += menuType_Click;

				menuTypes.DropDownItems.Add(menuType);
			}

			ToolStripMenuItem menuAll = new ToolStripMenuItem();
			menuAll.Text = ThorLanguages.Current.GetText("/language/models.navigation/categories/all", "all");
			menuAll.Tag = allTypes;
			menuAll.Checked = true;
			menuAll.Click += menuType_Click;
			menuTypes.DropDownItems.Insert(0, menuAll);

			menuTypes.Visible = toolStripSeparatorTypes.Visible = (module.Types.Count > 1);

			listTypes = allTypes;
			LoadEntitiesTree();
		}

		/// <summary>
		/// 点击类型
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void menuType_Click(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem == false) return;
			ToolStripMenuItem menuType = (ToolStripMenuItem)sender;

			foreach (ToolStripMenuItem menu in menuTypes.DropDownItems)
			{
				if (menu.Tag is List<Type> == false) continue;
				List<Type> ts = (List<Type>)menu.Tag;
				bool c = (menu == menuType);
				menu.Checked = (c);
				listTypes = ts;
				LoadEntitiesTree();
			}
		}

		/// <summary>
		/// 更新界面状态
		/// </summary>
		protected virtual void UpdateUI()
		{
			bool bSelectedEntity = (SelectedEntity != null);
			bool bBack = false;
			bool bNext = false;
			bool bSearch = (txtSearch.TextBox.Text.Trim().Length > 0);

			btnCreate.Enabled = (!ReadOnly);
			btnDelete.Enabled = (!ReadOnly && bSelectedEntity);
			btnModify.Enabled = (!ReadOnly && bSelectedEntity);
			btnClone.Enabled = (!ReadOnly && bSelectedEntity);

			btnBack.Enabled = bBack;
			btnNext.Enabled = bNext;
			btnSearch.Enabled = bSearch;
		}

		/// <summary>
		/// 搜索输入框内容改变时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void TextBox_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		/// <summary>
		/// 在搜索输入框中按下键盘时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void TextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && !e.Control && !e.Shift && !e.Alt)
			{
				btnSearch_Click(null, null);
			}
		}

		#region 树形视图



		public virtual void LoadEntitiesTree()
		{
			if (table.Columns.Count > 0) return;
			table.Columns.Add(new ThorDataTableColumn());

			treeModels.DataTable = table;

			List<CEntity> list = new List<CEntity>();

			EditorModuleDataProvider.GetEntities(Module, list);

			foreach (CEntity entity in list)
			{
				AddEntityToTree(entity);
			}
		}

		protected virtual void AddEntityToTree(CEntity entity)
		{
			ThorDataTableRow row = CEntityTableDataBuilder.GetEntityRow(entity);
			ThorDataTableRow rowCategory = CEntityTableDataBuilder.GetCategoryRow(table, entity.EditorCategory);

			if (rowCategory == null)
			{
				table.Rows.Add(row);
			}
			else
			{
				rowCategory.Rows.Add(row);
			}
		}


		public string GetCurrentCategory()
		{
			string ret = "";

			if (treeModels.SelectedRow != null)
			{
				if (treeModels.SelectedRow.TagData is CEntity)
				{
					CEntity entity = (CEntity)treeModels.SelectedRow.TagData;
					ret = entity.EditorCategory;
				}
				else
				{
					ret = treeModels.SelectedRow.Path;
				}
			}


			return ret;
		}
		#endregion

		#region 交互

		/// <summary>
		/// 新建数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCreate_Click(object sender, EventArgs e)
		{
			if (listTypes == null || listTypes.Count == 0)
			{
				return;
			}

			//----

			Type type = null;
			if (listTypes.Count > 1)
			{
				//选择一个类型
				DialogEntityTypeSelector dialog = new DialogEntityTypeSelector();
				dialog.SetTypes(listTypes);
				if (dialog.ShowDialog(this.FindForm()) == DialogResult.Cancel) return;

				type = dialog.SelectedType;
			}
			else
			{
				type = listTypes[0];
			}


			Object entityObject = System.Activator.CreateInstance(type);
			if (entityObject is CEntity == false) return;
			CEntity entityData = (CEntity)entityObject;

			entityData.EditorCategory = GetCurrentCategory();

			DialogEntityProperty dialogProperty = new DialogEntityProperty();
			dialogProperty.SetEntity(entityData);
			if (dialogProperty.ShowDialog(this.FindForm()) == DialogResult.Cancel) return;

			AddEntityToTree(entityData);
			treeModels.DataTable.Invalidated = true;
			treeModels.Invalidate();
		}

		/// <summary>
		/// 删除数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (SelectedEntity == null) return;

			string strContent = "你确定要删除 {0} 吗?";
			string strTitle = "删除数据";

			strContent = String.Format(strContent, SelectedEntity.GetFullID());

			if (ThorUI.ShowMessageBox(strTitle, strContent, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, this) == DialogResult.Cancel) return;

			CEntityPool.Current.Remove(SelectedEntity);

			if (treeModels.SelectedRow != null)
			{
				ThorDataTableMemberCollection<ThorDataTableRow> rows = (ThorDataTableMemberCollection<ThorDataTableRow>)treeModels.SelectedRow.OwnerCollection;

				rows.Remove(treeModels.SelectedRow);
				treeModels.DataTable.Invalidated = true;
				treeModels.Invalidate();
			}
		}

		/// <summary>
		/// 修改数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModify_Click(object sender, EventArgs e)
		{
			if (SelectedEntity == null) return;

			DialogEntityProperty dialogProperty = new DialogEntityProperty();
			dialogProperty.SetEntity(SelectedEntity);
			dialogProperty.ShowDialog(this.FindForm());

			ThorDataTableRow row= treeModels.SelectedRow;
			ThorDataTableMemberCollection<ThorDataTableRow> collection = (ThorDataTableMemberCollection<ThorDataTableRow>)treeModels.SelectedRow.OwnerCollection;

			collection.Remove(row);

			ThorDataTableRow rowCategory = CEntityTableDataBuilder.GetCategoryRow(treeModels.DataTable, SelectedEntity.EditorCategory);
			if (rowCategory == null)
			{
				treeModels.DataTable.Rows.Add(row);
			}
			else
			{
				rowCategory.Rows.Add(row);
			}

			treeModels.DataTable.Invalidated = true;
			treeModels.Invalidate();

		}

		/// <summary>
		/// 克隆数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClone_Click(object sender, EventArgs e)
		{

			if (SelectedEntity == null) return;

			CEntity cloneEntity = SelectedEntity.Clone();
			cloneEntity.Id = "";


			DialogEntityProperty dialogProperty = new DialogEntityProperty();
			dialogProperty.SetEntity(cloneEntity);
			if (dialogProperty.ShowDialog(this.FindForm()) == DialogResult.Cancel) return;

			AddEntityToTree(cloneEntity);

			treeModels.DataTable.Invalidated = true;
			treeModels.Invalidate();
		}

		/// <summary>
		/// 搜索数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSearch_Click(object sender, EventArgs e)
		{
			if (txtSearch.TextBox.Text.Trim().Length == 0) return;
			ThorDataTableRow row = ThorDataTableFinder.FindRow(treeModels.DataTable, txtSearch.TextBox.Text.Trim(), treeModels.SelectedRow);

			treeModels.SelectedRow = row;
			treeModels.ScrollToSelection();

			if (SelectionChanged != null)
			{
				SelectionChanged(this, new EventArgs());
			}

			UpdateUI();
		}

		/// <summary>
		/// 后退
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnBack_Click(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 前进
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnNext_Click(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 树形视图的选定内容改变时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void treeModels_SelectionChanged(object sender, EventArgs e)
		{
			UpdateUI();

			if (SelectionChanged != null)
			{
				SelectionChanged(this, new EventArgs());
			}
		}

		#endregion

		#region properties

		/// <summary>
		/// 获取当前选定的内容
		/// </summary>
		public CEntity SelectedEntity
		{
			get
			{
				if (treeModels.SelectedRow != null && treeModels.SelectedRow.TagData is CEntity)
				{
					return (CEntity)treeModels.SelectedRow.TagData;
				}

				return null;
			}
		}

		#endregion

		#region events
		/// <summary>
		/// 事件: 当选定内容改变时
		/// </summary>
		public event EventHandler SelectionChanged;
		#endregion

	}
}
