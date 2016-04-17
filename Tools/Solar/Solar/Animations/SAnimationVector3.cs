using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Animations
{
	public class SAnimationVector3 : SAnimationVector2
	{
		public SAnimationVector3()
		{
			X = 0;
			Y = 0;
			Direction = 0;
		}

		public SAnimationVector3(float x, float y, float direction) : base(x,y)
		{
			Direction = direction;
		}

		public float Direction { get; set; }
	}
}
