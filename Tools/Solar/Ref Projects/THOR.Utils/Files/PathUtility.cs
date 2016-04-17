using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace THOR.Utils.Files
{
	/// <summary>
	/// 路径工具类
	/// </summary>
	public class PathUtility
	{
		/// <summary>
		/// 检查目录是否存在, 如果不存在就创建一个
		/// </summary>
		/// <param name="path"></param>
		static public void CheckDirectory(string path)
		{
			if (!Directory.Exists(path))
			{
				try
				{
					Directory.CreateDirectory(path);
				}
				catch
				{
				}
			}
		}


		/// <summary>
		/// 检查文件目录是否存在, 如果不存在就创建一个
		/// </summary>
		/// <param name="path"></param>
		static public void CheckFile(string path)
		{
			string p = Path.GetDirectoryName(path);
			CheckDirectory(p);
		}


		/// <summary>
		/// 获取程序相对路径
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		static public string GetPathByApplicationPath(string name)
		{
			return Path.Combine(ApplicationPath, name);
		}


		/// <summary>
		/// 获取程序相对路径
		/// </summary>
		/// <param name="directory"></param>
		/// <param name="file"></param>
		/// <returns></returns>
		static public string GetPathByApplicationPath(string directory, string file)
		{
			string ret = Path.Combine(ApplicationPath, directory);
			ret = Path.Combine(ret, file);

			return ret;
		}


		/// <summary>
		/// 获取程序路径
		/// </summary>
		static public string ApplicationPath
		{
			get
			{
				return Path.GetDirectoryName(Application.ExecutablePath);
			}
		}
	}
}
