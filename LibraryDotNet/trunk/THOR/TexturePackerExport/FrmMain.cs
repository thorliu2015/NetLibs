using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using THOR.Images.Textures;
using THOR.Images.Textures.Readers;

namespace TexturePackerExport
{
	public partial class FrmMain : THOR.Windows.Dialogs.FlatForm
	{
		/// <summary>
		/// 构造
		/// </summary>
		public FrmMain()
		{
			InitializeComponent();

			InitForm();
		}

		/// <summary>
		/// 初始化
		/// </summary>
		protected virtual void InitForm()
		{

			this.Text = String.Format("{0} {1}", Application.ProductName, Application.ProductVersion);
			Screen scr = Screen.FromControl(this);
			this.Location = new Point((scr.WorkingArea.Width - Width) / 2, (scr.WorkingArea.Height - Height) / 2);
		}


		/// <summary>
		/// 浏览纹理图片
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnBrowseTextureFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Texture File (*.png)|*.png";
			if (dialog.ShowDialog(this) == DialogResult.Cancel) return;

			txtTextureFile.TextBox.Text = dialog.FileName;
		}

		/// <summary>
		/// 浏览纹理信息
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnBrowsePListFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Texture Info File (*.plist)|*.plist";
			if (dialog.ShowDialog(this) == DialogResult.Cancel) return;

			txtPListFile.TextBox.Text = dialog.FileName;
		}

		/// <summary>
		/// 导出帧
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnExport_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			if (dialog.ShowDialog(this) == DialogResult.Cancel) return;

			TextureInfo textureInfo = TexturePListReader.Load(txtPListFile.TextBox.Text);

			foreach (string key in textureInfo.Images.Keys)
			{
				TextureImage image = textureInfo.Images[key];

				Bitmap bmp = new Bitmap(image.SourceSize.Width, image.SourceSize.Height);
				Graphics g = Graphics.FromImage(bmp);

				Rectangle srcRect = image.Frame;
				Rectangle dstRect = new Rectangle(0, 0, srcRect.Width, srcRect.Height);

				dstRect.X += image.SourceColorRect.X;
				dstRect.Y += image.SourceColorRect.Y;

				g.DrawImage(textureInfo.Image, dstRect, srcRect, GraphicsUnit.Pixel);

				string bmpFile = Path.Combine(dialog.SelectedPath, key);



				bmp.Save(bmpFile);

				g.Dispose();
				bmp.Dispose();
			}
		}
	}
}
