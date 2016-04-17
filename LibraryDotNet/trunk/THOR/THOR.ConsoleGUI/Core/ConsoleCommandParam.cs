/*
 * ConsoleCommandParam
 * liuqiang@2016/3/30 9:33:42
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

namespace THOR.ConsoleGUI.Core
{
	/// <summary>
	/// 指令参数定义
	/// </summary>
	public class ConsoleCommandParam
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		/// <summary>
		/// 构造一个命令行参数定义
		/// </summary>
		/// <param name="syntax"></param>
		public ConsoleCommandParam(string syntax)
		{
			Regex regex = ConsoleCommand.GetCommandParamRegex();
			if (!regex.IsMatch(syntax))
			{
				throw new Exception(String.Format("无效的命令行参数定义 {0}", syntax));
			}

			Match match = regex.Match(syntax);
			ParamType = match.Result("${type}");
			ParamName = match.Result("${name}");
			ParamDescription = match.Result("${description}");

			string prefix = match.Result("${prefix}");
			string defaultValue = match.Result("${default}");

			Optional = (prefix == "[");

			this.DefaultValue = defaultValue;
		}

		/// <summary>
		/// 构造一个命令行参数定义
		/// </summary>
		/// <param name="paramType"></param>
		/// <param name="paramName"></param>
		/// <param name="paramDescription"></param>
		/// <param name="defaultValue"></param>
		/// <param name="optional"></param>
		public ConsoleCommandParam(string paramType, string paramName, string paramDescription, string defaultValue, bool optional)
		{
			ParamType = paramType;
			ParamName = paramName;
			ParamDescription = paramDescription;
			DefaultValue = defaultValue;
			Optional = optional;
		}

		#endregion

		#region methods

		#endregion

		#region properties

		/// <summary>
		/// 参数类型
		/// </summary>
		public string ParamType { get; protected set; }

		/// <summary>
		/// 参数名称
		/// </summary>
		public string ParamName { get; protected set; }

		/// <summary>
		/// 参数描述
		/// </summary>
		public string ParamDescription { get; protected set; }

		/// <summary>
		/// 参数默认值
		/// </summary>
		public string DefaultValue { get; protected set; }

		/// <summary>
		/// 是否是可选参数
		/// </summary>
		public bool Optional { get; protected set; }


		#endregion

		#region events

		#endregion
	}
}
