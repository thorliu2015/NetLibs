using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using THOR.Utils.Attributes;

namespace Solar.Data
{
	[Serializable()]
	[Note("基类", "所有数据的基础类型")]

	/// <summary>
	/// 数据模型基类
	/// </summary>
	public abstract class SModel : IComparable<SModel>
	{
		/// <summary>
		/// 数值正则表达式
		/// </summary>
		static private Regex regexNumberic = new Regex("^[0-9]+$", RegexOptions.Compiled);

		/// <summary>
		/// 构造
		/// </summary>
		public SModel()
		{
			ChangeType = DataChangeTypes.None;
		}


		[Category("核心"), DisplayName("(ID)"), Description("数据的唯一标识")]
		/// <summary>
		/// 唯一标识
		/// </summary>
		public string Id { get; set; }




		[Category("编辑器"), DisplayName("名称"), Description("在编辑器中显示的名称")]
		/// <summary>
		/// 编辑器中显示的名称
		/// </summary>
		public string EditorName { get; set; }




		[Category("编辑器"), DisplayName("描述"), Description("在编辑器中显示的描述")]
		/// <summary>
		/// 编辑器中显示的描述
		/// </summary>
		public string EditorDescription { get; set; }




		[Category("编辑器"), DisplayName("分类"), Description("在编辑器中显示的分类")]
		/// <summary>
		/// 编辑器中的显示分类
		/// </summary>
		public string EditorCategory { get; set; }




		[Category("编辑器"), DisplayName("后缀"), Description("在编辑器中显示的后缀")]
		/// <summary>
		/// 编辑器中显示的后缀
		/// </summary>
		public string EditorSuffix { get; set; }




		[Browsable(false)]
		/// <summary>
		/// 更改类型
		/// </summary>
		public DataChangeTypes ChangeType { get; set; }

		/// <summary>
		/// 数据比较
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo(SModel other)
		{
			int ret = 0;

			if (other == null)
			{
				ret = 1;
			}
			else
			{
				string a = Id.ToString().ToUpper();
				string b = other.Id.ToString().ToUpper();

				if (regexNumberic.IsMatch(a) && regexNumberic.IsMatch(b))
				{
					int ia = Convert.ToInt32(a);
					int ib = Convert.ToInt32(b);

					if (ia == ib) return 0;
					else if (ia > ib) return 1;
					else return -1;
				}
				else
				{
					return String.Compare(a, b);
				}
			}

			return ret;
		}

		/// <summary>
		/// 获取字符串信息
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			Type type = GetType();
			return String.Format("({0}:{1}){2}{3}", type.Name, Id, EditorName, EditorSuffix.Length > 0 ? "-" + EditorSuffix : "");
		}

		/// <summary>
		/// 克隆数据
		/// </summary>
		/// <returns></returns>
		public SModel Clone()
		{
			using (Stream objectStream = new MemoryStream())
			{
				IFormatter formatter = new BinaryFormatter();
				formatter.Serialize(objectStream, this);
				objectStream.Seek(0, SeekOrigin.Begin);
				return (SModel)formatter.Deserialize(objectStream);
			}
		}

		/// <summary>
		/// 数据被添加时
		/// </summary>
		virtual internal void OnAdd()
		{
		}

		/// <summary>
		/// 数据被移除时
		/// </summary>
		virtual internal void OnRemove()
		{
		}

		/// <summary>
		/// 数据被改名时
		/// </summary>
		virtual internal void OnRename(string newid)
		{
		}

		/// <summary>
		/// 获取基类的有效子类列表
		/// </summary>
		/// <param name="baseType">基类类型</param>
		/// <returns></returns>
		static public List<Type> GetTypes(Type baseType)
		{
			List<Type> types = new List<Type>();

			Assembly ass = Assembly.GetExecutingAssembly();
			Type[] ts = ass.GetTypes();
			foreach(Type t in ts)
			{
				//忽略抽象类
				if (t.IsAbstract) continue;
				if (t.IsSubclassOf(baseType))
				{
					types.Add(t);
				}
			}

			return types;
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
