/*
 * ThorEditorTypeIcons
 * liuqiang@2015/12/6 12:08:52
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

//---- 8< ------------------

namespace THOR.Windows.Editors.Common
{
	public class ThorEditorTypeIcons
	{
		#region constants

		#endregion

		#region variables

		static private Dictionary<string, Image> Images = new Dictionary<string, Image>();

		#endregion

		#region construct

		#endregion

		#region methods

		static public Image GetCategoryIcon(bool isExpanded)
		{
			return GetImage(isExpanded ? "CATEGORY_OPEN" : "CATEGORY_CLOSE");
		}

		static public Image GetTypeIcon(Type type)
		{
			Image img = GetImage(type.FullName);

			if (img == null) img = GetImage("DEFAULT");
			
			return img;
		}

		static private Image GetImage(string filename)
		{
			if (Images.ContainsKey(filename)) return Images[filename];

			string dir = Path.GetDirectoryName(Application.ExecutablePath);
			dir = Path.Combine(dir, @"Resources\Types");

			dir = Path.Combine(dir, String.Format("{0}.png", filename));

			if (File.Exists(dir))
			{
				MemoryStream stream = new MemoryStream();
				StreamReader reader = new StreamReader(dir);

				byte[] bytes = new byte[reader.BaseStream.Length];
				reader.BaseStream.Read(bytes, 0, bytes.Length);

				reader.Close();

				stream.Write(bytes, 0, bytes.Length);
				stream.Position = 0;

				Image img = Image.FromStream(stream);
				stream.Dispose();

				Images[filename] = img;
				
				return img;
			}

			return null;
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
