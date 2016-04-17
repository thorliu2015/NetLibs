/*
 * PListObjectType
 * liuqiang@2016/1/21 23:07:46
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
	public enum PListObjectType
	{
		Array,
		Dictionary,

		Boolean,
		Data,
		Date,
		Number,
		String
	}
}
