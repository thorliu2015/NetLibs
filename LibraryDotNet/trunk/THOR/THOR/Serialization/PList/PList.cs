/*
 * PList
 * liuqiang@2016/1/21 23:05:35
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using THOR.Files;


//---- 8< ------------------

namespace THOR.Serialization.PList
{
	public class PList
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public PList()
		{
		}

		#endregion

		#region methods

		#region load

		public void Load(string filename)
		{
			XmlDocument xml = new XmlDocument();
			xml.Load(filename);

			Load(xml);
		}

		public void Load(XmlDocument xml)
		{
			foreach (XmlNode node in xml.DocumentElement.ChildNodes)
			{
				if (node.NodeType == XmlNodeType.Element)
				{
					Root = ParseObjectNode(node);
					return;
				}
			}
		}

		protected virtual PListObject ParseObjectNode(XmlNode node)
		{
			if (node != null)
			{
				switch (node.Name.ToLower())
				{
					case "array":
						return ParseArrayNode(node);

					case "dict":
						return ParseDictionaryNode(node);

					default:
						break;
				}
			}
			return null;
		}

		protected virtual PListArray ParseArrayNode(XmlNode node)
		{
			if (node != null)
			{
				PListArray result = new PListArray();

				foreach (XmlNode childNode in node.ChildNodes)
				{
					switch (childNode.Name.ToLower())
					{
						case "array":
							result.Value.Add(ParseArrayNode(childNode));
							break;

						case "dict":
							result.Value.Add(ParseDictionaryNode(childNode));
							break;

						case "string":
							result.Value.Add(ParseStringNode(childNode));
							break;

						case "data":
							result.Value.Add(ParseDataNode(childNode));
							break;

						case "true":
						case "false":
							result.Value.Add(ParseBooleanNode(childNode));
							break;

						case "real":
						case "integer":
							result.Value.Add(ParseNumberNode(childNode));
							break;

						case "date":
							result.Value.Add(ParseDateNode(childNode));
							break;
					}
				}


				return result;
			}
			return null;
		}

		protected virtual PListDictionary ParseDictionaryNode(XmlNode node)
		{
			if (node != null)
			{
				PListDictionary result = new PListDictionary();

				XmlNodeList keys = node.SelectNodes("key");

				foreach (XmlNode key in keys)
				{
					XmlNode obj = key.NextSibling;
					PListObject objData = null;
					if (obj != null)
					{
						switch (obj.Name.ToLower())
						{
							case "array":
								objData = ParseArrayNode(obj);
								break;

							case "dict":
								objData = ParseDictionaryNode(obj);
								break;

							case "string":
								objData = ParseStringNode(obj);
								break;

							case "data":
								objData = ParseDataNode(obj);
								break;

							case "true":
							case "false":
								objData = ParseBooleanNode(obj);
								break;

							case "real":
							case "integer":
								objData = ParseNumberNode(obj);
								break;

							case "date":
								objData = ParseDateNode(obj);
								break;
						}
					}

					result.Value[key.InnerText] = objData;
				}

				return result;
			}
			return null;
		}

		protected virtual PListString ParseStringNode(XmlNode node)
		{
			if (node != null)
			{
				PListString result = new PListString();
				result.Value = node.InnerText;

				return result;
			}
			return null;
		}

		protected virtual PListData ParseDataNode(XmlNode node)
		{
			if (node != null)
			{
				PListData result = new PListData();

				//TODO: parse data node ...

				return result;
			}
			return null;
		}

		protected virtual PListBoolean ParseBooleanNode(XmlNode node)
		{
			if (node != null)
			{
				PListBoolean result = new PListBoolean();
				result.Value = (node.Name.ToLower().Trim() == "true");

				return result;
			}
			return null;
		}

		protected virtual PListNumber ParseNumberNode(XmlNode node)
		{
			if (node != null)
			{
				PListNumber result = new PListNumber();
				double d = 0;
				Double.TryParse(node.InnerText, out d);
				result.Value = d;

				return result;
			}
			return null;
		}

		protected virtual PListDate ParseDateNode(XmlNode node)
		{
			if (node != null)
			{
				PListDate result = new PListDate();
				DateTime d = new DateTime();
				DateTime.TryParse(node.InnerText, out d);
				result.Value = d;

				return result;
			}

			return null;
		}

		#endregion

		#region save
		public void Save(string filename)
		{
			XmlDocument xml = new XmlDocument();
			xml.LoadXml("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
				//"<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">" +
				"<plist version=\"1.0\"/>"
				);

			Save(xml.DocumentElement);

			XmlFile.Save(filename, xml);
		}

		public void Save(XmlNode node)
		{
			Save(node, Root);
		}

		public void Save(XmlNode node, PListObject obj)
		{
			if (obj is PListArray)
			{
				SaveArray(node, (PListArray)obj);
			}
			else if (obj is PListDictionary)
			{
				SaveDictionary(node, (PListDictionary)obj);
			}
			else if (obj is PListBoolean)
			{
				SaveBoolean(node, (PListBoolean)obj);
			}
			else if (obj is PListNumber)
			{
				SaveNumber(node, (PListNumber)obj);
			}
			else if (obj is PListString)
			{
				SaveString(node, (PListString)obj);
			}
			else if (obj is PListDate)
			{
				SaveDate(node, (PListDate)obj);
			}
			else if (obj is PListData)
			{
				SaveData(node, (PListData)obj);
			}
		}

		public void SaveArray(XmlNode node, PListArray data)
		{
			XmlNode n = node.OwnerDocument.CreateElement("array");
			node.AppendChild(n);

			foreach (PListObject d in data.Value)
			{
				Save(n, d);
			}
		}

		public void SaveDictionary(XmlNode node, PListDictionary data)
		{
			XmlNode n = node.OwnerDocument.CreateElement("dict");
			node.AppendChild(n);

			foreach (string key in data.Value.Keys)
			{
				XmlNode k = node.OwnerDocument.CreateElement("key");
				k.AppendChild(node.OwnerDocument.CreateTextNode(key));
				n.AppendChild(k);
				Save(n, data.Value[key]);
			}
		}

		public void SaveBoolean(XmlNode node, PListBoolean data)
		{
			XmlNode n = node.OwnerDocument.CreateElement(data.Value ? "true" : "false");
			node.AppendChild(n);
		}

		public void SaveNumber(XmlNode node, PListNumber data)
		{
			XmlNode n = node.OwnerDocument.CreateElement("real");
			n.AppendChild(node.OwnerDocument.CreateTextNode(data.Value.ToString()));
			node.AppendChild(n);
		}

		public void SaveString(XmlNode node, PListString data)
		{
			XmlNode n = node.OwnerDocument.CreateElement("string");
			n.AppendChild(node.OwnerDocument.CreateTextNode(data.Value));
			node.AppendChild(n);
		}

		public void SaveDate(XmlNode node, PListDate data)
		{
			DateTime d = data.Value.ToUniversalTime();
			string s = d.ToString("yyyy-MM-dd");
			s += "T";
			s += d.ToString("HH:mm:ss");
			s += "Z";
			XmlNode n = node.OwnerDocument.CreateElement("date");
			n.AppendChild(node.OwnerDocument.CreateTextNode(s));
			node.AppendChild(n);

		}

		public void SaveData(XmlNode node, PListData data)
		{
			XmlNode n = node.OwnerDocument.CreateElement("data");
			node.AppendChild(n);
		}



		#endregion

		#endregion

		#region properties

		public PListObject Root { get; set; }

		#endregion

		#region events

		#endregion
	}
}
