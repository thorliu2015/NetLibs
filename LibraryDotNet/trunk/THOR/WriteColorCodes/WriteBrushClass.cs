/*
 * WriteBrushClass
 * liuqiang@2015/11/25 10:45:49
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
	class WriteBrushClass
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
			string brushClassTemplate = TemplateUtils.GetTemplate("BrushClass.txt");
			string brushClassPropertyTemplate = TemplateUtils.GetTemplate("BrushClassProperty.txt");

			StringBuilder sbProperties = new StringBuilder();

			foreach (ColorListItem item in ColorList.Items)
			{
				sbProperties.Append(String.Format(brushClassPropertyTemplate, item.Name, item.Comment));
			}
			brushClassTemplate = brushClassTemplate.Replace("//$ColorProperties", sbProperties.ToString());

			StreamWriter writer = new StreamWriter(outputFilepath);
			writer.Write(brushClassTemplate);
			writer.Close();
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
