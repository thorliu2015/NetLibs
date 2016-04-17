using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Solar.Data;
using Solar.Dialogs;
using System.Diagnostics;
using THOR.Utils.Attributes;
using System.Reflection;

namespace Solar.Common
{

	/// <summary>
	/// 
	/// </summary>
	public partial class ModelDataNavigation : UserControl
	{

		/// <summary>
		/// 
		/// </summary>
		public ModelDataNavigation()
		{
			InitializeComponent();

			filterType = typeof(SModel);
		}

		//event biz ----

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_Click(object sender, EventArgs e)
		{
			Type newType = filterType;
			if (newType.IsAbstract)
			{
				//选择子类
				DialogSubTypeSelector typeSelector = new DialogSubTypeSelector();
				typeSelector.BaseType = newType;
				if (typeSelector.ShowDialog(this) == DialogResult.Cancel)
				{
					return;
				}
				else
				{
					newType = typeSelector.SelectedType;
				}
			}


			DialogModelProperty dialog = new DialogModelProperty();
			dialog.SelectedModelType = newType;
			dialog.SelectedAction = DialogModelPropertyAction.Add;
			dialog.SelectedCategory = SelectedCategory;
			if (dialog.ShowDialog(this) == DialogResult.Cancel) return;

			SModel newModel = dialog.SelectedModel;

			TreeNode node = new TreeNode();
			SetTreeNode(node, newModel);

			AddNode(node, GetCategoryNodes(newModel.EditorCategory));

			treeDataNavigation.SelectedNode = node;

			UpdateUI();

			SetDataChange();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		/// <param name="nodes"></param>
		protected void AddNode(TreeNode node, TreeNodeCollection nodes)
		{
			int i = -1;
			foreach (TreeNode e in nodes)
			{
				i++;

				if (e.Tag is SModel)
				{
					//如果旧节点是数据
					if (node.Tag is SModel)
					{
						//如果新节点也是数据
						if (((SModel)node.Tag).CompareTo((SModel)e.Tag) < 0)
						{
							nodes.Insert(i, node);
							return;
						}
					}
					else
					{
						//如果新节点不是数据
						nodes.Insert(i, node);
						return;
					}
				}
				else
				{
					//如果旧节点不是数据
					if (node.Tag is SModel == false)
					{
						//如果新节点也不是数据
						if (String.Compare(node.Text, e.Text) < 0)
						{
							nodes.Insert(i, node);
							return;
						}
					}
				}
			}

			nodes.Add(node);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (SelectedModel == null) return;

			if (MessageBox.Show(String.Format("确定要删除 {0} 么?", SelectedNode.Text), "删除数据", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
			{
				return;
			}

			SModelManager.Current.Remove(SelectedModel.Id);
			SelectedNode.Remove();

			UpdateUI();

			SetDataChange();

			if (AfterModelSelected != null)
			{
				AfterModelSelected(this, new EventArgs());
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnProperty_Click(object sender, EventArgs e)
		{
			DialogModelProperty dialog = new DialogModelProperty();
			dialog.SelectedAction = DialogModelPropertyAction.Modify;
			dialog.SelectedModel = SelectedModel;
			if (dialog.ShowDialog(this) == DialogResult.Cancel) return;

			SModel model = dialog.SelectedModel;

			TreeNode node = SelectedNode;
			node.Remove();
			SetTreeNode(node, model);
			AddNode(node, GetCategoryNodes(model.EditorCategory));
			treeDataNavigation.SelectedNode = node;

			UpdateUI();

			SetDataChange();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClone_Click(object sender, EventArgs e)
		{
			DialogModelProperty dialog = new DialogModelProperty();
			dialog.SelectedAction = DialogModelPropertyAction.Clone;
			dialog.SelectedModel = SelectedModel;
			if (dialog.ShowDialog(this) == DialogResult.Cancel) return;

			SModel newModel = dialog.SelectedModel;

			TreeNode node = new TreeNode();
			SetTreeNode(node, newModel);

			AddNode(node, GetCategoryNodes(newModel.EditorCategory));

			treeDataNavigation.SelectedNode = node;

			UpdateUI();

			SetDataChange();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSearch_Click(object sender, EventArgs e)
		{

			if (treeDataNavigation.Nodes.Count == 0) return;
			if (txtSearch.Text.Trim().Length == 0) return;
			TreeNode node = SelectedNode;
			if (node == null) node = treeDataNavigation.Nodes[0];

			bool alreadyLoop = false;
			while (node != null)
			{
				if (node.Text.IndexOf(txtSearch.Text.Trim()) >= 0 && node != SelectedNode && node.Tag is SModel)
				{
					treeDataNavigation.SelectedNode = node;
					return;
				}
				else
				{
					if (node.Nodes.Count > 0)
					{
						node = node.Nodes[0];
					}
					else if (node.NextNode != null)
					{
						node = node.NextNode;
					}
					else
					{

						while (true)
						{
							if (node.Parent == null)
							{
								if (!alreadyLoop)
								{
									node = treeDataNavigation.Nodes[0];
									alreadyLoop = true;
									break;
								}
								else
								{
									return;
								}
							}
							if (node.Parent.NextNode != null)
							{
								node = node.Parent.NextNode;
								break;
							}
							else
							{
								if (!alreadyLoop)
								{
									node = treeDataNavigation.Nodes[0];
									alreadyLoop = true;
									break;
								}
								else
								{
									return;
								}
							}
						}


					}
				}
			}

			UpdateUI();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void treeDataNavigation_AfterSelect(object sender, TreeViewEventArgs e)
		{
			UpdateUI();

			if (AfterModelSelected != null)
			{
				AfterModelSelected(this, new EventArgs());
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void treeDataNavigation_NodeDragDrop(object sender, THOR.Windows.UI.Components.NodeDragDropEventArgs e)
		{
			e.IsCancel = true;
			if (e.DragNode.Tag == null) return;
			if (e.TargetNode.Tag != null) return;
			e.DragNode.Remove();
			AddNode(e.DragNode, e.TargetNode.Nodes);
			treeDataNavigation.SelectedNode = e.DragNode;

			UpdateUI();

			SetDataChange();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			LoadModels();
			UpdateUI();
		}



		/// <summary>
		/// 
		/// </summary>
		public void LoadModels()
		{
			List<SModel> models = new List<SModel>();
			SModelManager.Current.GetModels(models, filterType);

			treeDataNavigation.Nodes.Clear();
			foreach (SModel model in models)
			{
				TreeNode node = new TreeNode();
				SetTreeNode(node, model);

				AddNode(node, GetCategoryNodes(model.EditorCategory));
			}

			UpdateUI();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		public void SelectModel(SModel model)
		{
			//TODO: SelectModel
		}

		/// <summary>
		/// 设置类型菜单需要支持的类型
		/// </summary>
		/// <param name="Types"></param>
		public void SetTypesMenu(List<Type> Types)
		{
			btnTypes.DropDownItems.Clear();

			if (Types.Count <= 1) return;

			foreach(Type type in Types)
			{
				string typeName = type.Name;
				object[] objs = type.GetCustomAttributes(typeof(NoteAttribute), true);
				if (objs.Length > 0)
				{
					if (objs[0] is NoteAttribute)
					{
						typeName = ((NoteAttribute)objs[0]).Name;
					}
				}
				ToolStripMenuItem item = new ToolStripMenuItem();
				item.Text = typeName;
				item.Tag = type;
				item.Click += item_Click;
				btnTypes.DropDownItems.Add(item);
			}

			UpdateUI();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void item_Click(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem)
			{
				ToolStripMenuItem item = (ToolStripMenuItem)sender;
				if (item.Tag is Type)
				{
					filterType = (Type)item.Tag;

					LoadModels();
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTypes_DropDownOpening(object sender, EventArgs e)
		{
			foreach (ToolStripMenuItem item in btnTypes.DropDownItems)
			{
				if (item.Tag == filterType)
				{
					item.Checked = true;
				}
				else
				{
					item.Checked = false;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		/// <param name="model"></param>
		protected void SetTreeNode(TreeNode node, SModel model)
		{
			if (model.EditorSuffix.Length > 0)
			{
				node.Text = String.Format("({0}){1}({2})", model.Id, model.EditorName, model.EditorSuffix);
			}
			else
			{
				node.Text = String.Format("({0}){1}", model.Id, model.EditorName, model.EditorSuffix);
			}

			node.ToolTipText = model.EditorDescription;


			string itemImageKey = String.Format("{0}.png", model.GetType().Name);

			if (!imageList.Images.ContainsKey(itemImageKey))
			{
				itemImageKey = "item.png";
			}

			node.ImageKey = node.SelectedImageKey = itemImageKey;
			node.Tag = model;

		}


		

		/// <summary>
		/// 
		/// </summary>
		protected void UpdateUI()
		{
			btnRemove.Enabled =
				btnProperty.Enabled =
				btnClone.Enabled =
				(SelectedModel != null);

			btnSearch.Enabled =
				txtSearch.Enabled =
				treeDataNavigation.Nodes.Count > 0;


			btnAdd.Visible =
				btnRemove.Visible =
				btnProperty.Visible =
				toolStripSeparator1.Visible =
				toolStripSeparator2.Visible =
				btnClone.Visible = !ReadOnly;

			btnTypes.Visible = btnTypes.DropDownItems.Count > 0;

		}

		protected void SetDataChange()
		{
			if (this.ParentForm is FrmAbstractModule)
			{
				((FrmAbstractModule)this.ParentForm).DataChanged = true;
				((FrmAbstractModule)this.ParentForm).UpdateMainUI();
			}
		}

		//properties ----


		/// <summary>
		/// 
		/// </summary>
		protected Type filterType;

		/// <summary>
		/// 
		/// </summary>
		public Type FilterType
		{
			get
			{
				return filterType;
			}
			set
			{
				if (filterType == value) return;
				filterType = value;

				LoadModels();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public SModel SelectedModel
		{
			get
			{
				if (SelectedNode != null)
				{
					if (SelectedNode.Tag is SModel)
					{
						return (SModel)SelectedNode.Tag;
					}
				}
				return null;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public TreeNode SelectedNode
		{
			get
			{
				return treeDataNavigation.SelectedNode;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SelectedCategory
		{
			get
			{
				string result = "";

				if (SelectedNode != null)
				{
					if (SelectedNode.Tag is SModel)
					{
						if (SelectedNode.Parent != null)
						{
							return SelectedNode.Parent.FullPath;
						}
					}
					else
					{
						return SelectedNode.FullPath;
					}
				}

				return result;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="categoryPath"></param>
		/// <returns></returns>
		public TreeNodeCollection GetCategoryNodes(string categoryPath)
		{

			string category = categoryPath;

			string[] categories = category.Split(new char[2] { '/', '\\' });

			TreeNodeCollection nodes = treeDataNavigation.Nodes;
			foreach (string categoryName in categories)
			{
				bool found = false;
				foreach (TreeNode node in nodes)
				{
					if (node.Tag != null) continue;
					if (node.Text == categoryName)
					{
						found = true;
						nodes = node.Nodes;
						break;
					}
				}
				if (!found)
				{
					TreeNode categoryNode = new TreeNode();
					categoryNode.Text = categoryName;
					categoryNode.ImageKey = categoryNode.SelectedImageKey = "category.png";
					AddNode(categoryNode, nodes);
					nodes = categoryNode.Nodes;
				}
			}


			return nodes;

		}

		/// <summary>
		/// 
		/// </summary>
		public event EventHandler AfterModelSelected;

		protected bool readOnly;
		public bool ReadOnly
		{
			get
			{
				return readOnly;
			}
			set
			{
				readOnly = value;
				UpdateUI();
			}
		}

		
	}
}
