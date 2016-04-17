using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace THOR.Utils.Attributes.PropertyGrids
{
	public class EnumCheckerEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}

		public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
		{

			IWindowsFormsEditorService editorService = null;
			if (provider != null)
			{
				editorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
			}

			if (editorService != null)
			{
				EnumChecker checker = new EnumChecker();
				checker.EnumValue = value;
				editorService.DropDownControl(checker);
				value = checker.EnumValue;
			}

			return value;
		}
	}
}
