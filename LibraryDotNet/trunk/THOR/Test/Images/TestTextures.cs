/*
 * TestTextures
 * liuqiang@2015/12/1 16:17:38
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Core;
using THOR.Images.Drawing;
using THOR.Images.Textures;
using THOR.Images.Textures.Readers;
using THOR.Windows.Components.Common;


//---- 8< ------------------

namespace Test.Images
{
	public class TestTextures : ITest
	{
		public void Run(FormMain MainForm)
		{
			string pListFile = @"Z:\Documents\aoe2\world\World\World_4.plist";

			TextureInfo textureInfo = TexturePListReader.Load(pListFile);

			List<string> addPicsList = new List<string>();

			addPicsList.Add("1269:0,0|1270:21,0|1271:56,0|1272:-18,0|1273:-36,0|1274:-64,0|1275:-89,0|1276:-113,0|1277:0,-57|1278:37,-44|1279: -52,-57|1280:-113,-38|1289:0,55|1290:11,53|1291:17,55|1292:-9,55|1293:-16,55|1294:-23,46|1295:-37,49");
			addPicsList.Add("500:-82,-53");
			addPicsList.Add("501:-92,-62");
			addPicsList.Add("502:-92,-62");
			addPicsList.Add("502:-92,-62|503:-92,-49");
			addPicsList.Add("502:-92,-62|504:-92,-50");
			addPicsList.Add("600:-56,41|601:-92,-51");
			addPicsList.Add("602:-65,11|603:-19,61|604:51,55|605:16,-41|606:66,-15");
			addPicsList.Add("607:-19,105|608:-56,44|609:-139,-48|610:-92,-65|611:-1,140");
			addPicsList.Add("700:55,46|705:0,140");
			addPicsList.Add("701:-30,13|702:-126,-47|703:-88,-69|704:-30,-67|705:0,140");

			Image image = new Bitmap(1000, 1000);
			Point zeroPoint = new Point(image.Width / 2, image.Height / 2);
			Graphics g = Graphics.FromImage(image);

			ThorImagePaint.DrawAlpha(g, new Rectangle(0, 0, 1000, 1000));

			foreach (string addPics in addPicsList)
			{
				string[] pics = addPics.Split(new char[1] { '|' });
				foreach (string pic in pics)
				{
					string[] setting = pic.Split(new char[2] { ',', ':' });

					string strId = String.Format("{0}.png", setting[0]);
					int x = Convert.ToInt32(setting[1]);
					int y = -Convert.ToInt32(setting[2]);

					x += zeroPoint.X;
					y += zeroPoint.Y;

					if (!textureInfo.Images.ContainsKey(strId))
					{
						Debug.WriteLine(String.Format("(ERROR) {0} not found !", strId));
						continue;
					}

					TextureImage frame = textureInfo.Images[strId];

					Rectangle rectSrc = new Rectangle();
					Rectangle rectDst = new Rectangle();

					rectSrc.X = frame.Frame.X;
					rectSrc.Y = frame.Frame.Y;
					rectSrc.Width = frame.Frame.Width;
					rectSrc.Height = frame.Frame.Height;

					rectDst.X = x;
					rectDst.Y = y;
					rectDst.Width = rectSrc.Width;
					rectDst.Height = rectSrc.Height;


					rectDst.Y -= frame.Frame.Height;

					g.DrawImage(textureInfo.Image, rectDst, rectSrc, GraphicsUnit.Pixel);
				}
			}

			//System.Windows.Forms.Clipboard.SetImage(image);
			image.Save(@"C:\Docs\temp\test.png");
			
			ThorUI.ShowMessageBox("Completed !");

			g.Dispose();
			image.Dispose();
		}

		public string GetName()
		{
			return this.GetType().Name;
		}
	}
}
