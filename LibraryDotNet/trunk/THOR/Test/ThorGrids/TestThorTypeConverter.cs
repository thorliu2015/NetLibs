/*
 * TestThorTypeConverter
 * liuqiang@2015/11/24 14:50:40
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Core;
using THOR.Attributes.Notes;
using THOR.Windows.Components.ThorGrids.TypeConverters;


//---- 8< ------------------

namespace Test.ThorGrids
{
	public class TestThorTypeConverter : ITest
	{

		public void Run(FormMain MainForm)
		{
			ThorTypeConverter typeConverter = new ThorTypeConverter();

			List<object> listData = new List<object>();
			System.Byte u8 = 1; listData.Add(u8);
			System.SByte i8 = 2; listData.Add(i8);
			System.Int16 i16 = 3000; listData.Add(i16);
			System.Int32 i32 = 4000000; listData.Add(i32);
			System.Int64 i64 = 500000000; listData.Add(i64);
			System.UInt16 u16 = 6000; listData.Add(u16);
			System.UInt32 u32 = 70000000; listData.Add(u32);
			System.UInt64 u64 = 800000000; listData.Add(u64);
			System.Single s = 9000000; listData.Add(s);
			System.Double d = 100000000000; listData.Add(d);
			System.Decimal dec = 11000000000000; listData.Add(dec);
			System.Boolean b = true; listData.Add(b);
			System.DateTime dt = DateTime.Now; listData.Add(dt);
			System.String str = "Liuqiang"; listData.Add(str);
			TestEnum en = TestEnum.B; listData.Add(en);

			listData.Add(this);

			foreach (object data in listData)
			{
				string text = "";
				object result = null;
				Type type = data.GetType();

				if (typeConverter.AllowGetText(data, type))
				{
					text = typeConverter.GetText(data, type);
				}

				if (typeConverter.AllowGetObject(text, type))
				{
					result = typeConverter.GetObject(text, type);
				}

				Debug.WriteLine("Type = {0}, Data = ({1}), Text = ({2}), Result = ({3})",
					type,
					data == null ? "NULL" : data,
					text == null ? "NULL" : text,
					result == null ? "NULL" : result);
			}
		}

		public string GetName()
		{
			return this.GetType().Name;
		}
	}

	public enum TestEnum
	{
		[Note("NAME_A")]
		A = 1,

		[Note("NAME_B")]
		B = 2,

		[Note("NAME_C")]
		C = 4
	}
}
