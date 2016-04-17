/*
 * XmlEntityEncoder
 * liuqiang@2015/11/1 17:33:01
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using THOR.Attributes.Notes;
using THOR.Files;


//---- 8< ------------------

namespace THOR.Serialization.XmlEntities
{
	/// <summary>
	/// 实体对象的XML编码方法
	/// </summary>
	public class XmlEntityEncoder
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public XmlEntityEncoder()
		{
		}

		#endregion

		#region methods

		#region DATA

		/// <summary>
		/// 创建节点
		/// </summary>
		/// <param name="entityNode"></param>
		/// <param name="entity"></param>
		/// <param name="property"></param>
		/// <param name="attribute"></param>
		/// <returns></returns>
		protected XmlNode CreateNode(XmlNode entityNode, Object entity, PropertyInfo property, XmlEntityPropertyAttribute attribute)
		{
			string nodeName = attribute.NodeName;
			if (nodeName.Trim().Length == 0) nodeName = property.Name;

			XmlNode node = entityNode.AppendChild(entityNode.OwnerDocument.CreateElement(nodeName));
			entityNode.AppendChild(node);

			return node;
		}

		/// <summary>
		/// 简单值
		/// </summary>
		/// <param name="entityNode"></param>
		/// <param name="entity"></param>
		/// <param name="property"></param>
		/// <param name="attribute"></param>
		protected void EncodeValue(XmlNode entityNode, Object entity, PropertyInfo property, XmlEntityPropertyAttribute attribute)
		{

			XmlNode node = CreateNode(entityNode, entity, property, attribute);
			object v = property.GetValue(entity);
			if (v != null)
			{
				node.AppendChild(entityNode.OwnerDocument.CreateTextNode(v.ToString()));
			}
		}

		/// <summary>
		/// 对象
		/// </summary>
		/// <param name="entityNode"></param>
		/// <param name="entity"></param>
		/// <param name="property"></param>
		/// <param name="attribute"></param>
		protected void EncodeObject(XmlNode entityNode, Object entity, PropertyInfo property, XmlEntityPropertyAttribute attribute)
		{
			XmlNode node = CreateNode(entityNode, entity, property, attribute);
			object v = property.GetValue(entity);
			if (v != null)
			{
				Encode(node, v, true);
			}
		}


		/// <summary>
		/// 枚举值
		/// </summary>
		/// <param name="entityNode"></param>
		/// <param name="entity"></param>
		/// <param name="property"></param>
		/// <param name="attribute"></param>
		protected void EncodeEnumValue(XmlNode entityNode, Object entity, PropertyInfo property, XmlEntityPropertyAttribute attribute)
		{
			XmlNode node = CreateNode(entityNode, entity, property, attribute);
			object v = property.GetValue(entity);
			if (v == null) return;

			string name = NoteAttribute.GetEnumValueName(v);

			node.AppendChild(entityNode.OwnerDocument.CreateTextNode(name));
		}


		/// <summary>
		/// 枚举标签
		/// </summary>
		/// <param name="entityNode"></param>
		/// <param name="entity"></param>
		/// <param name="property"></param>
		/// <param name="attribute"></param>
		protected void EncodeEnumTags(XmlNode entityNode, Object entity, PropertyInfo property, XmlEntityPropertyAttribute attribute)
		{
			XmlNode node = CreateNode(entityNode, entity, property, attribute);
			object v = property.GetValue(entity);
			if (v == null) return;

			UInt64 es = Convert.ToUInt64(v);
			List<string> vs = new List<string>();
			foreach (object eo in Enum.GetValues(v.GetType()))
			{
				UInt64 e = Convert.ToUInt64(eo);
				if (e == 0) continue;

				if ((es & e) == e)
				{
					vs.Add(NoteAttribute.GetEnumValueName(eo));
				}
			}

			node.AppendChild(entityNode.OwnerDocument.CreateTextNode(String.Join(",", vs)));
		}

		/// <summary>
		/// 简单值集合
		/// </summary>
		/// <param name="entityNode"></param>
		/// <param name="entity"></param>
		/// <param name="property"></param>
		/// <param name="attribute"></param>
		protected void EncodeCollectionValue(XmlNode entityNode, Object entity, PropertyInfo property, XmlEntityPropertyAttribute attribute)
		{
			XmlNode node = CreateNode(entityNode, entity, property, attribute);
			object v = property.GetValue(entity);

			if (v is IList == false) return;
			IList list = (IList)v;

			entityNode.AppendChild(node);


			foreach (object item in list)
			{
				XmlNode itemNode = entityNode.OwnerDocument.CreateElement("Item");
				node.AppendChild(itemNode);

				if (item != null)
				{
					itemNode.AppendChild(entityNode.OwnerDocument.CreateTextNode(item.ToString()));
				}
			}
		}

		/// <summary>
		/// 对象集合
		/// </summary>
		/// <param name="entityNode"></param>
		/// <param name="entity"></param>
		/// <param name="property"></param>
		/// <param name="attribute"></param>
		protected void EncodeCollectionObject(XmlNode entityNode, Object entity, PropertyInfo property, XmlEntityPropertyAttribute attribute)
		{
			XmlNode node = CreateNode(entityNode, entity, property, attribute);
			object v = property.GetValue(entity);

			if (v is IList == false) return;
			IList list = (IList)v;

			entityNode.AppendChild(node);


			foreach (object item in list)
			{
				XmlNode itemNode = entityNode.OwnerDocument.CreateElement("Item");
				node.AppendChild(itemNode);

				Encode(itemNode, item, true);
			}
		}

		#endregion

		/// <summary>
		/// 将entity编入xml节点
		/// </summary>
		/// <param name="node"></param>
		/// <param name="entity"></param>
		public void Encode(XmlNode node, Object entity, bool mergeToParentNode = false)
		{
			if (entity == null) return;

			Type entityType = entity.GetType();

			XmlNode entityNode = node;
			if (!mergeToParentNode)
			{
				entityNode = node.OwnerDocument.CreateElement(entityType.FullName);
				node.AppendChild(entityNode);
			}
			PropertyInfo[] propertyList = entityType.GetProperties();

			foreach (PropertyInfo property in propertyList)
			{
				if (!property.CanWrite) continue;	//不处理只读属性

				XmlEntityPropertyAttribute attribute = XmlEntityPropertyAttribute.GetAttribute(property);
				if (attribute == null) continue;	//没配置属性信息的不处理
				if (attribute.Disabled) continue;	//配置成屏蔽的属性不处理

				switch (attribute.PropertyMode)
				{
					case XmlEntityPropertyMode.Value:
						EncodeValue(entityNode, entity, property, attribute);
						break;

					case XmlEntityPropertyMode.Object:
						EncodeObject(entityNode, entity, property, attribute);
						break;

					case XmlEntityPropertyMode.EnumValue:
						EncodeEnumValue(entityNode, entity, property, attribute);
						break;

					case XmlEntityPropertyMode.EnumTags:
						EncodeEnumTags(entityNode, entity, property, attribute);
						break;

					case XmlEntityPropertyMode.CollectionValue:
						EncodeCollectionValue(entityNode, entity, property, attribute);
						break;

					case XmlEntityPropertyMode.CollectionObject:
						EncodeCollectionObject(entityNode, entity, property, attribute);
						break;
				}
			}
		}

		/// <summary>
		/// 将entity编入xml文档对象
		/// </summary>
		/// <param name="xml"></param>
		/// <param name="entity"></param>
		public void Encode(XmlDocument xml, Object entity)
		{
			Encode(xml.DocumentElement, entity);
		}

		/// <summary>
		/// 将entity编入xml文件
		/// </summary>
		/// <param name="file"></param>
		/// <param name="entity"></param>
		public void Encode(string file, Object entity)
		{
			XmlDocument xml = XmlFile.CreateXmlDocument("Data");
			Encode(xml, entity);

			XmlFile.Save(file, xml);
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
