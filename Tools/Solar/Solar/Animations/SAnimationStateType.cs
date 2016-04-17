using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Utils.Attributes;

namespace Solar.Animations
{
	/// <summary>
	/// 动画状态
	/// </summary>
	public enum SAnimationStateType
	{
		[Note("默认","默认状态","")]
		Normal,

		[Note("移动","移动状态","")]
		Move,

		[Note("瞄准","攻击前的瞄准预备状态","")]
		Targeting,

		[Note("攻击","攻击状态","")]
		Attack,

		[Note("死亡","死亡状态","")]
		Dead
	}



	public class SAnimationStateTypeConverter : TypeConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(SAnimationStateType))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(System.String) && value is SAnimationStateType)
			{
				return NoteAttribute.GetNoteNameByEnum(value);
			
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
				object o = NoteAttribute.GetEnumByNoteName(typeof(SAnimationStateType), value.ToString());
				if (o != null)
				{
					return o;
				}
			}
			return base.ConvertFrom(context, culture, value);
		}
	}
}
