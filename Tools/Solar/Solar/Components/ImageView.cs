using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Solar.Images;

namespace Solar.Components
{
	/// <summary>
	/// 图片视图
	/// </summary>
	public partial class ImageView : UserControl
	{

		protected ImageViewStyle CurrentImageViewStyle = ImageViewStyle.Light;

		protected bool redrawImage = true;
		protected bool redrawGrid = true;


		protected Image cacheImage;
		protected Image cacheGrid;

		public int SelectedRow = 0;
		public int SelectedColumn = 0;

		/// <summary>
		/// 构造
		/// </summary>
		public ImageView()
		{
			InitializeComponent();
		}

		public void setRedraw(bool image, bool grid)
		{
			redrawImage = image;
			redrawGrid = grid;
		}

		/// <summary>
		/// 浅色背景
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStyleLight_Click(object sender, EventArgs e)
		{
			btnStyleLight.Checked = true;
			btnStyleDark.Checked = false;
			CurrentImageViewStyle = ImageViewStyle.Light;
			Invalidate();
		}

		/// <summary>
		/// 深色背景
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStyleDark_Click(object sender, EventArgs e)
		{
			btnStyleDark.Checked = true;
			btnStyleLight.Checked = false;
			CurrentImageViewStyle = ImageViewStyle.Dark;
			Invalidate();
		}

		/// <summary>
		/// 绘制背景
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);

			e.Graphics.Clear(CurrentImageViewStyle.BackgroundBrush.Color);

			if (CurrentImage == null || currentImage.ImageSource == null)
			{
				return;
			}


			//cache image
			if (redrawImage || cacheImage == null)
			{
				if (cacheImage != null) cacheImage.Dispose();
				cacheImage = new Bitmap(currentImage.Width + 1, currentImage.Height + 1);
				Graphics g = Graphics.FromImage(cacheImage);

				g.DrawImageUnscaled(currentImage.ImageSource, new Point(0, 0));

				g.Dispose();


				AutoScrollMinSize = new Size(cacheImage.Width, cacheImage.Height);
			}


			//cache grid
			if (redrawGrid || cacheGrid == null)
			{
				if (cacheGrid != null) cacheGrid.Dispose();
				cacheGrid = new Bitmap(currentImage.Width + 1, currentImage.Height + 1);
				Graphics g = Graphics.FromImage(cacheGrid);

				//cache grid
				if (currentImage.Rows < 1) currentImage.Rows = 1;
				if (currentImage.Columns < 1) currentImage.Columns = 1;
				if (currentImage.Rows > currentImage.Height / 2) currentImage.Rows = currentImage.Height / 2;
				if (currentImage.Columns > currentImage.Width / 2) currentImage.Columns = currentImage.Width / 2;

				for (int r = 1; r <= currentImage.Rows; r++)
				{
					g.DrawLine(CurrentImageViewStyle.GridPen, 0, r * currentImage.FrameHeight, cacheImage.Width, r * currentImage.FrameHeight);
				}

				for (int c = 1; c <= currentImage.Columns; c++)
				{
					g.DrawLine(CurrentImageViewStyle.GridPen, c * currentImage.FrameWidth, 0, c * currentImage.FrameWidth, cacheImage.Height);
				}

				if (currentImage.Rows > 1 || currentImage.Columns > 1)
				{

					//cache selected
					if (SelectedRow > currentImage.Rows - 1) SelectedRow = currentImage.Rows - 1;
					if (SelectedColumn > currentImage.Columns - 1) SelectedColumn = currentImage.Columns - 1;
					if (SelectedRow < 0) SelectedRow = 0;
					if (SelectedColumn < 0) SelectedColumn = 0;

					Rectangle rectSelected = new Rectangle(SelectedColumn * currentImage.FrameWidth, SelectedRow * currentImage.FrameHeight, currentImage.FrameWidth, currentImage.FrameHeight);
					g.FillRectangle(CurrentImageViewStyle.SelectedBrush, rectSelected);

					//cache anchor
					int t_ax = currentImage.Anchor.X;
					int t_ay = currentImage.Anchor.Y;

					if (t_ax > currentImage.FrameWidth) t_ax = currentImage.FrameWidth;
					if (t_ay > currentImage.FrameHeight) t_ay = currentImage.FrameHeight;
					if (t_ax < 0) t_ax = 0;
					if (t_ay < 0) t_ay = 0;

					currentImage.Anchor = new Point(t_ax, t_ay);
					

					for (int r = 0; r < currentImage.Rows; r++)
					{
						for (int c = 0; c < currentImage.Columns; c++)
						{
							int ax = c * currentImage.FrameWidth + currentImage.Anchor.X;
							int ay = r * currentImage.FrameHeight + currentImage.Anchor.Y;
							g.DrawLine(CurrentImageViewStyle.AnchorPen, ax - CurrentImageViewStyle.AnchorRadius, ay, ax + CurrentImageViewStyle.AnchorRadius, ay);
							g.DrawLine(CurrentImageViewStyle.AnchorPen, ax, ay - CurrentImageViewStyle.AnchorRadius, ax, ay + CurrentImageViewStyle.AnchorRadius);
						}
					}

				}

				g.Dispose();
			}

			//draw
			Rectangle rectSource = new Rectangle();
			Rectangle rectTarget = new Rectangle();

			rectTarget.X = AutoScrollPosition.X;
			rectTarget.Y = AutoScrollPosition.Y;

			rectSource.Width = rectTarget.Width = cacheImage.Width;
			rectSource.Height = rectTarget.Height = cacheImage.Height;



			e.Graphics.DrawImage(cacheImage, rectTarget, rectSource, GraphicsUnit.Pixel);
			e.Graphics.DrawImage(cacheGrid, rectTarget, rectSource, GraphicsUnit.Pixel);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);


			if (CurrentImage == null) return;

			if (e.Alt && !e.Control && !e.Shift)
			{
				bool c = false;
				switch (e.KeyCode)
				{
					case Keys.Left:
						CurrentImage.Anchor = new Point(CurrentImage.Anchor.X - 1, CurrentImage.Anchor.Y);
						c = true;
						e.Handled = true;
						break;

					case Keys.Right:
						CurrentImage.Anchor = new Point(CurrentImage.Anchor.X + 1, CurrentImage.Anchor.Y);
						c = true;
						e.Handled = true;
						break;

					case Keys.Up:
						CurrentImage.Anchor = new Point(CurrentImage.Anchor.X, CurrentImage.Anchor.Y - 1);
						c = true;
						e.Handled = true;
						break;

					case Keys.Down:
						CurrentImage.Anchor = new Point(CurrentImage.Anchor.X, CurrentImage.Anchor.Y + 1);
						c = true;
						e.Handled = true;
						break;
				}

				if (c)
				{
					CurrentImage.ChangeType |= Data.DataChangeTypes.DataChanged;
					Invalidate();

					if (ParentForm is FrmAbstractModule)
					{
						((FrmAbstractModule)ParentForm).DataChanged = true;
						((FrmAbstractModule)ParentForm).UpdateMainUI();
					}
				}
			}
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);

			if (CurrentImage == null) return;
			if (CurrentImage.Columns == 0 || CurrentImage.Rows == 0) return;
			if (currentImage.Width == 0 || currentImage.Height == 0) return;

			if (e.Button == MouseButtons.Left)
			{
				int x = e.X - AutoScrollPosition.X;
				int y = e.Y - AutoScrollPosition.Y;
				int w = CurrentImage.FrameWidth;
				int h = CurrentImage.FrameHeight;

				x = x / w;
				y = y / h;

				if (x < 0) x = 0;
				if (y < 0) y = 0;
				if (x > CurrentImage.Columns - 1) x = CurrentImage.Columns - 1;
				if (y > CurrentImage.Rows - 1) y = CurrentImage.Rows - 1;

				SelectedRow = y;
				SelectedColumn = x;

				setRedraw(false, true);
				Invalidate();
			}
		}


		protected SImage currentImage;
		public SImage CurrentImage
		{
			get
			{
				return currentImage;
			}
			set
			{
				if (currentImage == value) return;
				currentImage = value;

				setRedraw(true, true);
				Invalidate();
			}
		}



	}
}
