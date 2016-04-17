/*
 * CEntity
 * liuqiang@2015/11/1 17:21:42
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using THOR.Serialization.XmlEntities;


//---- 8< ------------------

namespace THOR.Windows.Editors.Common.Data
{
	[Serializable()]

	/// <summary>
	/// 数据实体配置类
	/// </summary>
	public class CEntity
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		public CEntity()
		{
			IdPrefix = "";
			IdSuffix = "";
			Id = "";
			EditorName = "";
			EditorCategory = "";
			EditorDescription = "";
			EditorPrefix = "";
			EditorSuffix = "";
		}

		#endregion

		#region methods

		/// <summary>
		/// 获取完整ID
		/// </summary>
		/// <returns></returns>
		public virtual string GetFullID()
		{
			return GetFullID(this.Id);
		}

		/// <summary>
		/// 获取完整ID
		/// </summary>
		/// <param name="newId"></param>
		/// <returns></returns>
		public virtual string GetFullID(string newId)
		{
			if (IdPrefix.Length > 0 && IdSuffix.Length > 0)
			{
				return String.Format("{0}_{1}_{2}", IdPrefix, newId, IdSuffix);
			}
			else if (IdPrefix.Length > 0)
			{
				return String.Format("{0}_{1}", IdPrefix, newId);
			}
			else if (IdSuffix.Length > 0)
			{
				return String.Format("{0}_{1}", newId, IdSuffix);
			}
			else
			{
				return newId;
			}


		}

		/// <summary>
		/// 克隆数据
		/// </summary>
		/// <returns></returns>
		public CEntity Clone()
		{
			using (Stream objectStream = new MemoryStream())
			{
				IFormatter formatter = new BinaryFormatter();
				formatter.Serialize(objectStream, this);
				objectStream.Seek(0, SeekOrigin.Begin);
				return (CEntity)formatter.Deserialize(objectStream);
			}
		}

		/// <summary>
		/// 获取文本信息
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return String.Format("{{{0} {1}}}", GetType().Name, GetFullID());
		}
		#endregion

		#region properties

		/// <summary>
		/// 获取ID前缀
		/// </summary>
		public string IdPrefix { get; protected set; }

		/// <summary>
		/// 获取ID后缀
		/// </summary>
		public string IdSuffix { get; protected set; }


		[XmlEntityProperty()]
		/// <summary>
		/// 获取或设置唯一标识
		/// </summary>
		public string Id { get; set; }

		[XmlEntityProperty()]
		/// <summary>
		/// 获取或设置在编辑器中的显示名称
		/// </summary>
		public string EditorName { get; set; }

		[XmlEntityProperty()]
		/// <summary>
		/// 获取或设置在编辑器中的显示描述
		/// </summary>
		public string EditorDescription { get; set; }

		[XmlEntityProperty()]
		/// <summary>
		/// 获取或设置在编辑器中的显示分类
		/// </summary>
		public string EditorCategory { get; set; }

		[XmlEntityProperty()]
		/// <summary>
		/// 获取或设置在编辑器中的显示前缀
		/// </summary>
		public string EditorPrefix { get; set; }

		[XmlEntityProperty()]
		/// <summary>
		/// 获取或设置在编辑器中的显示后缀
		/// </summary>
		public string EditorSuffix { get; set; }

		#endregion

		#region events

		#endregion
	}
}
