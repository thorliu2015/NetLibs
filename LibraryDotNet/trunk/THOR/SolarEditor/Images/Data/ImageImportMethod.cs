/*
 * ImageImportMethod
 * liuqiang@2015/12/12 1:10:42
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.Editors.Common.Core;
using System.Windows.Forms;
using System.IO;
using THOR.Windows.Editors.Common.Data;
using System.Diagnostics;
using THOR.Windows.Utils;


//---- 8< ------------------

namespace SolarEditor.Images.Data
{
	public class ImageImportMethod : IEditorLoadMethod
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		/// <summary>
		/// 尝试导入文件
		/// </summary>
		/// <param name="module"></param>
		public void Load(EditorModule module)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Multiselect = true;
			dialog.Filter = "png(*.png)|*.png";
			if (dialog.ShowDialog(module.ModuleForm) == DialogResult.Cancel) return;

			foreach (string file in dialog.FileNames)
			{
				ImportImageFile(file, module);
			}
		}

		/// <summary>
		/// 导入图片文件
		/// </summary>
		/// <param name="file"></param>
		protected virtual void ImportImageFile(string file, EditorModule module)
		{
			string key = Path.GetFileNameWithoutExtension(file);
			string fullKey = String.Format("img_{0}", key);

			if (CEntityPool.Current.ContainId(fullKey))
			{
				Debug.WriteLine(String.Format("因为ID重复, 所以忽略 {0}", file));
			}
			else
			{
				CImage image = new CImage();
				image.Id = key;

				string dirPath = ApplicationUtils.CombinePath(String.Format("Data\\{0}", module.Key));

				if (!Directory.Exists(dirPath))
				{
					Directory.CreateDirectory(dirPath);
				}


				string filePath = Path.Combine(dirPath, String.Format("{0}.png", fullKey));

				try
				{
					File.Copy(file, filePath);
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					return;
				}

				CEntityPool.Current.Add(image);
			}

		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion

	}
}
