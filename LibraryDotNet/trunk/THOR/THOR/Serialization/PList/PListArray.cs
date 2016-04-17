/*
 * PListArray
 * liuqiang@2016/1/21 23:46:49
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
	public class PListArray : PListObject
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public PListArray()
			: base()
		{
			DataType = PListObjectType.Array;
			Value = new List<PListObject>();
		}


		#endregion

		#region methods

		public override string ToString()
		{
			return String.Format("{{Array {0}}}", Value.Count);
		}

		#endregion

		#region properties

		public List<PListObject> Value { get; set; }

		#endregion

		#region events

		#endregion
	}
}
