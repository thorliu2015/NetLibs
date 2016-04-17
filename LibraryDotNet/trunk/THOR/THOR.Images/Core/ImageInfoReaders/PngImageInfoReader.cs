/*
 * PngImageInfoReader
 * liuqiang@2015/12/12 10:30:56
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Images.Core.ImageInfoReaders
{
	public class PngImageInfoReader : IImageInfoReader
	{
		#region constants


		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		public void Parse(StreamReader reader, ImageInfo info)
		{
			byte[] bytes = new byte[4];
			reader.BaseStream.Position = 0x0008;

			int IHDR_SIZE = ReadInt32(reader);
			int IHDR_FLAG = ReadInt32(reader);
			int imgWidth = ReadInt32(reader);
			int imgHeight = ReadInt32(reader);

			reader.BaseStream.Read(bytes, 0, 1);
			int colorDepth = bytes[0];

			reader.BaseStream.Read(bytes, 0, 1);
			int colorType = bytes[0];
		
			//----
			switch (colorType)
			{
				case 0:	//灰度 1,2,4,8,16
					
					break;

				case 2: //真彩 8,16
					break;

				case 3:	//索引彩色 1,2,4,8
					
					break;

				case 4: //带a的灰度 8,16
					break;

				case 6:	//带a的真彩色 8,16
					break;
			}
			//----

			/*
			 * PNG8		colorDepth(1), colorType = 3
			 * PNG24	colorDepth(8), colorType = 2
			 * PNG32	colorDepth(8), colorType = 6
			 */
			if (colorDepth == 1 && colorType == 3) colorDepth = 8;
			else if (colorDepth == 8 && colorType == 2) colorDepth = 24;
			else if (colorDepth == 8 && colorType == 6) colorDepth = 32;
			else colorDepth = -1;

			info.ImageSize = new System.Drawing.Size(imgWidth, imgHeight);
			info.ColorDepth = colorDepth;
		}


		private int ReadInt32(StreamReader reader)
		{
			byte[] bytes = new byte[4];
			reader.BaseStream.Read(bytes, 0, 4);

			byte a = bytes[0];
			byte b = bytes[1];
			byte c = bytes[2];
			byte d = bytes[3];

			bytes[3] = a;
			bytes[2] = b;
			bytes[1] = c;
			bytes[0] = d;

			return BitConverter.ToInt32(bytes, 0);
		}


		#endregion

		#region properties

		#endregion

		#region events

		#endregion

	}
}
