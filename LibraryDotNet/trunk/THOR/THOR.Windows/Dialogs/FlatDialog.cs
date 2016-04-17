using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using THOR.Windows.Components.Common;
using THOR.Windows.Languages;

namespace THOR.Windows.Dialogs
{
	public partial class FlatDialog : THOR.Windows.Dialogs.FlatForm
	{
		protected List<ThorButton> Buttons = new List<ThorButton>();

		protected ThorButton buttonOK = null;

		/// <summary>
		/// 构造
		/// </summary>
		public FlatDialog()
		{
			InitializeComponent();
			InitDialogButtons();
			SetupDialogButtons();
			LayoutDialogButtons();
		}

		/// <summary>
		/// 定义按钮
		/// </summary>
		virtual protected void InitDialogButtons()
		{
			Buttons.Add(new ThorButton()
			{
				Text = ThorLanguages.Current.GetText("/language/buttons/ok", "OK"),
				Width = 70,
				Height = 30,
				DialogResult = System.Windows.Forms.DialogResult.OK
			});

			Buttons.Add(new ThorButton()
			{
				Text = ThorLanguages.Current.GetText("/language/buttons/cancel", "Cancel"),
				Width = 70,
				Height = 30,
				DialogResult = System.Windows.Forms.DialogResult.Cancel
			});
		}

		/// <summary>
		/// 安装按钮
		/// </summary>
		virtual protected void SetupDialogButtons()
		{
			boxButtons.Controls.Clear();

			int ti = 0;
			foreach (ThorButton btn in Buttons)
			{
				btn.Click += btn_Click;
				btn.TabIndex = ti;
				ti++;
				boxButtons.Controls.Add(btn);

				if (btn.DialogResult == System.Windows.Forms.DialogResult.OK)
				{
					buttonOK = btn;
					buttonOK.DialogResult = System.Windows.Forms.DialogResult.None;
				}
				if (btn.DialogResult == System.Windows.Forms.DialogResult.Cancel)
				{
					CancelButton = btn;
				}
			}
		}

		/// <summary>
		/// 布局按钮 
		/// </summary>
		virtual protected void LayoutDialogButtons()
		{
			int m = 5;
			int w = 70;
			int x = Width - m - (m + w) * Buttons.Count, y = m;
			foreach (ThorButton btn in Buttons)
			{
				btn.Left = x;
				btn.Top = y;

				x += m + w;
			}
		}

		/// <summary>
		/// 缩放
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			LayoutDialogButtons();
		}

		/// <summary>
		/// 显示
		/// </summary>
		/// <param name="e"></param>
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			LayoutDialogButtons();
		}

		/// <summary>
		/// 点击按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btn_Click(object sender, EventArgs e)
		{
			if (sender is ThorButton == false) return;

			ThorButton button = (ThorButton)sender;

			if (button == buttonOK)
			{
				if (!OnClickDialogButtonOK())
				{
					return;
				}
				else
				{
					DialogResult = System.Windows.Forms.DialogResult.OK;
					Close();
				}
			}

		}

		/// <summary>
		/// 取消对话框
		/// </summary>
		protected void CancelDialog()
		{
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
			Close();
		}

		/// <summary>
		/// 点击确认按钮时
		/// </summary>
		/// <returns></returns>
		virtual protected bool OnClickDialogButtonOK()
		{
			return true;
		}
	}
}
