using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using THOR.Windows.UI.Renders;
using THOR.Windows.UI.Components.LinkLabelCore.Formatters;

namespace THOR.Windows.UI.Components.LinkLabelCore
{
	/// <summary>
	/// 链接文本渲染方法
	/// </summary>
	public class LinkLabelRender : ILinkLabelRender
	{
		/// <summary>
		/// 构造
		/// </summary>
		public LinkLabelRender()
		{
			FormatterList = new Dictionary<String, ILinkItemSpanFormatter>();

			//基础类型

			FormatterList["Boolean"] = new BooleanSpanFormatter();
			FormatterList["String"] = new StringSpanFormatter();

			FormatterList["Int8"] = new IntSpanFormatter();
			FormatterList["UInt8"] = new UIntSpanFormatter();

			FormatterList["Int16"] = new IntSpanFormatter();
			FormatterList["UInt16"] = new UIntSpanFormatter();

			FormatterList["Int32"] = new IntSpanFormatter();
			FormatterList["UInt32"] = new UIntSpanFormatter();

			FormatterList["Int64"] = new IntSpanFormatter();
			FormatterList["UInt64"] = new UIntSpanFormatter();

			FormatterList["Single"] = new FloatSpanFormatter();
			FormatterList["Double"] = new FloatSpanFormatter();
		}

		/// <summary>
		/// 更新链接控件外观
		/// </summary>
		/// <param name="label">新链接控件</param>
		public void Update(TLinkLabel label)
		{
			UpdateLabelText(label);
		}

		/// <summary>
		/// 更新文本
		/// </summary>
		/// <param name="label"></param>
		protected virtual void UpdateLabelText(TLinkLabel label)
		{
			if (label.LinkItem == null) return;


			string text = label.LinkItem.Template;

			

			for (int i = label.LinkItem.Spans.Count - 1; i >= 0; i--)
			{
				LinkItemSpan span = label.LinkItem.Spans[i];
				if (FormatterList.ContainsKey(span.Type) == false) continue;

				ILinkItemSpanFormatter formatter = FormatterList[span.Type];
				formatter.Format(span);

				text = text.Substring(0, span.Index)
						+ span.Text
						+ text.Substring(span.Index + span.PlaceHolder.Length);

			}

			if (label.linkLabel.Text == text) return;

			label.linkLabel.Text = text;
			label.linkLabel.Links.Clear();

			int offset = 0;
			for (int i = 0; i < label.LinkItem.Spans.Count; i++)
			{
				LinkItemSpan span = label.LinkItem.Spans[i];
				int intStart = span.Index;
				int intLength = span.Text.Length;

				label.linkLabel.Links.Add(intStart + offset, intLength, span);
				offset += (span.Text.Length - span.PlaceHolder.Length);
			}
		}

		/// <summary>
		/// 链接片断格式化
		/// </summary>
		public Dictionary<String, ILinkItemSpanFormatter> FormatterList { get; set; }
	}
}
