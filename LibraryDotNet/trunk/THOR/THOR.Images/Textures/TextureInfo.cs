/*
 * TextureInfo
 * liuqiang@2015/12/1 15:52:42
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
	/// 纹理图片信息
	/// </summary>
	public class TextureInfo
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		public TextureInfo()
		{
			Images = new Dictionary<string, TextureImage>();
		}

		#endregion

		#region methods

		#endregion

		#region properties

		/// <summary>
		/// 纹理中包含的图片信息
		/// </summary>
		public Dictionary<string, TextureImage> Images { get; private set; }

		/// <summary>
		/// 真实的纹理文件名
		/// </summary>
		public string RealTextureFileName { get; set; }

		/// <summary>
		/// 纹理尺寸
		/// </summary>
		public Size Size { get; set; }

		/// <summary>
		/// 纹理文件名
		/// </summary>
		public string TextureFileName { get; set; }

		/// <summary>
		/// 纹理图片 
		/// </summary>
		public Image Image { get; set; }

		#endregion

		#region events

		#endregion
	}
}
