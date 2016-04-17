/*
 * TestThorDataTable
 * liuqiang@2015/11/14 14:06:04
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Test.Core;
using THOR.Windows.Components.ThorGrids.Models;
using System.Diagnostics;
using System.Collections;


//---- 8< ------------------

namespace Test.ThorGrids
{
	public class TestThorDataTable : ITest
	{
		public void Run(FormMain MainForm)
		{
			ThorDataTable table = new ThorDataTable();

			ThorDataTableRow row = new ThorDataTableRow();
			string p = @"C:\Docs\temp\Test\";

			table.Rows.Add(row);

			AddFolder(row, p);
			row.Cells.Add(new ThorDataTableCell() { Text = "/" });

			ThorDataTableRow r = table.Rows[0];
			while (r != null)
			{
				Debug.WriteLine("".PadLeft(r.Level, '\t') + r.ToString());

				string path = r.Path;

				r = r.GetNextRow();

			}
		}

		protected void AddFolder(ThorDataTableRow row, string p)
		{
			if (!Directory.Exists(p)) return;

			string[] directories = Directory.GetDirectories(p);

			foreach (string directory in directories)
			{
				ThorDataTableRow childrow = new ThorDataTableRow();
				row.Rows.Add(childrow);

				AddFolder(childrow, directory);
				childrow.Cells.Add(new ThorDataTableCell() { Text = Path.GetFileName(directory) });
			}

			//string[] files = Directory.GetFiles(p);

			//foreach (string file in files)
			//{
			//	ThorDataTableRow fileRow = new ThorDataTableRow();
			//	fileRow.Cells.Add(new ThorDataTableCell() { Text = Path.GetFileName(file) });
			//	row.Rows.Add(fileRow);
			//}
		}

		public string GetName()
		{
			return this.GetType().Name;
		}
	}
}
