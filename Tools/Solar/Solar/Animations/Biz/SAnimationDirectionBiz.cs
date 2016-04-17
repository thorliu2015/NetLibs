using Solar.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Animations.Biz
{
	/// <summary>
	/// 关于动画方向的业务逻辑
	/// </summary>
	public class SAnimationDirectionBiz
	{

		/// <summary>
		/// 获取实际方向数量
		/// </summary>
		/// <param name="direction"></param>
		/// <returns></returns>
		static public int GetActualDirection(int direction)
		{
			//横向翻转方式
			int result = direction;

			result -= 2;			//正上方和正下方不翻转
			result /= 2;		//其它方向减半
			result += 2;		//其它方向+上下方向

			return result;
		}

		/// <summary>
		/// 获取目标方向数量
		/// </summary>
		/// <param name="direction"></param>
		/// <returns></returns>
		static public int GetTargetDirection(int direction)
		{

			//同上...
			int result = direction;

			result -= 2;
			result *= 2;
			result += 2;

			return result;
		}

		/// <summary>
		/// 获取最大帧数
		/// </summary>
		/// <param name="direction"></param>
		/// <returns></returns>
		static public int GetMaxFrame(SAnimationDirection direction)
		{
			int result = 0;
			int temp = 0;
			foreach (SAnimationFrame frame in direction.Frames)
			{
				temp = frame.Index + frame.Length;
				if (result < temp) result = temp;
			}

			return result;
		}

		/// <summary>
		/// 导入单帧
		/// </summary>
		/// <param name="direction"></param>
		/// <param name="image"></param>
		/// <param name="row"></param>
		/// <param name="col"></param>
		static public void ImportFrame(SAnimationDirection direction, SImage image, int row = 0, int col = 0)
		{
			if (image == null) return;
			SAnimationFrame frame = new SAnimationFrame();
			frame.ImageID = image.Id;
			frame.ImageRowIndex = row;
			frame.ImageColumnIndex = col;

			frame.Length = 1;
			frame.Index = GetMaxFrame(direction);
			direction.Frames.Add(frame);
		}

		/// <summary>
		/// 导入多帧
		/// </summary>
		/// <param name="direction"></param>
		/// <param name="image"></param>
		static public void ImportFrames(SAnimationLayer layer, SImage image)
		{
			if (image == null) return;
			int dirs = image.Columns;
			if (dirs > 2)
			{
				dirs = GetTargetDirection(dirs);
			}

			layer.Directions.Clear();
			layer.TargetDirections = dirs;

			for (int c = 0; c < image.Columns; c++)
			{
				SAnimationDirection dir = layer.Directions[c];
				for (int r = 0; r < image.Rows; r++)
				{
					ImportFrame(dir, image, r, c);
				}
			}
		}

		static public SAnimationFrame GetFrameByIndex(SAnimationDirection direction, int index)
		{
			if (direction == null) return null;
			foreach (SAnimationFrame frame in direction.Frames)
			{
				if (frame.Index <= index && index < frame.Index + frame.Length)
				{
					return frame;
				}
			}

			return null;
		}


		static public void DeleteFrame(SAnimationDirection direction, SAnimationFrame frame)
		{
			if (direction != null && direction.Frames.Contains(frame))
			{
				direction.Frames.Remove(frame);
			}
		}

		/// <summary>
		/// 添加帧长度
		/// </summary>
		/// <param name="direction"></param>
		/// <param name="frame"></param>
		static public void AddFrameLength(SAnimationDirection direction, SAnimationFrame frame)
		{
			foreach (SAnimationFrame f in direction.Frames)
			{
				if (frame == f) continue;
				if (frame.Index > f.Index) continue;
				f.Index++;
			}
			frame.Length++;
		}

		/// <summary>
		/// 减少帧长度
		/// </summary>
		/// <param name="direction"></param>
		/// <param name="frame"></param>
		static public void RemoveFrameLength(SAnimationDirection direction, SAnimationFrame frame)
		{
			if (frame.Length <= 1) return;
			foreach (SAnimationFrame f in direction.Frames)
			{
				if (frame == f) continue;
				if (frame.Index > f.Index) continue;
				f.Index--;
			}
			frame.Length--;
		}

		/// <summary>
		/// 左移帧
		/// </summary>
		/// <param name="direction"></param>
		/// <param name="frame"></param>
		static public void MoveFrameLeft(SAnimationDirection direction, SAnimationFrame frame)
		{
			if (frame.Index <= 0) return;
			foreach (SAnimationFrame f in direction.Frames)
			{
				if (f == frame) continue;
				if (frame.Index >= f.Index && frame.Index <= f.Index + f.Length) return;
			}

			foreach (SAnimationFrame f in direction.Frames)
			{
				if (f.Index >= frame.Index)
				{
					f.Index--;
				}
			}

		}

		/// <summary>
		/// 右移帧
		/// </summary>
		/// <param name="direction"></param>
		/// <param name="frame"></param>
		static public void MoveFrameRight(SAnimationDirection direction, SAnimationFrame frame)
		{
			foreach (SAnimationFrame f in direction.Frames)
			{
				if (f.Index >= frame.Index)
				{
					f.Index++;
				}
			}
		}


		static public int GetDrectionIndex(int directionCount, float angle)
		{
			int fullDirections = directionCount;

			if (fullDirections > 1)
			{
				fullDirections = 2 + (fullDirections - 2) * 2;
			}

			float dirAngle = 360.0f / fullDirections;

			angle += 90;

			//考虑半个方向的角度偏差
			angle += dirAngle / 2;

			//保证角度是正数(0~360)
			if (angle < 0) angle += 360;
			if (angle > 360) angle = angle % 360;



			//计算角度对应的索引
			int index = Convert.ToInt32(angle / dirAngle);
			int beginIndex = 0;
			int endIndex = fullDirections / 2;

			if (index >= beginIndex && index <= endIndex)
			{
				return index;
			}
			else if (index > endIndex)
			{
				int offsetIndex = index - endIndex;

				return -(endIndex - offsetIndex);
			}

			return 0;
		}

	}
}
