/*
 * TestExcel
 * liuqiang@2015/12/9 15:19:03
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Core;


//---- 8< ------------------

namespace Test.Excels
{
	public class TestExcel : ITest
	{

		public void Run(FormMain MainForm)
		{
			try
			{
				string filePath = @"Z:\aoeii\Document\02.Design\09.策划配表\AOE2武将策略集.xls";
				string strConn;
				strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=False;IMEX=1'";
				OleDbConnection OleConn = new OleDbConnection(strConn);
				OleConn.Open();
				String sql = "SELECT * FROM  [策略集-程序用$A1:Z10000]";//可是更改Sheet名称，比如sheet2，等等   

				OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
				DataSet OleDsExcle = new DataSet();
				OleDaExcel.Fill(OleDsExcle, "Sheet1");
				OleConn.Close();
			}
			catch (Exception err)
			{
				MessageBox.Show("数据绑定Excel失败!失败原因：" + err.Message, "提示信息",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				
			}  
		}

		public string GetName()
		{
			return this.GetType().Name;
		}
	}
}
