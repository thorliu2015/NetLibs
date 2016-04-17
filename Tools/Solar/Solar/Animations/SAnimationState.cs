using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Utils.Attributes;
using THOR.Utils.Attributes.PropertyGrids;

namespace Solar.Animations
{
	/// <summary>
	/// 占位类型
	/// </summary>
	public enum SAnimationStatePlaceType
	{
		[Note("无", "占位类型", "")]
		None,

		[Note("网格", "占位类型", "")]
		Grid,

		[Note("圆形", "占位类型", "")]
		Circle
	}

	#region 占位类型转换
	/// <summary>
	/// 占位类型转换
	/// </summary>
	public class SAnimationStatePlaceTypeConverter : TypeConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(SAnimationStatePlaceType))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(System.String) && value is SAnimationStatePlaceType)
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
				object o = NoteAttribute.GetEnumByNoteName(typeof(SAnimationStatePlaceType), value.ToString());
				if (o != null)
				{
					return o;
				}
			}
			return base.ConvertFrom(context, culture, value);
		}
	}
	#endregion




	/// <summary>
	/// 动画状态
	/// </summary>
	[Serializable()]
	[Note("动画状态", "单位或者动画的不同状态, 例如默认的闲置, 行走, 瞄准, 攻击, 死亡等", "图形")]
	public class SAnimationState : SAnimationLayer, IComparable<SAnimationState>
	{
		/// <summary>
		/// 构造
		/// </summary>
		public SAnimationState()
		{
			StateType = SAnimationStateType.Normal;
		}

		/// <summary>
		/// 数据比较
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo(SAnimationState other)
		{
			int ret = 0;

			if (other == null)
			{
				ret = 1;
			}
			{
				int a = Convert.ToInt32(Enum.Format(typeof(SAnimationStateType), this.StateType, "d"));
				int b = Convert.ToInt32(Enum.Format(typeof(SAnimationStateType), other.StateType, "d"));

				if (a < b)
				{
					ret = -1;
				}
				else
				{
					ret = 1;
				}
			}

			return ret;
		}


		[Category("动画"), DisplayName("状态"), Description("动画状态类型"), DefaultValue(SAnimationStateType.Normal), Editor(typeof(EnumSelectorEditor), typeof(UITypeEditor)), TypeConverter(typeof(SAnimationStateTypeConverter))]
		public SAnimationStateType StateType { get; set; }

		[Category("占位"), DisplayName("占位类型"), Description("占位符号的类型"), DefaultValue(SAnimationStatePlaceType.None), Editor(typeof(EnumSelectorEditor), typeof(UITypeEditor)), TypeConverter(typeof(SAnimationStatePlaceTypeConverter))]
		public SAnimationStatePlaceType PlaceType { get; set; }

		[Category("占位"), DisplayName("占位半径"), Description("占位符号的半径"), DefaultValue(0)]
		public int PlaceSize { get; set; }

	}
}
