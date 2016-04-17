/*
 * FrameworkElement
 * liuqiang@2016/1/22 13:44:13
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.Editors.UI.Frameworks.Core.Params;


//---- 8< ------------------

namespace THOR.Windows.Editors.UI.Frameworks.Core
{
	public class FrameworkElement : UIElement
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public FrameworkElement()
			: base()
		{
			MinWidth = new Distance() { Amount = 0, Unit = DistanceUnits.Pixels };
			MaxWidth = new Distance() { Amount = int.MaxValue, Unit = DistanceUnits.Pixels };

			MinHeight = new Distance() { Amount = 0, Unit = DistanceUnits.Pixels };
			MaxHeight = new Distance() { Amount = int.MaxValue, Unit = DistanceUnits.Pixels };

			Padding = new Padding()
			{
				Left = new Distance() { Amount = 0, Unit = DistanceUnits.Pixels },
				Right = new Distance() { Amount = 0, Unit = DistanceUnits.Pixels },
				Top = new Distance() { Amount = 0, Unit = DistanceUnits.Pixels },
				Bottom = new Distance() { Amount = 0, Unit = DistanceUnits.Pixels }
			};

			Margin = new Padding()
			{
				Left = new Distance() { Amount = 0, Unit = DistanceUnits.Pixels },
				Right = new Distance() { Amount = 0, Unit = DistanceUnits.Pixels },
				Top = new Distance() { Amount = 0, Unit = DistanceUnits.Pixels },
				Bottom = new Distance() { Amount = 0, Unit = DistanceUnits.Pixels }
			};

			HorizontalAlignment = Params.HorizontalAlignment.Left;
			VerticalAlignment = Params.VerticalAlignment.Top;
		}


		#endregion

		#region methods

		#endregion

		#region properties

		public Distance MinWidth { get; set; }
		public Distance MaxWidth { get; set; }

		public Distance MinHeight { get; set; }
		public Distance MaxHeight { get; set; }

		public Padding Padding { get; set; }
		public Padding Margin { get; set; }

		public HorizontalAlignment HorizontalAlignment { get; set; }
		public VerticalAlignment VerticalAlignment { get; set; }

		#endregion

		#region events

		#endregion
	}
}
