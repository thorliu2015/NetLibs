using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Utils.Attributes;

namespace Solar.Data.Weapons
{
	[Serializable()]
	[Note("武器", "所有的主动能力, 武器, 法术之类", "核心")]
	public class SWeapon : SModel
	{
		public SWeapon()
			: base()
		{
		}


	}
}
