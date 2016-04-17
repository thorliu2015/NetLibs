/*
 * ThorPropertyGrid
 * liuqiang@2015/11/23 17:17:09
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
using THOR.Windows.Components.Common;
using THOR.Windows.Components.Drawing;
using THOR.Windows.Components.ThorGrids.Core;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.ThorPropertyGrid
{
	public class ThorPropertyGrid : Control
	{
		#region constants

		#endregion

		#region variables

		protected ThorBox boxDescription;
		protected ThorGrid gridProperties;
		protected ThorSplitter spliterProperties;

		protected ThorPropertyGridDataTableBuilder tableBuilder = new ThorPropertyGridDataTableBuilder();

		#endregion

		#region construct

		public ThorPropertyGrid()
			: base()
		{
			DoubleBuffered = true;
			InitThorPropertyGrid();
		}

		#endregion

		#region methods

		/// <summary>
		/// 初始化属性表
		/// </summary>
		protected virtual void InitThorPropertyGrid()
		{
			this.Size = new Size(200, 200);
			gridProperties = new ThorGrid();
			gridProperties.FixedRows = 0;
			gridProperties.Dock = DockStyle.Fill;
			Controls.Add(gridProperties);

			spliterProperties = new ThorSplitter();
			spliterProperties.Dock = DockStyle.Bottom;
			Controls.Add(spliterProperties);

			boxDescription = new ThorBox();
			boxDescription.Dock = DockStyle.Bottom;
			Controls.Add(boxDescription);

			ResizeRedraw = true;
		}

		/// <summary>
		/// 绘制背景
		/// </summary>
		/// <param name="pevent"></param>
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.OnPaintBackground(pevent);
			DrawPropertyGrid(pevent);
		}

		/// <summary>
		/// 绘制属性表
		/// </summary>
		/// <param name="e"></param>
		protected virtual void DrawPropertyGrid(PaintEventArgs e)
		{
			e.Graphics.FillRectangle(ThorBrushs.Control, e.ClipRectangle);

			if (!spliterProperties.Visible) return;

			string pName = "Property Name";
			string pDescription = "Property Description Description Description Description Description Description Description";
			int pad = 5;
			int sh = 16;
			Rectangle rect = new Rectangle(pad, spliterProperties.Bounds.Bottom + pad, Width - pad * 2, sh);
			TextRenderer.DrawText(e.Graphics, pName, Font, rect, ThorColors.HighLightText, TextFormatFlags.Left | TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);

			rect.Height = Height - pad - rect.Bottom - pad;
			rect.Y += sh + pad;
			if (rect.Height <= 0) return;
			TextRenderer.DrawText(e.Graphics, pDescription, Font, rect, ThorColors.ControlText, TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.WordBreak);
		}

		#endregion

		#region properties


		protected Object _SelectedObject;
		public Object SelectedObject
		{
			get
			{
				return _SelectedObject;
			}
			set
			{
				if (_SelectedObject == value) return;
				_SelectedObject = value;
				gridProperties.DataTable = tableBuilder.GetDataTable(_SelectedObject);
			}
		}

		#endregion

		#region events

		#endregion
	}
}
