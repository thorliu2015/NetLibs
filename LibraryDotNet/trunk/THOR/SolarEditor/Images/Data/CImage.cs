/*
 * CImage
 * liuqiang@2015/12/12 0:46:43
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.Editors.Common.Data;


//---- 8< ------------------

namespace SolarEditor.Images.Data
{
	[Serializable()]

	/// <summary>
	/// 图片信息
	/// </summary>
	public class CImage : CEntity
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		public CImage()
			: base()
		{
			IdPrefix = "img";
		}

		#endregion

		#region methods

		#endregion

		#region properties


		#endregion

		#region events

		#endregion
	}
}
