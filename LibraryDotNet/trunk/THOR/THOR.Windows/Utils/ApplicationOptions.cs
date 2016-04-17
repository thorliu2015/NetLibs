/*
 * ApplicationOptions
 * liuqiang@2015/12/9 21:31:32
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

namespace THOR.Windows.Utils
{
	public class ApplicationOptions
	{
		#region constants

		#endregion

		#region variables
		/// <summary>
		/// 选项键和值
		/// </summary>
		static private Dictionary<string, string> Options = new Dictionary<string, string>();
		#endregion

		#region construct
		/// <summary>
		/// 静态构造
		/// </summary>
		static ApplicationOptions()
		{
			FolderName = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
			Load();
		}
		#endregion

		#region methods
		/// <summary>
		/// 读取文件
		/// </summary>
		static public void Load()
		{
			//如果没有文件,则从当前目录复制默认文件至目标目录?

			Options.Clear();

			string filePath = FilePath;

			if (File.Exists(filePath))
			{
				XmlDocument xml = new XmlDocument();
				try
				{
					xml.Load(filePath);

					XmlNodeList nodes = xml.SelectNodes(@"options/option");
					foreach (XmlNode node in nodes)
					{
						string k = node.Attributes["key"].Value;
						string v = node.InnerText;

						Options[k] = v;
					}
				}
				catch
				{
				}
			}
		}

		/// <summary>
		/// 保存文件
		/// </summary>
		static public void Save()
		{
			try
			{
				XmlDocument xml = new XmlDocument();
				xml.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><options/>");

				foreach (string key in Options.Keys)
				{
					XmlNode node = xml.CreateElement("option");
					node.Attributes.Append(xml.CreateAttribute("key")).Value = key;
					node.AppendChild(xml.CreateTextNode(Options[key]));
					xml.DocumentElement.AppendChild(node);
				}


				string dir = Path.Combine(ApplicationUtils.ApplicationDataPath, FolderName);
				if (!Directory.Exists(dir))
				{
					Directory.CreateDirectory(dir);
				}

				xml.Save(FilePath);
			}
			catch
			{
			}
		}

		/// <summary>
		/// 获取文本
		/// </summary>
		/// <param name="key"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		static public string GetValue(string key, string defaultValue = "")
		{
			if (Options.ContainsKey(key))
			{
				return Options[key];
			}
			return defaultValue;
		}

		/// <summary>
		/// 设置文本
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		static public void SetValue(string key, string value)
		{
			Options[key] = value;
		}

		/// <summary>
		/// 获取逻辑值
		/// </summary>
		/// <param name="key"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		static public bool GetBool(string key, bool defaultValue = false)
		{
			if (Options.ContainsKey(key))
			{
				string s = Options[key];

				return s.Trim().ToLower() == "true";
			}

			return defaultValue;
		}

		/// <summary>
		/// 设置逻辑值
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		static public void SetBool(string key, bool value)
		{
			Options[key] = value.ToString().ToLower();
		}


		/// <summary>
		/// 获取整数
		/// </summary>
		/// <param name="key"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		static public Int32 GetInt32(string key, Int32 defaultValue = 0)
		{
			string s = GetValue(key, defaultValue.ToString());

			Int32 r = defaultValue;

			Int32.TryParse(s, out r);

			return r;
		}

		/// <summary>
		/// 设置整数
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		static public void SetInt32(string key, Int32 value)
		{
			Options[key] = value.ToString();
		}

		/// <summary>
		/// 获取浮点数
		/// </summary>
		/// <param name="key"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		static public float GetFloat(string key, float defaultValue = 0f)
		{
			string s = GetValue(key, defaultValue.ToString());

			float r = defaultValue;

			float.TryParse(s, out r);

			return r;
		}

		/// <summary>
		/// 设置浮点数
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		static public void SetFloat(string key, float value)
		{
			Options[key] = value.ToString();
		}
		#endregion

		#region properties
		/// <summary>
		/// 代表应用程序名称的文件夹名称
		/// </summary>
		static public string FolderName { get; set; }

		/// <summary>
		/// 配置文件名称
		/// </summary>
		static public string Filename
		{
			get
			{
				return "AppOptions.xml";
			}
		}


		/// <summary>
		/// 配置文件完整路径
		/// </summary>
		static public string FilePath
		{
			get
			{
				string appData = ApplicationUtils.ApplicationDataPath;
				string folderName = FolderName;
				string fileName = Filename;

				string ret = Path.Combine(appData, String.Format(@"{0}\{1}", folderName, fileName));

				return ret;
			}
		}
		#endregion

		#region events

		#endregion
	}
}
