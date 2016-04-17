using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using THOR.Utils.Encodings;
using System.ComponentModel;
using System.Reflection;

namespace THOR.Utils.Files
{
	public enum AAAA
	{
		[Description("")]
		a,
		b
	}

	/// <summary>
	/// 文本文件操作
	/// </summary>
	public class TextFile
	{
		/// <summary>
		/// 保存文件内容, 不包括签名之类的
		/// </summary>
		/// <param name="file"></param>
		/// <param name="content"></param>
		/// <param name="encoding"></param>
		static public void SaveFileContent(string file, string content, Encoding encoding)
		{
			StreamWriter writer = new StreamWriter(file, false, encoding);
			byte[] bytes = encoding.GetBytes(content);
			writer.BaseStream.Write(bytes, 0, bytes.Length);
			writer.Close();
		}

		/// <summary>
		/// 保存文件
		/// </summary>
		/// <param name="file">文件名</param>
		/// <param name="content">文件内容</param>
		/// <param name="encoding">编码</param>
		static public void Save(string file, string content, Encoding encoding)
		{
			StreamWriter writer = new StreamWriter(file, false, encoding);
			writer.Write(content);
			writer.Close();
		}

		/// <summary>
		/// 保存文件
		/// </summary>
		/// <param name="file">文件名</param>
		/// <param name="content">文件内容</param>
		static public void Save(string file, string content)
		{
			Save(file, content, Encoding.UTF8);
		}

		/// <summary>
		/// 加载文件
		/// </summary>
		/// <param name="file">文件名</param>
		/// <param name="encoding">编码</param>
		/// <returns>文件内容</returns>
		static public string Load(string file, Encoding encoding)
		{
			string result = "";
			StreamReader reader = new StreamReader(file, encoding);
			result = reader.ReadToEnd();
			reader.Close();

			return result;
		}

		/// <summary>
		/// 加载文件
		/// </summary>
		/// <param name="file">文件名</param>
		/// <returns>文件内容</returns>
		static public string Load(string file)
		{
			string result = "";

			StreamReader reader = new StreamReader(file);
			byte[] bytes = new byte[reader.BaseStream.Length];

			reader.BaseStream.Read(bytes, 0, Convert.ToInt32(reader.BaseStream.Length));

			Encoding encoding = EncodingTools.DetectInputCodepage(bytes);

			result = encoding.GetString(bytes);
			reader.Close();

			return result;
		}

		/// <summary>
		/// 获取文件编码
		/// </summary>
		/// <param name="file">文件名</param>
		/// <returns>编码</returns>
		static public Encoding GetEncoding(string file)
		{

			StreamReader reader = new StreamReader(file);
			byte[] bytes = new byte[reader.BaseStream.Length];

			reader.BaseStream.Read(bytes, 0, Convert.ToInt32(reader.BaseStream.Length));

			Encoding encoding = EncodingTools.DetectInputCodepage(bytes);
			reader.Close();

			return encoding;
		}
	}
}
