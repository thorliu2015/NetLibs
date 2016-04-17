/*
 * AbstractComponentTest
 * liuqiang@2015/11/1 19:06:05
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Core;


//---- 8< ------------------

namespace Test.Components
{
	public class AbstractComponentTest : ITest
	{
		protected PropertyGrid propertyGrid;
		protected FormMain OwnerForm;

		protected bool noDock = false;

		public void Run(FormMain MainForm)
		{
			OwnerForm = MainForm;
			Control control = CreateControl();

			if (control == null) return;

			if (!noDock)
			{
				control.Dock = DockStyle.Fill;
			}
			MainForm.panel2.Controls.Add(control);
			MainForm.propertyGrid1.SelectedObject = control;
		}

		protected virtual Control CreateControl()
		{
			return new Button();
		}

		public virtual string GetName()
		{
			return this.GetType().Name;
		}

	}
}
