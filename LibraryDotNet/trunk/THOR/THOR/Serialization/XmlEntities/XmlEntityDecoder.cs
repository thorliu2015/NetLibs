/*
 * XmlEntityDecoder
 * liuqiang@2015/11/1 17:32:47
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


//---- 8< ------------------

namespace THOR.Serialization.XmlEntities
{
	/// <summary>
	/// 实体对象的XML解析方法
	/// </summary>
	public class XmlEntityDecoder
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		public XmlEntityDecoder()
		{
		}

		#endregion

		#region methods

		#region Data

		/// <summary>
		/// 值类型
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="propertyNode"></param>
		/// <param name="propertyInfo"></param>
		protected void DecodeNodeValue(Object entity, XmlNode propertyNode, PropertyInfo propertyInfo)
		{
			string v = propertyNode.InnerText;
			if (v.Length == 0) return;

			object o = SerialicationUtils.ParseObject(v, propertyInfo.PropertyType);
			if (o != null)
			{
				propertyInfo.SetValue(entity, o);
			}
		}

		/// <summary>
		/// 对象类型
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="propertyNode"></param>
		/// <param name="propertyInfo"></param>
		protected void DecodeNodeObject(Object entity, XmlNode propertyNode, PropertyInfo propertyInfo)
		{
			object obj = System.Activator.CreateInstance(propertyInfo.PropertyType);
			if (obj == null) return;

			PropertyInfo[] propertyList = propertyInfo.PropertyType.GetProperties();
			foreach (XmlNode pNode in propertyNode.ChildNodes)
			{
				DecodeNode(obj, pNode, propertyList);
			}

			propertyInfo.SetValue(entity, obj);
		}

		/// <summary>
		/// 枚举值类型
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="propertyNode"></param>
		/// <param name="propertyInfo"></param>
		protected void DecodeNodeEnumValue(Object entity, XmlNode propertyNode, PropertyInfo propertyInfo)
		{
			string v = propertyNode.InnerText;
			if (v.Trim().Length == 0) return;

			object o = NoteAttribute.GetEnumName(propertyInfo.PropertyType, v);
			if (o == null) return;

			propertyInfo.SetValue(entity, o);
		}

		/// <summary>
		/// 枚举值类型
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="propertyNode"></param>
		/// <param name="propertyInfo"></param>
		protected void DecodeNodeEnumTags(Object entity, XmlNode propertyNode, PropertyInfo propertyInfo)
		{
			string v = propertyNode.InnerText;
			if (v.Trim().Length == 0) return;

			string[] tags = v.Split(new char[1] { ',' });
			UInt64 us = 0;
			foreach (string tag in tags)
			{
				UInt64 u = Convert.ToUInt64(NoteAttribute.GetEnumName(propertyInfo.PropertyType, tag));
				us |= u;
			}

			object o = Enum.ToObject(propertyInfo.PropertyType, us);

			propertyInfo.SetValue(entity, o);
		}


		/// <summary>
		/// 值集合
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="propertyNode"></param>
		/// <param name="propertyInfo"></param>
		protected void DecodeNodeCollectionValue(Object entity, XmlNode propertyNode, PropertyInfo propertyInfo)
		{
			object listObj = propertyInfo.GetValue(entity);
			if (listObj is IList == false) return;
			XmlEntityPropertyAttribute propertyAttribute = XmlEntityPropertyAttribute.GetAttribute(propertyInfo);
			if (propertyAttribute.ItemType == null) return;
			IList list = (IList)listObj;

			foreach (XmlNode itemNode in propertyNode.SelectNodes("Item"))
			{
				string v = itemNode.InnerText;
				if (v.Trim().Length == 0) continue;

				object o = SerialicationUtils.ParseObject(v, propertyAttribute.ItemType);
				if (o == null) continue;
				list.Add(o);
			}
		}

		/// <summary>
		/// 对象集合
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="propertyNode"></param>
		/// <param name="propertyInfo"></param>
		protected void DecodeNodeCollectionObject(Object entity, XmlNode propertyNode, PropertyInfo propertyInfo)
		{
			object listObj = propertyInfo.GetValue(entity);
			if (listObj is IList == false) return;
			XmlEntityPropertyAttribute propertyAttribute = XmlEntityPropertyAttribute.GetAttribute(propertyInfo);
			if (propertyAttribute.ItemType == null) return;
			IList list = (IList)listObj;

			PropertyInfo[] propertyList = propertyAttribute.ItemType.GetProperties();

			foreach (XmlNode itemNode in propertyNode.SelectNodes("Item"))
			{
				object itemObj = System.Activator.CreateInstance(propertyAttribute.ItemType);
				if (itemObj == null) continue;

				foreach (XmlNode pNode in itemNode.ChildNodes)
				{
					DecodeNode(itemObj, pNode, propertyList);
				}
				list.Add(itemObj);
			}
		}

		#endregion

		protected void DecodeNode(Object entity, XmlNode propertyNode, PropertyInfo[] propertyList)
		{
			foreach (PropertyInfo property in propertyList)
			{
				XmlEntityPropertyAttribute propertyAttribute = XmlEntityPropertyAttribute.GetAttribute(property);

				if (propertyAttribute == null) continue;

				string propertyNodeName = propertyAttribute.NodeName;
				if (propertyNodeName.Trim().Length == 0) propertyNodeName = property.Name;

				if (propertyNode.Name != propertyNodeName) continue;

				switch (propertyAttribute.PropertyMode)
				{
					case XmlEntityPropertyMode.Value:
						DecodeNodeValue(entity, propertyNode, property);
						break;

					case XmlEntityPropertyMode.Object:
						DecodeNodeObject(entity, propertyNode, property);
						break;

					case XmlEntityPropertyMode.EnumValue:
						DecodeNodeEnumValue(entity, propertyNode, property);
						break;

					case XmlEntityPropertyMode.EnumTags:
						DecodeNodeEnumTags(entity, propertyNode, property);
						break;

					case XmlEntityPropertyMode.CollectionValue:
						DecodeNodeCollectionValue(entity, propertyNode, property);
						break;

					case XmlEntityPropertyMode.CollectionObject:
						DecodeNodeCollectionObject(entity, propertyNode, property);
						break;
				}
			}
		}


		/// <summary>
		/// 解析节点
		/// </summary>
		/// <param name="node"></param>
		public List<object> Decode(XmlNode node)
		{
			List<object> list = new List<object>();

			foreach (XmlNode entityNode in node.ChildNodes)
			{
				Type entityType = SerialicationTypes.Current.GetType(entityNode.Name);
				if (entityType == null) continue;

				Object entity = System.Activator.CreateInstance(entityType);
				if (entity == null) continue;

				PropertyInfo[] propertyList = entityType.GetProperties();

				foreach (XmlNode propertyNode in entityNode.ChildNodes)
				{
					DecodeNode(entity, propertyNode, propertyList);
				}

				list.Add(entity);
			}

			return list;
		}

		/// <summary>
		/// 解析xml
		/// </summary>
		/// <param name="xml"></param>
		public List<object> Decode(XmlDocument xml)
		{
			return Decode(xml.DocumentElement);
		}

		/// <summary>
		/// 解析文件
		/// </summary>
		/// <param name="file"></param>
		public List<object> Decode(string file)
		{
			XmlDocument xml = new XmlDocument();
			xml.Load(file);

			return Decode(xml);
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
