/*
 * ConsoleParamBoolean
 * liuqiang@2016/4/9 13:58:04
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.ConsoleGUI.Core;


//---- 8< ------------------

namespace THOR.ConsoleGUI.ParamTypes
{
	public class ConsoleParamBoolean : IConsoleParamType
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		public object GetObject(string str)
		{
			if (str == null) return false;

			return (str.Trim().ToLower() == "true");
		}

		public string GetString(object obj)
		{
			if (obj is bool)
			{
				if ((bool)obj)
				{
					return "true";
				}
			}

			return "false";
		}

		public string Match(string input)
		{
			if ("true".IndexOf(input) == 0)
			{
				return "true";
			}

			if ("false".IndexOf(input) == 0)
			{
				return "false";
			}

			return "";
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion

	}
}
