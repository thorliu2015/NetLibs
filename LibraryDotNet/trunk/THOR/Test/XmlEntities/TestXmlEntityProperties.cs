/*
 * TestXmlEntityProperties
 * liuqiang@2015/11/1 17:49:15
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Core;
using THOR.Serialization;
using THOR.Serialization.XmlEntities;


//---- 8< ------------------

namespace Test.XmlEntities
{
	public class TestXmlEntityProperties : ITest
	{

		public void Run(FormMain MainForm)
		{
			SerialicationTypes.Current.AddApplicationDomain(AppDomain.CurrentDomain);

			TestUnit unit = new TestUnit();
			unit.Id = "302";
			unit.Name = "步枪兵";
			unit.Attributes = TestUnitAttributes.Ground;

			XmlEntityEncoder encoder = new XmlEntityEncoder();
			encoder.Encode(@"C:\Docs\temp\1.xml", unit);

			XmlEntityDecoder decoder = new XmlEntityDecoder();
			List<object> decodeObjects = decoder.Decode(@"C:\Docs\temp\1.xml");

			Debug.WriteLine("-- Completed --");
		}

		public string GetName()
		{
			return this.GetType().Name;
		}
	}
}
