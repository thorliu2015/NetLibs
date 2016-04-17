/*
 * PListBoolean
 * liuqiang@2016/1/21 23:47:28
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
	public class PListBoolean : PListObject
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public PListBoolean(bool value = false)
			: base()
		{
			DataType = PListObjectType.Boolean;
			Value = false;
		}

		#endregion

		#region methods

		public override string ToString()
		{
			return String.Format("{{Boolean {0}}}", Value);
		}

		#endregion

		#region properties

		public bool Value { get; set; }

		#endregion

		#region events

		#endregion
	}
}
