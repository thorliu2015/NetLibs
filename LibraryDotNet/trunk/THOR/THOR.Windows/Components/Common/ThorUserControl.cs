using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Windows.Components.Drawing;

namespace THOR.Windows.Components.Common
{
	public partial class ThorUserControl : UserControl
	{
		public ThorUserControl()
		{
			InitializeComponent();
			InitUserControl();
		}

		protected Color GetThemeColor()
		{
			return ThorColors.Focus;
		}

		protected virtual void InitUserControl()
		{
			DoubleBuffered = true;
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
			DrawBackground(e);
		}

		protected virtual void DrawBackground(PaintEventArgs e)
		{
			e.Graphics.FillRectangle(ThorBrushs.Control, e.ClipRectangle);
		}
	}
}
