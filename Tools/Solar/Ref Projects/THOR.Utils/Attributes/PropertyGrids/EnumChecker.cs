using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THOR.Utils.Attributes.PropertyGrids
{
	public class EnumChecker : UserControl
	{
		protected bool inited = false;
		protected List<CheckBox> items;
		public EnumChecker()
		{
			items = new List<CheckBox>();
			Padding = new System.Windows.Forms.Padding(10);
			AutoScroll = true;
		}


		protected void Init()
		{
			if (enumValue == null) return;
			if (inited) return;

			Type type = enumValue.GetType();

			string[] names = type.GetEnumNames();

			Dictionary<string, List<string>> values = new Dictionary<string, List<string>>();

			foreach (string name in names)
			{
				MemberInfo[] members = type.GetMember(name);
				if (members.Length == 0) continue;

				Attribute attrib = members[0].GetCustomAttribute(typeof(NoteAttribute));
				if (attrib == null) continue;

				NoteAttribute note = (NoteAttribute)attrib;

				if (!values.ContainsKey(note.Category))
				{
					values[note.Category] = new List<string>();
				}

				values[note.Category].Add(note.Name);
			}

			this.SuspendLayout();
			foreach (string category in values.Keys)
			{
				GroupBox groupBox = new GroupBox();
				groupBox.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
				groupBox.Text = category;
				groupBox.Dock = DockStyle.Top;
				groupBox.Text = "啥?";
				int h = 20;

				foreach (string noteName in values[category])
				{
					CheckBox checkBox = new CheckBox();
					checkBox.Text = noteName;
					checkBox.Dock = DockStyle.Top;
					groupBox.Controls.Add(checkBox);
					h += checkBox.Height;
					items.Add(checkBox);
				}

				h += 0;
				groupBox.Height = h;


				Controls.Add(groupBox);
			}
			this.ResumeLayout();
			inited = true;
		}

		protected void Update()
		{
			Init();
		}

		protected object enumValue;
		public object EnumValue
		{
			get
			{
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
