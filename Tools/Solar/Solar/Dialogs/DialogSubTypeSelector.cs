using Solar.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using THOR.Utils.Attributes;

namespace Solar.Dialogs
{
	public partial class DialogSubTypeSelector : THOR.Windows.UI.Forms.DialogBase
	{
		public DialogSubTypeSelector()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Type b = BaseType;
			List<Type> ts = SModel.GetTypes(b);

			treeTypes.Nodes.Clear();
			foreach (Type t in ts)
			{
				string typeName = t.Name;
				string categoryName = "";
				string description = "";
				object[] objs = t.GetCustomAttributes(typeof(NoteAttribute), false);
				if (objs.Length > 0)
				{
					if (objs[0] is NoteAttribute)
					{
						NoteAttribute note = ((NoteAttribute)objs[0]);
						typeName = note.Name;
						categoryName = note.Category;
						description = note.Description;
					}
				}

				TreeNodeCollection nodes = treeTypes.Nodes;

				if (categoryName.Length > 0)
				{
					bool found = false;
					foreach (TreeNode cnode in treeTypes.Nodes)
					{
						if (cnode.Tag is Type) continue;
						if (cnode.Text == categoryName)
						{
							nodes = cnode.Nodes;
							found = true;
							break;
						}
					}

					if (!found)
					{
						TreeNode n = new TreeNode();
						n.ImageKey = n.SelectedImageKey = "category.png";
						n.Text = categoryName;
						treeTypes.Nodes.Add(n);
						nodes = n.Nodes;
					}
				}

				TreeNode nodeType = new TreeNode();
				nodeType.ImageKey = nodeType.SelectedImageKey = "item.png";
				nodeType.Text = typeName;
				nodeType.ToolTipText = description;
				nodeType.Tag = t;
				nodes.Add(nodeType);

			}

			treeTypes.ExpandAll();
		}

		protected override bool OnButtonOKClick()
		{
			bool result = SelectedType != null;

			if (!result)
			{
				MessageBox.Show("请选择数据类型", "错误操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			return result;
		}

		public Type BaseType { get; set; }
		public Type SelectedType
		{
			get
			{
				if (treeTypes.SelectedNode != null)
				{
					if (treeTypes.SelectedNode.Tag is Type)
					{
						return (Type)treeTypes.SelectedNode.Tag;
					}
				}
				return null;
			}
		}
	}
}
