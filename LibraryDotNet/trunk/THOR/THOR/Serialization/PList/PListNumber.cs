/*
 * PListNumber
 * liuqiang@2016/1/21 23:48:09
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
	public class PListNumber : PListObject
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public PListNumber()
			: base()
		{
			DataType = PListObjectType.Number;
			Value = 0;
		}

		#endregion

		#region methods

		public override string ToString()
		{
			return String.Format("{{Number {0}}}", Value);
		}

		#endregion

		#region properties

		public double Value { get; set; }

		#endregion

		#region events

		#endregion
	}
}
