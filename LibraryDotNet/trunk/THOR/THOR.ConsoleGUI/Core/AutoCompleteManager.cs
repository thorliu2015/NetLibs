/*
 * AutoCompleteManager
 * liuqiang@2016/3/30 17:43:13
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


//---- 8< ------------------

namespace THOR.ConsoleGUI.Core
{
	public class AutoCompleteManager
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		/// <summary>
		/// 更新输入框
		/// </summary>
		/// <param name="inputBox"></param>
		/// <returns></returns>
		static public bool Update(TextBox inputBox)
		{
			int selectedIndex = inputBox.SelectionStart;
			int selectedLength = inputBox.SelectionLength;
			string text = inputBox.Text;

			if (text.Trim().Length == 0) return false;

			ConsoleCommandLine cmd = new ConsoleCommandLine(text);

			int currentGroupIndex = cmd.GetCurrentGroupIndex(selectedIndex);
			string currentGroupText = cmd.GetGroupText(currentGroupIndex);

			//匹配指令
			if (currentGroupIndex == 0)
			{
				string matchCommandName = MatchCommandName(currentGroupText);
				if (matchCommandName.Length > 0)
				{
					inputBox.Text = matchCommandName;
					inputBox.Select(currentGroupText.Length, matchCommandName.Length - currentGroupText.Length);
				}

				return true;
			}
			//匹配参数
			else
			{
				string commandName = cmd.Matches[0].Value;
				int currentArgIndex = currentGroupIndex - 1;
				string matchCommandArg = MatchCommandArg(commandName, currentGroupIndex, currentGroupText);

				//Debug.WriteLine(String.Format("匹配参数: [{0},{1},{4}] {2} @ {3}", selectedIndex, selectedLength, commandName, currentGroupText, currentArgIndex));
				if (matchCommandArg.Length > 0)
				{
					StringBuilder sbReplace = new StringBuilder();
					sbReplace.Append(commandName);

					int nSelectionIndex = -1;
					int nSelectionLength = -1;

					if (cmd.Matches.Count - 1 <= currentArgIndex)
					{
						sbReplace.Append(" ");
						nSelectionIndex = sbReplace.Length - currentGroupText.Length;

						sbReplace.Append(matchCommandArg);
						nSelectionLength = matchCommandArg.Length - currentGroupText.Length;
					}
					else
					{
						for (int i = 1; i < cmd.Matches.Count; i++)
						{
							sbReplace.Append(" ");
							if (i == currentArgIndex + 1)
							{
								nSelectionIndex = sbReplace.Length + currentGroupText.Length;
								sbReplace.Append(matchCommandArg);
								nSelectionLength = matchCommandArg.Length - currentGroupText.Length;
							}
							else
							{
								sbReplace.Append(cmd.Matches[i].Value);
							}
						}
					}

					inputBox.Text = sbReplace.ToString();
					inputBox.Select(nSelectionIndex, nSelectionLength);

					//Debug.WriteLine(String.Format("{0}", matchCommandArg, inputBox.Text));

					return true;
				}


			}

			return false;
		}

		/// <summary>
		/// 匹配指令名称
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		static private string MatchCommandName(string text)
		{
			string result = "";

			foreach (string cmdName in ConsoleManager.Current.CommandNames)
			{
				if (cmdName.IndexOf(text) == 0) return cmdName;
			}

			return result;
		}

		static private string MatchCommandArg(string name, int index, string input)
		{
			string result = "";

			//查找匹配的指令
			if (ConsoleManager.Current.CommandNames.Contains(name))
			{
				foreach (ConsoleCommand cmd in ConsoleManager.Current.Commands)
				{
					if (cmd.Name != name) continue;

					//查找匹配的参数
					if (index >= 0 && index < cmd.Params.Count)
					{
						ConsoleCommandParam p = cmd.Params[index];

						//匹配默认参数
						if (p.DefaultValue != null && p.DefaultValue.Trim().Length > 0)
						{
							if (p.DefaultValue.IndexOf(input) == 0)
							{
								return p.DefaultValue.Trim();
							}
						}

						//匹配数据类型
						if (!ConsoleManager.Current.ParamTypes.ContainsKey(p.ParamType)) continue;

						IConsoleParamType paramType = ConsoleManager.Current.ParamTypes[p.ParamType];

						string r = paramType.Match(input);
						if (r.Length != 0) return r;

						return p.ParamName;
					}
				}
			}

			return result;
		}


		/// <summary>
		/// 选择上一组
		/// </summary>
		/// <param name="inputBox"></param>
		static public void SelectPrevGroup(TextBox inputBox)
		{
			ConsoleCommandLine cmd = new ConsoleCommandLine(inputBox.Text);
			int selectedIndex = inputBox.SelectionStart;
			int currentGroupIndex = cmd.GetCurrentGroupIndex(selectedIndex);

			if (cmd.Matches == null) return;

			int i = currentGroupIndex - 1;
			if (i < 0 || i >= cmd.Matches.Count) return;

			Match match = cmd.Matches[i];

			inputBox.Select(match.Index, match.Length);
		}

		/// <summary>
		/// 选择下一组
		/// </summary>
		/// <param name="inputBox"></param>
		static public void SelectNextGroup(TextBox inputBox)
		{
			ConsoleCommandLine cmd = new ConsoleCommandLine(inputBox.Text);
			int selectedIndex = inputBox.SelectionStart;
			int currentGroupIndex = cmd.GetCurrentGroupIndex(selectedIndex);

			if (cmd.Matches == null) return;

			int i = currentGroupIndex + 1;
			if (i < 0 || i >= cmd.Matches.Count) return;

			Match match = cmd.Matches[i];

			inputBox.Select(match.Index, match.Length);
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
