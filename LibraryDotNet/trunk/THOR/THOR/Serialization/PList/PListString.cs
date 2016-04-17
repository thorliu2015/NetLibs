/*
 * PListString
 * liuqiang@2016/1/21 23:48:25
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
	public class PListString : PListObject
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public PListString()
			: base()
		{
			DataType = PListObjectType.String;
			Value = "";
		}

		#endregion

		#region methods

		public override string ToString()
		{
			return String.Format("{{String \"{0}\"}}", Value);
		}

		#endregion

		#region properties

		public string Value { get; set; }

		#endregion

		#region events

		#endregion
	}
}
