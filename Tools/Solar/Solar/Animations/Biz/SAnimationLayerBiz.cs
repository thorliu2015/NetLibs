using Solar.Data;
using Solar.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Utils.Attributes;
using THOR.Windows.UI.Forms;

namespace Solar.Animations.Biz
{
	/// <summary>
	/// 动画图层的业务逻辑
	/// </summary>
	public class SAnimationLayerBiz
	{
		/// <summary>
		/// 加载图层树
		/// </summary>
		/// <param name="treeView"></param>
		/// <param name="animation"></param>
		static public void LoadLayers(TreeView treeView, SAnimation animation)
		{
			treeView.Nodes.Clear();

			foreach (SAnimationState state in animation.States)
			{
				AddTreeNode(treeView.Nodes, state);
			}
		}

		/// <summary>
		/// 设定节点参数
		/// </summary>
		/// <param name="node"></param>
		/// <param name="layer"></param>
		static public void SetTreeNode(TreeNode node, SAnimationLayer layer)
		{
			string iconKey = (layer is SAnimationState) ? "state.png" : "layer.png";

			if (layer is SAnimationState)
			{
				string t = NoteAttribute.GetNoteNameByEnum(((SAnimationState)layer).StateType);
				node.Text = String.Format("({1}){0}", layer.Name, t);
			}
			else
			{
				node.Text = layer.Name;
			}
			
			node.ImageKey = node.SelectedImageKey = iconKey;
			node.Tag = layer;
		
		}

	

		/// <summary>
		/// 图层对象选定时
		/// </summary>
		/// <param name="nodes"></param>
		/// <param name="layer"></param>
		/// <returns></returns>
		static public TreeNode AddTreeNode(TreeNodeCollection nodes, SAnimationLayer layer)
		{
			TreeNode node = new TreeNode();
			SetTreeNode(node, layer);

			if (layer is SAnimationState)
			{
				bool added = false;
				for (int i = 0; i < nodes.Count; i++)
				{

					if (nodes[i].Tag is SAnimationState)
					{
						if (((SAnimationState)layer).CompareTo((SAnimationState)nodes[i].Tag) < 0)
						{
							added = true;
							nodes.Insert(i, node);
							break;
						}
					}
				}

				if (!added)
				{
					nodes.Add(node);
				}
			}
			else
			{
				nodes.Add(node);
			}

			return node;
		}

		/// <summary>
		/// 添加状态
		/// </summary>
		/// <param name="animation"></param>
		static public void AddState(SAnimation animation, TreeView tree)
		{

			SAnimationState state = new SAnimationState();
			animation.States.Add(state);
			state.OwnerAnimation = animation;


			TreeNode node = AddTreeNode(tree.Nodes, state);
			tree.SelectedNode = node;

			animation.ChangeType |= DataChangeTypes.DataChanged;
		}


		/// <summary>
		/// 添加图层
		/// </summary>
		/// <param name="layer"></param>
		static public void AddLayer(SAnimationLayer layer, TreeView tree)
		{
			if (tree.SelectedNode == null || tree.SelectedNode.Tag is SAnimationLayer == false) return;

			SAnimationLayer newLayer = new SAnimationLayer();
			newLayer.OwnerAnimation = layer.OwnerAnimation;
			layer.Add(newLayer);


			TreeNode node = AddTreeNode(tree.SelectedNode.Nodes, newLayer);
			tree.SelectedNode = node;

			layer.OwnerAnimation.ChangeType |= DataChangeTypes.DataChanged;
		}


		/// <summary>
		/// 删除图层
		/// </summary>
		/// <param name="layer"></param>
		static public void DeleteLayer(TreeView tree)
		{
			if (tree.SelectedNode == null || tree.SelectedNode.Tag is SAnimationLayer == false) return;

			if (MessageBox.Show(String.Format("确定要删除 {0} 吗?", tree.SelectedNode.Text), "删除节点", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) return;

			SAnimationLayer layer = (SAnimationLayer)tree.SelectedNode.Tag;

			layer.OwnerAnimation.ChangeType |= Data.DataChangeTypes.DataChanged;
			if (layer is SAnimationState)
			{
				layer.OwnerAnimation.States.Remove((SAnimationState)layer);
			}
			else
			{
				layer.Remove();
			}

			tree.SelectedNode.Remove();

			layer.OwnerAnimation.ChangeType |= DataChangeTypes.DataChanged;
		}


		/// <summary>
		/// 打开属性
		/// </summary>
		/// <param name="layer"></param>
		static public void OpenProperty(FrmAbstractModule form, TreeView tree)
		{
			if (tree.SelectedNode == null || tree.SelectedNode.Tag is SAnimationLayer == false) return;



			SAnimationLayer layer = (SAnimationLayer)tree.SelectedNode.Tag;
			DialogObjectProperty dialog = new DialogObjectProperty();
			dialog.Text = "属性";
			dialog.Title = layer.GetNoteName();
			dialog.CurrentObject = layer;
			dialog.Show(form, true);

			SetTreeNode(tree.SelectedNode, layer);
		}

		/// <summary>
		/// 上移节点
		/// </summary>
		/// <param name="layer"></param>
		static public void MoveUp(SAnimationLayer layer)
		{
		}

		/// <summary>
		/// 下移节点
		/// </summary>
		/// <param name="layer"></param>
		static public void MoveDown(SAnimationLayer layer)
		{
		}
	}
}
