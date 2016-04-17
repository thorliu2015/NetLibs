using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THOR.Utils.Attributes.PropertyGrids
{
	public class EnumSelector : UserControl
	{
		protected ListBox list;

		public EnumSelector()
			: base()
		{
			DoubleBuffered = true;

			list = new ListBox();
			list.BorderStyle = System.Windows.Forms.BorderStyle.None;
			list.Dock = DockStyle.Fill;
			Controls.Add(list);
		}

		public void Update()
		{
			if (enumValue == null) return;
			Type EnumType = EnumValue.GetType();
			if (enumValue == null) return;
			
			string[] names = EnumType.GetEnumNames();

			list.Items.Clear();

			int i = 0;
			int si = 0;
			foreach (string name in names)
			{
				MemberInfo[] members = EnumType.GetMember(name);
				if (members.Length == 0) continue;

				Attribute n = members[0].GetCustomAttribute(typeof(NoteAttribute));
				if (n == null) continue;

				NoteAttribute note = (NoteAttribute)n;

				list.Items.Add(note.Name);

				if (name == enumValue.ToString())
				{
					si = i;
				}
				i++;
			}

			list.SelectedIndex = si;
		}

		protected object enumValue;
		public object EnumValue
		{
			get
			{
				if (list.Items.Count > 0)
				{
					Type EnumType = enumValue.GetType();
					int i = list.SelectedIndex;
					if (i < 0) i = 0;
					string na = list.Items[i].ToString();

					string[] names = EnumType.GetEnumNames();
					foreach (string name in names)
					{
						MemberInfo[] members = EnumType.GetMember(name);
						if (members.Length == 0) continue;

						Attribute n = members[0].GetCustomAttribute(typeof(NoteAttribute));
						if (n == null) continue;

						NoteAttribute note = (NoteAttribute)n;

						if (note.Name == na)
						{
							enumValue = Enum.Parse(EnumType, name);
						}
					}
				}

				return enumValue;
			}
			set
			{
				enumValue = value;
				Update();
			}
		}
	}
}
