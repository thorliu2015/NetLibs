/*
 * ConsoleParamNumbers
 * liuqiang@2016/4/9 13:56:02
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
	public class ConsoleParamInt8 : IConsoleParamType
	{
		public object GetObject(string str)
		{
			return Convert.ToSByte(str);
		}

		public string GetString(object obj)
		{
			if (obj == null) return "0";
			return obj.ToString();
		}

		public string Match(string input)
		{
			return "";
		}
	}

	public class ConsoleParamInt16 : IConsoleParamType
	{
		public object GetObject(string str)
		{
			return Convert.ToInt16(str);
		}

		public string GetString(object obj)
		{
			if (obj == null) return "0";
			return obj.ToString();
		}

		public string Match(string input)
		{
			return "";
		}
	}

	public class ConsoleParamInt32 : IConsoleParamType
	{
		public object GetObject(string str)
		{
			return Convert.ToInt32(str);
		}

		public string GetString(object obj)
		{
			if (obj == null) return "0";
			return obj.ToString();
		}

		public string Match(string input)
		{
			return "";
		}
	}

	public class ConsoleParamInt64 : IConsoleParamType
	{
		public object GetObject(string str)
		{
			return Convert.ToInt64(str);
		}

		public string GetString(object obj)
		{
			if (obj == null) return "0";
			return obj.ToString();
		}

		public string Match(string input)
		{
			return "";
		}
	}

	public class ConsoleParamUInt8 : IConsoleParamType
	{
		public object GetObject(string str)
		{
			return Convert.ToByte(str);
		}

		public string GetString(object obj)
		{
			if (obj == null) return "0";
			return obj.ToString();
		}

		public string Match(string input)
		{
			return "";
		}
	}

	public class ConsoleParamUInt16 : IConsoleParamType
	{
		public object GetObject(string str)
		{
			return Convert.ToUInt16(str);
		}

		public string GetString(object obj)
		{
			if (obj == null) return "0";
			return obj.ToString();
		}

		public string Match(string input)
		{
			return "";
		}
	}

	public class ConsoleParamUInt32 : IConsoleParamType
	{
		public object GetObject(string str)
		{
			return Convert.ToUInt32(str);
		}

		public string GetString(object obj)
		{
			if (obj == null) return "0";
			return obj.ToString();
		}

		public string Match(string input)
		{
			return "";
		}
	}

	public class ConsoleParamUInt64 : IConsoleParamType
	{
		public object GetObject(string str)
		{
			return Convert.ToUInt64(str);
		}

		public string GetString(object obj)
		{
			if (obj == null) return "0";
			return obj.ToString();
		}

		public string Match(string input)
		{
			return "";
		}
	}

	public class ConsoleParamDecimal : IConsoleParamType
	{
		public object GetObject(string str)
		{
			return Convert.ToDecimal(str);
		}

		public string GetString(object obj)
		{
			if (obj == null) return "0";
			return obj.ToString();
		}

		public string Match(string input)
		{
			return "";
		}
	}

	public class ConsoleParamSingle : IConsoleParamType
	{
		public object GetObject(string str)
		{
			return Convert.ToSingle(str);
		}

		public string GetString(object obj)
		{
			if (obj == null) return "0";
			return obj.ToString();
		}

		public string Match(string input)
		{
			return "";
		}
	}

	public class ConsoleParamDouble : IConsoleParamType
	{
		public object GetObject(string str)
		{
			return Convert.ToDouble(str);
		}

		public string GetString(object obj)
		{
			if (obj == null) return "0";
			return obj.ToString();
		}

		public string Match(string input)
		{
			return "";
		}
	}


}
