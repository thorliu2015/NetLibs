using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THOR.Images.Core
{
	public interface IImageInfoReader
	{
		void Parse(StreamReader reader, ImageInfo info);
	}
}
