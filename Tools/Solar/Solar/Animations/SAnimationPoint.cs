using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Animations
{
	public class SAnimationPoint : SAnimationVector4
	{
		public SAnimationPoint()
			: base(0, 0, 0, 0)
		{
		}

		public SAnimationPoint(float x, float y, float direction, float distance)
			: base(x, y, direction, distance)
		{
			Vector = new SAnimationVector4();
		}

		public SAnimationVector4 Vector { get; set; }
		public SAnimationDisplayLayer DisplayLayer { get; set; }
	}
}
