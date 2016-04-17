/*
 * SerialicationUtils
 * liuqiang@2015/11/1 17:41:24
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Serialization
{
	/// <summary>
	/// 序列化工具类
	/// </summary>
	public class SerialicationUtils
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		static public object ParseObject(string data, Type type, object defaultObj = null)
		{
			try
			{
				switch (type.ToString())
				{
					case "System.Byte":
						return Convert.ToByte(data);

					case "System.SByte":
						return Convert.ToSByte(data);

					case "System.Int16":
						return Convert.ToInt16(data);

					case "System.Int32":
						return Convert.ToInt32(data);

					case "System.Int64":
						return Convert.ToInt64(data);

					case "System.UInt16":
						return Convert.ToUInt16(data);

					case "System.UInt32":
						return Convert.ToUInt32(data);

					case "System.UInt64":
						return Convert.ToUInt64(data);

					case "System.Decimal":
						return Convert.ToDecimal(data);

					case "System.Single":
						return Convert.ToSingle(data);

					case "System.Double":
						return Convert.ToDouble(data);

					case "System.Boolean":
						return Convert.ToBoolean(data);

					case "System.String":
						return Convert.ToString(data);

					case "System.DateTime":
						return Convert.ToDateTime(data);

					//----

					default:
						return null;
				}
			}
			catch (Exception ex)
			{
			}

			return defaultObj;
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
