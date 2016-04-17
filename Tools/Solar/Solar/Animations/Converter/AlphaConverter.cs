using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Solar.Animations.Converter
{
	/// <summary>
	/// 透明度转换
	/// </summary>
	public class AlphaConverter : TypeConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(float))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(System.String) && value is float)
			{
				return String.Format("{0}%", Convert.ToSingle(value) * 100);
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
			{
				return true;
			}
			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
		{
			if (value is string)
			{
				Regex regex = new Regex("^(?<value>([0-9]+(\\.[0-9]*)?))%?$", RegexOptions.Compiled);
				if (regex.IsMatch(value.ToString()))
				{
					Match m = regex.Match(value.ToString());
					string v = m.Result("${value}");
					float f = Convert.ToSingle(v);
					if (f < 0) f = 0;
					if (f > 100) f = 100;
					return f / 100;
				}
			}
			return base.ConvertFrom(context, culture, value);
		}
	}
}
