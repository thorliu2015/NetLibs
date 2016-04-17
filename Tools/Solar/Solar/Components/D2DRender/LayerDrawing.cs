using SharpDX;
using SharpDX.Direct2D1;
using Solar.Animations;
using Solar.Data;
using Solar.Images;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Utils.Files;

namespace Solar.Components.D2DRender
{
	public class LayerDrawing
	{
		static public Dictionary<string, Bitmap> CacheBitmaps = new Dictionary<string, Bitmap>();

		/// <summary>
		/// 绘制图层节点
		/// </summary>
		/// <param name="layer"></param>
		/// <param name="context"></param>
		static public void DrawLayer(SAnimationLayer layer, AnimationViewContext context)
		{
			if (layer == null) return;
			AnimationViewContext c = context.Clone();

			if (layer.Directions.Count > 0)
			{
				int directionIndex = layer.GetDirection(context);
				bool flip = directionIndex < 0;
				directionIndex = Math.Abs(directionIndex);

				if (directionIndex < 0 || directionIndex > layer.Directions.Count - 1) return;

				SAnimationDirection direction = layer.Directions[directionIndex];

				int totalFrame = direction.TotalFrame;

				if (totalFrame > 0)
				{
					int frameIndex = Convert.ToInt32(context.FrameIndex % totalFrame);
					

					SAnimationFrame frame = direction[frameIndex];
					if (frame != null)
					{

						DrawFrame(frame, c, flip);
					}
				}

				VectorDrawing.DrawShootPosition(context, direction);
			}


			for (int i = 0; i < layer.Count; i++)
			{
				SAnimationLayer childLayer = (SAnimationLayer)layer[i];

				DrawLayer(childLayer, c);
			}
		}


		static private void DrawFrame(SAnimationFrame frame, AnimationViewContext context, bool flip = false)
		{
			if (frame == null) return;

			SModel imageModel = SModelManager.Current.GetModel(frame.ImageID);
			if (imageModel is SImage == false) return;
			SImage image = (SImage)imageModel;

			Bitmap bmp = GetBitmap(image, context);

			if (bmp == null)
			{
				Debug.WriteLine(string.Format("(ERROR)加载图片资源失败 ID = {0}", frame.ImageID));
				return;
			}

			RectangleF sourceRect = GetFrameSourceRect(bmp, image, frame);
			RectangleF targetRect = new RectangleF(0, 0, sourceRect.Width, sourceRect.Height);

			targetRect.X = context.Position.X;
			targetRect.Y = context.Position.Y;
			targetRect.X -= image.Anchor.X;
			targetRect.Y -= image.Anchor.Y;

			targetRect.X += frame.Position.X * context.Scale.X;
			targetRect.Y += frame.Position.Y * context.Scale.Y;

			Vector2 anchor = new Vector2();
			anchor.X = context.Position.X;
			anchor.Y = context.Position.Y;

			anchor.X += frame.Position.X * context.Scale.X;
			anchor.Y += frame.Position.Y * context.Scale.Y;

			//设定矩阵
			context.Render.Transform = SharpDX.Matrix.Transformation2D(
					anchor,	//缩放中心
					0f,
					new Vector2(context.Scale.X  * frame.ScaleX * (flip ? -1 : 1), context.Scale.Y * frame.ScaleY),	//缩放比例
					anchor,	//旋转中心
					MathUtil.DegreesToRadians(frame.Rotation),				//旋转角度
					new Vector2(0, 0)
				);

			//绘制图片
			context.Render.DrawBitmap(bmp, targetRect, 1.0f * frame.Alpha, BitmapInterpolationMode.Linear, sourceRect);


			//重置矩阵
			context.Render.Transform = SharpDX.Matrix.Transformation2D(
					new Vector2(0, 0),	//缩放中心
					0f,
					new Vector2(1, 1),	//缩放比例
					new Vector2(0, 0),	//旋转中心
					0f,					//旋转角度
					new Vector2(0, 0)
				);
		}

		/// <summary>
		/// 获取位图
		/// </summary>
		/// <param name="image"></param>
		/// <param name="context"></param>
		/// <returns></returns>
		static private Bitmap GetBitmap(SImage image, AnimationViewContext context)
		{
			if (CacheBitmaps.ContainsKey(image.Id))
			{
				return CacheBitmaps[image.Id];
			}
			else
			{
				if (context.Controller != null)
				{
					string imageFile = PathUtility.GetPathByApplicationPath("images", image.Id.ToString() + ".png");

					try
					{
						Bitmap bmp = context.Controller.LoadBitmap(imageFile);
						CacheBitmaps.Add(image.Id, bmp);

						return bmp;
					}
					catch
					{
					}
				}
			}


			return null;
		}

		/// <summary>
		/// 获取帧的资源矩形
		/// </summary>
		/// <param name="bitmap"></param>
		/// <param name="image"></param>
		/// <param name="frame"></param>
		/// <returns></returns>
		static private RectangleF GetFrameSourceRect(Bitmap bitmap, SImage image, SAnimationFrame frame)
		{
			RectangleF rect = new RectangleF();

			rect.Width = bitmap.PixelSize.Width / image.Columns;
			rect.Height = bitmap.PixelSize.Height / image.Rows;
			rect.X = frame.ImageColumnIndex * rect.Width;
			rect.Y = frame.ImageRowIndex * rect.Height;

			return rect;
		}

		static public bool CheckCacheBitmapsRunning()
		{
			MessageBox.Show("图片文件已经被占用, 请在启动动画模块之前进行操作!", "无效操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
			return CacheBitmaps.Count > 0;
		}
	}
}
