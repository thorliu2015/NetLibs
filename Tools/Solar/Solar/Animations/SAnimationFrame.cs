using Solar.Animations.Converter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Utils.Attributes;

namespace Solar.Animations
{
	/// <summary>
	/// 关键帧
	/// </summary>
	[Serializable()]
	[Note("动画关键帧", "动画的帧", "图形")]
	public class SAnimationFrame
	{
		/// <summary>
		/// 构造
		/// </summary>
		public SAnimationFrame()
		{
			Position = new Point();
			Scale = new SizeF(1, 1);
			Rotation = 0;

			ImageID = "";

			Alpha = 1;

		}


		//----

		[Category("时间轴"), DisplayName("起始位置"), Description("关键帧内容的起始位置"), ReadOnly(true)]
		/// <summary>
		/// 帧索引
		/// </summary>
		public int Index { get; set; }

		[Category("时间轴"), DisplayName("持续长度"), Description("关键帧内容的持续长度"), ReadOnly(true)]
		/// <summary>
		/// 帧长度
		/// </summary>
		public int Length { get; set; }

		//----

		[Browsable(false)]
		/// <summary>
		/// 位置
		/// </summary>
		public Point Position { get; set; }

		[Category("座标"), DisplayName("横向位置"), Description("关键帧内容的横向位置"), DefaultValue(0)]
		public int X
		{
			get
			{
				return Position.X;
			}
			set
			{
				Position = new Point(value, Position.Y);
			}
		}

		[Category("座标"), DisplayName("纵向位置"), Description("关键帧内容的纵向位置"), DefaultValue(0)]
		public int Y
		{
			get
			{
				return Position.Y;
			}
			set
			{
				Position = new Point(Position.X, value);
			}
		}

		[Browsable(false)]
		/// <summary>
		/// 缩放比率
		/// </summary>
		public SizeF Scale { get; set; }

		[Category("缩放"), DisplayName("横向缩放"), Description("关键帧内容的横向缩放比率"), DefaultValue(1), TypeConverter(typeof(PercentageConverter))]
		public float ScaleX
		{
			get
			{
				return Scale.Width;
			}
			set
			{
				Scale = new SizeF(value, Scale.Height);
			}
		}

		[Category("缩放"), DisplayName("纵向缩放"), Description("关键帧内容的纵向缩放比率"), DefaultValue(1), TypeConverter(typeof(PercentageConverter))]
		public float ScaleY
		{
			get
			{
				return Scale.Height;
			}
			set
			{
				Scale = new SizeF(Scale.Width, value);
			}
		}


		[Category("常用"), DisplayName("旋转角度"), Description("关键帧内容的旋转角度"), DefaultValue(0)]
		/// <summary>
		/// 旋转角度
		/// </summary>
		public float Rotation { get; set; }

		[Category("常用"), DisplayName("透明度"), Description("关键帧内容的透明度"), DefaultValue(1), TypeConverter(typeof(AlphaConverter))]
		/// <summary>
		/// 透明度
		/// </summary>
		public float Alpha { get; set; }


		//----

		[Category("资源"), DisplayName("图片"), Description("关键帧内容的图片资源的ID"), ReadOnly(true)]
		/// <summary>
		/// 图片ID
		/// </summary>
		public string ImageID { get; set; }

		[Category("资源"), DisplayName("图片行号"), Description("关键帧内容的图片资源的行号"), ReadOnly(true)]
		/// <summary>
		/// 图片集行号
		/// </summary>
		public int ImageRowIndex { get; set; }

		[Category("资源"), DisplayName("图片列号"), Description("关键帧内容的图片资源的列号"), ReadOnly(true)]
		/// <summary>
		/// 图片集列号
		/// </summary>
		public int ImageColumnIndex { get; set; }
	}
}
