using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THOR.ConsoleGUI.Core
{
	public class ConsoleCommandOutputColors
	{

		static public ConsoleCommandOutputColors Current { get; protected set; }

		static ConsoleCommandOutputColors()
		{
			Current = new ConsoleCommandOutputColors();
		}

		private ConsoleCommandOutputColors()
		{
			Red = ColorTranslator.FromHtml("#FF6600");
			Green = ColorTranslator.FromHtml("#66FF00");
			Blue = ColorTranslator.FromHtml("#0066FF");
			Yellow = ColorTranslator.FromHtml("#FFCC00");
			Purple = ColorTranslator.FromHtml("#FF0066");
			White = ColorTranslator.FromHtml("#FFFFFF");
			Secondary = ColorTranslator.FromHtml("#444444");
			Normal = ColorTranslator.FromHtml("#999999");

			Error = Red;
			Command = Green;
		}

		public Color Command { get; set; }
		public Color Error { get; set; }
		public Color Normal { get; set; }
		public Color Secondary { get; set; }
		public Color Red { get; set; }
		public Color Green { get; set; }
		public Color Blue { get; set; }
		public Color Yellow { get; set; }
		public Color Purple { get; set; }
		public Color White { get; set; }
	}
}
