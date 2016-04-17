/*
 * ThorAbstractDomainField
 * liuqiang@2015/11/17 14:11:43
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
using System.Timers;
using THOR.Windows.Components.Drawing;


//---- 8< ------------------

namespace THOR.Windows.Components.Fields
{
	public class ThorAbstractDomainField : ThorTextField
	{
		#region constants

		protected const int THOR_DOMAIN_BUTTON_SIZE = 15;
		protected const int THOR_DOMAIN_BUTTON_DELAY = 500;
		protected const int THOR_DOMAIN_BUTTON_STEP = 200;

		#endregion

		#region variables

		protected System.Windows.Forms.Timer timerDelay = new System.Windows.Forms.Timer();
		protected System.Windows.Forms.Timer timerStep = new System.Windows.Forms.Timer();
		protected bool pressed = false;
		protected int direction = 0;

		#endregion

		#region construct

		public ThorAbstractDomainField()
			: base()
		{
		}

		#endregion

		#region methods

		protected override void CreateFieldContent()
		{
			base.CreateFieldContent();

			timerDelay.Interval = THOR_DOMAIN_BUTTON_DELAY;
			timerStep.Interval = THOR_DOMAIN_BUTTON_SIZE;
			timerDelay.Tick += timerDelay_Tick;
			timerStep.Tick += timerStep_Tick;
		}

		protected virtual void OnDomainAutoChange(int step)
		{
		}

		protected void timerStep_Tick(object sender, EventArgs e)
		{
			OnDomainAutoChange(direction);
		}

		protected void timerDelay_Tick(object sender, EventArgs e)
		{
			timerDelay.Stop();
			timerDelay.Enabled = true;

			timerStep.Enabled = true;
			timerStep.Start();
			
		}

		protected override void LayoutFieldContent()
		{
			base.LayoutFieldContent();

			if (textBox != null)
			{
				textBox.Width -= THOR_DOMAIN_BUTTON_SIZE;
			}
		}

		protected override void DrawFieldForeground(System.Windows.Forms.PaintEventArgs e)
		{
			base.DrawFieldForeground(e);

			Rectangle rect = new Rectangle();
			rect.Width = THOR_DOMAIN_BUTTON_SIZE;
			rect.Height = (this.Height - this.Padding.Top - this.Padding.Bottom) / 2 ;
			rect.X = this.Width - this.Padding.Right - THOR_DOMAIN_BUTTON_SIZE;
			//rect.Y = this.Padding.Top;

			ThorControlPaint.DrawArrow(e.Graphics, rect, ThorColors.HighLightText, ThorArrowDirection.Up);


			rect.Y += rect.Height;
			ThorControlPaint.DrawArrow(e.Graphics, rect, ThorColors.HighLightText, ThorArrowDirection.Down);
		}

		protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
		{
			base.OnMouseClick(e);

			int hitButtonFlag = HitDomainButtonByPoint(e.X, e.Y);
			if (hitButtonFlag != 0) OnDomainButtonClick(hitButtonFlag);
		}

		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			base.OnMouseDown(e);

			int ret = HitDomainButtonByPoint(e.X, e.Y);
			if (ret == 0) return;
			if (pressed) return;
			pressed = true;

			direction = ret;
			timerStep.Stop();
			timerDelay.Enabled = true;
			timerDelay.Start();
		}

		protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
		{
			base.OnMouseUp(e);

			if (!pressed) return;
			pressed = false;

			timerStep.Stop();
			timerStep.Enabled = false;
			timerDelay.Stop();
			timerDelay.Enabled = false;
		}

		protected int HitDomainButtonByPoint(int x, int y)
		{
			int ret = 0;

			if (x < 0 || x > Width) return 0;
			if (y < 0 || y > Height) return 0;

			if (x > Width - THOR_DOMAIN_BUTTON_SIZE)
			{
				if (y < Height / 2)
				{
					ret = 1;// -1;
				}
				else
				{
					ret = -1;
				}
			}

			return ret;
		}

		protected virtual void OnDomainButtonClick(int flag)
		{
			Debug.WriteLine(flag.ToString());
		}

		#endregion

		#region properties

		

		#endregion

		#region events

		#endregion
	}
}
