using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using THOR.Windows.UI.Renders;
using System.Drawing;
using System.Diagnostics;

namespace THOR.Windows.UI.Components
{
	public class TTreeView : TreeView
	{
		public TTreeView()
			: base()
		{
			Init();
		}

		protected void Init()
		{
			this.Font = UIRender.DefaultFont;
			this.BorderStyle = BorderStyle.None;
			this.LineColor = Color.FromArgb(0x80, SystemColors.ControlDark);

			Dock = DockStyle.Fill;

			this.AllowDrop = true;
			this.ItemDrag += TTreeView_ItemDrag;
			this.DragEnter += TTreeView_DragEnter;
			this.DragDrop += TTreeView_DragDrop;
			this.DragOver += TTreeView_DragOver;
		}

		void TTreeView_DragOver(object sender, DragEventArgs e)
		{

			Point pt = this.PointToClient(new Point(e.X, e.Y));
			SelectedNode = GetNodeAt(pt);
			if (SelectedNode != null)
			{
				SelectedNode.Expand();
			}
		}

		void TTreeView_DragDrop(object sender, DragEventArgs e)
		{

			Point targetPoint = this.PointToClient(new Point(e.X, e.Y));
			TreeNode targetNode = GetNodeAt(targetPoint);

			TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
			if (!draggedNode.Equals(targetNode))
			{
				if (targetNode != null && !ContainsNode(draggedNode, targetNode))
				{
					if (NodeDragDrop != null)
					{
						NodeDragDropEventArgs ea = new NodeDragDropEventArgs(draggedNode, targetNode);
						NodeDragDrop(this, ea);

						if (ea.IsCancel) return;
					}

					draggedNode.Remove();
					targetNode.Nodes.Add(draggedNode);

					SelectedNode = draggedNode;

					
				}
			}

			targetNode.ExpandAll();

		}

		void TTreeView_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode"))
			{
				e.Effect = DragDropEffects.Move;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		void TTreeView_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (!AllowDragNode) return;
			if (e.Button == MouseButtons.Left)
			{
				DoDragDrop(e.Item, DragDropEffects.Move);
			}
		}

		private bool ContainsNode(TreeNode node1, TreeNode node2)
		{
			if (node2.Parent == null) return false;
			if (node2.Parent.Equals(node1)) return true;
			return ContainsNode(node1, node2.Parent);
		}



		public delegate void NodeDragDropEventHandler(object sender, NodeDragDropEventArgs e);
		public event NodeDragDropEventHandler NodeDragDrop;

		public bool AllowDragNode { get; set; }
	}

	public class NodeDragDropEventArgs : EventArgs
	{
		public NodeDragDropEventArgs(TreeNode dragNode, TreeNode targetNode)
		{
			DragNode = dragNode;
			TargetNode = targetNode;
		}

		public bool IsCancel { get; set; }
		public TreeNode DragNode { get; private set; }
		public TreeNode TargetNode { get; private set; }
	}
}
