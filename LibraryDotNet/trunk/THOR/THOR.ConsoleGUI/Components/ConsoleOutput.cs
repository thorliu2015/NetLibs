﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THOR.ConsoleGUI.Components
{
	public partial class ConsoleOutput : UserControl
	{
		public ConsoleOutput()
		{
			InitializeComponent();

			Clear();
		}

		void t_Tick(object sender, EventArgs e)
		{
			Write(Color.Red, DateTime.Now.ToString());
			WriteLine(Color.Blue, " blah blah");
		}

		/// <summary>
		/// 清空内容
		/// </summary>
		public virtual void Clear()
		{
			txtOutput.Clear();
		}

		/// <summary>
		/// 输出文本
		/// </summary>
		/// <param name="color"></param>
		/// <param name="content"></param>
		public virtual void Write(Color color, string content)
		{
			txtOutput.SuspendLayout();

			txtOutput.Select(txtOutput.Text.Length, 0);
			txtOutput.SelectionColor = color;
			txtOutput.SelectedText = content;

			
			txtOutput.Select(txtOutput.Text.Length, 0);
			txtOutput.ScrollToCaret();

			txtOutput.ResumeLayout();

		}

		/// <summary>
		/// 输出文本行
		/// </summary>
		/// <param name="color"></param>
		/// <param name="content"></param>
		public virtual void WriteLine(Color color, string content)
		{
			Write(color, content + "\r\n");
		}

		
	}
}
