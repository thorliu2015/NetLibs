using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.ConsoleGUI.Core;

namespace THOR.ConsoleGUI.ParamTypes
{
	public class ConsoleParamEnum : IConsoleParamType
	{
		protected Type type;

		public ConsoleParamEnum(Type enumType)
		{
			type = enumType;

		}

		public object GetObject(string str)
		{
			if (type == null || type.IsEnum == false) return null;

			return Enum.Parse(type, str);
		}

		public string GetString(object obj)
		{
			if (type == null || type.IsEnum == false) return "";
			if (obj == null) return "";

			return obj.ToString();
		}

		public string Match(string input)
		{
			if (type == null || type.IsEnum == false) return "";

			string[] names = Enum.GetNames(type);

			foreach(string name in names)
			{
				if (name.ToLower().IndexOf(input.ToLower()) == 0) return name;
			}

			return "";
		}
	}
}
