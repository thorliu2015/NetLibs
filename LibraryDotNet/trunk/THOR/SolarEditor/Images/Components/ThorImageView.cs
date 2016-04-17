/*
 * ThorImageView
 * liuqiang@2015/12/12 20:17:24
 * ---- 8< ------------------
 * NOTE
 */

using SolarEditor.Images.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Images.Core;
using THOR.Images.Drawing;
using THOR.Windows.Components.Common;
using THOR.Windows.Components.Drawing;
using THOR.Windows.Utils;


//---- 8< ------------------

namespace SolarEditor.Images.Components
{
	public class ThorImageView : ThorScrollView
	{
		#region constants

		#endregion

		#region variables

		protected Image currentImageCache = null;

		#endregion

		#region construct

		public ThorImageView()
			: base()
		{
			InitImageView();
		}

		#endregion

		#region methods



		/// <summary>
		/// 初始化图片视图
		/// </summary>
		protected virtual void InitImageView()
		{

			this.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		}

		/// <summary>
		/// 绘制内容
		/// </summary>
		/// <param name="e"></param>
		protected override void DrawScrollContent(System.Windows.Forms.PaintEventArgs e)
		{
			Rectangle rect = new Rectangle(0, 0, Width, Height);

			rect.Width -= (this.vScrollBar.Visible ? this.vScrollBar.Width : 0);
			rect.Height -= (this.hScrollBar.Visible ? this.hScrollBar.Height : 0);

			ThorImagePaint.DrawAlpha(e.Graphics, rect, ThorColors.ImageViewAlpha1, ThorColors.ImageViewAlpha2);

			if (currentImageCache == null) return;

			Rectangle rectSrc = new Rectangle(0, 0, currentImageCache.Width, currentImageCache.Height);
			Rectangle rectDst = new Rectangle(0, 0, currentImageCache.Width, currentImageCache.Height);

			rectDst.Width = Convert.ToInt32(rectDst.Width * currentScale);
			rectDst.Height = Convert.ToInt32(rectDst.Height * currentScale);

			Size s = new Size(Width, Height);
			s.Width -= (vScrollBar.Visible ? vScrollBar.Width : 0);
			s.Height -= (hScrollBar.Visible ? hScrollBar.Height : 0);

			if (rectDst.Width < s.Width && rectDst.Height < s.Height)
			{
				rectDst.X += (s.Width - rectDst.Width) / 2;
				rectDst.Y += (s.Height - rectDst.Height) / 2;
			}
			else
			{
				rectDst.X -= hScrollBar.Value;
				rectDst.Y -= vScrollBar.Value;
			}

			ThorControlPaint.DrawRectangle(e.Graphics, rectDst, ThorPens.ControlLight, false);
			e.Graphics.DrawImage(currentImageCache, rectDst, rectSrc, GraphicsUnit.Pixel);



		}

		/// <summary>
		/// 计算滚动内容
		/// </summary>
		/// <returns></returns>
		protected override Size MeasureScrollContentSize()
		{
			Size size = new Size();

			if (currentImage != null)
			{
				LoadImage();

				if (currentImageCache != null)
				{
					size.Width = Convert.ToInt32(currentImageCache.Width * currentScale);
					size.Height = Convert.ToInt32(currentImageCache.Height * currentScale);
				}
			}

			return size;
		}

		/// <summary>
		/// 加载图片 
		/// </summary>
		protected virtual void LoadImage()
		{
			if (currentImageCache != null) return;
			if (currentImage == null) return;

			string imageDirPath = ApplicationUtils.CombinePath(@"Data\Images");
			string imageFilePath = String.Format("{0}.png", currentImage.GetFullID());
			imageFilePath = Path.Combine(imageDirPath, imageFilePath);

			currentImageCache = ImageFileUtils.LoadImage(imageFilePath);
		}

		#endregion

		#region properties

		protected CImage currentImage = null;
		public CImage CurrentImage
		{
			get
			{
				return currentImage;
			}
			set
			{
				if (currentImage == value) return;
				currentImage = value;
				if (currentImageCache != null)
				{
					currentImageCache.Dispose();
					currentImageCache = null;
				}

				this.LayoutScrollView();
				this.Invalidate();
			}
		}


		protected float currentScale = 1f;
		public float CurrentScale
		{
			get
			{
				return currentScale;
			}
			set
			{
				float newScale = value;

				if (newScale > 5) newScale = 5;
				if (newScale < 0.5f) newScale = 0.5f;

				if (currentScale == newScale) return;
				currentScale = newScale;
				this.LayoutScrollView();
				this.Invalidate();
			}
		}

		#endregion

		#region events

		#endregion
	}
}
