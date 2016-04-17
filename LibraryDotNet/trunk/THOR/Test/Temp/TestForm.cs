using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.Temp
{
	public partial class TestForm : Form
	{
		public TestForm()
		{
			InitializeComponent();

			
		}

		private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
		{
			Point p = testPanel1.AutoScrollPosition;
			p.Y = vScrollBar1.Value;
			testPanel1.AutoScrollPosition = p;
		}

		private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
		{
			Point p = testPanel1.AutoScrollPosition;
			p.X = hScrollBar1.Value;
			testPanel1.AutoScrollPosition = p;
		}
	}
}
