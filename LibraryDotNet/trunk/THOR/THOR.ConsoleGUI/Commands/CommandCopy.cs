using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.ConsoleGUI.Core;

namespace THOR.ConsoleGUI.Commands
{
	public class CommandCopy : ConsoleCommandExecutor
	{
		public override void Execute(object[] args)
		{
			if (ConsoleManager.Current.Output == null) return;

			ConsoleManager.Current.Output.Copy((bool)args[0]);
		}
	}
}
