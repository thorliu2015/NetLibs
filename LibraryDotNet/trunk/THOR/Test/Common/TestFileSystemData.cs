/*
 * TestFileSystemData
 * liuqiang@2015/11/19 15:10:39
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.Components.ThorGrids.Models;


//---- 8< ------------------

namespace Test.Common
{
	public class TestFileSystemData
	{
		#region 文件系统
		static public ThorDataTable GetDataTableFromFileSystem()
		{
			string path = @"C:\Docs\dev\android-sdk-windows";
			ThorDataTable dataTable = new ThorDataTable();

			//name
			dataTable.Columns.Add(new ThorDataTableColumn() { Width = 200 });
			//type
			dataTable.Columns.Add(new ThorDataTableColumn() { Width = 80 });
			//time
			dataTable.Columns.Add(new ThorDataTableColumn() { Width = 250 });

			ThorDataTableRow fixedRow = new ThorDataTableRow();

			fixedRow.Cells.Add(new ThorDataTableCell() { Text = "Name" });
			fixedRow.Cells.Add(new ThorDataTableCell() { Text = "Type" });
			fixedRow.Cells.Add(new ThorDataTableCell() { Text = "DateTime" });
			dataTable.Rows.Add(fixedRow);


			ThorDataTableRow row = GetDataTableRowFromFileSystem(path);
			if (row != null)
			{
				dataTable.Rows.Add(row);
			}
			return dataTable;
		}

		static public ThorDataTableRow GetDataTableRowFromFileSystem(string path)
		{
			ThorDataTableRow row = new ThorDataTableRow();

			if (Directory.Exists(path))
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(path);
				row.Cells.Add(new ThorDataTableCell() { Text = directoryInfo.Name });
				row.Cells.Add(new ThorDataTableCell() { Text = "" });
				row.Cells.Add(new ThorDataTableCell() { Text = directoryInfo.LastWriteTime.ToString() });


				string[] dirs = Directory.GetDirectories(path);
				foreach (string dir in dirs)
				{
					ThorDataTableRow childRow = GetDataTableRowFromFileSystem(dir);
					if (childRow != null)
					{
						row.Rows.Add(childRow);
					}
				}

				string[] files = Directory.GetFiles(path);
				foreach (string file in files)
				{
					ThorDataTableRow childRow = new ThorDataTableRow();
					FileInfo fileInfo = new FileInfo(file);
					childRow.Cells.Add(new ThorDataTableCell() { Text = Path.GetFileNameWithoutExtension(fileInfo.Name) });
					childRow.Cells.Add(new ThorDataTableCell() { Text = fileInfo.Extension });
					childRow.Cells.Add(new ThorDataTableCell() { Text = fileInfo.LastWriteTime.ToString() });
					row.Rows.Add(childRow);
				}
			}

			else
			{
				return null;
			}

			return row;
		}

		#endregion
	}
}
