using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THOR.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class ExportAttribute : Attribute
	{
		public ExportAttribute(bool isExported)
		{
			Exported = isExported;
		}

		/// <summary>
		/// 是否导出
		/// </summary>
		public bool Exported { get; set; }

		
	}

	
}
