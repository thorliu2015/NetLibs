/*
 * ConsoleManager
 * liuqiang@2016/3/30 17:46:26
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.ConsoleGUI.Core
{
	public class ConsoleManager
	{
		#region constants

		#endregion

		#region variables

		

		#endregion

		#region construct

		static public ConsoleManager Current { get; protected set; }

		static ConsoleManager()
		{
			Current = new ConsoleManager();
		}
		
		private ConsoleManager()
		{
			Commands = new List<ConsoleCommand>();
			CommandNames = new List<string>();
			ParamTypes = new Dictionary<string, IConsoleParamType>();
		}

		#endregion

		#region methods

		public void Setup()
		{
			CommandNames.Clear();

			foreach (ConsoleCommand cmd in Commands)
			{
				CommandNames.Add(cmd.Name);
			}

			CommandNames.Sort();
		}

		#endregion

		#region properties

		public List<ConsoleCommand> Commands { get; protected set; }
		public List<string> CommandNames { get; protected set; }

		public Dictionary<string, IConsoleParamType> ParamTypes { get; protected set; }

		#endregion

		#region events

		#endregion
	}
}
