/*
 * TestThorListBox
 * liuqiang@2015/11/13 11:18:11
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.Components.Common;
using THOR.Windows.Components.ThorGrids.ThorList;


//---- 8< ------------------

namespace Test.Components
{
	public class TestThorListBox : AbstractComponentTest
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		protected override System.Windows.Forms.Control CreateControl()
		{
			//List<int> list = new List<int>();
			//for (int i = 0; i < 100; i++)
			//{
			//	list.Add(i + 1);
			//}

			List<TEST_THOR_LIST_BOX_DATA> list = new List<TEST_THOR_LIST_BOX_DATA>();

			for (int i = 0; i < 200; i++)
			{
				list.Add(new TEST_THOR_LIST_BOX_DATA() { Id = i + 1, Name = String.Format("Item {0}", i + 1) });
			}
			ThorListBox listBox = new ThorListBox();
			listBox.ListItemDisplayName = "Name";
			listBox.ListItems = list;
			listBox.SelectionChanged += listBox_SelectionChanged;
			return listBox;
		}

		void listBox_SelectionChanged(object sender, EventArgs e)
		{
			ThorListBox listBox = (ThorListBox)sender;
			//ThorUI.ShowMessageBox(String.Format("{0} Items", listBox.SelectedObjects.Count));

		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}

	public class TEST_THOR_LIST_BOX_DATA
	{
		public TEST_THOR_LIST_BOX_DATA()
		{
		}

		public int Id { get; set; }
		public string Name { get; set; }
	}
}
