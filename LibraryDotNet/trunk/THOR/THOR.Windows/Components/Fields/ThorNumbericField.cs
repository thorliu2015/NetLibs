/*
 * ThorNumbericField
 * liuqiang@2015/11/17 14:33:30
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Windows.Components.Fields
{
	public class ThorNumbericField : ThorAbstractDomainField
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public ThorNumbericField()
			: base()
		{
		}

		#endregion

		#region methods

		protected override void CreateFieldContent()
		{
			base.CreateFieldContent();

			textBox.Text = _value.ToString();
			textBox.KeyPress += textBox_KeyPress;
			textBox.TextChanged += textBox_TextChanged;
		}

		protected override void OnDomainAutoChange(int step)
		{
			_value += step;
			if (_value > _max) _value = _max;
			if (_value < _min) _value = _min;
			textBox.Text = _value.ToString();
		}

		void textBox_TextChanged(object sender, EventArgs e)
		{
			decimal d = 0;
			bool b = decimal.TryParse(textBox.Text, out d);
			if (!b) return;

			bool v = true;
			if (d > _max)
			{
				v = false;
				d = _max;
			}
			if (d < _min)
			{
				v = false;
				d = _min;
			}

			_value = d;
			if (!v)
			{
				textBox.Text = _value.ToString();
			}
		}

		protected void textBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (TextBoxReadOnly)
			{
				e.Handled = true;
				return;
			}
		
			if (Char.IsDigit(e.KeyChar)) return;

			if (e.KeyChar == '-'
				|| e.KeyChar == '.')
			{
				if (e.KeyChar == '-')
				{
					if (textBox.SelectionStart > 0) e.Handled = true;
				}
				if (e.KeyChar == '.')
				{
					if (textBox.SelectionStart < 1) e.Handled = true;
				}
				if (textBox.Text.IndexOf(e.KeyChar) >= 0) e.Handled = true;
			}
		}

		protected override void OnDomainButtonClick(int flag)
		{
			//base.OnDomainButtonClick(flag);
			if (flag > 0)
			{
				if (_value < _max)
				{
					_value++;
				}
			}
			else if (flag < 0)
			{
				if (_value > _min)
				{
					_value--;
				}
			}

			textBox.Text = _value.ToString();
		}

		#endregion

		#region properties

		protected Decimal _value = 0;
		protected Decimal _min = Decimal.MinValue;
		protected Decimal _max = Decimal.MaxValue;

		public Decimal Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;

			}
		}

		public Decimal Min
		{
			get
			{
				return _min;
			}
			set
			{
				_min = value;
			}
		}

		public Decimal Max
		{
			get
			{
				return _max;
			}
			set
			{
				_max = value;
			}
		}

		public bool TextBoxReadOnly { get; set; }

		#endregion

		#region events

		#endregion
	}
}
