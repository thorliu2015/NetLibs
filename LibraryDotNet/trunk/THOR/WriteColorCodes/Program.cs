using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteColorCodes
{
	class Program
	{
		static void Main(string[] args)
		{

			string drawingPath = @"Z:\Documents\Visual Studio 2012\Projects\SVN\LibraryDotNet\trunk\THOR\THOR.Windows\Components\Drawing";

			WriteThemeClass.Write(Path.Combine(drawingPath, "ThorComponentTheme.cs"));

			WriteColorClass.Write(Path.Combine(drawingPath, "ThorColors.cs"));
			WriteBrushClass.Write(Path.Combine(drawingPath, "ThorBrushs.cs"));
			WritePenClass.Write(Path.Combine(drawingPath, "ThorPens.cs"));
			
		}
	}
}
