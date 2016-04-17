using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using THOR.Utils.Files;

namespace THOR.Utils.Files
{
	public class XmlObjectUtility
	{
		/// <summary>
		/// 对象序列化
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		static public string Encode(object obj)
		{
			StringWriter writer = new StringWriter();
			XmlSerializer ser = new XmlSerializer(obj.GetType());
			ser.Serialize(writer, obj);
			string result = writer.ToString();
			writer.Close();
			return result;
		}

		/// <summary>
		/// 对象序列化
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="filename"></param>
		static public void EncodeToFile(object obj, string filename)
		{
			string content = Encode(obj);
			TextFile.Save(filename, content);
		}

		/// <summary>
		/// 反序列化一个对象
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		static public object Decode(string str, Type type)
		{
			StringReader reader = new StringReader(str);
			XmlSerializer ser = new XmlSerializer(type);
			object result = ser.Deserialize(reader);
			reader.Close();

			return result;
		}

		/// <summary>
		/// 反序列化一个对象
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		static public object DecodeFromFile(string filename, Type type)
		{
			string content = TextFile.Load(filename);

			return Decode(content, type);
		}
	}
}
