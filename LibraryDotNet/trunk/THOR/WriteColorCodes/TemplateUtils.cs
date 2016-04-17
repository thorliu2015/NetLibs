/*
 * TemplateUtils
 * liuqiang@2015/11/25 10:24:12
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//---- 8< ------------------

namespace WriteColorCodes
{
	public class TemplateUtils
	{
		static public string GetTemplate(string name)
		{
			string appPath = Path.GetDirectoryName(Application.ExecutablePath);
			string templatePath = Path.Combine(appPath, "Templates");
			string templateFile = Path.Combine(templatePath, name);

			string result = "";

			if(File.Exists(templateFile))
			{
				StreamReader reader = new StreamReader(templateFile);

				result = reader.ReadToEnd();

				reader.Close();
			}

			return result;
		}
	}
}
