/*
 * TexturePListReader
 * liuqiang@2015/12/1 16:12:20
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


//---- 8< ------------------

namespace THOR.Images.Textures.Readers
{
	public class TexturePListReader
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		/// <summary>
		/// 加载plist文件
		/// </summary>
		/// <param name="plistFile"></param>
		/// <returns></returns>
		static public TextureInfo Load(string plistFile, bool plistOnly = true)
		{
			TextureInfo textureInfo = new TextureInfo();

			XmlDocument xml = new XmlDocument();
			xml.Load(plistFile);

			XmlNodeList nodeKeys = xml.DocumentElement.SelectNodes("dict/key");

			foreach (XmlNode nodeKey in nodeKeys)
			{
				string szKey = nodeKey.InnerText.Trim().ToLower();

				switch (szKey)
				{
					case "frames":
						ParseFrames(textureInfo, nodeKey.NextSibling);
						break;

					case "metadata":
						ParseMetadata(textureInfo, nodeKey.NextSibling);
						break;
				}
			}

			if (!plistOnly)
			{
				//尝试加载图片
				string plistDirectory = Path.GetDirectoryName(plistFile);
				textureInfo.RealTextureFileName = Path.Combine(plistDirectory, textureInfo.RealTextureFileName);
				textureInfo.TextureFileName = Path.Combine(plistDirectory, textureInfo.TextureFileName);

				StreamReader reader = new StreamReader(textureInfo.RealTextureFileName);
				byte[] textureBytes = new byte[reader.BaseStream.Length];
				reader.BaseStream.Read(textureBytes, 0, textureBytes.Length);
				reader.Close();

				MemoryStream stream = new MemoryStream();
				stream.Write(textureBytes, 0, textureBytes.Length);
				stream.Position = 0;
				Image img = Image.FromStream(stream);

				textureInfo.Image = img;
			}
			return textureInfo;
		}

		/// <summary>
		/// 解释metadata节点
		/// </summary>
		/// <param name="texture"></param>
		/// <param name="metadataNode"></param>
		static private void ParseMetadata(TextureInfo texture, XmlNode metadataNode)
		{
			XmlNodeList nodeKeys = metadataNode.SelectNodes("key");

			foreach (XmlNode nodeKey in nodeKeys)
			{
				string szKey = nodeKey.InnerText.Trim().ToLower();
				XmlNode nodeData = nodeKey.NextSibling;
				switch (szKey)
				{
					case "realtexturefilename":
						texture.RealTextureFileName = nodeData.InnerText;
						break;

					case "size":
						texture.Size = GetSize(nodeData.InnerText);
						break;

					case "texturefilename":
						texture.TextureFileName = nodeData.InnerText;
						break;
				}
			}
		}

		/// <summary>
		/// 解释frames节点
		/// </summary>
		/// <param name="texture"></param>
		/// <param name="framesNode"></param>
		static private void ParseFrames(TextureInfo texture, XmlNode framesNode)
		{
			XmlNodeList nodeKeys = framesNode.SelectNodes("key");
			foreach (XmlNode nodeKey in nodeKeys)
			{
				string szFrameKey = nodeKey.InnerText;
				XmlNode nodeFrame = nodeKey.NextSibling;

				TextureImage image = new TextureImage();
				image.TextureInfo = texture;
				texture.Images[szFrameKey] = image;

				XmlNodeList nodeImageKeys = nodeFrame.SelectNodes("key");

				foreach (XmlNode childNodeKey in nodeImageKeys)
				{
					string szKey = childNodeKey.InnerText.Trim().ToLower();
					XmlNode nodeData = childNodeKey.NextSibling;

					switch (szKey)
					{
						case "frame":
							image.Frame = GetRectangle(nodeData.InnerText);
							break;

						case "offset":
							image.Offset = GetPoint(nodeData.InnerText);
							break;

						case "rotated":
							image.Rotated = (nodeData.Name.Trim().ToLower() == "true");
							break;

						case "sourcecolorrect":
							image.SourceColorRect = GetRectangle(nodeData.InnerText);
							break;

						case "sourcesize":
							image.SourceSize = GetSize(nodeData.InnerText);
							break;
					}
				}
			}
		}

		/// <summary>
		/// 获取尺寸
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		static private Size GetSize(string text)
		{
			Size size = new Size();

			string sz = text.Trim();
			if (sz.Length > 2)
			{
				sz = sz.Substring(1, sz.Length - 2);
				string[] vs = sz.Split(new char[1] { ',' });
				if (vs.Length == 2)
				{
					size.Width = Convert.ToInt32(vs[0]);
					size.Height = Convert.ToInt32(vs[1]);
				}
			}

			return size;
		}

		/// <summary>
		/// 获取位置
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		static private Point GetPoint(string text)
		{
			Point point = new Point();

			string sz = text.Trim();
			if (sz.Length > 2)
			{
				sz = sz.Substring(1, sz.Length - 2);
				string[] vs = sz.Split(new char[1] { ',' });
				if (vs.Length == 2)
				{
					point.X = Convert.ToInt32(Convert.ToSingle(vs[0]));
					point.Y = Convert.ToInt32(Convert.ToSingle(vs[1]));
				}
			}

			return point;
		}

		static private Rectangle GetRectangle(string text)
		{
			Rectangle rect = new Rectangle();

			string sz = text.Trim();
			if (sz.Length > 2)
			{
				//{{2,0},{66,61}}
				sz = sz.Substring(1, sz.Length - 2);
				//{2,0},{66,61}
				int index = sz.IndexOf("},{");
				if (index >= 0)
				{
					string szLocation = sz.Substring(0, index + 1);
					string szSize = sz.Substring(index + 2);

					rect.Location = GetPoint(szLocation);
					rect.Size = GetSize(szSize);
				}
			}

			return rect;
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
