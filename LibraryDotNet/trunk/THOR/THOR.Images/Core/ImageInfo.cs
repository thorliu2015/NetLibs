/*
 * ImageInfo
 * liuqiang@2015/12/12 10:17:27
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


//---- 8< ------------------

namespace THOR.Images.Core
{
	[Serializable()]

	public class ImageInfo
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public ImageInfo()
		{
			ImageSize = new Size();
		}

		#endregion

		#region methods

		public override string ToString()
		{
			if (ColorDepth > 0)
			{
				return String.Format("{{{0}x{1}({2}bit)}}", ImageSize.Width, ImageSize.Height , ColorDepth);
			}
			else
			{
				return String.Format("{{{0}x{1}}}", ImageSize.Width, ImageSize.Height);
			}
			
		}

		#endregion

		#region properties

		/// <summary>
		/// 图片尺寸
		/// </summary>
		public Size ImageSize { get; set; }

		/// <summary>
		/// 颜色深度
		/// </summary>
		public int ColorDepth { get; set; }

		#endregion

		#region events

		#endregion
	}
}
