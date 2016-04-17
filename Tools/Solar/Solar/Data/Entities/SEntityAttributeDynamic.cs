using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Data.Entities
{
	/// <summary>
	/// 单位动态特征
	/// </summary>
	public enum SEntityAttributeDynamic
	{
		/// <summary>
		/// 我方
		/// </summary>
		We					= 1 << 0,

		/// <summary>
		/// 敌方
		/// </summary>
		Enemy				= 1 << 1,

		/// <summary>
		/// 友方
		/// </summary>
		Friendly			= 1 << 2,

		/// <summary>
		/// 别人的
		/// </summary>
		Others				= 1 << 3,

		/// <summary>
		/// 受伤的
		/// </summary>
		Wounded				= 1 << 4,

		/// <summary>
		/// 死亡的
		/// </summary>
		Death				= 1 << 5,

		/// <summary>
		/// 召唤的
		/// </summary>
		Calls				= 1 << 6,

		/// <summary>
		/// 活的
		/// </summary>
		Alive				= 1 << 7,

		/// <summary>
		/// 同一编队的
		/// </summary>
		SameGroup			= 1 << 8
	}
}
