using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Animations
{
	public class SAnimationVector4 : SAnimationVector3
	{
		public SAnimationVector4()
		{
			X = 0;
			Y = 0;
			Distance = 0;
			Direction = 0;
		}

		public SAnimationVector4(float x, float y, float direction, float distance)
			: base(x, y, direction)
		{
			Distance = distance;
		}

		public float Distance { get; set; }
	}
}
