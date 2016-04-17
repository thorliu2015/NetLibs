/*
 * XmlSaveMethod
 * liuqiang@2015/11/22 16:44:08
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using THOR.Serialization.XmlEntities;
using THOR.Windows.Editors.Common.Data;
using THOR.Windows.Utils;


//---- 8< ------------------

namespace THOR.Windows.Editors.Common.Core
{
	/// <summary>
	/// 模块的XML数据保存方法
	/// </summary>
	public class XmlSaveMethod : IEditorSaveMethod
	{
		#region constants

		#endregion

		#region variables

		protected XmlEntityEncoder encoder = new XmlEntityEncoder();

		#endregion

		#region construct

		public XmlSaveMethod()
		{
		}

		#endregion

		#region methods

		/// <summary>
		/// 清理文件
		/// </summary>
		/// <param name="entities"></param>
		protected virtual void CleanFiles(EditorModule module, List<CEntity> entities)
		{
			string dirPath = ApplicationUtils.CombinePath(String.Format(@"Data\{0}", module.Key));

			if (!Directory.Exists(dirPath)) return;

			string[] files = Directory.GetFiles(dirPath, "*.xml", SearchOption.AllDirectories);
			Dictionary<string, string> dict = new Dictionary<string, string>();

			foreach (string file in files)
			{
				string key = Path.GetFileNameWithoutExtension(file);
				dict[key] = file;
			}

			foreach (CEntity entity in entities)
			{
				string key = entity.GetFullID();

				if (dict.ContainsKey(key))
				{
					dict[key] = "";
				}
			}

			foreach (string key in dict.Keys)
			{
				string file = dict[key];

				if (file.Trim().Length > 0)
				{
					try
					{
						File.Delete(file);
					}
					catch (Exception ex)
					{
					}
				}
			}
		}

		/// <summary>
		/// 保存模块的数据
		/// </summary>
		/// <param name="module"></param>
		public void Save(EditorModule module)
		{
			//清除之前的数据
			List<CEntity> list = new List<CEntity>();

			EditorModuleDataProvider.GetEntities(module, list);

			CleanFiles(module, list);

			foreach (CEntity entity in list)
			{
				SaveEntity(module, entity);
			}
		}

		/// <summary>
		/// 保存对象
		/// </summary>
		/// <param name="module"></param>
		/// <param name="entity"></param>
		protected virtual void SaveEntity(EditorModule module, CEntity entity)
		{
			string filename = ApplicationUtils.CombinePath(String.Format(@"Data\{0}", module.Key));

			if (!Directory.Exists(filename))
			{
				try
				{
					Directory.CreateDirectory(filename);
				}
				catch (Exception ex)
				{
				}
			}


			filename = Path.Combine(filename, String.Format("{0}.xml", entity.GetFullID()));

			encoder.Encode(filename, entity);
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion

	}
}
