/*
 * XmlEntityPropertyAttribute
 * liuqiang@2015/11/1 17:33:15
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Serialization.XmlEntities
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	/// <summary>
	/// Xml属性描述信息
	/// </summary>
	public class XmlEntityPropertyAttribute : Attribute
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		/// <summary>
		/// 屏蔽此属性
		/// </summary>
		/// <param name="disabled"></param>
		public XmlEntityPropertyAttribute(bool disabled)
			: base()
		{
			Disabled = disabled;
			NodeName = "";
			PropertyMode = XmlEntityPropertyMode.Value;
			ItemType = null;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="propertyMode"></param>
		public XmlEntityPropertyAttribute(XmlEntityPropertyMode propertyMode, Type itemType = null)
			: base()
		{
			Disabled = false;
			NodeName = "";
			PropertyMode = propertyMode;
			ItemType = itemType;

		}

		/// <summary>
		/// 指定节点名称以及处理模式
		/// </summary>
		/// <param name="nodeName"></param>
		/// <param name="propertyMode"></param>
		public XmlEntityPropertyAttribute(string nodeName = "", XmlEntityPropertyMode propertyMode = XmlEntityPropertyMode.Value, Type itemType = null)
			: base()
		{
			Disabled = false;
			NodeName = nodeName;
			PropertyMode = propertyMode;
			ItemType = itemType;
		}

		#endregion

		#region methods

		/// <summary>
		/// 获取属性信息
		/// </summary>
		/// <param name="property"></param>
		/// <returns></returns>
		static public XmlEntityPropertyAttribute GetAttribute(PropertyInfo property)
		{
			if (property != null)
			{
				Attribute attribute = property.GetCustomAttribute(typeof(XmlEntityPropertyAttribute));

				if (attribute is XmlEntityPropertyAttribute)
				{
					return (XmlEntityPropertyAttribute)attribute;
				}
			}

			return null;
		}
		#endregion

		#region methods

		#endregion

		#region properties

		/// <summary>
		/// 获取或设置是否屏蔽此属性
		/// </summary>
		public bool Disabled { get; protected set; }

		/// <summary>
		/// 获取或设置节点名称
		/// </summary>
		public string NodeName { get; protected set; }

		/// <summary>
		/// 获取或设置属性处理模式
		/// </summary>
		public XmlEntityPropertyMode PropertyMode { get; protected set; }

		/// <summary>
		/// 获取或设置集合成员类型
		/// </summary>
		public Type ItemType { get; protected set; }

		#endregion

		#region events

		#endregion
	}
}
