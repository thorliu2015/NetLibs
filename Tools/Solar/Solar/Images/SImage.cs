using Solar.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Utils.Attributes;

namespace Solar.Images
{
	[Serializable()]
	[Note("图片", "图标, 图片, 序列帧资源等", "图形")]
	public class SImage : SModel
	{
		/// <summary>
		/// 构造
		/// </summary>
		public SImage()
			: base()
		{
		}

		//----

		/// <summary>
		/// 图片源
		/// </summary>
		public Image ImageSource { get; set; }

		/// <summary>
		/// 行数
		/// </summary>
		public int Rows { get; set; }

		/// <summary>
		/// 列数
		/// </summary>
		public int Columns { get; set; }

		/// <summary>
		/// 锚点位置
		/// </summary>
		public Point Anchor { get; set; }

		//----

		/// <summary>
		/// 获取图片宽度
		/// </summary>
		public int Width
		{
			get
			{
				if (ImageSource != null) return ImageSource.Width;
				return 0;
			}
		}

		/// <summary>
		/// 获取图片高度
		/// </summary>
		public int Height
		{
			get
			{
				if (ImageSource != null) return ImageSource.Height;
				return 0;
			}
		}

		/// <summary>
		/// 获取帧宽度
		/// </summary>
		public int FrameWidth
		{
			get
			{
				if (Width <= 0) return 0;
				if (Columns < 1) return Width;

				return Width / Columns;
			}
		}

		/// <summary>
		/// 获取帧高度
		/// </summary>
		public int FrameHeight
		{
			get
			{
				if (Height <= 0) return 0;
				if (Rows < 1) return Height;

				return Height / Rows;
			}
		}

		//----

		public bool OpenImage(string imageFile)
		{
			try
			{
				Image tmp = Image.FromFile(imageFile);
				if (ImageSource != null)
				{
					ImageSource.Dispose();
					ImageSource = null;
				}
				ImageSource = new Bitmap(tmp.Width, tmp.Height);

				Graphics g = Graphics.FromImage(ImageSource);

				g.DrawImage(tmp, new Rectangle(0, 0, tmp.Width, tmp.Height));

				g.Dispose();
				tmp.Dispose();
				return true;
			}
			catch
			{
				return false;
			}
		}

		//----

		/// <summary>
		/// 删除行
		/// </summary>
		/// <param name="index"></param>
		/// <param name="count"></param>
		public void DeleteRows(int index, int count = 1)
		{
			if (count < 1) return;
			if (index + count > Rows) return;

			if (ImageSource == null) return;
			if (FrameHeight == 0) return;

			Image newImage = new Bitmap(Width, (Rows - count) * FrameHeight);
			Graphics g = Graphics.FromImage(newImage);

			//top
			Rectangle rect = new Rectangle(0, 0, Width, Height);
			rect.Y = 0;
			rect.Height = index * FrameHeight;
			if (rect.Height > 0)
			{
				g.DrawImage(ImageSource, 0, 0, rect, GraphicsUnit.Pixel);
			}


			//bottom
			rect.Height = (Rows - index - count) * FrameHeight;
			rect.Y = (index + count) * FrameHeight;
			if (rect.Height > 0)
			{
				g.DrawImage(ImageSource, 0, index * FrameHeight, rect, GraphicsUnit.Pixel);
			}

			Rows -= count;

			g.Dispose();
			ImageSource = newImage;

			ChangeType = DataChangeTypes.DataChanged | DataChangeTypes.FileChanged;
			//newImage.Save(@"C:\Docs\temp\ss\tmp.png");
		}

		/// <summary>
		/// 删除列
		/// </summary>
		/// <param name="index"></param>
		/// <param name="count"></param>
		public void DeleteColumns(int index, int count = 1)
		{
			if (count < 1) return;
			if (index + count > Columns) return;
			if (ImageSource == null) return;
			if (FrameWidth == 0) return;

			Image newImage = new Bitmap((Columns - count) * FrameWidth, Height);
			Graphics g = Graphics.FromImage(newImage);

			//left
			Rectangle rect = new Rectangle(0, 0, Width, Height);
			rect.X = 0;
			rect.Width = index * FrameWidth;
			if (rect.Width > 0)
			{
				g.DrawImage(ImageSource, 0, 0, rect, GraphicsUnit.Pixel);
			}

			//right
			rect.Width = (Columns - index - count) * FrameWidth;
			rect.X = (index + count) * FrameWidth;
			if (rect.Width > 0)
			{
				g.DrawImage(ImageSource, index * FrameWidth, 0, rect, GraphicsUnit.Pixel);
			}

			Columns -= count;

			g.Dispose();
			ImageSource = newImage;

			ChangeType = DataChangeTypes.DataChanged | DataChangeTypes.FileChanged;
			//newImage.Save(@"C:\Docs\temp\ss\tmp.png");
		}


		/// <summary>
		/// 导出指定帧
		/// </summary>
		/// <param name="dir"></param>
		/// <param name="row"></param>
		/// <param name="col"></param>
		public void ExportFrame(string dir, int row, int col, string id)
		{
			if (ImageSource == null) return;
			if (Rows == 0 || Columns == 0) return;
			if (row < 0 || col < 0) return;
			if (row >= Rows || col >= Columns) return;
			if (FrameWidth <= 0 || FrameHeight <= 0) return;

			Bitmap frame = new Bitmap(FrameWidth, FrameHeight);

			Rectangle src = new Rectangle();
			src.Width = FrameWidth;
			src.Height = FrameHeight;

			src.X = col * FrameWidth;
			src.Y = row * FrameHeight;

			Graphics g = Graphics.FromImage(frame);

			g.DrawImage(ImageSource, 0, 0, src, GraphicsUnit.Pixel);

			g.Dispose();

			string imgPath = Path.Combine(dir, String.Format("{0}_{1}_{2}.png", id, row, col));
			frame.Save(imgPath);

		}

		/// <summary>
		/// 导出所有帧
		/// </summary>
		/// <param name="dir"></param>
		public void ExportFrames(string dir, string id)
		{
			for (int r = 0; r < Rows; r++)
			{
				for (int c = 0; c < Columns; c++)
				{
					ExportFrame(dir, r, c, id);
				}
			}
		}


		/// <summary>
		/// 纵向滚动
		/// </summary>
		/// <param name="offset"></param>
		public void ScrollRows(int offset)
		{
			if (offset == 0) return;
			if (Rows <= 1) return;
			if (ImageSource == null) return;
			if (FrameHeight == 0) return;
			if (offset >= Rows) return;

			Image newImage = new Bitmap(Width, Height);
			Graphics g = Graphics.FromImage(newImage);


			Rectangle sRect = new Rectangle(0, 0, Width, Height);
			Rectangle tRect = new Rectangle(0, 0, Width, Height);

			//top
			sRect.Y = 0;
			sRect.Height = offset * FrameHeight;
			tRect.Y = (Rows - offset) * FrameHeight;
			tRect.Height = sRect.Height;

			g.DrawImage(ImageSource, tRect.X, tRect.Y, sRect, GraphicsUnit.Pixel);

			//bottom
			sRect.Y = offset * FrameHeight;
			sRect.Height = (Rows - offset) * FrameHeight;
			tRect.Y = 0;
			tRect.Height = sRect.Height;
			g.DrawImage(ImageSource, tRect.X, tRect.Y, sRect, GraphicsUnit.Pixel);

			g.Dispose();
			ImageSource = newImage;

			ChangeType = DataChangeTypes.DataChanged | DataChangeTypes.FileChanged;

			//newImage.Save(@"C:\Docs\temp\ss\tmp.png");
		}

		/// <summary>
		/// 横向滚动
		/// </summary>
		/// <param name="offset"></param>
		public void ScrollColumns(int offset)
		{
			if (offset == 0) return;
			if (Columns <= 1) return;
			if (ImageSource == null) return;
			if (FrameWidth == 0) return;
			if (offset >= Columns) return;

			Image newImage = new Bitmap(Width, Height);
			Graphics g = Graphics.FromImage(newImage);

			Rectangle sRect = new Rectangle(0, 0, Width, Height);
			Rectangle tRect = new Rectangle(0, 0, Width, Height);

			//left
			sRect.X = 0;
			sRect.Width = offset * FrameWidth;
			tRect.X = (Columns - offset) * FrameWidth;
			tRect.Width = sRect.Width;
			g.DrawImage(ImageSource, tRect.X, tRect.Y, sRect, GraphicsUnit.Pixel);

			//right
			sRect.X = offset * FrameWidth;
			sRect.Width = (Columns - offset) * FrameWidth;
			tRect.X = 0;
			tRect.Width = sRect.Width;
			g.DrawImage(ImageSource, tRect.X, tRect.Y, sRect, GraphicsUnit.Pixel);

			g.Dispose();
			ImageSource = newImage;

			ChangeType = DataChangeTypes.DataChanged | DataChangeTypes.FileChanged;

			//newImage.Save(@"C:\Docs\temp\ss\tmp.png");
		}

		/// <summary>
		/// 缩放
		/// </summary>
		/// <param name="rate"></param>
		public void Resize(double rate)
		{
			if (rate == 1) return;
			if (ImageSource == null) return;
			if (FrameWidth == 0) return;
			if (FrameHeight == 0) return;
			if (Rows < 1) return;
			if (Columns < 1) return;

			int newFrameWidth = Convert.ToInt32(FrameWidth * rate);
			int newFrameHeight = Convert.ToInt32(FrameHeight * rate);

			int newWidth = newFrameWidth * Columns;
			int newHeight = newFrameHeight * Rows;

			Image newImage = new Bitmap(newWidth, newHeight);
			Graphics g = Graphics.FromImage(newImage);

			g.DrawImage(ImageSource, new Rectangle(0, 0, newWidth, newHeight), new Rectangle(0, 0, Width, Height), GraphicsUnit.Pixel);

			g.Dispose();
			ImageSource = newImage;

			ChangeType = DataChangeTypes.DataChanged | DataChangeTypes.FileChanged;

			//newImage.Save(@"C:\Docs\temp\ss\tmp.png");
		}
	}
}
