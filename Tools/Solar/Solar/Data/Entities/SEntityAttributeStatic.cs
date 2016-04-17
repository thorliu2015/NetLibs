using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Data.Entities
{
	/// <summary>
	/// 单位静态特征
	/// </summary>
	public enum SEntityAttributeStatic
	{
		/// <summary>
		/// 地面
		/// </summary>
		Ground						= 1 << 0,

		/// <summary>
		/// 空中
		/// </summary>
		Air							= 1 << 1,

		/// <summary>
		/// 水中
		/// </summary>
		Water						= 1 << 2,

		/// <summary>
		/// 建筑
		/// </summary>
		Structure					= 1 << 3,

		/// <summary>
		/// 陷阱
		/// </summary>
		Trap						= 1 << 4,

		/// <summary>
		/// 英雄
		/// </summary>
		Heroic						= 1 << 5,


		/// <summary>
		/// 生物
		/// </summary>
		Biological					= 1 << 6,

		/// <summary>
		/// 机械
		/// </summary>
		Mechanical					= 1 << 7,

		/// <summary>
		/// 机器人/电子
		/// </summary>
		Robot						= 1 << 8,

		/// <summary>
		/// 灵能
		/// </summary>
		Psionic						= 1 << 9,

		/// <summary>
		/// 工人
		/// </summary>
		Worker						= 1 << 10,

		/// <summary>
		/// 平民
		/// </summary>
		Civilian					= 1 << 11,

		/// <summary>
		/// 无敌的
		/// </summary>
		Invincible					= 1 << 12,

		/// <summary>
		/// 侦测的
		/// </summary>
		Dectection					= 1 << 13,

		/// <summary>
		/// 隐形的
		/// </summary>
		Cloak						= 1 << 14,

		/// <summary>
		/// 障碍物
		/// </summary>
		Obstacle					= 1 << 15,

		/// <summary>
		/// 作战单位
		/// </summary>
		Combat						= 1 << 16,

		/// <summary>
		/// 资源
		/// </summary>
		Resource					= 1 << 17,

		/// <summary>
		/// 不保存
		/// </summary>
		NoSave						= 1 << 18,

		/// <summary>
		/// 发射物
		/// </summary>
		Projectile					= 1 << 19
	}
}
