/*
 * PListDate
 * liuqiang@2016/1/21 23:47:55
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
	public class PListDate : PListObject
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public PListDate()
			: base()
		{
			DataType = PListObjectType.Date;
			Value = DateTime.Now;
		}

		#endregion

		#region methods

		public override string ToString()
		{
			return String.Format("{{Date {0}}}", Value.ToString());
		}

		#endregion

		#region properties

		public DateTime Value { get; set; }

		#endregion

		#region events

		#endregion
	}
}
