/*
 * ColorList
 * liuqiang@2015/11/25 9:51:34
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


//---- 8< ------------------

namespace WriteColorCodes
{

	public class ColorListItem
	{
		protected string _DarkColor = "";
		protected string _LightColor = "";

		public ColorListItem(string name, string dark, string light, string comment)
		{
			this.Name = name;
			this.DarkColor = dark;
			this.LightColor = light;
			this.Comment = comment;
		}

		public string Name { get; set; }
		public string Comment { get; set; }

		public string DarkColor
		{
			get
			{
				ColorListItem item = ColorList.GetColorItemByName(_DarkColor);
				if (item != null) return item.DarkColor;

				return _DarkColor;
			}
			set
			{
				_DarkColor = value;
			}
		}

		public string LightColor
		{
			get
			{
				ColorListItem item = ColorList.GetColorItemByName(_LightColor);
				if (item != null) return item.LightColor;

				return _LightColor;
			}
			set
			{
				_LightColor = value;

			}
		}
	}

	public class ColorList
	{
		//name, code, comment
		static public List<ColorListItem> Items = new List<ColorListItem>();

		static private void Add(string name, string dark, string light, string comment)
		{
			Items.Add(new ColorListItem(name, dark, light, comment));
		}

		//name, dark, light, comment
		static ColorList()
		{
			string colorsXml = TemplateUtils.GetTemplate("Colors.xml");
			XmlDocument xml = new XmlDocument();
			xml.LoadXml(colorsXml);

			foreach(XmlNode colorNode in xml.SelectNodes("/Colors/Color"))
			{
				string sName = colorNode.Attributes["Name"].Value;
				string sDark = colorNode.Attributes["Dark"].Value;
				string sLight = colorNode.Attributes["Light"].Value;
				string sComment = colorNode.Attributes["Comment"].Value;

				Add(sName, sDark, sLight, sComment);
			}
			
		}


		static public ColorListItem GetColorItemByName(string name)
		{
			foreach(ColorListItem item in Items)
			{
				if(item.Name==name)
				{
					return item;
				}
			}
			return null;
		}


	}



}
