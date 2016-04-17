using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Solar.Dialogs
{
	public partial class DialogObjectProperty : THOR.Windows.UI.Forms.ToolBoxBase
	{
		public DialogObjectProperty()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 标题文本
		/// </summary>
		public string Title
		{
			get
			{
				return panelMain.Title;
			}
			set
			{
				panelMain.Title = value;
			}
		}

		/// <summary>
		/// 当前对象
		/// </summary>
		public object CurrentObject
		{
			get
			{
				return propertyGrid.SelectedObject;
			}
			set
			{
				propertyGrid.SelectedObject = value;
			}
		}
	}
}
