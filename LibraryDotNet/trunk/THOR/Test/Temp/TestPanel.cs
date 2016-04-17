/*
 * TestPanel
 * liuqiang@2015/11/21 13:59:59
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//---- 8< ------------------

namespace Test.Temp
{
	public class TestPanel : Panel
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public TestPanel()
			: base()
		{
			DoubleBuffered = true;
		}

		#endregion

		#region methods

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);

			e.Graphics.Clear(Color.Black);

			if (DesignMode) return;

			Point p = new Point();

			for (int x = 0; x < 100; x++)
			{
				for (int y = 0; y < 100; y++)
				{
					p.X = x * 50 + AutoScrollPosition.X;
					p.Y = y * 50 + AutoScrollPosition.Y;
					TextRenderer.DrawText(e.Graphics, String.Format("{0},{1}", x, y), Font, p, Color.Yellow);
				}
			}
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
