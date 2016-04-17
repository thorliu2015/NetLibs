/*
 * ThorLanguages
 * liuqiang@2015/11/22 11:51:42
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


//---- 8< ------------------

namespace THOR.Windows.Languages
{
	public class ThorLanguages
	{
		#region constants

		#endregion

		#region variables

		protected XmlDocument xml;

		#endregion

		#region construct

		static public ThorLanguages Current { get; private set; }

		static ThorLanguages()
		{
			Current = new ThorLanguages();
		}

		private ThorLanguages()
		{
			Load();
		}

		#endregion

		#region methods

		/// <summary>
		/// 加载语言配置
		/// </summary>
		protected void Load()
		{
			string currentLanguageSetting = System.Configuration.ConfigurationSettings.AppSettings["Language"];
			if (currentLanguageSetting == null || currentLanguageSetting.Trim().Length == 0) currentLanguageSetting = "zh-CN";

			string languageFilename = Path.GetDirectoryName(Application.ExecutablePath);
			languageFilename = Path.Combine(languageFilename, "Languages");
			languageFilename = Path.Combine(languageFilename, string.Format("{0}.xml", currentLanguageSetting));

			try
			{
				xml = new XmlDocument();
				xml.Load(languageFilename);
			}
			catch(Exception ex)
			{
				xml = null;
			}
		}

		/// <summary>
		/// 获取文本
		/// </summary>
		/// <param name="key">多语言节点xpath</param>
		/// <param name="value">默认值</param>
		/// <returns></returns>
		public string GetText(string key, string value = "")
		{
			if (xml != null)
			{
				XmlNode node = xml.SelectSingleNode(key.Trim().ToLower());
				if (node != null)
				{
					string ret = node.InnerText.Trim();
					if (ret.Length > 0) return ret;
				}
			}

			return value;
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
