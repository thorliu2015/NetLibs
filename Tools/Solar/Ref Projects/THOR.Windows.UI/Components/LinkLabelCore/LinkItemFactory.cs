using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace THOR.Windows.UI.Components.LinkLabelCore
{
	/// <summary>
	/// 表示链接项目工厂
	/// </summary>
	public class LinkItemFactory
	{


		/// <summary>
		/// 设置一个链接项目
		/// </summary>
		/// <param name="template"></param>
		/// <param name="item"></param>
		static public void SetLinkItem(string template, LinkItem item)
		{
			Regex regex = new Regex("(?<PlaceHolder>\\{(?<PlaceHolderKey>\\w+)\\})", RegexOptions.Compiled | RegexOptions.Multiline);
			MatchCollection matchs = regex.Matches(template);

			if (item.Spans == null) item.Spans = new List<LinkItemSpan>();
			item.Template = template;
			foreach (Match match in matchs)
			{
				string placeHolder = match.Result("${PlaceHolder}");
				string placeHolderKey = match.Result("${PlaceHolderKey}");

				LinkItemSpan span = new LinkItemSpan();
				span.PlaceHolder = placeHolder;
				span.Type = placeHolderKey;
				span.Index = match.Index;

				item.Spans.Add(span);
			}
		}

		/// <summary>
		/// 创建一个链接项目
		/// </summary>
		/// <param name="template"></param>
		/// <returns></returns>
		static public LinkItem CreateLinkItem(string template)
		{
			LinkItem result = new LinkItem();

			SetLinkItem(template, result);

			return result;
		}
	}
}
