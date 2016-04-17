/*
 * TextureImage
 * liuqiang@2015/12/1 16:03:31
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Images.Textures
{
	/// <summary>
	/// 表示纹理中的图片信息
	/// </summary>
	public class TextureImage
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		public TextureImage()
		{
			Frame = new Rectangle();
			SourceColorRect = new Rectangle();
			SourceSize = new Size();
			Offset = new Point();
			Rotated = false;
		}

		#endregion

		#region methods

		#endregion

		#region properties

		/// <summary>
		/// 图片在纹理中的区域
		/// </summary>
		public Rectangle Frame { get; set; }

		/// <summary>
		/// 图片的源始
		/// </summary>
		public Rectangle SourceColorRect { get; set; }

		/// <summary>
		/// 图片的原始尺寸
		/// </summary>
		public Size SourceSize { get; set; }

		/// <summary>
		/// 图片中心点的偏移位置
		/// </summary>
		public Point Offset { get; set; }

		/// <summary>
		/// 图片在纹理中是否进行了旋转
		/// </summary>
		public bool Rotated { get; set; }

		/// <summary>
		/// 图片隶属的纹理
		/// </summary>
		public TextureInfo TextureInfo { get; set; }

		#endregion

		#region events

		#endregion
	}
}
