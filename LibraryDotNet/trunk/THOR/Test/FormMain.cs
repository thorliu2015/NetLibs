using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Test.Core;
using Test.Attributes;
using Test.XmlEntities;
using Test.Components;
using Test.Data;
using THOR.Windows.Dialogs;
using THOR.Windows.Components.Common;
using THOR.Windows.Utils;
using Test.ThorGrids;
using Test.Fields;
using THOR.Windows.Components.Tools;
using THOR.Windows.Editors.Common.Dialogs;
using THOR.Windows.Components.ThorGrids.Core;
using THOR.Windows.Components.Drawing;
using Test.Temp;
using Test.Images;
using Test.Tiled;
using THOR.Windows.Components.ThorGrids.ThorPropertyGrid;
using Test.Excels;
using THOR.D2D;
using System.Xml;
using THOR.Windows.Components.D2D;

namespace Test
{
	public partial class FormMain : FlatForm
	{
		public FormMain()
		{
			InitializeComponent();

		


			//FlatSplash splash = new FlatSplash();
			//splash.Show();

			//new FrmAbstractModule().Show();

			this.panel1.BackColor =
			this.panel2.BackColor = Color.FromArgb(0x444444);
			this.WindowState = FormWindowState.Maximized;
			//_ThemeColor = ColorTranslator.FromHtml("#FF0099");
			this.Text = "THOR.dll Tests";

			//----

			AddTestModule("Common", new TestSimpleComponent(new ThorButton()));
			AddTestModule("Common", new TestSimpleComponent(new ThorBox()));
			AddTestModule("Common", new TestSimpleComponent(new ThorPanel()));
			AddTestModule("Common", new TestSimpleComponent(new ThorSplitter()));
			AddTestModule("Common", new TestSimpleComponent(new ThorBand()));
			AddTestModule("Common", new TestSimpleComponent(new ThorFlatButton()));
			AddTestModule("Common", new TestSimpleComponent(new ThorLabel()));

			AddTestModule("Fields", new TestThorTextField());
			AddTestModule("Fields", new TestThorNumbericField());
			AddTestModule("Fields", new TestThorComboBox());


			AddTestModule("Tools", new TestSimpleComponent(new ThorToolBar()));
			AddTestModule("Tools", new TestSimpleComponent(new ThorStatusBar()));


			AddTestModule("Scrolls", new TestSimpleComponent(new ThorHScrollBar() { Maximum = 2000 }));
			AddTestModule("Scrolls", new TestSimpleComponent(new ThorVScrollBar() { Maximum = 2000 }));
			AddTestModule("Scrolls", new TestThorListBox());
			AddTestModule("Scrolls", new TestThorTreeView());
			AddTestModule("Scrolls", new TestThorGrid());
			AddTestModule("Scrolls", new TestThorPropertyGrid(), true);

			AddTestModule("Images", new TestBWImageToAlpha());
			AddTestModule("Images", new TestTextures());
			AddTestModule("Images", new TestImageInfo());
			

			AddTestModule("Tiled", new TestTiledMap());

			AddTestModule("Data", new TestThorTypeConverter());
			AddTestModule("Data", new TestExcel());
			AddTestModule("Data", new TestPList());
			AddTestModule("Data", new TestCommonParams());

			AddTestModule("DirectX", new TestSimpleComponent(
				new ThorDirect2DView()
				{
					Canvas = new Direct2DCanvas()
					{
						RenderMethod = new Direct2DRenderMethod()
					}
				}));


			if (FirstTest != null)
			{
				FirstTest.Run(this);
			}
		}

		#region Test Modules

		protected ITest FirstTest = null;
		protected Dictionary<string, ToolStripMenuItem> categories = new Dictionary<string, ToolStripMenuItem>();

		protected void AddTestModule(string category, ITest test, bool isFirstTest = false)
		{
			if (isFirstTest) FirstTest = test;

			if (!categories.ContainsKey(category))
			{
				ToolStripMenuItem menu = new ToolStripMenuItem();
				menu.Text = category;
				categories[category] = menu;
				menuDemos.DropDownItems.Add(menu);
			}

			ToolStripMenuItem menuCategory = categories[category];

			ToolStripMenuItem menuTest = new ToolStripMenuItem();
			menuTest.Text = test.GetName();
			menuTest.Click += menuTest_Click;
			menuTest.Tag = test;
			menuCategory.DropDownItems.Add(menuTest);
		}

		protected void menuTest_Click(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem)
			{
				ToolStripMenuItem menuTest = (ToolStripMenuItem)sender;
				if (menuTest.Tag is ITest)
				{
					panel2.Controls.Clear();
					ITest test = (ITest)menuTest.Tag;
					this.Text = test.GetName();
					this.Invalidate();
					test.Run(this);
				}
			}
		}
		#endregion


	}
}
