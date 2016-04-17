using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.WIC;
using SharpDX.DXGI;

namespace THOR.D2D.Core
{
	/// <summary>
	/// Direct2D 控制器
	/// </summary>
	public class D2DController
	{
		#region constants

		#endregion

		#region variables

		/// <summary>
		/// 是否已经初始化
		/// </summary>
		protected bool _Inittalized = false;

		/// <summary>
		/// 绑定控件
		/// </summary>
		protected System.Windows.Forms.Panel _Target;

		/// <summary>
		/// 渲染属性
		/// </summary>
		protected HwndRenderTargetProperties _Properties;

		/// <summary>
		/// 2D渲染方法
		/// </summary>
		protected WindowRenderTarget _Render2D;

		/// <summary>
		/// Direct2D工厂
		/// </summary>
		protected SharpDX.Direct2D1.Factory _Factory2D;

		/// <summary>
		/// DirectDraw工厂
		/// </summary>
		protected SharpDX.DirectWrite.Factory _FactoryDirectWrite;

		/// <summary>
		/// 图片工厂
		/// </summary>
		protected SharpDX.WIC.ImagingFactory _FactoryImage;

		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		public D2DController()
		{
			_Factory2D = new SharpDX.Direct2D1.Factory();
			_FactoryDirectWrite = new SharpDX.DirectWrite.Factory();
			_FactoryImage = new SharpDX.WIC.ImagingFactory();
		}

		#endregion

		#region methods

		#region 初始化
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="target"></param>
		virtual public void Initialize(System.Windows.Forms.Panel target)
		{
			if (_Inittalized)
			{
				return;
			}

			_Inittalized = true;
			_Target = target;

			_Properties = new HwndRenderTargetProperties();
			_Properties.Hwnd = target.Handle;
			_Properties.PixelSize = new Size2(target.Width, target.Height);
			_Properties.PresentOptions = PresentOptions.None;

			_Render2D = new WindowRenderTarget(
				_Factory2D,
				new RenderTargetProperties(
					new SharpDX.Direct2D1.PixelFormat(
						Format.Unknown,
						AlphaMode.Premultiplied)), _Properties);

			_Render2D.AntialiasMode = AntialiasMode.PerPrimitive;
			_Render2D.StrokeWidth = 1;
			_Target.Resize += _Target_Resize;
		}

		/// <summary>
		/// 控件缩放
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void _Target_Resize(object sender, EventArgs e)
		{
			Target.Invalidate();
			//_Render2D.Resize(new Size2(_Target.Width, _Target.Height));
		}
		#endregion

		#region 绘图

		/// <summary>
		/// 获取颜色
		/// </summary>
		/// <param name="color"></param>
		/// <returns></returns>
		public SharpDX.Color4 GetColor(System.Drawing.Color color)
		{
			uint r = color.R;
			uint g = color.G;
			uint b = color.B;
			uint a = color.A;

			uint c = (a << 24) | (b << 16) | (g << 8) | (r);
			
			return SharpDX.Color.FromRgba(c);
		}

		/// <summary>
		/// 获取颜色
		/// </summary>
		/// <param name="argb"></param>
		/// <returns></returns>
		public SharpDX.Color4 GetColor(uint argb)
		{
			uint a = (argb & 0xFF000000) >> 24;
			uint r = (argb & 0x00FF0000) >> 16;
			uint g = (argb & 0x0000FF00) >> 8;
			uint b = (argb & 0x000000FF);

			uint c = (a << 24) | (b << 16) | (g << 8) | (r);


			return SharpDX.Color.FromRgba(c);
		}

		/// <summary>
		/// 获取颜色
		/// </summary>
		/// <param name="alpha"></param>
		/// <param name="rgb"></param>
		/// <returns></returns>
		public SharpDX.Color4 GetColor(int alpha, int rgb)
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
			
			return GetColor(c);
		}

		/// <summary>
		/// 获取纯色笔刷
		/// </summary>
		/// <param name="argb"></param>
		/// <returns></returns>
		public SolidColorBrush GetSolidColorBrush(uint argb)
		{
			return new SolidColorBrush(_Render2D, GetColor(argb));
		}

		/// <summary>
		/// 获取纯色笔刷
		/// </summary>
		/// <param name="alpha"></param>
		/// <param name="rgb"></param>
		/// <returns></returns>
		public SolidColorBrush GetSolidColorBrush(int alpha, int rgb)
		{
			return new SolidColorBrush(_Render2D, GetColor(alpha, rgb));
		}

		/// <summary>
		/// 获取纯色笔刷
		/// </summary>
		/// <param name="color"></param>
		/// <returns></returns>
		public SolidColorBrush GetSolidColorBrush(System.Drawing.Color color)
		{
			return new SolidColorBrush(_Render2D, GetColor(color));
		}

		#endregion

		#region 图片

		/// <summary>
		/// 加载图片
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		public SharpDX.Direct2D1.Bitmap LoadBitmap(string file)
		{
			if (!_Inittalized) return null;

			BitmapDecoder decoder = new SharpDX.WIC.BitmapDecoder(_FactoryImage, file, SharpDX.IO.NativeFileAccess.Read, SharpDX.WIC.DecodeOptions.CacheOnLoad);
			SharpDX.WIC.BitmapFrameDecode source = decoder.GetFrame(0);
			SharpDX.WIC.FormatConverter converter = new FormatConverter(_FactoryImage);
			converter.Initialize(source, SharpDX.WIC.PixelFormat.Format32bppPBGRA);

			return SharpDX.Direct2D1.Bitmap.FromWicBitmap(_Render2D, converter);
		}

		#endregion



		#endregion

		#region properties

		/// <summary>
		/// 获取绑定控件
		/// </summary>
		public System.Windows.Forms.Panel Target { get { return _Target; } }

		/// <summary>
		/// 获取渲染目标
		/// </summary>
		public WindowRenderTarget WindowRenderTarget { get { return _Render2D; } }

		public SharpDX.Direct2D1.Factory Factory2D { get { return _Factory2D; } }
		public SharpDX.DirectWrite.Factory FactoryWrite { get { return _FactoryDirectWrite; } }
		public SharpDX.WIC.ImagingFactory FactoryImage { get { return _FactoryImage; } }

		#endregion

	}
}
