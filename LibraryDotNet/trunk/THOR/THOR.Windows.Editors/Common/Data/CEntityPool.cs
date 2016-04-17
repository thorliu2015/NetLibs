/*
 * CEntityPool
 * liuqiang@2015/11/1 19:41:31
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Windows.Editors.Common.Data
{
	/// <summary>
	/// 实体对象池
	/// </summary>
	public class CEntityPool
	{
		#region constants

		#endregion

		#region variables

		/// <summary>
		/// 实体对象字典
		/// </summary>
		protected Dictionary<string, CEntity> Entities;

		/// <summary>
		/// ID验证规则
		/// </summary>
		protected Regex IdRegex = new Regex("^(?<id>[a-zA-Z_0-9]+)$", RegexOptions.Compiled);

		#endregion

		#region construct

		/// <summary>
		/// 获取当前实例
		/// </summary>
		static public CEntityPool Current { get; private set; }

		static CEntityPool()
		{
			Current = new CEntityPool();
		}

		/// <summary>
		/// 构造
		/// </summary>
		private CEntityPool()
		{
			Entities = new Dictionary<string, CEntity>();
		}

		#endregion

		#region methods

		/// <summary>
		/// 验证ID是否合法
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool VerifyID(string id)
		{
			return IdRegex.IsMatch(id);
		}

		/// <summary>
		/// 获取ID是否存在
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool ContainId(string id)
		{
			return Entities.ContainsKey(id);
		}

		/// <summary>
		/// 获取对象是否存在
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public bool ContainEntity(CEntity entity)
		{
			return Entities.ContainsValue(entity);
		}

		/// <summary>
		/// 获取指定ID的对象
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public CEntity GetEntity(string id)
		{
			if (Entities.ContainsKey(id)) return Entities[id];

			return null;
		}

		/// <summary>
		/// 获取对象集合
		/// </summary>
		/// <param name="result"></param>
		/// <param name="types"></param>
		public void GetEntities(List<CEntity> result, Type[] types)
		{
			foreach (CEntity entity in Entities.Values)
			{
				if (entity == null) continue;

				Type entityType = entity.GetType();

				bool matchType = false;

				foreach (Type type in types)
				{
					if (type == entityType)
					{
						matchType = true;
						break;
					}
					else if (entityType.IsSubclassOf(type))
					{
						matchType = true;
						break;
					}
				}


				if (matchType)
				{
					result.Add(entity);
				}
			}
		}

		/// <summary>
		/// 添加对象
		/// </summary>
		/// <param name="entity"></param>
		public void Add(CEntity entity)
		{
			if (Entities.ContainsKey(entity.GetFullID())) return;
			if (Entities.ContainsValue(entity)) return;

			Entities[entity.GetFullID()] = entity;
		}

		/// <summary>
		/// 移除对象
		/// </summary>
		/// <param name="entity"></param>
		public void Remove(CEntity entity)
		{
			string id = entity.GetFullID();
			if (Entities.ContainsKey(id))
			{
				if (Entities[id] == entity)
				{
					Entities.Remove(id);
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
