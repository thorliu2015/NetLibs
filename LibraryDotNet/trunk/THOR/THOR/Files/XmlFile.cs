/*
 * XmlFile
 * liuqiang@2015/11/1 18:04:08
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


//---- 8< ------------------

namespace THOR.Files
{
	/// <summary>
	/// XML文件常用功能
	/// </summary>
	public class XmlFile
	{
		static public XmlDocument CreateXmlDocument(string rootNodeName)
		{
			string strXml = string.Format("<?xml version=\"1.0\" encoding=\"UTF-8\"?><{0}/>", rootNodeName);
			XmlDocument xml = new XmlDocument();
			xml.LoadXml(strXml);

			return xml;
		}

		/// <summary>
		/// 保存节点
		/// </summary>
		/// <param name="node">参考节点</param>
		/// <param name="path">路径</param>
		/// <returns></returns>
		static public XmlNode SaveNode(XmlNode node, string path)
		{
			string[] nodes = path.Split(new char[1] { '/' });
			XmlNode temp = node;
			XmlNode p = node;
			foreach (string n in nodes)
			{
				temp = temp.SelectSingleNode(n);
				if (temp == null)
				{
					temp = node.OwnerDocument.CreateElement(n);
					p.AppendChild(temp);
				}
				p = temp;
			}
			return temp;
		}


		static public void SaveTextNode(XmlNode node, string path, Int64 content)
		{
			SaveTextNode(node, path, content.ToString());
		}

		static public void SaveTextNode(XmlNode node, string path, UInt64 content)
		{
			SaveTextNode(node, path, content.ToString());
		}

		static public void SaveTextNode(XmlNode node, string path, decimal content)
		{
			SaveTextNode(node, path, content.ToString());
		}

		static public void SaveTextNode(XmlNode node, string path, double content)
		{
			SaveTextNode(node, path, content.ToString());
		}

		static public void SaveTextNode(XmlNode node, string path, bool content)
		{
			SaveTextNode(node, path, content.ToString());
		}

		static public void SaveTextNode(XmlNode node, string path, Point content)
		{
			SaveTextNode(node, path, String.Format("{0},{1}", content.X, content.Y));
		}

		static public void SaveTextNode(XmlNode node, string path, PointF content)
		{
			SaveTextNode(node, path, String.Format("{0},{1}", content.X, content.Y));
		}

		static public void SaveTextNode(XmlNode node, string path, Size content)
		{
			SaveTextNode(node, path, String.Format("{0},{1}", content.Width, content.Height));
		}

		static public void SaveTextNode(XmlNode node, string path, SizeF content)
		{
			SaveTextNode(node, path, String.Format("{0},{1}", content.Width, content.Height));
		}

		static public void SaveTextNode(XmlNode node, string path, Rectangle content)
		{
			SaveTextNode(node, path, string.Format("{0},{1},{2},{3}", content.X, content.Y, content.Width, content.Height));
		}

		static public void SaveTextNode(XmlNode node, string path, RectangleF content)
		{
			SaveTextNode(node, path, string.Format("{0},{1},{2},{3}", content.X, content.Y, content.Width, content.Height));
		}

		/// <summary>
		/// 保存文本内容到指定位置
		/// </summary>
		/// <param name="node">参考节点</param>
		/// <param name="path">路径</param>
		/// <param name="content">文本内容</param>
		static public void SaveTextNode(XmlNode node, string path, string content)
		{
			XmlNode n = SaveNode(node, path);
			if (content == null || content.Length == 0) return;
			n.AppendChild(node.OwnerDocument.CreateTextNode(content));
		}

		static public Int16 LoadTextNode(XmlNode node, string path, Int16 defaultContent)
		{
			string v = LoadTextNode(node, path, defaultContent.ToString());

			Int16 r = defaultContent;

			Int16.TryParse(v, out r);

			return r;
		}

		static public UInt16 LoadTextNode(XmlNode node, string path, UInt16 defaultContent)
		{
			string v = LoadTextNode(node, path, defaultContent.ToString());

			UInt16 r = defaultContent;

			UInt16.TryParse(v, out r);

			return r;
		}

		static public Int32 LoadTextNode(XmlNode node, string path, Int32 defaultContent)
		{
			string v = LoadTextNode(node, path, defaultContent.ToString());

			Int32 r = defaultContent;

			Int32.TryParse(v, out r);

			return r;
		}

		static public UInt32 LoadTextNode(XmlNode node, string path, UInt32 defaultContent)
		{
			string v = LoadTextNode(node, path, defaultContent.ToString());

			UInt32 r = defaultContent;

			UInt32.TryParse(v, out r);

			return r;
		}

		static public Int64 LoadTextNode(XmlNode node, string path, Int64 defaultContent)
		{
			string v = LoadTextNode(node, path, defaultContent.ToString());

			Int64 r = defaultContent;

			Int64.TryParse(v, out r);

			return r;
		}

		static public UInt64 LoadTextNode(XmlNode node, string path, UInt64 defaultContent)
		{
			string v = LoadTextNode(node, path, defaultContent.ToString());

			UInt64 r = defaultContent;

			UInt64.TryParse(v, out r);

			return r;
		}

		static public decimal LoadTextNode(XmlNode node, string path, decimal defaultContent)
		{
			string v = LoadTextNode(node, path, defaultContent.ToString());

			decimal r = defaultContent;

			decimal.TryParse(v, out r);

			return r;
		}

		static public float LoadTextNode(XmlNode node, string path, float defaultContent)
		{
			string v = LoadTextNode(node, path, defaultContent.ToString());

			float r = defaultContent;

			float.TryParse(v, out r);

			return r;
		}

		static public double LoadTextNode(XmlNode node, string path, double defaultContent)
		{
			string v = LoadTextNode(node, path, defaultContent.ToString());

			double r = defaultContent;

			double.TryParse(v, out r);

			return r;
		}

		static public bool LoadTextNode(XmlNode node, string path, bool defaultContent)
		{
			string v = LoadTextNode(node, path, defaultContent.ToString());

			switch (v.Trim().ToUpper())
			{
				case "TRUE":
					return true;

				case "FALSE":
					return false;

				default:
					return defaultContent;
			}
		}

		static public Point LoadTextNode(XmlNode node, string path, Point defaultContent)
		{
			Point result = new Point(defaultContent.X, defaultContent.Y);

			string v = LoadTextNode(node, path, "");

			string[] vs = System.Text.RegularExpressions.Regex.Split(v, ",");

			try
			{
				result.X = Convert.ToInt32(vs[0]);
				result.Y = Convert.ToInt32(vs[1]);
			}
			catch
			{
			}

			return result;
		}


		static public PointF LoadTextNode(XmlNode node, string path, PointF defaultContent)
		{
			PointF result = new PointF(defaultContent.X, defaultContent.Y);

			string v = LoadTextNode(node, path, "");

			string[] vs = System.Text.RegularExpressions.Regex.Split(v, ",");

			try
			{
				result.X = Convert.ToSingle(vs[0]);
				result.Y = Convert.ToSingle(vs[1]);
			}
			catch
			{
			}

			return result;
		}


		static public Size LoadTextNode(XmlNode node, string path, Size defaultContent)
		{
			Size result = new Size(defaultContent.Width, defaultContent.Height);

			string v = LoadTextNode(node, path, "");

			string[] vs = System.Text.RegularExpressions.Regex.Split(v, ",");

			try
			{
				result.Width = Convert.ToInt32(vs[0]);
				result.Height = Convert.ToInt32(vs[1]);
			}
			catch
			{
			}

			return result;
		}


		static public SizeF LoadTextNode(XmlNode node, string path, SizeF defaultContent)
		{
			SizeF result = new SizeF(defaultContent.Width, defaultContent.Height);

			string v = LoadTextNode(node, path, "");

			string[] vs = System.Text.RegularExpressions.Regex.Split(v, ",");

			try
			{
				result.Width = Convert.ToSingle(vs[0]);
				result.Height = Convert.ToSingle(vs[1]);
			}
			catch
			{
			}

			return result;
		}

		static public Rectangle LoadTextNode(XmlNode node, string path, Rectangle defaultContent)
		{
			Rectangle result = new Rectangle(defaultContent.X, defaultContent.Y, defaultContent.Width, defaultContent.Height);

			string v = LoadTextNode(node, path, "");

			string[] vs = System.Text.RegularExpressions.Regex.Split(v, ",");

			try
			{
				result.X = Convert.ToInt32(vs[0]);
				result.Y = Convert.ToInt32(vs[1]);
				result.Width = Convert.ToInt32(vs[2]);
				result.Height = Convert.ToInt32(vs[3]);
			}
			catch
			{
			}

			return result;
		}


		static public RectangleF LoadTextNode(XmlNode node, string path, RectangleF defaultContent)
		{
			RectangleF result = new RectangleF(defaultContent.X, defaultContent.Y, defaultContent.Width, defaultContent.Height);

			string v = LoadTextNode(node, path, "");

			string[] vs = System.Text.RegularExpressions.Regex.Split(v, ",");

			try
			{
				result.X = Convert.ToSingle(vs[0]);
				result.Y = Convert.ToSingle(vs[1]);
				result.Width = Convert.ToSingle(vs[2]);
				result.Height = Convert.ToSingle(vs[3]);
			}
			catch
			{
			}

			return result;
		}




		/// <summary>
		/// 读取指定位置的文本内容
		/// </summary>
		/// <param name="node">参考节点</param>
		/// <param name="path">路径</param>
		/// <param name="defaultContent">文本内容</param>
		/// <returns></returns>
		static public string LoadTextNode(XmlNode node, string path, string defaultContent)
		{
			XmlNode find = node.SelectSingleNode(path);
			if (find == null) return defaultContent;

			return find.InnerText;
		}

		/// <summary>
		/// 保存属性值
		/// </summary>
		/// <param name="node">参考节点</param>
		/// <param name="path">属性名称</param>
		/// <param name="value">属性值</param>
		static public void SaveAttribute(XmlNode node, string name, string value)
		{
			if (node.Attributes[name] == null)
			{
				node.Attributes.Append(node.OwnerDocument.CreateAttribute(name)).Value = value;
			}
			else
			{
				node.Attributes[name].Value = value;
			}
		}


		/// <summary>
		/// 保存XML内容
		/// </summary>
		/// <param name="file">文件名</param>
		/// <param name="xml">XML文档</param>
		static public void Save(string file, XmlDocument xml)
		{
			StringBuilder sb = new StringBuilder();
			StreamWriter sw = new StreamWriter(file);

			XmlTextWriter xtw = new XmlTextWriter(sw);

			xtw.Formatting = Formatting.Indented;
			xtw.Indentation = 1;
			xtw.IndentChar = '\t';

			xml.Save(xtw);

			xtw.Dispose();
		}
	}
}
