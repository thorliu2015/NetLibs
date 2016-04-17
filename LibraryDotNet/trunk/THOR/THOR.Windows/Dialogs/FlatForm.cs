using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Windows.Components.Common;
using THOR.Windows.Components.Drawing;
using THOR.Windows.Properties;

namespace THOR.Windows.Dialogs
{
	/// <summary>
	/// 扁平化窗体
	/// </summary>
	public partial class FlatForm : Form
	{
		#region constants

		protected int FLAT_FORM_BORDER = 3;
		protected int FLAT_FORM_TITLE = 24;

		protected int FLAT_FORM_BUTTON_WIDTH = 34;
		protected int FLAT_FORM_BUTTON_HEIGHT = 24;


		#endregion

		#region variables

		protected bool focusIn = false;
		protected int hoverButtonIndex = -1;
		protected bool canResize = true;
		protected bool canMove = true;

		#endregion

		#region construct

		public FlatForm()
		{
			InitializeComponent();
			Init();
		}

		#endregion

		#region methods

		#region 基础

		/// <summary>
		/// 初始化窗体
		/// </summary>
		virtual protected void Init()
		{
			DoubleBuffered = true;
			SetStyle(ControlStyles.UserPaint |
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.OptimizedDoubleBuffer |
				ControlStyles.ResizeRedraw |
				ControlStyles.OptimizedDoubleBuffer, true);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			Padding = new Padding(FLAT_FORM_BORDER, FLAT_FORM_BORDER + FLAT_FORM_TITLE, FLAT_FORM_BORDER, FLAT_FORM_BORDER);
			UpdateMaxScreen();
			this.StartPosition = FormStartPosition.CenterScreen;
		}


		/// <summary>
		/// 更新全屏时的尺寸
		/// </summary>
		virtual protected void UpdateMaxScreen()
		{
			Screen screen = Screen.FromControl(this);
			this.MaximizedBounds = screen.WorkingArea;
		}

		/// <summary>
		/// 窗体移动时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMove(EventArgs e)
		{
			base.OnMove(e);
			UpdateMaxScreen();
		}

		/// <summary>
		/// 获得焦点后
		/// </summary>
		/// <param name="e"></param>
		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
			focusIn = true;
			Invalidate();
			if (skin != null) skin.Main_SizeChanged(this, new EventArgs());
		}

		/// <summary>
		/// 失去焦点后
		/// </summary>
		/// <param name="e"></param>
		protected override void OnDeactivate(EventArgs e)
		{
			base.OnDeactivate(e);
			focusIn = false;
			Invalidate();
			if (skin != null) skin.Main_SizeChanged(this, new EventArgs());
		}

		/// <summary>
		/// 加载窗体时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (DisableSkinForm)
			{
				Win32.EnabledDropShadow(this.Handle);
			}
		}

		/// <summary>
		/// 缩放时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Invalidate();
		}

		/// <summary>
		/// 绘制背景
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
			DrawForm(e);
		}

		virtual protected void DrawTitleText(PaintEventArgs e)
		{
			//title
			Rectangle rectTitle = MeasureFormTitleRect();

			rectTitle.X += 10;
			rectTitle.Width -= 10;

			Rectangle rectShadow = new Rectangle(rectTitle.X, rectTitle.Y, rectTitle.Width, rectTitle.Height);
			rectShadow.X++;
			rectShadow.Y++;

			Font tFont = new Font(Font, FontStyle.Bold);



			TextFormatFlags tf = TextFormatFlags.EndEllipsis | TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
			TextRenderer.DrawText(e.Graphics, this.Text, tFont, rectShadow, ThorColors.WindowTextShadow, tf);
			TextRenderer.DrawText(e.Graphics, this.Text, tFont, rectTitle, focusIn ?
				((_ThemeColor != Color.Transparent) ? _ThemeColor : ThorColors.Focus)
				:
				ThorColors.WindowText
				, tf);
		}

		virtual protected void DrawButtons(PaintEventArgs e)
		{
			//buttons
			Rectangle rectButtons = MeasureFormButtonsRect();
			List<Image> buttonIcons = new List<Image>();

			bool isMaxState = (this.WindowState == FormWindowState.Maximized);

			if (ThorComponentTheme.Current.Theme != ThorComponentThemes.Dark)
			{
				if (this.MinimizeBox) buttonIcons.Add(Resources.FormMinB);
				if (this.MaximizeBox)
				{
					if (isMaxState)
					{
						buttonIcons.Add(Resources.FormRestoreB);
					}
					else
					{
						buttonIcons.Add(Resources.FormMaxB);
					}
				}
				buttonIcons.Add(Resources.FormCloseB);
			}
			else
			{
				if (this.MinimizeBox) buttonIcons.Add(Resources.FormMinW);
				if (this.MaximizeBox)
				{
					if (isMaxState) 
					{
						buttonIcons.Add(Resources.FormRestoreW);
					}
					else
					{
						buttonIcons.Add(Resources.FormMaxW);
					}
				}
				buttonIcons.Add(Resources.FormCloseW);
			}

			Rectangle rect = new Rectangle();
			rect.Width = FLAT_FORM_BUTTON_WIDTH;
			rect.Height = FLAT_FORM_BUTTON_HEIGHT;
			rect.Y = 1;
			rect.X = Width - 1;
			rect.X -= buttonIcons.Count * FLAT_FORM_BUTTON_WIDTH;

			for (int i = 0; i < buttonIcons.Count; i++)
			{
				if (i == hoverButtonIndex)
				{
					ThorControlPaint.DrawFlatButton(e.Graphics, rect, ThorButtonState.Hover, true, false);
				}
				else
				{
					ThorControlPaint.DrawFlatButton(e.Graphics, rect, ThorButtonState.Normal, true, false);
				}
				ThorControlPaint.DrawIcon(e.Graphics, rect, buttonIcons[i]);
				rect.X += FLAT_FORM_BUTTON_WIDTH;
				//Debug.WriteLine(String.Format("[{0}]: x:{1}, y:{2}, w:{3}, h:{4}", i, rect.X, rect.Y, rect.Width, rect.Height));
			}
		}

		/// <summary>
		/// 绘制窗体背景
		/// </summary>
		/// <param name="e"></param>
		virtual protected void DrawFormBackground(PaintEventArgs e)
		{
			ThorControlPaint.DrawForm(e.Graphics, Bounds, focusIn, this, WindowState != FormWindowState.Normal);
		}

		/// <summary>
		/// 绘制窗体
		/// </summary>
		/// <param name="e"></param>
		virtual protected void DrawForm(PaintEventArgs e)
		{
			DrawFormBackground(e);
			DrawTitleText(e);
			DrawButtons(e);
		}

		/// <summary>
		/// 测试窗体按钮
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		virtual protected void HitFormButtons(int x, int y)
		{
			hoverButtonIndex = -1;

			Rectangle rect = MeasureFormButtonsRect();
			int buttonsCount = MeasureFormButtonCount();

			Rectangle rectButton = new Rectangle();

			rectButton.Width = FLAT_FORM_BUTTON_WIDTH;
			rectButton.Height = FLAT_FORM_BUTTON_HEIGHT;
			rectButton.X = rect.X;
			rectButton.Y = rect.Y;
			for (int i = 0; i < buttonsCount; i++)
			{
				if (rectButton.Contains(x, y))
				{
					hoverButtonIndex = i;
					break;
				}

				rectButton.X += FLAT_FORM_BUTTON_WIDTH;
			}
		}

		/// <summary>
		/// 计算按钮位置
		/// </summary>
		/// <returns></returns>
		virtual protected Rectangle MeasureFormButtonsRect()
		{
			Rectangle rect = new Rectangle();

			rect.Width = FLAT_FORM_BUTTON_WIDTH * MeasureFormButtonCount();
			rect.Height = FLAT_FORM_BUTTON_HEIGHT;
			rect.X = Width - 1 - rect.Width;
			rect.Y = 1;// FLAT_FORM_BORDER;

			return rect;
		}

		/// <summary>
		/// 计算标题区域位置
		/// </summary>
		/// <returns></returns>
		virtual protected Rectangle MeasureFormTitleRect()
		{
			Rectangle rect = new Rectangle();

			rect.Width = Width - FLAT_FORM_BORDER - FLAT_FORM_BUTTON_WIDTH * MeasureFormButtonCount();
			rect.Height = FLAT_FORM_TITLE;
			rect.X = 1;
			rect.Y = 1;

			return rect;
		}

		/// <summary>
		/// 计算窗体按钮数量
		/// </summary>
		/// <returns></returns>
		virtual protected int MeasureFormButtonCount()
		{
			int ret = 1;

			if (this.MinimizeBox) ret++;
			if (this.MaximizeBox) ret++;

			return ret;
		}

		#endregion

		#region 鼠标

		protected bool isMousePressed = false;
		protected Point mousePressedPoint = new Point();
		protected FormMousePositions mousePressedPointType = FormMousePositions.Unknow;
		protected Rectangle bakupFormBound = new Rectangle();

		/// <summary>
		/// 设置鼠标指针
		/// </summary>
		/// <param name="p"></param>
		protected void SetMouseCursor(FormMousePositions p)
		{
			if (!canResize) return;

			switch (p)
			{
				case FormMousePositions.BorderLeft:
				case FormMousePositions.BorderRight:
					this.Cursor = Cursors.SizeWE;
					break;

				case FormMousePositions.BorderLeftTop:
				case FormMousePositions.BorderRightBottom:
					this.Cursor = Cursors.SizeNWSE;
					break;

				case FormMousePositions.BorderLeftBottom:
				case FormMousePositions.BorderRightTop:
					this.Cursor = Cursors.SizeNESW;
					break;

				case FormMousePositions.BorderTop:
				case FormMousePositions.BorderBottom:
					this.Cursor = Cursors.SizeNS;
					break;

				default:
					this.Cursor = Cursors.Default;
					break;
			}
		}

		/// <summary>
		/// 获取鼠标位置类型
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		protected FormMousePositions GetMousePositionType(int x, int y)
		{
			FormMousePositions ret = FormMousePositions.Unknow;

			if (y <= FLAT_FORM_BORDER)
			{
				if (x <= FLAT_FORM_BORDER)
				{
					ret = FormMousePositions.BorderLeftTop;
				}
				else if (x >= Width - FLAT_FORM_BORDER)
				{
					ret = FormMousePositions.BorderRightTop;
				}
				else
				{
					ret = FormMousePositions.BorderTop;
				}
			}
			else if (y >= Height - FLAT_FORM_BORDER)
			{
				if (x <= FLAT_FORM_BORDER)
				{
					ret = FormMousePositions.BorderLeftBottom;
				}
				else if (x >= Width - FLAT_FORM_BORDER)
				{
					ret = FormMousePositions.BorderRightBottom;
				}
				else
				{
					ret = FormMousePositions.BorderBottom;
				}
			}
			else
			{
				if (x <= FLAT_FORM_BORDER)
				{
					ret = FormMousePositions.BorderLeft;
				}
				else if (x >= Width - FLAT_FORM_BORDER)
				{
					ret = FormMousePositions.BorderRight;
				}
				else
				{
					if (y <= FLAT_FORM_TITLE + FLAT_FORM_BORDER)
					{
						ret = FormMousePositions.Title;
					}
					else
					{
						ret = FormMousePositions.Unknow;
					}
				}
			}

			return ret;
		}

		/// <summary>
		/// 点击
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);
			HitFormButtons(e.X, e.Y);
			OnFormButtonClick();
		}

		/// <summary>
		/// 点击窗体按钮
		/// </summary>
		protected void OnFormButtonClick()
		{
			int buttonCount = MeasureFormButtonCount();
			if (hoverButtonIndex < 0) return;
			if (buttonCount == 1)
			{
				doFormButtonClose();
			}
			else if (buttonCount == 2)
			{
				if (hoverButtonIndex == 1) doFormButtonClose();
				else
				{
					if (MinimizeBox) doFormButtonMin();
					else if (MaximizeBox) doFormButtonMax();
				}
			}
			else if (buttonCount == 3)
			{
				if (hoverButtonIndex == 2) doFormButtonClose();
				else if (hoverButtonIndex == 1 && MaximizeBox) doFormButtonMax();
				else if (hoverButtonIndex == 0 && MinimizeBox) doFormButtonMin();
			}
		}

		/// <summary>
		/// 最大化窗口
		/// </summary>
		virtual protected void doFormButtonMax()
		{
			if (WindowState == FormWindowState.Maximized)
			{
				WindowState = FormWindowState.Normal;
			}
			else
			{
				WindowState = FormWindowState.Maximized;
			}
			this.Invalidate();
		}

		/// <summary>
		/// 最小化窗口
		/// </summary>
		virtual protected void doFormButtonMin()
		{
			WindowState = FormWindowState.Minimized;
		}

		/// <summary>
		/// 关闭窗体
		/// </summary>
		virtual protected void doFormButtonClose()
		{
			FormClosingEventArgs e = new FormClosingEventArgs(CloseReason.UserClosing, false);
			OnFormClosing(e);
			if (e.Cancel) return;
			Close();
		}

		/// <summary>
		/// 鼠标移出
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.hoverButtonIndex = -1;
			this.Invalidate();
		}

		/// <summary>
		/// 按下鼠标
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (isMousePressed) return;
			isMousePressed = true;
		}

		/// <summary>
		/// 移动鼠标
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			HitFormButtons(e.X, e.Y);
			if (!isMousePressed)
			{
				if (this.WindowState == FormWindowState.Normal)
				{
					FormMousePositions p = GetMousePositionType(e.X, e.Y);
					SetMouseCursor(p);
				}
			}

			this.Invalidate();
		}

		/// <summary>
		/// 松开鼠标
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (!isMousePressed) return;
			isMousePressed = false;
		}

		/// <summary>
		/// 双击鼠标
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			base.OnMouseDoubleClick(e);

			if (!MaximizeBox) return;

			FormMousePositions p = GetMousePositionType(e.X, e.Y);
			if (p == FormMousePositions.Title)
			{
				UpdateMaxScreen();
				WindowState = (WindowState == FormWindowState.Maximized) ? FormWindowState.Normal : FormWindowState.Maximized;
			}
		}

		#region 鼠标消息
		protected const int Guying_HTLEFT = 10;
		protected const int Guying_HTRIGHT = 11;
		protected const int Guying_HTTOP = 12;
		protected const int Guying_HTTOPLEFT = 13;
		protected const int Guying_HTTOPRIGHT = 14;
		protected const int Guying_HTBOTTOM = 15;
		protected const int Guying_HTBOTTOMLEFT = 0x10;
		protected const int Guying_HTBOTTOMRIGHT = 17;
		protected override void WndProc(ref Message m)
		{

			if (this.WindowState == FormWindowState.Maximized || this.WindowState == FormWindowState.Minimized)
			{
				base.WndProc(ref m);
				return;
			}

			//----

			switch (m.Msg)
			{
				case 0x0084:
					base.WndProc(ref m);
					if (!canResize) break;

					Point vPoint = new Point((int)m.LParam & 0xFFFF, (int)m.LParam >> 16 & 0xFFFF);
					vPoint = PointToClient(vPoint);
					if (vPoint.X <= FLAT_FORM_BORDER)
					{
						if (vPoint.Y <= FLAT_FORM_BORDER)
						{
							m.Result = (IntPtr)Guying_HTTOPLEFT;
						}
						else if (vPoint.Y >= ClientSize.Height - FLAT_FORM_BORDER)
						{
							m.Result = (IntPtr)Guying_HTBOTTOMLEFT;
						}
						else
						{
							m.Result = (IntPtr)Guying_HTLEFT;
						}
					}
					else if (vPoint.X >= ClientSize.Width - FLAT_FORM_BORDER)
					{
						if (vPoint.Y <= FLAT_FORM_BORDER)
						{
							m.Result = (IntPtr)Guying_HTTOPRIGHT;
						}
						else if (vPoint.Y >= ClientSize.Height - FLAT_FORM_BORDER)
						{
							m.Result = (IntPtr)Guying_HTBOTTOMRIGHT;
						}
						else
						{
							m.Result = (IntPtr)Guying_HTRIGHT;
						}
					}
					else if (vPoint.Y <= FLAT_FORM_BORDER)
					{
						m.Result = (IntPtr)Guying_HTTOP;
					}
					else if (vPoint.Y >= ClientSize.Height - FLAT_FORM_BORDER)
					{
						m.Result = (IntPtr)Guying_HTBOTTOM;
					}
					if (skin != null)
					{
						skin.Main_SizeChanged(this, new EventArgs());
					}
					break;
				case 0x0201:                //鼠标左键按下的消息   
					if (hoverButtonIndex >= 0 || !canMove)
					{
						base.WndProc(ref m);
						break;
					}
					Point vPoint2 = new Point((int)m.LParam & 0xFFFF, (int)m.LParam >> 16 & 0xFFFF);
					vPoint2 = PointToClient(vPoint2);


					m.Msg = 0x00A1;         //更改消息为非客户区按下鼠标   
					m.LParam = IntPtr.Zero; //默认值   
					m.WParam = new IntPtr(2);//鼠标放在标题栏内   
					base.WndProc(ref m);

					if (skin != null)
					{
						skin.Main_LocationChanged(this, new EventArgs());
					}
					break;
				default:
					base.WndProc(ref m);
					break;
			}
		}
		#endregion

		#endregion

		#region 坐标

		virtual public Rectangle MeasureWindowContentArea()
		{
			Rectangle rect = new Rectangle();

			rect.Width = Width - FLAT_FORM_BORDER * 2;
			rect.Height = Height - FLAT_FORM_BORDER * 2;
			rect.Height -= FLAT_FORM_TITLE;
			rect.Y += FLAT_FORM_TITLE;

			return rect;
		}

		virtual public Size MeasureWindowSize(Size contentSize)
		{
			Size size = new Size(contentSize.Width, contentSize.Height);

			size.Width += FLAT_FORM_BORDER * 2;
			size.Height += FLAT_FORM_BORDER * 2;
			size.Height += FLAT_FORM_TITLE;

			return size;
		}

		#endregion

		#region 外发光阴影

		protected bool DisableSkinForm = false;
		private SkinForm skin;
		protected override void OnVisibleChanged(EventArgs e)
		{
			if (Visible)
			{
				//if (!DesignMode)
				//{
				//	//淡入
				//	Win32.AnimateWindow(this.Handle, 150, Win32.AW_BLEND | Win32.AW_ACTIVATE);
				//}
				base.OnVisibleChanged(e);

				if (!DesignMode && skin == null && !DisableSkinForm)
				{
					skin = new SkinForm(this);
					skin.Show(this);
					
				}

				if (skin != null) skin.Main_SizeChanged(this, new EventArgs());
			}
			else
			{
				base.OnVisibleChanged(e);
				Win32.AnimateWindow(this.Handle, 150, Win32.AW_BLEND | Win32.AW_HIDE);
			}
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);

			if (e.Cancel) return;

			if (skin != null)
			{
				skin.Close();
			}
			Win32.AnimateWindow(this.Handle, 150, Win32.AW_BLEND | Win32.AW_HIDE);
		}

		#endregion

		#endregion

		#region properties

		public bool FocusIn { get { return focusIn; } }

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new FormBorderStyle FormBorderStyle
		{
			get { return base.FormBorderStyle; }
			set { base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; }
		}

		protected Color _ThemeColor = ColorTranslator.FromHtml("#0078CF");

		//0078CF	蓝色
		//CC5100	橙色
		// Color.Transparent;
		public Color ThemeColor
		{
			get
			{
				return _ThemeColor;
			}
			set
			{
				if (_ThemeColor == value) return;
				_ThemeColor = value;
				this.Refresh();
			}
		}

		#endregion

		#region events

		#endregion
	}

	/// <summary>
	/// 窗体的鼠标位置
	/// </summary>
	public enum FormMousePositions
	{
		Unknow,
		Title,
		BorderTop,
		BorderBottom,
		BorderLeft,
		BorderRight,
		BorderLeftTop,
		BorderRightTop,
		BorderLeftBottom,
		BorderRightBottom
	}
}
