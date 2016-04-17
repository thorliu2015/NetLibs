/*
 * ImageFileUtils
 * liuqiang@2015/12/12 10:22:12
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
using THOR.Images.Core.ImageInfoReaders;


//---- 8< ------------------

namespace THOR.Images.Core
{
	public class ImageFileUtils
	{
		#region constants

		#endregion

		#region variables

		static public Dictionary<string, IImageInfoReader> ImageInfoReaders = new Dictionary<string, IImageInfoReader>();

		#endregion

		#region construct

		static ImageFileUtils()
		{
			ImageInfoReaders[".PNG"] = new PngImageInfoReader();
		}

		#endregion

		#region methods

		/// <summary>
		/// 加载图片
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		static public Image LoadImage(string filename)
		{
			MemoryStream stream = new MemoryStream();
			StreamReader reader = new StreamReader(filename);
			byte[] bytes = new byte[reader.BaseStream.Length];
			reader.BaseStream.Read(bytes, 0, bytes.Length);
			reader.Close();

			stream.Write(bytes, 0, bytes.Length);
			stream.Position = 0;

			Image image = Image.FromStream(stream);
			stream.Dispose();
			return image;
		}

		/// <summary>
		/// 加载图片信息
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		static public ImageInfo LoadImageInfo(string filename)
		{
			
			ImageInfo imageInfo = new ImageInfo();

			string fileType = Path.GetExtension(filename).Trim().ToUpper();
			if (ImageInfoReaders.ContainsKey(fileType))
			{
				IImageInfoReader infoReader = ImageInfoReaders[fileType];
				StreamReader reader = new StreamReader(filename);

				infoReader.Parse(reader, imageInfo);

				reader.Close();
			}

			return imageInfo;
		}

		

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
