using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace THOR.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public class NoteAttribute : Attribute
	{
		public NoteAttribute(string strNote, string strDescription, string strCategory = "")
		{
			Name = strNote;
			Description = strDescription;
			Category = strCategory;
		}

		/// <summary>
		/// 显示名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 显示描述
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// 分类
		/// </summary>
		public string Category { get; set; }



		/// <summary>
		/// 获取枚举信息
		/// </summary>
		/// <param name="type"></param>
		/// <param name="dict"></param>
		static public void GetEnum(Type type, Dictionary<string, NoteAttribute> dict)
		{
			dict.Clear();

			string[] names = type.GetEnumNames();

			foreach (string name in names)
			{
				MemberInfo[] members = type.GetMember(name);
				if (members.Length == 0) continue;
				MemberInfo member = members[0];
				Attribute attrib = member.GetCustomAttribute(typeof(NoteAttribute));
				if (attrib == null) continue;
				NoteAttribute note = (NoteAttribute)attrib;



				dict[member.Name] = note;
			}
		}

		static public string GetEnumName(object enumObj)
		{
			Type type = enumObj.GetType();
			MemberInfo[] members = type.GetMember(enumObj.ToString());
			if (members.Length == 0) return enumObj.ToString();
			MemberInfo member = members[0];
			Attribute attrib = member.GetCustomAttribute(typeof(NoteAttribute));
			if (attrib == null) return enumObj.ToString();
			NoteAttribute note = (NoteAttribute)attrib;

			return note.Name;
		}


		static public string GetNoteNameByEnum(object e)
		{
			Type type = e.GetType();
			string eName = e.ToString();
			string[] names = type.GetEnumNames();
			foreach (string name in names)
			{
				if (name != eName) continue;

				MemberInfo[] members = type.GetMember(name);
				if (members.Length == 0) continue;
				Attribute attrib = members[0].GetCustomAttribute(typeof(NoteAttribute));
				if (attrib != null)
				{
					return ((NoteAttribute)attrib).Name;
				}
			}

			return "";
		}

		static public object GetEnumByNoteName(Type type, string noteName)
		{
			string[] names = type.GetEnumNames();
			foreach (string name in names)
			{
				MemberInfo[] members = type.GetMember(name);
				if (members.Length == 0) continue;
				Attribute attrib = members[0].GetCustomAttribute(typeof(NoteAttribute));
				if (attrib != null)
				{
					if (((NoteAttribute)attrib).Name == noteName)
					{
						return Enum.Parse(type, name);
					}
				}
			}
			return null;
		}

		static public string GetNoteNamesByEnum(object e)
		{
			List<String> list = new List<string>();

			return "";
		}

		static public object GetEnumByNoteNames(Type type, string noteNames)
		{
			return null;
		}
	}
}
