/*
 * ConsoleCommand
 * liuqiang@2016/3/30 9:33:23
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//---- 8< ------------------

//	ConsoleCommand cmd = new ConsoleCommand(null, "cls(清屏) <(type)name(desc)=defaultValue> [(type)name(desc)=defaultValue]");

namespace THOR.ConsoleGUI.Core
{
	/// <summary>
	/// 控制台指令定义
	/// </summary>
	public class ConsoleCommand
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct


		public ConsoleCommand(IConsoleCommandExecutor executor, string syntax)
		{

			Regex regex = GetCommandRegex();

			if (!regex.IsMatch(syntax))
			{
				throw new Exception(String.Format("无效的命令行定义 {0}", syntax));
			}

			Match match = regex.Match(syntax);
			string pms = match.Result("${CommandParams}").Trim();

			string[] pmsAry = Regex.Split(pms, @"\s+");
			Params = new List<ConsoleCommandParam>();
			foreach (string pm in pmsAry)
			{
				string p = pm.Trim();
				if (p.Length == 0) continue;

				ConsoleCommandParam ccp = new ConsoleCommandParam(p);
				Params.Add(ccp);
			}

			Executor = executor;

			Name = match.Result("${CommandName}");
			Description = match.Result("${CommandDescription}");
			

			
		}


		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="executor">指令执行接口</param>
		/// <param name="name">指令名称</param>
		/// <param name="description">指令描述</param>
		/// <param name="pms">指令参数</param>
		public ConsoleCommand(IConsoleCommandExecutor executor, string name, string description, params ConsoleCommandParam[] pms)
		{
			Params = new List<ConsoleCommandParam>();
			Executor = executor;
			Name = name;
			Description = description;
			foreach (ConsoleCommandParam p in pms)
			{
				Params.Add(p);
			}
		}

		#endregion

		#region methods

		static public Regex GetCommandRegex()
		{
			return new Regex("^(?<CommandName>[^\\(\\)\\x20\\r\\n]+)(\\((?<CommandDescription>[^\\(\\)]*)\\))?(?<CommandParams>[^\\r\\n]+)?$", RegexOptions.Compiled | RegexOptions.Singleline);
		}

		static public Regex GetCommandParamRegex()
		{
			return new Regex("(?<prefix>(\\<|\\[))\\((?<type>[^\\(\\)]+)\\)(?<name>[^\\(\\)=]+)(\\((?<description>[^\\(\\)]*)\\))?(=(?<default>[^\\>\\]]+))?(?<suffix>(\\>|\\]))", RegexOptions.Compiled | RegexOptions.Singleline);
		}

		#endregion

		#region properties

		/// <summary>
		/// 指令名称
		/// </summary>
		public string Name { get; protected set; }

		/// <summary>
		/// 指令描述
		/// </summary>
		public string Description { get; protected set; }

		/// <summary>
		/// 指令参数
		/// </summary>
		public List<ConsoleCommandParam> Params { get; protected set; }

		/// <summary>
		/// 指令执行接口
		/// </summary>
		public IConsoleCommandExecutor Executor { get; protected set; }

		#endregion

		#region events

		#endregion
	}
}
