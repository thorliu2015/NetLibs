using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using THOR.Utils.Attributes;
using System.ComponentModel;

namespace Solar.Data
{

	[Serializable()]
/// <summary>
	/// 树型节点数据
	/// </summary>
	public abstract class SModelNode
	{
		/// <summary>
		/// 子节点列表
		/// </summary>
		protected List<SModelNode> ChildNodes = new List<SModelNode>();

		/// <summary>
		/// 构造
		/// </summary>
		public SModelNode()
		{
		}

	

		/// <summary>
		/// 获取指定索引的子节点
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public SModelNode this[int index]
		{
			get
			{
				if (index >= 0 && index < ChildNodes.Count)
				{
					return ChildNodes[index];
				}

				return null;
			}
		}





		/// <summary>
		/// 检查是否包含指定的子节点
		/// </summary>
		/// <param name="node">子节点</param>
		/// <param name="checkChildLevels">是否递归检查子级节点</param>
		/// <returns></returns>
		public bool Contains(SModelNode node, bool checkChildLevels = false)
		{
			foreach (SModelNode child in ChildNodes)
			{
				if (child == node) return true;

				if (checkChildLevels)
				{
					if (child.Contains(node, checkChildLevels)) return true;
				}
			}

			return false;
		}

		/// <summary>
		/// 添加一个子节点
		/// </summary>
		/// <param name="node"></param>
		public void Add(SModelNode node)
		{
			if (node == null) return;
			if (Contains(node)) return;

			node.ParentNode = this;
			ChildNodes.Add(node);
			node.OnAddToParent();
		}

		/// <summary>
		/// 添加一个子节点到指定的索引位置
		/// </summary>
		/// <param name="node"></param>
		/// <param name="index"></param>
		public void Add(SModelNode node, int index)
		{
			if (node == null) return;
			if (Contains(node)) return;

			if (index >= 0 && index < ChildNodes.Count)
			{
				node.ParentNode = this;
				ChildNodes.Insert(index, node);
				node.OnAddToParent();
			}
			else
			{
				node.ParentNode = this;
				ChildNodes.Add(node);
				node.OnAddToParent();
			}
		}

	
		/// <summary>
		/// 移除指定的子节点
		/// </summary>
		/// <param name="node"></param>
		public void Remove(SModelNode node)
		{
			for (int i = ChildNodes.Count - 1; i >= 0; i--)
			{
				if (ChildNodes[i] == node)
				{
					ChildNodes[i].OnRemoveFromParent();
					ChildNodes[i].ParentNode = null;
					ChildNodes.RemoveAt(i);
				}
			}
		}

		/// <summary>
		/// 移除当前节点
		/// </summary>
		public void Remove()
		{
			if (ParentNode == null) return;

			ParentNode.Remove(this);
		}

		/// <summary>
		/// 清除所有子节点
		/// </summary>
		public void Clear()
		{
			foreach (SModelNode node in ChildNodes)
			{
				node.Clear();

				node.OnRemoveFromParent();
				node.ParentNode = null;
			}

			ChildNodes.Clear();
		}

		/// <summary>
		/// 上移子节点
		/// </summary>
		public void MoveUp()
		{
			if (ParentNode == null) return;
			SModelNode parent = ParentNode;
			int index = Index;

			if (index <= 0) return;
			index--;
			if (index < 0) index = 0;

			parent.ChildNodes.Remove(this);
			parent.ChildNodes.Insert(index, this);

		}

		/// <summary>
		/// 下移子节点
		/// </summary>
		public void MoveDown()
		{
			if (ParentNode == null) return;
			SModelNode parent = ParentNode;
			int index = Index;

			if (index >= ParentNode.Count - 1) return;

			index++;

			parent.ChildNodes.Remove(this);
			if (index > parent.ChildNodes.Count - 1)
			{
				parent.ChildNodes.Add(this);
			}
			else
			{
				parent.ChildNodes.Insert(index, this);
			}
		}

		/// <summary>
		/// 从父节点移除时
		/// </summary>
		virtual protected void OnRemoveFromParent()
		{
		}

		/// <summary>
		/// 添加到父节点时
		/// </summary>
		virtual protected void OnAddToParent()
		{
		}


		[Browsable(false)]
		/// <summary>
		/// 获取当前父节点
		/// </summary>
		public SModelNode ParentNode { get; protected set; }



		[Browsable(false)]
		/// <summary>
		/// 获取子节点数量
		/// </summary>
		public int Count
		{
			get
			{
				return ChildNodes.Count;
			}
		}


		[Browsable(false)]
		/// <summary>
		/// 获取当前节点的索引
		/// </summary>
		public int Index
		{
			get
			{
				if (ParentNode != null)
				{
					for (int i = 0; i < ParentNode.Count; i++)
					{
						if (ParentNode[i] == this) return i;
					}
				}
				return 0;
			}
		}






		/// <summary>
		/// 获取备注信息
		/// </summary>
		/// <returns></returns>
		public NoteAttribute GetNoteAttribute()
		{
			Type t = this.GetType();
			object[] os = t.GetCustomAttributes(typeof(NoteAttribute), true);
			if (os.Length > 0)
			{
				if (os[0] is NoteAttribute)
				{
					return (NoteAttribute)os[0];
				}
			}

			return null;
		}


		/// <summary>
		/// 获取备注名称
		/// </summary>
		/// <returns></returns>
		public string GetNoteName()
		{
			NoteAttribute note = GetNoteAttribute();

			if (note != null)
			{
				return note.Name;
			}

			return "";
		}

		/// <summary>
		/// 获取备注分类
		/// </summary>
		/// <returns></returns>
		public string GetNoteCategory()
		{
			NoteAttribute note = GetNoteAttribute();

			if (note != null)
			{
				return note.Category;
			}

			return "";
		}

		/// <summary>
		/// 获取备注描述
		/// </summary>
		/// <returns></returns>
		public string GetNoteDescription()
		{
			NoteAttribute note = GetNoteAttribute();

			if (note != null)
			{
				return note.Description;
			}

			return "";
		}
	}
}
