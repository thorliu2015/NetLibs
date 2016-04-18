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
using THOR.ConsoleGUI.Commands;
using THOR.ConsoleGUI.Components;
using THOR.ConsoleGUI.ParamTypes;


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

			InitCommands();
			InitParamTypes();
		}

		#endregion

		#region methods

		protected void InitParamTypes()
		{
			ParamTypes.Clear();

			//基础数据类型
			ParamTypes["Boolean"] = new ConsoleParamBoolean();
			ParamTypes["Int8"] = new ConsoleParamInt8();
			ParamTypes["Int16"] = new ConsoleParamInt16();
			ParamTypes["Int32"] = new ConsoleParamInt32();
			ParamTypes["Int64"] = new ConsoleParamInt64();
			ParamTypes["UInt8"] = new ConsoleParamUInt8();
			ParamTypes["UInt16"] = new ConsoleParamUInt16();
			ParamTypes["UInt32"] = new ConsoleParamUInt32();
			ParamTypes["UInt64"] = new ConsoleParamUInt64();
			ParamTypes["Decimal"] = new ConsoleParamDecimal();
			ParamTypes["Single"] = new ConsoleParamSingle();
			ParamTypes["Double"] = new ConsoleParamDouble();

			ParamTypes["File"] = ConsoleParamPath.GetFiles("*.*", "");
			ParamTypes["Directory"] = ConsoleParamPath.GetDirectories("*.*", "");

			ParamTypes["test"] = new ConsoleParamEnum(typeof(System.Windows.Forms.FormStartPosition));
		}

		protected void InitCommands()
		{
			CommandNames.Clear();
			Commands.Clear();

			Commands.Add(new ConsoleCommand(new CommandClear(), "cls(清屏)"));
			Commands.Add(new ConsoleCommand(new CommandCopy(), "copy(复制输出信息至剪贴板) [(Boolean)rtf(富文本)=true]"));

			//TODO: help
		}

		public void Setup()
		{
			CommandNames.Clear();

			foreach (ConsoleCommand cmd in Commands)
			{
				CommandNames.Add(cmd.Name);
			}

			CommandNames.Sort();
		}


		public void Execute(string szCmd)
		{

			if (Output != null)
				Output.WriteLine(
					ConsoleCommandOutputColors.Current.Command,
					String.Format("> {0}", szCmd));

			ConsoleCommandLine cmd = new ConsoleCommandLine(szCmd);

			if (cmd.Matches==null || cmd.Matches.Count == 0) return;

			string cmdName = cmd.Matches[0].ToString();

			if (!CommandNames.Contains(cmdName))
			{
				if (Output != null)
					Output.WriteLine(
						ConsoleCommandOutputColors.Current.Error,
						String.Format("<{0}> not found.", cmdName));
				return;
			}

			foreach (ConsoleCommand command in Commands)
			{
				if (command.Name == cmdName)
				{
					if (command.Params.Count != cmd.Matches.Count - 1)
					{
						if (Output != null)
							Output.WriteLine(
								ConsoleCommandOutputColors.Current.Error,
								String.Format("<{0}> params error.", command.Name));
					}
					else
					{
						if (command.Executor != null)
						{
							object[] args = GetCommandArgs(command, cmd);

							command.Executor.Execute(args);
						}
						else
						{
							if (Output != null)
								Output.WriteLine(
									ConsoleCommandOutputColors.Current.Error, 
									String.Format("<{0}> No executor.",command.Name));
						}
					}
					return;
				}
			}
		}

		private object[] GetCommandArgs(ConsoleCommand command, ConsoleCommandLine cmd)
		{

			object[] result = new object[command.Params.Count];

			for (int i = 0; i < command.Params.Count; i++)
			{
				object argValue = null;

				if (ParamTypes.ContainsKey(command.Params[i].ParamType))
				{
					string szArg = cmd.Matches[i + 1].Value;
					argValue = ParamTypes[command.Params[i].ParamType].GetObject(szArg);
				}

				result[i] = argValue;
			}

			return result;
		}
		#endregion

		#region properties

		public List<ConsoleCommand> Commands { get; protected set; }
		public List<string> CommandNames { get; protected set; }

		public Dictionary<string, IConsoleParamType> ParamTypes { get; protected set; }

		public ConsoleOutput Output { get; set; }

		#endregion

		#region events




	
		

		#endregion
	}
}
