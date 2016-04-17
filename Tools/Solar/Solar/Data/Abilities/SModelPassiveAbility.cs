using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Utils.Attributes;

namespace Solar.Data.Abilities
{
	[Serializable()]
	[Note("被动", "所有的被动能力, 天赋等", "核心")]
	public class SModelPassiveAbility : SModel
	{
		public SModelPassiveAbility()
			: base()
		{
		}
	}
}
