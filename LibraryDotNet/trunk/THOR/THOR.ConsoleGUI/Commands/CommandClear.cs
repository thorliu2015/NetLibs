using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.ConsoleGUI.Core;

namespace THOR.ConsoleGUI.Commands
{
	public class CommandClear : ConsoleCommandExecutor
	{
		public override void Execute(object[] args)
		{
			if(ConsoleManager.Current.Output!=null)
			{
				ConsoleManager.Current.Output.Clear();
			}
		}
	}
}
