/*
 * WritePenClass
 * liuqiang@2015/11/25 10:45:32
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
	public class WritePenClass
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
			string penClassTemplate = TemplateUtils.GetTemplate("PenClass.txt");
			string penClassPropertyTemplate = TemplateUtils.GetTemplate("PenClassProperty.txt");

			StringBuilder sbProperties = new StringBuilder();

			foreach (ColorListItem item in ColorList.Items)
			{
				sbProperties.Append(String.Format(penClassPropertyTemplate, item.Name, item.Comment));
			}
			penClassTemplate = penClassTemplate.Replace("//$ColorProperties", sbProperties.ToString());

			StreamWriter writer = new StreamWriter(outputFilepath);
			writer.Write(penClassTemplate);
			writer.Close();
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
