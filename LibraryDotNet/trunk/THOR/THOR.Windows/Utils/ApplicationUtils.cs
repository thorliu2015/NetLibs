/*
 * ApplicationUtils
 * liuqiang@2015/11/22 14:25:41
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//---- 8< ------------------

namespace THOR.Windows.Utils
{
	public class ApplicationUtils
	{
		#region 路径

		/// <summary>
		/// 获取应用程序数据路径
		/// </summary>
		static public string ApplicationDataPath
		{
			get
			{
				return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			}
		}

		/// <summary>
		/// 获取一个相对于执行文件所在位置的路径
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		static public string CombinePath(string path)
		{
			return Path.Combine(ExecutableFolderPath, path);
		}

		/// <summary>
		/// 获取执行文件所在路径
		/// </summary>
		static public string ExecutableFolderPath
		{
			get
			{
				return Path.GetDirectoryName(Application.ExecutablePath);
			}
		}

		/// <summary>
		/// 浏览路径
		/// </summary>
		/// <param name="path"></param>
		static public void BrowsePath(string path)
		{
			if (System.IO.Directory.Exists(path))
			{
				BrowseDirectory(path);
			}
			else if (System.IO.File.Exists(path))
			{
				BrowseFile(path);
			}
			else
			{
				//无效路径
			}
		}

		/// <summary>
		/// 浏览目录
		/// </summary>
		/// <param name="path"></param>
		static public void BrowseDirectory(string path)
		{
			if (!System.IO.Directory.Exists(path)) return;
		}

		/// <summary>
		/// 浏览文件
		/// </summary>
		/// <param name="path"></param>
		static public void BrowseFile(string path)
		{
			if (!System.IO.File.Exists(path)) return;
		}

		#endregion

		#region 程序集属性

		/// <summary>
		/// 获取产品名称
		/// </summary>
		static public string ProductName
		{
			get
			{
				object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0)
				{
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title != "")
					{
						return titleAttribute.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		/// <summary>
		/// 获取产品版本号
		/// </summary>
		static public string ProductVersion
		{
			get
			{
				return Assembly.GetEntryAssembly().GetName().Version.ToString();
			}
		}

		/// <summary>
		/// 获取产品版权信息
		/// </summary>
		static public string ProductCopyright
		{
			get
			{
				object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		/// <summary>
		/// 获取公司机构
		/// </summary>
		static public string ProductCompany
		{
			get
			{
				object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}

		/// <summary>
		/// 获取产品描述信息
		/// </summary>
		static public string ProductDescription
		{
			get
			{
				object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		#endregion

		#region 反射

		/// <summary>
		/// 获取当前应用程序的所有程序集
		/// </summary>
		/// <returns></returns>
		static public List<Assembly> GetAssemblies()
		{
			List<Assembly> result = new List<Assembly>();

			string applicationPath = Path.GetDirectoryName(Application.ExecutablePath);
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

			foreach (Assembly assembly in assemblies)
			{
				string assemblyPath = Path.GetDirectoryName(assembly.Location);
				if (assemblyPath != applicationPath) continue;

				result.Add(assembly);
			}

			return result;
		}

		/// <summary>
		/// 获取当前应用程序的所有类型
		/// </summary>
		/// <returns></returns>
		static public List<Type> GetTypes()
		{
			List<Type> result = new List<Type>();

			List<Assembly> assemblies = GetAssemblies();

			foreach (Assembly assembly in assemblies)
			{
				Type[] types = assembly.GetTypes();

				foreach (Type type in types)
				{
					if (result.Contains(type)) continue;
					result.Add(type);
				}
			}

			return result;
		}
		#endregion
	}
}
