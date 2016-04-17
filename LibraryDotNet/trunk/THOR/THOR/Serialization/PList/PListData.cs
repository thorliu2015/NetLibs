/*
 * PListData
 * liuqiang@2016/1/21 23:47:41
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
	public class PListData : PListObject
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public PListData()
			: base()
		{
			DataType = PListObjectType.Data;
		}

		#endregion

		#region methods

		public override string ToString()
		{
			return String.Format("{{Data}}", 0);
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
