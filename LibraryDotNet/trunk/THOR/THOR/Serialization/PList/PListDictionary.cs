/*
 * PListDictionary
 * liuqiang@2016/1/21 23:47:06
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Serialization.PList
{
	[Serializable()]
	public class PListDictionary : PListObject
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public PListDictionary()
			: base()
		{
			DataType = PListObjectType.Dictionary;
			Value = new Dictionary<string, PListObject>();
		}

		#endregion

		#region methods

		public override string ToString()
		{
			return String.Format("{{Dictionary {0}}}", Value.Count);
		}

		#endregion

		#region properties

		public Dictionary<string, PListObject> Value { get; set; }

		#endregion

		#region events

		#endregion
	}
}
