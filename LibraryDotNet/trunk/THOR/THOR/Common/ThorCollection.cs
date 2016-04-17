/*
 * ThorCollection
 * liuqiang@2015/11/4 10:12:25
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Common
{
	public class ThorCollection<T> : CollectionBase
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		/// <summary>
		/// 添加成员
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public int Add(T item)
		{
			return List.Add(item);
		}

		/// <summary>
		/// 移除成员
		/// </summary>
		/// <param name="item"></param>
		public void Remove(T item)
		{
			List.Remove(item);
		}

		/// <summary>
		/// 插入成员
		/// </summary>
		/// <param name="index"></param>
		/// <param name="item"></param>
		public void Insert(int index, T item)
		{
			List.Insert(index, item);
		}

		/// <summary>
		/// 检查是否包含指定的成员
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public bool Contains(T item)
		{
			return List.Contains(item);
		}

		/// <summary>
		/// 搜索成员
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public int IndexOf(T item)
		{
			return List.IndexOf(item);
		}


		/// <summary>
		/// 清除成员时
		/// </summary>
		protected override void OnClear()
		{
			base.OnClear();

			foreach (T item in List)
			{
				OnRemove(item);
			}
		}

		/// <summary>
		/// 添加成员时
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		protected override void OnInsert(int index, object value)
		{
			base.OnInsert(index, value);

			if (value is T)
			{
				OnAdd((T)value);
			}
		}

		/// <summary>
		/// 移除成员时
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete(index, value);

			if (value is T)
			{
				OnRemove((T)value);
			}
		}

		/// <summary>
		/// 更改成员时
		/// </summary>
		/// <param name="index"></param>
		/// <param name="oldValue"></param>
		/// <param name="newValue"></param>
		protected override void OnSetComplete(int index, object oldValue, object newValue)
		{
			base.OnSetComplete(index, oldValue, newValue);

			if (oldValue is T)
			{
				OnRemove((T)oldValue);
			}

			if (newValue is T)
			{
				OnAdd((T)newValue);
			}
		}


		/// <summary>
		/// 添加成员时
		/// </summary>
		/// <param name="item"></param>
		virtual protected void OnAdd(object item)
		{
			//Debug.WriteLine(String.Format("OnAdd: {0}", item.ToString()));
		}

		/// <summary>
		/// 移除成员时
		/// </summary>
		/// <param name="item"></param>
		virtual protected void OnRemove(object item)
		{
			//Debug.WriteLine(String.Format("OnRemove: {0}", item.ToString()));
		}

		/// <summary>
		/// 检查成员类型
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		virtual protected bool CheckItemType(T item)
		{
			return true;
		}

		#endregion

		#region properties

		/// <summary>
		/// 获取或设置指定索引的成员
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public T this[int index]
		{
			get
			{
				if (index >= 0 && index < Count)
				{
					return (T)List[index];
				}
				return default(T);
			}
			set
			{
				if (value is T)
				{
					if (index >= 0 && index < Count)
					{
						List[index] = value;
					}
				}
			}
		}

		/// <summary>
		/// 获取成员类型
		/// </summary>
		public Type MemberType
		{
			get
			{
				return typeof(T);
			}
		}


		#endregion

		#region events

		#endregion
	}
}
