/*
 * TestNoteAttribute
 * liuqiang@2015/11/1 17:02:39
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


//---- 8< ------------------

namespace Test.Attributes
{
	public class TestNoteAttribute : ITest
	{
		public void Run(FormMain MainForm)
		{
			NoteAttributeSampleClass sample = new NoteAttributeSampleClass();
			Type sampleType = sample.GetType();
			string memberName = "Name";

			NoteAttribute note1 = NoteAttribute.GetNote(sample);
			NoteAttribute note2 = NoteAttribute.GetNote(sampleType);
			NoteAttribute note3 = NoteAttribute.GetNote(sample, memberName);
			NoteAttribute note4 = NoteAttribute.GetNote(sampleType, memberName);

			Debug.WriteLine("-- Completed --");
		}


		public string GetName()
		{
			return this.GetType().Name;
		}
	}
}
