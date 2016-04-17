/*
 * TestBWImageToAlpha
 * liuqiang@2015/11/21 22:56:44
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Test.Core;


//---- 8< ------------------

namespace Test.Images
{
	public class TestBWImageToAlpha : ITest
	{
		
		public void Run(FormMain MainForm)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "*.png|*.png";
			if (dialog.ShowDialog() == DialogResult.Cancel) return;

			Bitmap bmp = (Bitmap)Image.FromFile(dialog.FileName);

			for (int x = 0; x < bmp.Width; x++)
			{
				for (int y = 0; y < bmp.Height; y++)
				{
					Color colorSrc = bmp.GetPixel(x, y);
					int a = (colorSrc.R + colorSrc.G + colorSrc.B) / 3;
					Color colorDst = Color.FromArgb(a, 0xFF, 0xFF, 0xFF);
					bmp.SetPixel(x, y, colorDst);
				}
			}

			SaveFileDialog dialog2 = new SaveFileDialog();
			dialog2.Filter = "*.png|*.png";
			if (dialog2.ShowDialog() != DialogResult.Cancel)
			{
				bmp.Save(dialog2.FileName);
			}

			bmp.Dispose();
		}

		public string GetName()
		{
			return this.GetType().Name;
		}
	}
}
