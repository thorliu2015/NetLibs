/*
 * FlatMessageBox
 * liuqiang@2015/11/12 13:10:54
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
using THOR.Windows.Languages;
using THOR.Windows.Properties;


//---- 8< ------------------

namespace THOR.Windows.Dialogs
{
	public class FlatMessageBox : FlatForm
	{
		#region constants

		protected const int THOR_MSGBOX_ICON_SIZE = 50;
		protected const int THOR_MSGBOX_CONTENT_SPACING = 10;

		protected Padding THOR_MSGBOX_CONTENT_MARGIN = new Padding(20, 20, 20, 20);

		protected const int THOR_MSGBOX_BUTTON_WIDTH = 70;
		protected const int THOR_MSGBOX_BUTTON_HEIGHT = 30;

		protected const int THOR_MSGBOX_BUTTON_SPACING = 5;
		protected Padding THOR_MSGBOX_BUTTON_MARGIN = new Padding(10, 10, 10, 10);

		#endregion

		#region variables

		protected List<ThorButton> buttons = new List<ThorButton>();

		#endregion

		#region construct

		public FlatMessageBox()
			: base()
		{
			this.Width = 0;
			this.Height = 0;
			MinimizeBox = false;
			MaximizeBox = false;
			canResize = false;
			KeyPreview = true;
			StartPosition = FormStartPosition.Manual;
			this.Size = this.MinimumSize = new Size(0, 0);
			//DisableSkinForm = true;

			//this.MinimumSize = new Size(100, FLAT_FORM_BORDER * 2 + FLAT_FORM_TITLE + (THOR_MSGBOX_CONTENT_MARGIN * 2) + 20 + THOR_MSGBOX_BUTTON_HEIGHT + THOR_MSGBOX_BUTTON_MARGIN);

			//this.MessageBoxIcon = System.Windows.Forms.MessageBoxIcon.Information;
			//this.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
			//this.MessageBoxPrompt = "";
			//this.StartPosition = FormStartPosition.CenterParent;
		}

		#endregion

		#region methods

		protected override void OnShown(EventArgs e)
		{
			//----
			base.OnShown(e);
			//----
			CreateButtions();

			Rectangle rect = MeasureMessageBoxBound();

			this.Bounds = rect;

			//this.Left = rect.Left;
			//this.Top = rect.Top;
			//this.Width = rect.Width;
			//this.Height = rect.Height;

			LayoutButtons();

			if (buttons.Count > 0)
			{
				buttons[0].Select();
			}

			PlaySound();

			
		}

		virtual protected void PlaySound()
		{
			switch (MessageBoxIcon)
			{
				case System.Windows.Forms.MessageBoxIcon.Warning:
					System.Media.SystemSounds.Asterisk.Play();
					break;

				case System.Windows.Forms.MessageBoxIcon.Question:
					System.Media.SystemSounds.Question.Play();
					break;

				case System.Windows.Forms.MessageBoxIcon.Error:
					System.Media.SystemSounds.Exclamation.Play();
					break;

				default:
					System.Media.SystemSounds.Beep.Play();
					break;
			}
		}

		virtual protected void LayoutButtons()
		{
			Rectangle rectContent = MeasureWindowContentArea();
			int x = rectContent.Left;
			int y = rectContent.Bottom;

			int bw = buttons.Count * (THOR_MSGBOX_BUTTON_WIDTH + THOR_MSGBOX_BUTTON_SPACING) - THOR_MSGBOX_BUTTON_SPACING;

			y -= THOR_MSGBOX_BUTTON_MARGIN.Bottom;
			y -= THOR_MSGBOX_BUTTON_HEIGHT;
			//x += THOR_MSGBOX_BUTTON_MARGIN.Left;
			x = (this.Width - bw) / 2;

			foreach (ThorButton btn in buttons)
			{
				btn.Left = x;
				btn.Top = y;

				x += THOR_MSGBOX_BUTTON_WIDTH + THOR_MSGBOX_BUTTON_SPACING;
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			LayoutButtons();
		}

		virtual protected void CreateButtions()
		{
			switch (MessageBoxButtons)
			{
				case System.Windows.Forms.MessageBoxButtons.OK:
					buttons.Add(new ThorButton()
					{
						Text = ThorLanguages.Current.GetText("/language/buttons/ok", "OK"),
						Tag = "O",
						DialogResult = System.Windows.Forms.DialogResult.OK
					});
					break;

				case System.Windows.Forms.MessageBoxButtons.OKCancel:
					buttons.Add(new ThorButton() { Text = ThorLanguages.Current.GetText("/language/buttons/ok", "OK"), Tag = "O", DialogResult = System.Windows.Forms.DialogResult.OK });
					buttons.Add(new ThorButton() { Text = ThorLanguages.Current.GetText("/language/buttons/cancel", "Cancel"), Tag = "C", DialogResult = System.Windows.Forms.DialogResult.Cancel });
					break;

				case System.Windows.Forms.MessageBoxButtons.RetryCancel:
					buttons.Add(new ThorButton() { Text = ThorLanguages.Current.GetText("/language/buttons/retry", "Retry"), Tag = "O", DialogResult = System.Windows.Forms.DialogResult.Retry });
					buttons.Add(new ThorButton() { Text = ThorLanguages.Current.GetText("/language/buttons/cancel", "Cancel"), Tag = "C", DialogResult = System.Windows.Forms.DialogResult.Cancel });
					break;

				case System.Windows.Forms.MessageBoxButtons.YesNo:
					buttons.Add(new ThorButton() { Text = ThorLanguages.Current.GetText("/language/buttons/yes", "Yes"), Tag = "Y", DialogResult = System.Windows.Forms.DialogResult.Yes });
					buttons.Add(new ThorButton() { Text = ThorLanguages.Current.GetText("/language/buttons/no", "No"), Tag = "N", DialogResult = System.Windows.Forms.DialogResult.No });
					break;

				case System.Windows.Forms.MessageBoxButtons.YesNoCancel:
					buttons.Add(new ThorButton() { Text = ThorLanguages.Current.GetText("/language/buttons/yes", "Yes"), Tag = "Y", DialogResult = System.Windows.Forms.DialogResult.Yes });
					buttons.Add(new ThorButton() { Text = ThorLanguages.Current.GetText("/language/buttons/no", "No"), Tag = "N", DialogResult = System.Windows.Forms.DialogResult.No });
					buttons.Add(new ThorButton() { Text = ThorLanguages.Current.GetText("/language/buttons/cancel", "Cancel"), Tag = "C", DialogResult = System.Windows.Forms.DialogResult.Cancel });
					break;

				case System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore:
					buttons.Add(new ThorButton() { Text = ThorLanguages.Current.GetText("/language/buttons/abort", "Abort"), Tag = "A", DialogResult = System.Windows.Forms.DialogResult.Abort });
					buttons.Add(new ThorButton() { Text = ThorLanguages.Current.GetText("/language/buttons/retry", "Retry"), Tag = "R", DialogResult = System.Windows.Forms.DialogResult.Retry });
					buttons.Add(new ThorButton() { Text = ThorLanguages.Current.GetText("/language/buttons/ignore", "Ignore"), Tag = "I", DialogResult = System.Windows.Forms.DialogResult.Ignore });
					break;
			}

			foreach (ThorButton btn in buttons)
			{
				btn.Width = THOR_MSGBOX_BUTTON_WIDTH;
				btn.Height = THOR_MSGBOX_BUTTON_HEIGHT;
				this.Controls.Add(btn);
			}
		}


		protected override void DrawFormBackground(PaintEventArgs e)
		{
			ThorControlPaint.DrawForm(e.Graphics, Bounds, (!DisableSkinForm), this);
		}

		/// <summary>
		/// 绘制窗体
		/// </summary>
		/// <param name="e"></param>
		protected override void DrawForm(System.Windows.Forms.PaintEventArgs e)
		{
			base.DrawForm(e);
			DrawMessageBoxIcon(e);
			DrawMessageBoxPrompt(e);
		}

		protected override void DrawButtons(PaintEventArgs e)
		{
			//base.DrawButtons(e);
		}

		protected override int MeasureFormButtonCount()
		{
			return 0;
			//return base.MeasureFormButtonCount();
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);

			switch (e.KeyCode)
			{
				case Keys.Enter:

					foreach (ThorButton btn in buttons)
					{
						switch (btn.DialogResult)
						{
							case System.Windows.Forms.DialogResult.OK:
							case System.Windows.Forms.DialogResult.Yes:
							case System.Windows.Forms.DialogResult.Retry:
								this.DialogResult = btn.DialogResult;
								this.Close();
								return;
						}
					}
					break;

				case Keys.Escape:
					foreach (ThorButton btn in buttons)
					{
						switch (btn.DialogResult)
						{
							case System.Windows.Forms.DialogResult.Cancel:
							case System.Windows.Forms.DialogResult.No:
							case System.Windows.Forms.DialogResult.Abort:
								this.DialogResult = btn.DialogResult;
								this.Close();
								return;
						}
					}
					break;
			}
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);

			string k = e.KeyChar.ToString().Trim().ToUpper();

			foreach (ThorButton btn in buttons)
			{
				if (k == btn.Tag.ToString().Trim().ToUpper())
				{
					this.DialogResult = btn.DialogResult;
					this.Close();
					return;
				}
			}
		}

		/// <summary>
		/// 绘制图标
		/// </summary>
		/// <param name="e"></param>
		virtual protected void DrawMessageBoxIcon(PaintEventArgs e)
		{
			if (MessageBoxIcon == System.Windows.Forms.MessageBoxIcon.None) return;

			Rectangle rect = MeasureMessageBoxIconBound();
			ThorControlPaint.DrawIcon(e.Graphics, rect, GetMessageBoxIcon());
		}

		/// <summary>
		/// 绘制内容
		/// </summary>
		/// <param name="e"></param>
		virtual protected void DrawMessageBoxPrompt(PaintEventArgs e)
		{
			Rectangle rect = MeasureMessageBoxPromptBound();
			//e.Graphics.FillRectangle(ThorBrushs.ControlLight, rect);
			TextFormatFlags tf = TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.EndEllipsis | TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl;
			TextRenderer.DrawText(e.Graphics, MessageBoxPrompt.Trim(), Font, rect, ThorColors.ControlText, tf);
		}

		/// <summary>
		/// 计算窗体范围
		/// </summary>
		/// <returns></returns>
		virtual protected Rectangle MeasureMessageBoxBound()
		{
			Rectangle rect = new Rectangle();

			Rectangle rectIcon = MeasureMessageBoxIconBound();
			Rectangle rectPrompt = MeasureMessageBoxPromptBound();

			rect.Width = rectPrompt.Width;
			rect.Height = Math.Max(rectIcon.Height, rectPrompt.Height);

			if (rectIcon.Width > 0)
			{
				rect.Width += rectIcon.Width + THOR_MSGBOX_CONTENT_SPACING;
			}

			int buttonsWidth = buttons.Count * (THOR_MSGBOX_BUTTON_WIDTH + THOR_MSGBOX_BUTTON_SPACING) - THOR_MSGBOX_BUTTON_SPACING;

			if (rect.Width < buttonsWidth) rect.Width = buttonsWidth;

			rect.Height += THOR_MSGBOX_BUTTON_HEIGHT + THOR_MSGBOX_BUTTON_MARGIN.Bottom;

			rect.Width += THOR_MSGBOX_CONTENT_MARGIN.Left + THOR_MSGBOX_CONTENT_MARGIN.Right;
			rect.Height += THOR_MSGBOX_CONTENT_MARGIN.Top + THOR_MSGBOX_CONTENT_MARGIN.Bottom;

			//rect.Width = rectPrompt.Width;
			//rect.Height = rectPrompt.Height;

			//if (rectIcon.Width > 0) rect.Width += rectIcon.Width + THOR_MSGBOX_CONTENT_SPACING;
			//if (rectIcon.Height > rect.Height) rect.Height = rectIcon.Height;
			//rect.Height += FLAT_FORM_TITLE + FLAT_FORM_BORDER;
			//rect.Height += FLAT_FORM_BORDER;
			//rect.Height += 50;	//buttons
			//rect.Width += THOR_MSGBOX_CONTENT_MARGIN * 2;
			//rect.Height += THOR_MSGBOX_CONTENT_MARGIN * 2;

			rect.Size = MeasureWindowSize(rect.Size);

			if (this.Text.Trim().Length == 0)
			{
				rect.Height -= FLAT_FORM_TITLE;
			}

			Rectangle ownerRect = new Rectangle();
			if (this.Owner != null && this.Owner.Visible)
			{
				ownerRect = this.Owner.Bounds;

				if (this.Owner.WindowState == FormWindowState.Minimized)
				{
					ownerRect.Width = 0;
					ownerRect.Height = 0;
				}
				else if (this.Owner.WindowState == FormWindowState.Maximized)
				{
					Screen scr = Screen.FromControl(this.Owner);
					if (scr != null)
					{
						Rectangle scrRect = scr.WorkingArea;
						ownerRect.Width = scrRect.Width;
						ownerRect.Height = scrRect.Height;
					}
				}
			}

			if (this.Owner == null || ownerRect.Width <= 0 || ownerRect.Height <= 0)
			{
				Screen scr = Screen.FromControl(this);
				if (scr != null)
				{
					Rectangle scrRect = scr.WorkingArea;
					rect.X = (scrRect.Width - rect.Width) / 2;
					rect.Y = (scrRect.Height - rect.Height) / 2;
				}
			}
			else
			{
				rect.X = ((ownerRect.Width - rect.Width) / 2) + ownerRect.X;
				rect.Y = ((ownerRect.Height - rect.Height) / 2) + ownerRect.Y;
			}


			return rect;
		}

		/// <summary>
		/// 获取图标
		/// </summary>
		/// <returns></returns>
		virtual protected Image GetMessageBoxIcon()
		{
			switch (this.MessageBoxIcon)
			{
				//[i]
				case MessageBoxIcon.Information:
					return Resources.MsgBox_Info;

				//[!]
				case MessageBoxIcon.Warning:
					return Resources.MsgBox_Waring;

				//[?]
				case MessageBoxIcon.Question:
					return Resources.MsgBox_Help;

				//[x]
				case MessageBoxIcon.Error:
					return Resources.MsgBox_Error;
			}

			return null;
		}

		/// <summary>
		/// 获取图标范围
		/// </summary>
		/// <returns></returns>
		virtual protected Rectangle MeasureMessageBoxIconBound()
		{
			Rectangle rect = new Rectangle();
			Rectangle rectContent = MeasureWindowContentArea();

			if (MessageBoxIcon != System.Windows.Forms.MessageBoxIcon.None)
			{
				rect.Width = THOR_MSGBOX_ICON_SIZE;
				rect.Height = THOR_MSGBOX_ICON_SIZE;
			}

			rect.X = rectContent.X;
			rect.Y = rectContent.Y;

			rect.X += THOR_MSGBOX_CONTENT_MARGIN.Left;
			rect.Y += THOR_MSGBOX_CONTENT_MARGIN.Top;

			if (this.Text.Trim().Length == 0)
			{
				rect.Y -= FLAT_FORM_TITLE;
			}


			//rect.X += FLAT_FORM_BORDER + THOR_MSGBOX_BUTTON_MARGIN;
			//rect.Y += FLAT_FORM_BORDER + FLAT_FORM_TITLE + THOR_MSGBOX_BUTTON_MARGIN;

			return rect;
		}

		/// <summary>
		/// 获取内容范围
		/// </summary>
		/// <returns></returns>
		virtual protected Rectangle MeasureMessageBoxPromptBound()
		{
			Rectangle rectContent = MeasureWindowContentArea();
			Rectangle rect = new Rectangle();

			TextFormatFlags tf = TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.WordBreak;

			Screen scr = Screen.FromControl(this);

			Size sizeMax = new System.Drawing.Size(scr.WorkingArea.Width, scr.WorkingArea.Height);
			sizeMax.Width -= 200;
			sizeMax.Height -= 200;


			Size sizeAuto = TextRenderer.MeasureText(MessageBoxPrompt.Trim(), this.Font, sizeMax);

			rect.Width = sizeAuto.Width;
			rect.Height = sizeAuto.Height;
			if (rect.Width > sizeMax.Width) rect.Width = sizeMax.Width;
			if (rect.Height > sizeMax.Height) rect.Height = sizeMax.Height;

			if (MessageBoxIcon != System.Windows.Forms.MessageBoxIcon.None)
			{
				rect.X += THOR_MSGBOX_ICON_SIZE + THOR_MSGBOX_CONTENT_SPACING;
				if (sizeAuto.Height < THOR_MSGBOX_ICON_SIZE)
				{
					rect.Y += (THOR_MSGBOX_ICON_SIZE - sizeAuto.Height) / 2;
				}
			}

			rect.X += rectContent.Left + THOR_MSGBOX_CONTENT_MARGIN.Left;
			rect.Y += rectContent.Top + THOR_MSGBOX_CONTENT_MARGIN.Top;


			if (this.Text.Trim().Length == 0)
			{
				rect.Y -= FLAT_FORM_TITLE;
			}

			return rect;
		}

		#endregion

		#region properties

		public string MessageBoxPrompt { get; set; }
		public MessageBoxButtons MessageBoxButtons { get; set; }
		public MessageBoxIcon MessageBoxIcon { get; set; }

		#endregion

		#region events

		#endregion
	}
}
