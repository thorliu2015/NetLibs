using Solar.Animations.Biz;
using Solar.Components.D2DRender;
using Solar.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Utils.Attributes;
using THOR.Utils.Attributes.PropertyGrids;

namespace Solar.Animations
{

	[Note("方向绑定类型", "单位的角度朝向绑定方式", "图形")]
	public enum AnimationDirectionType
	{
		[Note("无", "", "")]
		None,

		[Note("移动", "", "")]
		Move,

		[Note("攻击", "", "")]
		Attack
	}

	public class AnimationDirectionTypeConverter : TypeConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(AnimationDirectionType))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(System.String) && value is AnimationDirectionType)
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
				object o = NoteAttribute.GetEnumByNoteName(typeof(AnimationDirectionType), value.ToString());
				if (o != null)
				{
					return o;
				}
			}
			return base.ConvertFrom(context, culture, value);
		}
	}


	/// <summary>
	/// 动画图层
	/// </summary>
	[Serializable()]
	[Note("动画图层", "动画的图层", "图形")]
	public class SAnimationLayer : SModelNode
	{
		/// <summary>
		/// 构造
		/// </summary>
		public SAnimationLayer()
		{
			Name = "未命名";

			Directions = new List<SAnimationDirection>();
			Directions.Add(new SAnimationDirection());

		}

		/// <summary>
		/// 获取方向
		/// </summary>
		/// <returns></returns>
		public int GetDirection(AnimationViewContext context)
		{

			float angle = 0;
			switch (this.DirectionType)
			{
				case AnimationDirectionType.None:
					if (Directions.Count > 0) return 0;
					break;

				case AnimationDirectionType.Attack:
					angle = context.AttackAngle;
					break;

				case AnimationDirectionType.Move:
					angle = context.MoveAngle;
					break;
			}

			return SAnimationDirectionBiz.GetDrectionIndex(Directions.Count, angle);
		}

		/// <summary>
		/// 调整方向数组的数量
		/// </summary>
		protected void ResizeDirections()
		{
			int actualDirections = SAnimationDirectionBiz.GetActualDirection(targetDirections);

			if (actualDirections == Directions.Count) return;
			int oldCount = Directions.Count;
			if (actualDirections < Directions.Count)
			{
				//remove ...
				for (int i = 0; i < oldCount - actualDirections; i++)
				{
					Directions.RemoveAt(Directions.Count - 1);
				}
			}
			else
			{
				//add ...
				for (int i = 0; i < actualDirections - oldCount; i++)
				{
					Directions.Add(new SAnimationDirection());
				}
			}
		}

		/// <summary>
		/// 获取所属状态
		/// </summary>
		/// <returns></returns>
		public SAnimationState GetState()
		{
			if (this is SAnimationState) return (SAnimationState)this;

			SModelNode node = this;
			while (node.ParentNode != null)
			{
				if (node.ParentNode is SAnimationState)
				{
					return (SAnimationState)node.ParentNode;
				}

				node = node.ParentNode;
			}
			return null;
		}


		[Category("动画"), DisplayName("名称"), Description("图层的显示名称"), DefaultValue("未命名")]
		/// <summary>
		/// 图层名称
		/// </summary>
		public string Name { get; set; }



		[Browsable(false)]
		/// <summary>
		/// 方向
		/// </summary>
		public List<SAnimationDirection> Directions { get; set; }



		[Browsable(false)]
		/// <summary>
		/// 隶属的动画
		/// </summary>
		public SAnimation OwnerAnimation { get; set; }


		[Category("动画"), DisplayName("方向绑定"), Description("自动控制方向的类型"), DefaultValue(AnimationDirectionType.None), TypeConverter(typeof(AnimationDirectionTypeConverter)), Editor(typeof(EnumSelectorEditor), typeof(UITypeEditor))]
		public AnimationDirectionType DirectionType { get; set; }


		protected int targetDirections = 1;
		[Category("动画"), DisplayName("方向"), Description("图层所包含的最终方向数量"), DefaultValue(1)]
		public int TargetDirections
		{
			get
			{
				return targetDirections;
			}
			set
			{
				targetDirections = value;
				ResizeDirections();
			}
		}

	}
}
