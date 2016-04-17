using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Solar.Animations;
using Solar.Animations.Biz;

namespace Solar.Components
{

	/// <summary>
	/// 时间轴控件
	/// </summary>
	public partial class Timeline : UserControl
	{
		/// <summary>
		/// 帧宽度
		/// </summary>
		public const int FRAME_WIDTH = 16;

		/// <summary>
		/// 帧高度
		/// </summary>
		public const int FRAME_HEIGHT = 20;

		/// <summary>
		/// 标尺高度
		/// </summary>
		public const int RULER_Height = 20;

		/// <summary>
		/// 标尺小刻度高度
		/// </summary>
		public const int RULER_GRID_HEIGHT_1 = 5;

		/// <summary>
		/// 标尺大刻度高度
		/// </summary>
		public const int RULER_GRID_HEIGHT_2 = 10;


		Pen NormalPen = SystemPens.ControlDark;
		Brush NormalBrush = SystemBrushes.Control;

		Pen SelectedPen = SystemPens.Highlight;
		Brush SelectedBrush = new SolidBrush(Color.FromArgb(0x40, SystemColors.Highlight));

		Pen CurrentPen = new Pen(new SolidBrush(Color.FromArgb(0x80, 0xFF, 0x33, 0x00)));

		/// <summary>
		/// 构造
		/// </summary>
		public Timeline()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 点击
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);

			int x = e.X;
			int y = e.Y;

			x -= AutoScrollPosition.X;
			int index = x / FRAME_WIDTH;

			if (y > RULER_Height && y < RULER_Height + FRAME_HEIGHT)
			{
				//选定帧
				SAnimationFrame frame = SAnimationDirectionBiz.GetFrameByIndex(currentDirection, index);
				if (frame != null)
				{
					CurrentFrame = frame;
				}
				else
				{
					CurrentFrame = null;
					CurrentFrameIndex = index;
				}
				Invalidate();
			}
			else
			{
				//选定索引
				CurrentFrameIndex = index;
				Invalidate();
			}

			if (AfterSelectedChanged != null) AfterSelectedChanged(this, new EventArgs());
		}


		/// <summary>
		/// 绘制
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);

			int w = 0;
			if (currentDirection != null)
			{
				w = SAnimationDirectionBiz.GetMaxFrame(currentDirection) + 10;
				w *= FRAME_WIDTH;

				if (w != AutoScrollMinSize.Width)
				{
					AutoScrollMinSize = new Size(w, 0);
				}
			}
			else
			{
				return;
			}

			DrawFrames(e);
			DrawRuler(e);
			
		}

		/// <summary>
		/// 绘制标尺
		/// </summary>
		/// <param name="e"></param>
		protected void DrawRuler(PaintEventArgs e)
		{
			Rectangle rect = new Rectangle(0, 0, Width, RULER_Height);
			e.Graphics.FillRectangle(SystemBrushes.Control, rect);

			//当前帧(红线)
			int currentX = CurrentFrameIndex * FRAME_WIDTH + (FRAME_WIDTH / 2);
			currentX += AutoScrollPosition.X;
			e.Graphics.DrawLine(CurrentPen, currentX, 0, currentX, Height);
			//e.Graphics.FillRectangle(CurrentBrush, currentX, RULER_Height - 2, FRAME_WIDTH, 2);


			e.Graphics.DrawLine(SystemPens.ControlDark, 0, rect.Bottom, Width, rect.Bottom);


			int offset = AutoScrollPosition.X % FRAME_WIDTH;
			int x = offset;
			int r = 1;
			int i = 0;
			int y1 = 0;
			int y2 = 0;
			while (true)
			{
				i = ((x - AutoScrollPosition.X) / FRAME_WIDTH);
				if (i % 10 == 0)
				{
					r = 2;
					y1 = RULER_Height;
					//y2 = y1 - RULER_GRID_HEIGHT_2;
					y2 = y1 - RULER_Height;
				}
				else
				{
					r = 1;
					y1 = RULER_Height;
					y2 = y1 - RULER_GRID_HEIGHT_1;
				}

				e.Graphics.DrawLine(SystemPens.ControlDark, x, y1, x, y2);

				if (r == 2)
				{
					TextRenderer.DrawText(e.Graphics, i.ToString(), Font, new Point(x, 0), ForeColor);
				}

				x += FRAME_WIDTH;
				if (x > Width) break;


			}
		}

		/// <summary>
		/// 绘制帧
		/// </summary>
		/// <param name="e"></param>
		protected void DrawFrames(PaintEventArgs e)
		{
			if (currentDirection == null) return;
			foreach (SAnimationFrame frame in currentDirection.Frames)
			{
				DrawFrame(e, frame);
			}
		}


		/// <summary>
		/// 绘制帧
		/// </summary>
		/// <param name="frame"></param>
		protected void DrawFrame(PaintEventArgs e, SAnimationFrame frame)
		{
			Rectangle rect = new Rectangle(frame.Index * FRAME_WIDTH, RULER_Height + 2, FRAME_WIDTH * frame.Length, FRAME_HEIGHT);
			rect.X += AutoScrollPosition.X;
			rect.X += 1;
			rect.Width -= 2;

			if (rect.Right < 0 || rect.Left > Width) return;


			if (frame == CurrentFrame)
			{
				e.Graphics.FillRectangle(SelectedBrush, rect);
				e.Graphics.DrawRectangle(SelectedPen, rect);
			}
			else
			{
				e.Graphics.FillRectangle(NormalBrush, rect);
				e.Graphics.DrawRectangle(NormalPen, rect);
			}
		}


		public void SetCurrentFrameIndex(Int64 frameindex)
		{
			if (currentDirection == null)
			{
				CurrentFrameIndex = 0;
				return;
			}
			if (currentDirection.TotalFrame == 0)
			{
				CurrentFrameIndex = 0;
				return;
			}
			Int64 i = frameindex % currentDirection.TotalFrame;
			CurrentFrameIndex = Convert.ToInt32(i);

			Invalidate();
		}

		public void SetCurrentDirection(SAnimationDirection dir)
		{
			currentDirection = dir;
			CurrentFrameIndex = 0;

			Invalidate();
		}


		/// <summary>
		/// 当前方向
		/// </summary>
		protected SAnimationDirection currentDirection;

		/// <summary>
		/// 当前方向
		/// </summary>
		public SAnimationDirection CurrentDirection
		{
			get
			{
				return currentDirection;
			}
			set
			{
				currentDirection = value;
				this.Invalidate();
			}
		}


		/// <summary>
		/// 当前帧索引
		/// </summary>
		public int CurrentFrameIndex { get; set; }

		/// <summary>
		/// 当前帧
		/// </summary>
		public SAnimationFrame CurrentFrame { get; set; }



		public event EventHandler AfterSelectedChanged;
	}
}
