/*
 * XmlEntitiesClasses
 * liuqiang@2015/11/1 17:42:41
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Attributes.Notes;
using THOR.Serialization.XmlEntities;


//---- 8< ------------------

namespace Test.XmlEntities
{
	public enum TestUnitAttributes
	{
		[Note("无")]
		None = 0,
		[Note("地面")]
		Ground = 1 << 0,
		[Note("空中")]
		Air = 1 << 1,
		[Note("水中")]
		Water = 1 << 2
	}

	public class TestUnit
	{
		public TestUnit()
		{
		}

		[XmlEntityProperty()]
		public string Id { get; set; }

		[XmlEntityProperty()]
		public string Name { get; set; }

		[XmlEntityProperty("Attributes", XmlEntityPropertyMode.EnumTags)]
		public TestUnitAttributes Attributes { get; set; }
	}

}
