using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Tiled.Common;
using THOR.Tiled.Diamond;
using THOR.Tiled.Square;
using THOR.Tiled.Staggered;

namespace Test.Tiled
{
	public partial class TestTiledMapControl : UserControl
	{
		public TestTiledMapControl()
		{
			InitializeComponent();

			InitTiledMap();
		}

		//------

		protected const int TILED_ROWS = 20;
		protected const int TILED_COLUMNS = 5;
		protected const int TILED_WIDTH = 40;
		protected const int TILED_HEIGHT = 20;

		protected ITiledCoordinate coordinate;
		protected TileCoordinateGrid grid;

		protected int mouseX = 0;
		protected int mouseY = 0;

		protected void InitTiledMap()
		{
			DoubleBuffered = true;

			//coordinate = new DiamondCoordinate();
			//coordinate.TileSize = new Size(TILED_WIDTH, TILED_HEIGHT);

			coordinate = new StaggeredCoordinate();
			coordinate.TileSize = new Size(TILED_WIDTH, TILED_HEIGHT);

			//coordinate = new SquareCoordinate();
			//coordinate.TileSize = new Size(30, 30);
		}


		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);

			e.Graphics.FillRectangle(SystemBrushes.ControlDarkDark, e.ClipRectangle);
			DrawGrid(e);
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);

			mouseX = e.X - (TILED_ROWS * (TILED_WIDTH / 2));
			mouseY = e.Y - 20;

			//正方形或者交错
			mouseX = e.X;

			this.Invalidate();
		}

		protected virtual void DrawGrid(PaintEventArgs e)
		{
			if (coordinate == null) return;
			if (grid == null)
			{
				grid = coordinate.GetGrid(TILED_ROWS, TILED_COLUMNS);
			}

			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;


			int ox = TILED_ROWS * (TILED_WIDTH / 2);
			int oy = 20;


			//正方形或者交错
			ox = 0;

			Pen p1 = new Pen(new SolidBrush(ColorTranslator.FromHtml("#40000000")));
			Pen p2 = new Pen(new SolidBrush(ColorTranslator.FromHtml("#FF000000")));

			foreach (TileCoordinatedGridLine line in grid.RowLines)
			{
				if (line.Index % 5 == 0 || line.Index == grid.RowLines.Count - 1)
				{
					e.Graphics.DrawLine(p2, line.X1 + ox, line.Y1 + oy, line.X2 + ox, line.Y2 + oy);
				}
				else
				{
					e.Graphics.DrawLine(p1, line.X1 + ox, line.Y1 + oy, line.X2 + ox, line.Y2 + oy);
				}
			}

			foreach (TileCoordinatedGridLine line in grid.ColumnLines)
			{
				if (line.Index % 5 == 0 || line.Index == grid.ColumnLines.Count - 1)
				{
					e.Graphics.DrawLine(p2, line.X1 + ox, line.Y1 + oy, line.X2 + ox, line.Y2 + oy);
				}
				else
				{
					e.Graphics.DrawLine(p1, line.X1 + ox, line.Y1 + oy, line.X2 + ox, line.Y2 + oy);
				}

			}

			Point tiledPosition = coordinate.DisplayToTile(mouseX, mouseY);
			Point isoPosition = coordinate.DisplayToIso(mouseX, mouseY);

			Point tileToDisplayPosition = coordinate.TileToDisplay(tiledPosition.X, tiledPosition.Y);
			Point isoToDisplayPosition = coordinate.IsoToDisplay(isoPosition.X, isoPosition.Y);

			TextRenderer.DrawText(e.Graphics,
				String.Format("display:[{0},{1}], tiled:[{2},{3}], iso:[{4},{5}], t2d:[{6},{7}], i2d:[{8},{9}]",
				mouseX,
				mouseY,
				tiledPosition.X,
				tiledPosition.Y,
				isoPosition.X,
				isoPosition.Y,
				tileToDisplayPosition.X,
				tileToDisplayPosition.Y,
				isoToDisplayPosition.X,
				isoToDisplayPosition.Y
				), Font, new Point(0, 0), SystemColors.ControlLightLight);
		}
	}
}
