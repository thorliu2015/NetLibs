/*
 * ConsoleCommandLine
 * liuqiang@2016/4/4 20:33:06
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


//---- 8< ------------------

namespace THOR.ConsoleGUI.Core
{
	public class ConsoleCommandLine
	{
		#region constants

		#endregion

		#region variables

		static public Regex RegexCommandLine = new Regex("\\S+", RegexOptions.Compiled | RegexOptions.Singleline);

		protected string _args = "";

		protected MatchCollection _matches;

		#endregion

		#region construct

		public ConsoleCommandLine(string text)
		{
			parse(text);
		}

		#endregion

		#region methods

		/// <summary>
		/// 解析命令行内容
		/// </summary>
		/// <param name="text"></param>
		public virtual void parse(string text)
		{
			if (!RegexCommandLine.IsMatch(text))
			{
				_matches = null;
			}
			else
			{
				_matches = RegexCommandLine.Matches(text);
			}
		}

		/// <summary>
		/// 获取当前组
		/// </summary>
		/// <param name="selectionIndex"></param>
		/// <returns></returns>
		public virtual int GetCurrentGroupIndex(int selectionIndex)
		{
			int result = -1;

			if (_matches == null || _matches.Count == 0) return result;

			for (int i = 0; i < _matches.Count; i++)
			{
				Match match = _matches[i];
				if (selectionIndex >= match.Index)
				{
					result = i;

					if (selectionIndex > match.Index + match.Length)
					{
						result++;
					}
				}
			}

			return result;
		}

		/// <summary>
		/// 获取指定索引的组内容
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public virtual string GetGroupText( int index)
		{
			string result = "";

			if (_matches != null && _matches.Count > 0)
			{
				if (index >= 0 && index < _matches.Count)
				{
					return _matches[index].Value;
				}
			}

			return result;
		}

		#endregion

		#region properties

		public MatchCollection Matches { get { return _matches; } }


		#endregion

		#region events

		#endregion
	}
}
