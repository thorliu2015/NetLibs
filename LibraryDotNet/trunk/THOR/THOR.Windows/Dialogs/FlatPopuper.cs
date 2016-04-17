/*
 * FlatPopuper
 * liuqiang@2015/11/17 16:10:25
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Windows.Components.ThorGrids.ThorList;


//---- 8< ------------------

namespace THOR.Windows.Dialogs
{
	/// <summary>
	/// 扁平化弹出层
	/// </summary>
	public class FlatPopuper : FlatForm
	{
		#region constants


		protected int THOR_FLAT_POPUPER_SPACING = 0;
	

		#endregion

		#region variables

		protected Control _OwnerControl;
		protected bool _FixedPopuperWidth = false;
		protected Rectangle _CustomOwnerControlBounds = new Rectangle();

		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		public FlatPopuper()
			: base()
		{
			ResizeRedraw = true;
			canResize = false;
			canMove = false;
			this.Padding = new System.Windows.Forms.Padding(1);
			this.TopMost = true;
			this.ShowInTaskbar = false;

			this.Width = 100;
			this.Height = 100;
			this.MinimumSize = new Size(10, 5);
			
		}

		#endregion

		#region methods

		/// <summary>
		/// 设置弹出内容的尺寸
		/// </summary>
		/// <param name="w"></param>
		/// <param name="h"></param>
		public virtual void SetPopupContentSize(int w, int h)
		{
			this.Size = new System.Drawing.Size(w + this.Padding.Left + this.Padding.Right, h + this.Padding.Top + this.Padding.Bottom);
		}

		public virtual void Show(Control ownerControl)
		{
			Show(ownerControl, new Rectangle());
		}

		/// <summary>
		/// 显示层到特定控件
		/// </summary>
		/// <param name="ownerControl"></param>
		public virtual void Show(Control ownerControl, Rectangle customBounds)
		{
			if (_OwnerControl != null)
			{
				_OwnerControl.Move -= _OwnerControl_Move;
				_OwnerControl.Resize -= _OwnerControl_Resize;
			}

			_OwnerControl = ownerControl;
			_CustomOwnerControlBounds.X = customBounds.X;
			_CustomOwnerControlBounds.Y = customBounds.Y;
			_CustomOwnerControlBounds.Width = customBounds.Width;
			_CustomOwnerControlBounds.Height = customBounds.Height;

			if (_OwnerControl != null)
			{
				_OwnerControl.Move += _OwnerControl_Move;
				_OwnerControl.Resize += _OwnerControl_Resize;
			}

			AlignToOwnerControl();
		}


		/// <summary>
		/// 隶属控件缩放时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void _OwnerControl_Resize(object sender, EventArgs e)
		{
			if (!this.Visible) return;
			AlignToOwnerControl();
		}

		/// <summary>
		/// 隶属控件移动时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void _OwnerControl_Move(object sender, EventArgs e)
		{
			if (!this.Visible) return;
			AlignToOwnerControl();
		}

		/// <summary>
		/// 对齐层到特定控件
		/// </summary>
		public virtual void AlignToOwnerControl()
		{
			if (_OwnerControl == null) return;

			Screen screen = Screen.FromControl(_OwnerControl);
			Rectangle rectScreen = screen.WorkingArea;

			Rectangle rect = _OwnerControl.Bounds;

			if (_CustomOwnerControlBounds.Width != 0 && _CustomOwnerControlBounds.Height != 0)
			{
				rect.X = _CustomOwnerControlBounds.X;
				rect.Y = _CustomOwnerControlBounds.Y;
				rect.Width = _CustomOwnerControlBounds.Width;
				rect.Height = _CustomOwnerControlBounds.Height;
			}

			rect.Location = _OwnerControl.Parent.PointToScreen(rect.Location);

			Rectangle rectPopuper = new Rectangle();
			rectPopuper.Height = this.Height;
			rectPopuper.Width = _FixedPopuperWidth ? this.Width : rect.Width;

			//如果底部超出
			if (rect.Bottom + THOR_FLAT_POPUPER_SPACING + Height > rectScreen.Bottom)
			{
				rectPopuper.X = rect.Left;
				rectPopuper.Y = rect.Top - rectPopuper.Height - THOR_FLAT_POPUPER_SPACING;
			}
			else
			{
				rectPopuper.X = rect.Left;
				rectPopuper.Y = rect.Bottom + THOR_FLAT_POPUPER_SPACING;
			}

			this.Size = rectPopuper.Size;
			this.Location = rectPopuper.Location;

			this.Show();
			this.Select();

		}
		/// <summary>
		/// 没有窗体按钮
		/// </summary>
		/// <returns></returns>
		protected override int MeasureFormButtonCount()
		{
			return 0;
		}

		/// <summary>
		/// 不画窗体按钮
		/// </summary>
		/// <param name="e"></param>
		protected override void DrawButtons(System.Windows.Forms.PaintEventArgs e)
		{
			
		}

		/// <summary>
		/// 不画窗体文本
		/// </summary>
		/// <param name="e"></param>
		protected override void DrawTitleText(System.Windows.Forms.PaintEventArgs e)
		{
			
		}

		/// <summary>
		/// 失去焦点时隐藏窗体
		/// </summary>
		/// <param name="e"></param>
		protected override void OnDeactivate(EventArgs e)
		{
			base.OnDeactivate(e);
			this.Hide();
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
