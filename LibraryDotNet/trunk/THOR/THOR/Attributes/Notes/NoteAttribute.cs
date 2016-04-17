/*
 * NoteAttribute
 * liuqiang@2015/11/1 16:49:06
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

//---- 8< ------------------

namespace THOR.Attributes.Notes
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]

	/// <summary>
	/// 备注信息 
	/// </summary>
	public class NoteAttribute : Attribute
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="name">名称</param>
		/// <param name="description">描述</param>
		/// <param name="category">分类</param>
		/// <param name="sortIndex">序号</param>
		public NoteAttribute(string name, string description = "", string category = "", int sortIndex = 0, int categorySortIndex = 0)
		{
			this.Name = name;
			this.Description = description;
			this.Category = category;
			this.SortIndex = sortIndex;
			this.CategorySortIndex = categorySortIndex;
		}

		#endregion

		#region methods

		/// <summary>
		/// 获取备注信息
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		static public NoteAttribute GetNote(Type type)
		{
			if (type != null)
			{
				Attribute attribute = type.GetCustomAttribute(typeof(NoteAttribute));

				if (attribute is NoteAttribute)
				{
					return (NoteAttribute)attribute;
				}
			}
			return null;
		}

		/// <summary>
		/// 获取备注信息
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		static public NoteAttribute GetNote(Object obj)
		{
			if (obj != null)
			{
				Type type = obj.GetType();
				return GetNote(type);
			}
			return null;
		}

		/// <summary>
		/// 获取备注信息
		/// </summary>
		/// <param name="type"></param>
		/// <param name="memberName"></param>
		/// <returns></returns>
		static public NoteAttribute GetNote(Type type, string memberName)
		{
			if (type != null)
			{
				MemberInfo[] members = type.GetMember(memberName);
				foreach (MemberInfo member in members)
				{
					Attribute attribute = member.GetCustomAttribute(typeof(NoteAttribute));
					if (attribute is NoteAttribute) return (NoteAttribute)attribute;
				}
			}
			return null;
		}

		/// <summary>
		/// 获取备注信息
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="memberName"></param>
		/// <returns></returns>
		static public NoteAttribute GetNote(Object obj, string memberName)
		{
			if (obj != null)
			{
				Type type = obj.GetType();

				return GetNote(type, memberName);
			}
			return null;
		}


		/// <summary>
		/// 获取名称代表的枚举值
		/// </summary>
		/// <param name="type"></param>
		/// <param name="noteName"></param>
		/// <returns></returns>
		static public Object GetEnumName(Type type, string noteName)
		{
			if (type != null)
			{
				string[] names = Enum.GetNames(type);

				foreach (string name in names)
				{
					MemberInfo[] members = type.GetMember(name);
					foreach (MemberInfo member in members)
					{
						Attribute attribute = member.GetCustomAttribute(typeof(NoteAttribute), true);
						if (attribute is NoteAttribute)
						{
							NoteAttribute note = (NoteAttribute)attribute;
							if (note.Name == noteName)
							{
								return Enum.Parse(type, name);
							}
						}
					}
				}

				return Enum.Parse(type, noteName);
			}
			return null;
		}

		/// <summary>
		/// 获取枚举值的名称
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		static public string GetEnumValueName(object value)
		{
			if (value != null)
			{
				Type type = value.GetType();

				string[] names = Enum.GetNames(type);

				foreach (string name in names)
				{
					if (name != value.ToString()) continue;

					MemberInfo[] members = type.GetMember(name);
					foreach (MemberInfo member in members)
					{
						Attribute attribute = member.GetCustomAttribute(typeof(NoteAttribute), true);
						if (attribute is NoteAttribute)
						{
							NoteAttribute note = (NoteAttribute)attribute;
							return note.Name;
						}
					}
				}

				return value.ToString();
			}

			return "";
		}

		#endregion

		#region properties

		/// <summary>
		/// 获取或设置备注名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 获取或设置备注描述
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// 获取或设置备注分类
		/// </summary>
		public string Category { get; set; }

		/// <summary>
		/// 获取或设置备注序号
		/// </summary>
		public int SortIndex { get; set; }

		/// <summary>
		/// 获取或设置分类序号
		/// </summary>
		public int CategorySortIndex { get; set; }

		#endregion

		#region events

		#endregion
	}
}
