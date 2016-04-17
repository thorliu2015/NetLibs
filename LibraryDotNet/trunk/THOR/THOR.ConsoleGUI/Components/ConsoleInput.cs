using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.ConsoleGUI.Core;
using THOR.Windows.Utils;
using System.Diagnostics;

namespace THOR.ConsoleGUI.Components
{
	public partial class ConsoleInput : UserControl
	{
		#region variables

		protected bool lockAutoCompolete = false;

		#endregion

		#region construct
		public ConsoleInput()
		{
			InitializeComponent();
		}
		#endregion

		#region methods


		#region layout

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			LayoutUI();
		}

		protected virtual void LayoutUI()
		{
			int pHeight = this.Height;
			int pMargin = (pHeight - txtInput.Height) / 2;

			txtInput.Location = new Point(pMargin, pMargin);
			txtInput.Size = new Size(Width - pMargin * 2, txtInput.Height);
		}

		#endregion

		#region input


		/// <summary>
		/// 键盘事件
		/// </summary>
		/// <param name="sender"></param>	
		/// <param name="e"></param>
		protected virtual void txtInput_KeyDown(object sender, KeyEventArgs e)
		{
			//退格
			if (KeyUtils.IsKey(e, Keys.Back))
			{
				lockAutoCompolete = true;
				e.Handled = true;
				return;
			}

			//回车
			if (e.KeyCode == Keys.Enter)
			{
				ExecuteCommandLine();
				e.Handled = true;
				return;
			}

			//F1
			if(KeyUtils.IsKey(e, Keys.F1))
			{
				CommandLineHelp();
				e.Handled = true;
				return;
			}

			//SHIFT + BACK
			if (KeyUtils.IsShiftKey(e, Keys.Back))
			{
				txtInput.Text = "";
				e.Handled = true;
				return;
			}

			//UP
			if (KeyUtils.IsKey(e, Keys.Up))
			{
				PrevCommandLine();
				e.Handled = true;
				return;
			}

			//DOWN
			if (KeyUtils.IsKey(e, Keys.Down))
			{
				NextCommandLine();
				e.Handled = true;
				return;
			}

			//SHIFT + UP
			if (KeyUtils.IsShiftKey(e, Keys.Up))
			{
				SelectPrevGroup();
				e.Handled = true;
				return;
			}

			//SHIFT + DOWN
			if (KeyUtils.IsShiftKey(e, Keys.Down))
			{
				SelectNextGroup();
				e.Handled = true;
				return;
			}

			//ALT + UP
			if (KeyUtils.IsAltKey(e, Keys.Up))
			{
				SwitchPrevGroup();
				e.Handled = true;
				return;
			}

			//ALT + DOWN
			if (KeyUtils.IsAltKey(e, Keys.Down))
			{
				SwitchNextGroup();
				e.Handled = true;
				return;
			}

			//ALT + Left
			if (KeyUtils.IsAltKey(e, Keys.Left))
			{
				e.Handled = true;
				txtInput.Select(0, 0);
				return;
			}

			//ALT + Right
			if (KeyUtils.IsAltKey(e, Keys.Right))
			{
				e.Handled = true;
				txtInput.Select(txtInput.Text.Length, 0);
				return;
			}
		}

		private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void txtInput_TextChanged(object sender, EventArgs e)
		{
			AutoComplete();
		}

		/// <summary>
		/// 自动完成
		/// </summary>
		protected virtual void AutoComplete()
		{
			if (lockAutoCompolete)
			{
				lockAutoCompolete = false;
				return;
			}


			lockAutoCompolete = true;
			AutoCompleteManager.Update(txtInput);
			lockAutoCompolete = false;
		}
		#endregion

		/// <summary>
		/// 执行命令行
		/// </summary>
		protected virtual void ExecuteCommandLine()
		{
			Debug.WriteLine("TODO: ExecuteCommandLine");
		}

		/// <summary>
		/// 命令行帮助
		/// </summary>
		protected virtual void CommandLineHelp()
		{
			Debug.WriteLine("TODO: CommandLineHelp");
		}

		/// <summary>
		/// 上一条指令
		/// </summary>
		protected virtual void PrevCommandLine()
		{
			Debug.WriteLine("TODO: PrevCommandLine");
		}

		/// <summary>
		/// 下一条指令
		/// </summary>
		protected virtual void NextCommandLine()
		{
			Debug.WriteLine("TODO: NextCommandLine");
		}

		/// <summary>
		/// 选择上一组
		/// </summary>
		protected virtual void SelectPrevGroup()
		{
			AutoCompleteManager.SelectPrevGroup(txtInput);
		}

		/// <summary>
		/// 选择下一组
		/// </summary>
		protected virtual void SelectNextGroup()
		{
			AutoCompleteManager.SelectNextGroup(txtInput);
		}

		/// <summary>
		/// 切换上一组数据
		/// </summary>
		protected virtual void SwitchPrevGroup()
		{
			Debug.WriteLine("TODO: SwitchPrevGroup");
		}

		/// <summary>
		/// 切换下一组数据
		/// </summary>
		protected virtual void SwitchNextGroup()
		{
			Debug.WriteLine("TODO: SwitchNextGroup");
		}

		#endregion

		

		
	}
}
