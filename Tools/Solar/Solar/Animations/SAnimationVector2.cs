using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Animations
{
	public class SAnimationVector2
	{
		public SAnimationVector2()
		{
			X = 0;
			Y = 0;
		}

		public SAnimationVector2(float x, float y)
		{
			X = x;
			Y = y;
		}

		public float X { get; set; }
		public float Y { get; set; }
	}
}
