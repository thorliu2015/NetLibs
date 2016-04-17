/*
 * NoteAttributeSampleClass
 * liuqiang@2015/11/1 17:02:53
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Attributes.Notes;


//---- 8< ------------------

namespace Test.Attributes
{
	[Note("NoteName", "NoteDescription", "NoteCategory")]
	public class NoteAttributeSampleClass
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public NoteAttributeSampleClass()
		{
		}

		#endregion

		#region methods

		#endregion

		#region properties

		[Note("Name", "Description", "Category", 0)]
		public string Name { get; set; }

		#endregion

		#region events

		#endregion
	}
}
