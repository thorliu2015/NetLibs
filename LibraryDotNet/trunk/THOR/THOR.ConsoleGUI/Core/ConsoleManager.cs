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

			ParamTypes["File"] = ConsoleParamPath.GetFiles("*.*", @"Y:\NetProjects\git\NetLibs\Tools\Solar\Ref Projects\THOR.JSON\");
			ParamTypes["Directory"] = ConsoleParamPath.GetDirectories("*.*", "");
		}

		protected void InitCommands()
		{
			CommandNames.Clear();
			Commands.Clear();

			Commands.Add(new ConsoleCommand(null, "cls(清屏)"));
			Commands.Add(new ConsoleCommand(null, "copy(复制输出信息至剪贴板)"));
			Commands.Add(new ConsoleCommand(null, "test(测试) <(File)test(文件)>"));

			//ConsoleManager.Current.Commands.Add(new ConsoleCommand(null, "copy(复制)  <(type)name(desc)=defaultValue> [(type)name(desc)=defaultValue]"));
			//ConsoleManager.Current.Commands.Add(new ConsoleCommand(null, "cls(清屏)  <(type)name(desc)=defaultValue> [(type)name(desc)=defaultValue]"));

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
