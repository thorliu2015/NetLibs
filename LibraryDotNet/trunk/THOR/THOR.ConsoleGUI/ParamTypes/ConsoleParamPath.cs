using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.ConsoleGUI.Core;

namespace THOR.ConsoleGUI.ParamTypes
{
	public class ConsoleParamPath : IConsoleParamType
	{
		public ConsoleParamPath()
		{
			FileMode = true;
			BasePath = "";
			Pattern = "*.*";
		}

		static public ConsoleParamPath GetFiles(string pattern, string basePath = "")
		{
			ConsoleParamPath ret = new ConsoleParamPath();
			ret.FileMode = true;
			ret.BasePath = basePath;
			ret.Pattern = pattern;

			return ret;
		}

		static public ConsoleParamPath GetDirectories(string pattern, string basePath = "")
		{
			ConsoleParamPath ret = new ConsoleParamPath();
			ret.FileMode = false;
			ret.BasePath = basePath;
			ret.Pattern = pattern;
			return ret;
		}

		public string Pattern { get; set; }
		public string BasePath { get; set; }
		public bool FileMode { get; set; }



		public object GetObject(string str)
		{
			return str;
		}

		public string GetString(object obj)
		{
			if (obj == null) return "";
			return obj.ToString();
		}

		public string Match(string input)
		{

			if (BasePath.Length == 0)
			{
				//绝对路径
				if (input.Length <= 3)
				{
					//匹配盘符
					DriveInfo[] ds = DriveInfo.GetDrives();
					foreach (DriveInfo d in ds)
					{
						if (d.Name.ToLower().IndexOf(input.ToLower()) == 0)
						{
							return d.Name;
						}
					}

					return "";
				}
				else
				{
					int sIndex = input.LastIndexOf(@"\");
					if (sIndex < 0) return "";


					string sPath = input.Substring(0, sIndex + 1);
					string sName = input.Substring(sIndex + 1);


					if (!Directory.Exists(sPath)) return "";

					if (FileMode)
					{
						string[] files = Directory.GetFiles(sPath, Pattern);

						foreach (string file in files)
						{
							if (file.ToLower().IndexOf(input.ToLower()) == 0)
							{
								return file;
							}
						}
					}

					string[] folders = Directory.GetDirectories(sPath, "*.*");
					foreach (string folder in folders)
					{	
						if (folder.ToLower().IndexOf(input.ToLower()) == 0)
						{
							return folder + "\\";
						}
					}

					return "";
				}
			}
			else
			{
				//相对路径
				if (!Directory.Exists(BasePath)) return "";

				string sPath = "";
				string sName = "";

				if (input.Length > 0)
				{
					int sIndex = input.LastIndexOf(@"\");
					if (sIndex < 0)
					{
						sPath = "";
						sName = input;

						if(Directory.Exists(Path.Combine(BasePath, input)))
						{
							sPath = input;
							sName = "";
						}
					}
					else
					{
						sPath = input.Substring(0, sIndex + 1);
						sName = input.Substring(sIndex + 1);
					}

					sPath = Path.Combine(BasePath, sPath);

					if (!Directory.Exists(sPath)) return "";

					if (FileMode)
					{
						string[] files = Directory.GetFiles(sPath, Pattern);
						foreach (string file in files)
						{
							string rFile = file.Substring(BasePath.Length);
							if (rFile.ToLower().IndexOf(sName.ToLower()) == 0)
							{
								return rFile;
							}
						}
					}

					string[] folders = Directory.GetDirectories(sPath, "*.*");
					foreach (string folder in folders)
					{
						string rFolder = folder.Substring(BasePath.Length) + "\\";
						if (rFolder.ToLower().IndexOf(sName.ToLower()) == 0)
						{
							return rFolder;
						}
					}

					return "";
				}
				else
				{
					if (FileMode)
					{
						string[] files = Directory.GetFiles(BasePath, Pattern);
						foreach (string file in files)
						{
							string rFile = file.Substring(BasePath.Length);
							if (rFile.ToLower().IndexOf(input.ToLower()) == 0)
							{
								return rFile;
							}
						}
					}

					string[] folders = Directory.GetDirectories(BasePath, "*.*");
					foreach (string folder in folders)
					{
						string rFolder = folder.Substring(BasePath.Length) + "\\";
						if (rFolder.ToLower().IndexOf(input.ToLower()) == 0)
						{
							return rFolder;
						}
					}

					return "";
				}
			}



			return "";
		}

	}
}
