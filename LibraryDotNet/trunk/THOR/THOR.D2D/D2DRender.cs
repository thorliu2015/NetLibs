/*
 * D2DRender
 * liuqiang@2015/12/15 11:49:42
 * ---- 8< ------------------
 * NOTE
 */

using SharpDX.Direct2D1;
using SharpDX.DXGI;
using SharpDX.WIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//---- 8< ------------------

namespace THOR.D2D
{
	/// <summary>
	/// 渲染器
	/// </summary>
	public class D2DRender
	{
		#region constants

		#endregion

		#region variables

		protected bool _Initialized = false;
		protected HwndRenderTargetProperties _RenderTargetProperties;
		protected WindowRenderTarget _RenderTarget;
		protected Control _Target;

		protected SharpDX.Direct2D1.Factory _Factory2D;
		protected SharpDX.DirectWrite.Factory _FactoryDW;
		protected SharpDX.WIC.ImagingFactory _FactoryImage;

		public bool Disposed { get; protected set; }

		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		public D2DRender()
		{
			_Factory2D = new SharpDX.Direct2D1.Factory();
			_FactoryDW = new SharpDX.DirectWrite.Factory();
			_FactoryImage = new SharpDX.WIC.ImagingFactory();
		}

		#endregion

		#region methods

		public virtual void Dispose()
		{
			Disposed = true;

			if (_RenderTarget != null)
			{
				_RenderTarget.Dispose();
			}

			if (_Factory2D != null)
			{
				_Factory2D.Dispose();
			}

			if (_FactoryDW != null)
			{
				_FactoryDW.Dispose();
			}

			if (_FactoryImage != null)
			{
				_FactoryImage.Dispose();
			}
		}

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="target"></param>
		public virtual void Initialize(Control target)
		{
			if (target == null) return;
			if (target.IsDisposed) return;

			if (_Initialized) return;

			_Initialized = true;
			_Target = target;

			_RenderTargetProperties = new HwndRenderTargetProperties();
			_RenderTargetProperties.Hwnd = target.Handle;
			_RenderTargetProperties.PixelSize = new SharpDX.Size2(target.Width, target.Height);
			_RenderTargetProperties.PresentOptions = PresentOptions.Immediately;



			_RenderTarget = new WindowRenderTarget(
				_Factory2D,
				new RenderTargetProperties(
					new SharpDX.Direct2D1.PixelFormat(
						Format.Unknown,
						AlphaMode.Premultiplied)),
						_RenderTargetProperties);

			_RenderTarget.AntialiasMode = AntialiasMode.PerPrimitive;
			_RenderTarget.TextAntialiasMode = TextAntialiasMode.Grayscale;
			_RenderTarget.StrokeWidth = 1.2f;
		}


		/// <summary>
		/// 加载图片
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		public SharpDX.Direct2D1.Bitmap LoadBitmap(string file)
		{
			if (Disposed) return null;
			if (!_Initialized) return null;

			BitmapDecoder decoder = new SharpDX.WIC.BitmapDecoder(_FactoryImage, file, SharpDX.IO.NativeFileAccess.Read, SharpDX.WIC.DecodeOptions.CacheOnLoad);
			SharpDX.WIC.BitmapFrameDecode source = decoder.GetFrame(0);
			SharpDX.WIC.FormatConverter converter = new FormatConverter(_FactoryImage);
			converter.Initialize(source, SharpDX.WIC.PixelFormat.Format32bppPBGRA);

			SharpDX.Direct2D1.Bitmap bmp = SharpDX.Direct2D1.Bitmap.FromWicBitmap(_RenderTarget, converter);
			source.Dispose();
			converter.Dispose();
			decoder.Dispose();
			return bmp;
		}

		#region 颜色值

		/// <summary>
		/// 获取网页代码指定的颜色
		/// </summary>
		/// <param name="color"></param>
		/// <returns></returns>
		public SharpDX.Color4 GetColor4(string color)
		{
			return GetColor4(System.Drawing.ColorTranslator.FromHtml(color));
		}

		/// <summary>
		/// 获取颜色
		/// </summary>
		/// <param name="color"></param>
		/// <returns></returns>
		public SharpDX.Color4 GetColor4(System.Drawing.Color color)
		{
			uint r = color.R;
			uint g = color.G;
			uint b = color.B;
			uint a = color.A;

			uint c = (a << 24) | (b << 16) | (g << 8) | (r);

			return SharpDX.Color.FromRgba(c);
		}

		/// <summary>
		/// 获取指定颜色值的颜色
		/// </summary>
		/// <param name="argb"></param>
		/// <returns></returns>
		public SharpDX.Color4 GetColor4(uint argb)
		{
			uint a = (argb & 0xFF000000) >> 24;
			uint r = (argb & 0x00FF0000) >> 16;
			uint g = (argb & 0x0000FF00) >> 8;
			uint b = (argb & 0x000000FF);

			uint c = (a << 24) | (b << 16) | (g << 8) | (r);


			return SharpDX.Color.FromRgba(c);
		}


		/// <summary>
		/// 获取指定透明度的颜色
		/// </summary>
		/// <param name="alpha"></param>
		/// <param name="rgb"></param>
		/// <returns></returns>
		public SharpDX.Color4 GetColor4(int alpha, int rgb)
		{
			double a = alpha;
			a = a / 100;
			a = a * 255;

			uint aa = Convert.ToUInt32(a);
			uint u_rgb = Convert.ToUInt32(rgb);

			uint r = (u_rgb & 0xFF0000) >> 16;
			uint g = (u_rgb & 0x00FF00) >> 8;
			uint b = (u_rgb & 0x0000FF);

			uint c = (aa << 24) | (r << 16) | (g << 8) | (b);

			return GetColor4(c);
		}

		#endregion

		#region 笔刷

		/// <summary>
		/// 获取纯色笔刷
		/// </summary>
		/// <param name="color"></param>
		/// <returns></returns>
		public SolidColorBrush GetSolidColorBrush(string color)
		{
			return new SolidColorBrush(_RenderTarget, GetColor4(color));
		}

		/// <summary>
		/// 获取纯色笔刷
		/// </summary>
		/// <param name="color"></param>
		/// <param name="alpha"></param>
		/// <returns></returns>
		public SolidColorBrush GetSolidColorBrush(string color, float alpha)
		{
			if (alpha <= 0) alpha = 0;
			if (alpha > 1) alpha = 1;
			int a = Convert.ToInt32(0xFF * alpha);

			System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml(color);
			c = System.Drawing.Color.FromArgb(a, c);

			return GetSolidColorBrush(c);
		}

		/// <summary>
		/// 获取纯色笔刷
		/// </summary>
		/// <param name="argb"></param>
		/// <returns></returns>
		public SolidColorBrush GetSolidColorBrush(uint argb)
		{
			return new SolidColorBrush(_RenderTarget, GetColor4(argb));
		}

		/// <summary>
		/// 获取纯色笔刷
		/// </summary>
		/// <param name="alpha"></param>
		/// <param name="rgb"></param>
		/// <returns></returns>
		public SolidColorBrush GetSolidColorBrush(int alpha, int rgb)
		{
			return new SolidColorBrush(_RenderTarget, GetColor4(alpha, rgb));
		}

		/// <summary>
		/// 获取纯色笔刷
		/// </summary>
		/// <param name="color"></param>
		/// <returns></returns>
		public SolidColorBrush GetSolidColorBrush(System.Drawing.Color color)
		{
			return new SolidColorBrush(_RenderTarget, GetColor4(color));
		}

		#endregion

		#endregion

		#region properties

		public WindowRenderTarget RenderTarget { get { return _RenderTarget; } }
		public SharpDX.Direct2D1.Factory Factory2D { get { return _Factory2D; } }
		public SharpDX.DirectWrite.Factory FactoryDirectWrite { get { return _FactoryDW; } }
		public SharpDX.WIC.ImagingFactory FactoryImage { get { return _FactoryImage; } }

		#endregion

		#region events

		#endregion
	}
}
