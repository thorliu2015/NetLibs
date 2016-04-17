/*
 * WriteThemeClass
 * liuqiang@2015/11/25 10:05:40
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


//---- 8< ------------------

namespace WriteColorCodes
{
	public class WriteThemeClass
	{
		#region constants

		#endregion

		#region variables


		
		#endregion

		#region construct

		#endregion

		#region methods

		static public void Write(string outputFilepath)
		{
			string themeClassTemplate = TemplateUtils.GetTemplate("ThemeClass.txt");
			string themeClassPropertyTemplate = TemplateUtils.GetTemplate("ThemeClassProperty.txt");
			string themeClassInitTemplate = TemplateUtils.GetTemplate("ThemeClassInit.txt");

			StringBuilder sbProperties = new StringBuilder();
			StringBuilder sbDark = new StringBuilder();
			StringBuilder sbLight = new StringBuilder();

			foreach (ColorListItem item in ColorList.Items)
			{
				sbProperties.Append(String.Format(themeClassPropertyTemplate, item.Name, item.Comment));
				sbDark.Append(String.Format(themeClassInitTemplate, item.Name, item.DarkColor));
				sbLight.Append(String.Format(themeClassInitTemplate, item.Name, item.LightColor));
				
			}

			themeClassTemplate = themeClassTemplate.Replace("//$ColorProperties", sbProperties.ToString());
			themeClassTemplate = themeClassTemplate.Replace("//$DarkColors", sbDark.ToString());
			themeClassTemplate = themeClassTemplate.Replace("//$LightColors", sbLight.ToString());

			StreamWriter writer = new StreamWriter(outputFilepath);
			writer.Write(themeClassTemplate);
			writer.Close();
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
