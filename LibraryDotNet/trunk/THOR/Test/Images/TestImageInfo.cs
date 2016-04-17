/*
 * TestImageInfo
 * liuqiang@2015/12/12 10:46:49
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Core;
using THOR.Images.Core;


//---- 8< ------------------

namespace Test.Images
{
	public class TestImageInfo : ITest
	{

		public void Run(FormMain MainForm)
		{
			string filename = @"Z:\Documents\temp\png8.png";

			ImageInfo imgInfo = ImageFileUtils.LoadImageInfo(filename);
		}

		public string GetName()
		{
			return this.GetType().Name;
		}
	}
}
