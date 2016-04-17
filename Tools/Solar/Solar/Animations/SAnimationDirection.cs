using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Utils.Attributes;

namespace Solar.Animations
{
	

	/// <summary>
	/// 动画方向
	/// </summary>
	[Serializable()]
	[Note("动画方向", "单位的角度朝向", "图形")]
	public class SAnimationDirection
	{
		/// <summary>
		/// 构造
		/// </summary>
		public SAnimationDirection()
		{
			Frames = new List<SAnimationFrame>();
			ShootPosition = new List<SAnimationPoint>();
		}

		/// <summary>
		/// 获取指定帧
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public SAnimationFrame this[int index]
		{
			get
			{
				foreach (SAnimationFrame frame in Frames)
				{
					if (frame.Index <= index)
					{
						if (frame.Index + frame.Length > index)
						{
							return frame;
						}
					}
				}
				return null;
			}
		}

		/// <summary>
		/// 枪口
		/// </summary>
		public List<SAnimationPoint> ShootPosition { get; set; }

		/// <summary>
		/// 关键帧
		/// </summary>
		public List<SAnimationFrame> Frames { get; set; }


		/// <summary>
		/// 总帧数
		/// </summary>
		public int TotalFrame
		{
			get
			{
				int result = 0;

				foreach (SAnimationFrame frame in Frames)
				{
					int i = frame.Index + frame.Length;

					if (result < i) result = i;
				}

				return result;
			}
		}

	}
}
