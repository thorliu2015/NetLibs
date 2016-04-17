/*
 * ThorPanel
 * liuqiang@2015/11/1 22:43:30
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
using THOR.Windows.Components.Drawing;


//---- 8< ------------------

namespace THOR.Windows.Components.Common
{
	public class ThorPanel : Panel
	{
		#region constants

		#endregion

		#region variables

		protected int border = 0;
		protected int title = 20;
		protected bool focusIn = false;
		#endregion

		#region construct

		public ThorPanel()
			: base()
		{
			DoubleBuffered = true;
			InitPanelProperties();
		}

		#endregion

		#region methods

		protected void InitPanelProperties()
		{
			this.Padding = new Padding(border, border + title, border, border);
		}

		protected override void OnResize(EventArgs eventargs)
		{
			base.OnResize(eventargs);

			this.Invalidate();
		}

		protected override void OnEnter(EventArgs e)
		{
			base.OnGotFocus(e);
			focusIn = true;
			this.Invalidate();
		}

		protected override void OnLeave(EventArgs e)
		{
			base.OnLostFocus(e);
			focusIn = false;
			this.Invalidate();
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
			e.Graphics.Clear(ThorColors.Control);

			Rectangle rect = new Rectangle(0, 0, Width, title);
			ThorControlPaint.DrawRectangle(e.Graphics, rect, ThorPens.PanelBorder);
			
			ThorControlPaint.DrawBand(e.Graphics, rect, true, 3, true);

			int indent = 15;
			rect.X += indent;
			rect.Width -= indent;
			TextFormatFlags tf = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;
			TextRenderer.DrawText(e.Graphics, _title, Font, rect, ThorColors.ControlDark, tf);

			rect.X--;
			rect.Y--;
			TextRenderer.DrawText(e.Graphics, _title, Font, rect, ThorColors.ControlText, tf);

			//{
			//	rect.X = 0;
			//	rect.Y = title;
			//	rect.Width = Width;
			//	rect.Height = Height - title;

			//	ThorControlPaint.DrawRectangle(e.Graphics, rect, focusIn ? ThorPens.Focus : ThorPens.ControlLight , false);
			//}
		}

		#endregion

		#region properties

		protected string _title = "Untitled";
		/// <summary>
		/// 获取或设置面板标题
		/// </summary>
		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				if (_title == value) return;

				_title = value;
				this.Invalidate();
			}
		}

		#endregion

		#region events

		#endregion
	}
}
