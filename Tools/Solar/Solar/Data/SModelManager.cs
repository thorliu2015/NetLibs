using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Solar.Data
{
	/// <summary>
	/// 数据模型管理器
	/// </summary>
	public class SModelManager
	{
		/// <summary>
		/// 构造
		/// </summary>
		static SModelManager()
		{
			Current = new SModelManager();
		}

		/// <summary>
		/// 构造
		/// </summary>
		private SModelManager()
		{
			Models = new Dictionary<string, SModel>();
			TileSize = new Size(40, 30);

			try
			{
				int tw = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["TileWidth"]);
				int th = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["TileHeight"]);

				if (tw > 0 && th > 0)
				{
					TileSize = new Size(tw, th);
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// 获取当前实例
		/// </summary>
		static public SModelManager Current { get; private set; }

		//----

		public Size TileSize { get; set; }

		/// <summary>
		/// 所有数据模型
		/// </summary>
		private Dictionary<string, SModel> Models;

		/// <summary>
		/// 验证ID命名是否合法
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool VerifyId(string id)
		{
			return Regex.IsMatch(id, "^(?<id>[a-zA-Z0-9][a-zA-Z0-9_]*)$");
		}

		/// <summary>
		/// 检查是否包含了指定的ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool Contains(string id)
		{
			return Models.ContainsKey(id);
		}

		/// <summary>
		/// 检查是否包含了指定的数据
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public bool Contains(SModel model)
		{
			return Models.ContainsValue(model);
		}

		/// <summary>
		/// 添加一个新的数据
		/// </summary>
		/// <param name="model"></param>
		public void Add(SModel model)
		{
			if (!VerifyId(model.Id))
			{
				throw new Exception(String.Format("Id命名不符合标准, 请使用英文, 数字, 下划线, 并且首字符必须是英文或者数字 !"));
			}
			else if (Contains(model.Id))
			{
				throw new Exception(String.Format("此Id已经存在, 请使用新的Id !"));
			}
			else if (Contains(model))
			{
				throw new Exception(String.Format("此数据已经存在 !"));
			}
			else
			{
				Models[model.Id] = model;
				model.OnAdd();
			}
		}

		/// <summary>
		/// 移除指定ID的数据
		/// </summary>
		/// <param name="id"></param>
		public void Remove(string id)
		{
			if (Models.ContainsKey(id))
			{
				SModel model = Models[id];
				Models.Remove(id);
				model.OnRemove();
			}
		}



		/// <summary>
		/// 清除所有数据
		/// </summary>
		public void Clear()
		{
			foreach (SModel model in Models.Values)
			{
				model.OnRemove();
			}
			Models.Clear();
		}


		/// <summary>
		/// 更改数据的ID
		/// </summary>
		/// <param name="model"></param>
		/// <param name="newid"></param>
		public void Rename(SModel model, string newid)
		{
			if (Models.ContainsKey(newid))
			{
				throw new Exception(String.Format("此Id已经存在, 请使用新的Id !"));
			}

			if (Models.ContainsKey(model.Id))
			{
				Models.Remove(model.Id);
				model.OnRename(newid);
				model.Id = newid;
				Models.Add(model.Id, model);

			}

		}

		/// <summary>
		/// 获取所有数据
		/// </summary>
		/// <param name="models"></param>
		public void GetModels(List<SModel> models)
		{
			foreach (SModel model in Models.Values)
			{
				models.Add(model);
			}
		}

		/// <summary>
		/// 获取指定类型的数据
		/// </summary>
		/// <param name="models"></param>
		/// <param name="type"></param>
		public void GetModels(List<SModel> models, Type type)
		{
			foreach (SModel model in Models.Values)
			{
				Type mType = model.GetType();

				if (mType == type)
				{
					models.Add(model);
				}
			}
		}

		/// <summary>
		/// 获取指定类型的数据
		/// </summary>
		/// <param name="models"></param>
		/// <param name="types"></param>
		public void GetModels(List<SModel> models, List<Type> types)
		{
			foreach (SModel model in Models.Values)
			{
				foreach (Type type in types)
				{
					if (model.GetType() == type)
					{
						models.Add(model);
					}
				}
			}
		}

		/// <summary>
		/// 获取指定ID的数据模型
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public SModel GetModel(string id)
		{
			if (Models.ContainsKey(id))
			{
				return Models[id];
			}

			return null;
		}
	}
}
