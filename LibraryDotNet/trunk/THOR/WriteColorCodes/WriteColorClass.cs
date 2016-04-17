/*
 * WriteColorClass
 * liuqiang@2015/11/25 10:47:55
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace WriteColorCodes
{
	public class WriteColorClass
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
			string colorClassTemplate = TemplateUtils.GetTemplate("ColorClass.txt");
			string colorClassPropertyTemplate = TemplateUtils.GetTemplate("ColorClassProperty.txt");

			StringBuilder sbProperties = new StringBuilder();

			foreach (ColorListItem item in ColorList.Items)
			{
				sbProperties.Append(String.Format(colorClassPropertyTemplate, item.Name, item.Comment));
			}
			colorClassTemplate = colorClassTemplate.Replace("//$ColorProperties", sbProperties.ToString());

			StreamWriter writer = new StreamWriter(outputFilepath);
			writer.Write(colorClassTemplate);
			writer.Close();
		}
		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
