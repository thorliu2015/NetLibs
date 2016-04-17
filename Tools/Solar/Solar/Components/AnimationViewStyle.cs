using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Components
{
	/// <summary>
	/// 动画视图样式
	/// </summary>
	public class AnimationViewStyle
	{
		/// <summary>
		/// 浅色风格
		/// </summary>
		static public AnimationViewStyle Light
		{
			get
			{
				ImageViewStyle img = ImageViewStyle.Light;

				AnimationViewStyle result = new AnimationViewStyle();
				result.Background = img.BackgroundBrush.Color;
				result.Grid = img.GridPen.Color;
				result.Anchor = img.AnchorPen.Color;
				result.Weapon = Color.FromArgb(0x99, 0x99, 0x00);
				return result;
			}
		}

		/// <summary>
		/// 暗色风格
		/// </summary>
		static public AnimationViewStyle Dark
		{
			get
			{
				ImageViewStyle img = ImageViewStyle.Dark;

				AnimationViewStyle result = new AnimationViewStyle();
				result.Background = img.BackgroundBrush.Color;
				result.Grid = img.GridPen.Color;
				result.Anchor = img.AnchorPen.Color;
				result.Weapon = Color.Yellow;
				return result;
			}
		}


		/// <summary>
		/// 构造
		/// </summary>
		public AnimationViewStyle()
		{
		}


		public Color Background { get; set; }
		public Color Grid { get; set; }
		public Color Anchor { get; set; }

		public Color Weapon { get; set; }
	}
}
