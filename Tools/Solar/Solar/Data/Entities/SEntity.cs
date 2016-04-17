using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Utils.Attributes;

namespace Solar.Data.Entities
{
	[Serializable()]
	[Note("单位", "所有的建筑,士兵,子弹,地雷等个体", "核心")]
	public class SEntity : SModel
	{
		/// <summary>
		/// 构造
		/// </summary>
		public SEntity()
			: base()
		{
			Weapons = new List<string>();
			Abilities = new List<string>();
		}


		public SEntityAttributeStatic StaticAttributes { get; set; }
		public SEntityAttributeDynamic DynamicAttributes { get; set; }

		/// <summary>
		/// 链接为"主动能力"
		/// </summary>
		public List<String> Weapons { get; set; }

		/// <summary>
		/// 链接为"背动能力"
		/// </summary>
		public List<String> Abilities { get; set; }

		
	}
}
