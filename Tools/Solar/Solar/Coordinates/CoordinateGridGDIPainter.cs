using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Solar.Coordinates
{
	public class CoordinateGridGDIPainter : ICoordinateGridPainter
	{
		public CoordinateGridGDIPainter()
		{
			Rows = 0;
			Columns = 0;

			OffsetX = 0;
			OffsetY = 0;

			GridColor = Color.FromArgb(0x66, Color.White);
			Grid5Color = Color.FromArgb(0x99, Color.White);
			Grid10Color = Color.FromArgb(0xCC, Color.White);
			BorderColor = Color.FromArgb(0xFF, Color.Yellow);
		}


		public void Draw(Graphics g)
		{
			if (Coordinate == null) return;
			if (Rows <= 0 || Columns <= 0) return;

			List<int> x1 = new List<int>();
			List<int> x2 = new List<int>();
			List<int> y1 = new List<int>();
			List<int> y2 = new List<int>();

			List<int> x3 = new List<int>();
			List<int> y3 = new List<int>();
			List<int> x4 = new List<int>();
			List<int> y4 = new List<int>();

			Coordinate.GetGridPoints(Rows, Columns, x1, x2, x3, x4, y1, y2, y3, y4);

			Pen borderPen = new Pen(new SolidBrush(BorderColor));
			Pen gridPen = new Pen(new SolidBrush(GridColor));
			Pen grid5Pen = new Pen(new SolidBrush(Grid5Color));
			Pen grid10Pen = new Pen(new SolidBrush(Grid10Color));

			Pen pen = gridPen;

			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			for (int i = 0; i <= Rows; i++)
			{
				if (i == 0 || i == Rows) pen = borderPen;
				else if (Rows < 10) pen = gridPen;
				else if (i % 10 == 0) pen = grid10Pen;
				else if (i % 5 == 0) pen = grid5Pen;
				else pen = gridPen;

				g.DrawLine(pen,
					x1[i] + OffsetX,
					y1[i] + OffsetY,
					x2[i] + OffsetX,
					y2[i] + OffsetY);
			}

			for (int i = 0; i <= Columns; i++)
			{
				if (i == 0 || i == Columns) pen = borderPen;
				else if (Columns < 10) pen = gridPen;
				else if (i % 10 == 0) pen = grid10Pen;
				else if (i % 5 == 0) pen = grid5Pen;
				else pen = gridPen;

				g.DrawLine(pen,
					x3[i] + OffsetX,
					y3[i] + OffsetY,
					x4[i] + OffsetX,
					y4[i] + OffsetY);
			}
		}

		public ICoordinate Coordinate { get; set; }

		public int OffsetX { get; set; }

		public int OffsetY { get; set; }

		public int Rows { get; set; }

		public int Columns { get; set; }

		public Color BorderColor { get; set; }

		public Color GridColor { get; set; }

		public Color Grid5Color { get; set; }

		public Color Grid10Color { get; set; }
	}
}
