using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;

namespace AutoVersion
{
	class Program
	{
		static public Regex regex = new Regex("^\\s*\\[assembly:\\s*(?<field>(AssemblyVersion|AssemblyFileVersion))\\(\\\"(?<version>[^\\\"]+)\\\"\\)\\]\\s*$", RegexOptions.Multiline | RegexOptions.Compiled);
		static void Main(string[] args)
		{
			//UpdateVersion(@"\\psf\Home\Documents\Visual Studio 2012\Projects\AutoVersion\AutoVersion");

			//return;
			foreach (string path in args)
			{
				UpdateVersion(path);
			}
		}

		/// <summary>
		/// 工程目录
		/// </summary>
		/// <param name="path"></param>
		static void UpdateVersion(string path)
		{
			string folderPath = Path.Combine(path, "Properties");
			string filePath = Path.Combine(folderPath, "AssemblyInfo.cs");

			try
			{
				//load
				StreamReader reader = new StreamReader(filePath);
				string content = reader.ReadToEnd();
				reader.Close();

				//update
				MatchCollection mc = regex.Matches(content);

				for (int i = mc.Count - 1; i >= 0; i--)
				{
					Match m = mc[i];

					string ver = m.Result("${version}");
					if (ver.IndexOf(".") < 0) continue;
					string[] verAry = ver.Split(new char[1] { '.' });

					int v = Convert.ToInt32(verAry[verAry.Length - 1]);
					v++;
					verAry[verAry.Length - 1] = v.ToString();

					string n = String.Format("[assembly: {0}(\"{1}\")]", m.Result("${field}"), string.Join(".", verAry));

					content = content.Substring(0, m.Index) + n + content.Substring(m.Index + m.Length);
				}

				//save
				//Debug.WriteLine(content);
				StreamWriter writer = new StreamWriter(filePath);
				writer.Write(content);
				writer.Close();
			}
			catch (Exception err)
			{
			}
		}
	}
}
