/*
 * XmlLoadMethod
 * liuqiang@2015/11/22 16:43:53
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using THOR.Serialization.XmlEntities;
using THOR.Windows.Editors.Common.Data;
using THOR.Windows.Utils;


//---- 8< ------------------

namespace THOR.Windows.Editors.Common.Core
{
	/// <summary>
	/// 模块的XML数据读取方法
	/// </summary>
	public class XmlLoadMethod : IEditorLoadMethod
	{
		#region constants

		#endregion

		#region variables

		protected XmlEntityDecoder decoder = new XmlEntityDecoder();

		#endregion

		#region construct

		public XmlLoadMethod()
		{
		}

		#endregion

		#region methods

		public void Load(EditorModule module)
		{
			if (module == null) return;
			string folderPath = ApplicationUtils.CombinePath(String.Format(@"Data\{0}", module.Key));

			if (!Directory.Exists(folderPath)) return;

			string[] files = Directory.GetFiles(folderPath, "*.xml", SearchOption.AllDirectories);

			ThorEditorManager.Current.SplashForm.SetProgressInfo(0, files.Length, "Loading Module KEY Data ...", "");

			for (int i = 0; i < files.Length; i++)
			{
				string file = files[i];
				ThorEditorManager.Current.SplashForm.SetProgressInfo(i, files.Length, "Loading Module KEY Data ({0}/{1})", 
					String.Format(@"{0}\{1}",module.Key, Path.GetFileName(file))
					);
				LoadFile(module, file);

			}
		}

		protected virtual void LoadFile(EditorModule module, string filename)
		{
			List<object> data = decoder.Decode(filename);

			foreach (object obj in data)
			{
				if (obj is CEntity)
				{
					CEntity entity = (CEntity)obj;

					CEntityPool.Current.Add(entity);
				}
			}
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion

	}
}
