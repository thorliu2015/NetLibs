using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Drawing;

namespace THOR.Utils.Files
{
	public class XmlFileUtility
	{

		static public string ToInt32(Int32 d)
		{
			return d.ToString();
		}

		static public string ToSingle(Single d)
		{
			return d.ToString();
		}

		static public string ToBool(bool d)
		{
			return d ? "true" : "false";
		}

		static public string ToPoint(Point d)
		{
			return String.Format("{0},{1}", d.X, d.Y);
		}

		static public string ToPointF(PointF d)
		{
			return String.Format("{0},{1}", d.X, d.Y);
		}

		static public string ToSize(Size d)
		{
			return String.Format("{0},{1}", d.Width, d.Height);
		}

		static public string ToSizeF(SizeF d)
		{
			return String.Format("{0},{1}", d.Width, d.Height);
		}

		static public string ToRect(Rectangle d)
		{
			return String.Format("{0},{1},{2},{3}", d.X, d.Y, d.Width, d.Height);
		}

		static public string ToRectF(RectangleF d)
		{
			return String.Format("{0},{1},{2},{3}", d.X, d.Y, d.Width, d.Height);
		}

		//----------------

		static public bool GetBool(XmlNode node, string name, bool defaultValue = false)
		{
			string v = XmlFile.LoadTextNode(node, name, "").ToLower();

			return v == "true";
		}

		static public Int32 GetInt32(XmlNode node, string name, Int32 defaultValue = 0)
		{
			Int32 result = defaultValue;

			string v = XmlFile.LoadTextNode(node, name, "");
			Int32.TryParse(v, out result);

			return result;
		}

		static public Single GetSingle(XmlNode node, string name, Single defaultValue = 0)
		{
			Single result = defaultValue;

			string v = XmlFile.LoadTextNode(node, name, "");
			Single.TryParse(v, out result);

			return result;
		}

		static public string[] GetSplit(XmlNode node, string name)
		{
			string[] result = null;

			string v = XmlFile.LoadTextNode(node, name, "");

			if (v.Length > 0)
			{
				result = System.Text.RegularExpressions.Regex.Split(v, ",");
			}

			return result;
		}

		//----

		static public Point GetPoint(XmlNode node, string name)
		{
			Point result = new Point();

			string[] p = GetSplit(node, name);
			if (p != null && p.Length == 2)
			{
				result.X = Int32.Parse(p[0]);
				result.Y = Int32.Parse(p[1]);
			}

			return result;
		}

		static public PointF GetPointF(XmlNode node, string name)
		{
			PointF result = new PointF();

			string[] p = GetSplit(node, name);
			if (p != null && p.Length == 2)
			{
				result.X = Single.Parse(p[0]);
				result.Y = Single.Parse(p[1]);
			}

			return result;
		}

		//----

		static public Size GetSize(XmlNode node, string name)
		{
			Size result = new Size();

			string[] p = GetSplit(node, name);
			if (p != null && p.Length == 2)
			{
				result.Width = Int32.Parse(p[0]);
				result.Height = Int32.Parse(p[1]);
			}

			return result;
		}

		static public SizeF GetSizeF(XmlNode node, string name)
		{
			SizeF result = new SizeF();

			string[] p = GetSplit(node, name);
			if (p != null && p.Length == 2)
			{
				result.Width = Single.Parse(p[0]);
				result.Height = Single.Parse(p[1]);
			}

			return result;
		}


		//----

		static public Rectangle GetRect(XmlNode node, string name)
		{
			Rectangle result = new Rectangle();

			string[] p = GetSplit(node, name);
			if (p != null && p.Length == 4)
			{
				result.X = Int32.Parse(p[0]);
				result.Y = Int32.Parse(p[1]);
				result.Width = Int32.Parse(p[2]);
				result.Height = Int32.Parse(p[3]);
			}

			return result;
		}

		static public RectangleF GetRectF(XmlNode node, string name)
		{
			RectangleF result = new RectangleF();

			string[] p = GetSplit(node, name);
			if (p != null && p.Length == 4)
			{
				result.X = Single.Parse(p[0]);
				result.Y = Single.Parse(p[1]);
				result.Width = Single.Parse(p[2]);
				result.Height = Single.Parse(p[3]);
			}

			return result;
		}

	}
}
