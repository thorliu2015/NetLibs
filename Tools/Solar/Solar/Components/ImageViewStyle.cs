using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Components
{
	/// <summary>
	/// 图片视图样式
	/// </summary>
	public class ImageViewStyle
	{
		/// <summary>
		/// 构造
		/// </summary>
		public ImageViewStyle()
		{
			AnchorRadius = 5;
		}

		/// <summary>
		/// 锚点半径
		/// </summary>
		public int AnchorRadius { get; set; }

		/// <summary>
		/// 背景笔刷
		/// </summary>
		public SolidBrush BackgroundBrush { get; set; }

		/// <summary>
		/// 网格笔触
		/// </summary>
		public Pen GridPen { get; set; }

		/// <summary>
		/// 锚点笔触
		/// </summary>
		public Pen AnchorPen { get; set; }

		/// <summary>
		/// 选定笔刷
		/// </summary>
		public SolidBrush SelectedBrush { get; set; }

		/// <summary>
		/// 浅色风格
		/// </summary>
		static public ImageViewStyle Light
		{
			get
			{
				return new ImageViewStyle()
				{
					BackgroundBrush = new SolidBrush(Color.FromArgb(0xFF, 0xFF, 0xFF)),
					GridPen = new Pen(new SolidBrush(Color.FromArgb(0xCC, 0xCC, 0xCC))),
					AnchorPen = new Pen(new SolidBrush(Color.Red)),
					SelectedBrush = new SolidBrush(Color.FromArgb(0x20, 0xFF, 0x00, 0x00))
				};
			}
		}

		/// <summary>
		/// 深色风格
		/// </summary>
		static public ImageViewStyle Dark
		{
			get
			{
				return new ImageViewStyle()
				{
					BackgroundBrush = new SolidBrush(Color.FromArgb(0x33, 0x33, 0x33)),
					GridPen = new Pen(new SolidBrush(Color.FromArgb(0x66, 0x66, 0x66))),
					AnchorPen = new Pen(new SolidBrush(Color.Red)),
					SelectedBrush = new SolidBrush(Color.FromArgb(0x20, 0xFF, 0x00, 0x00))
				};
			}
		}

	}

}
