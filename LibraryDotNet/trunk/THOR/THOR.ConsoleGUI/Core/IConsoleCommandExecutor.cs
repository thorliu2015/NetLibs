using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THOR.ConsoleGUI.Core
{
	public interface IConsoleCommandExecutor
	{
		void Execute(object[] args);
	}
}
