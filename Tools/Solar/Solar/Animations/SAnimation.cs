using Solar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Utils.Attributes;

namespace Solar.Animations
{
	[Serializable()]
	[Note("动画", "界面, 单位, 技能, 武器等动画效果", "图形")]

	///动画配置
	public class SAnimation : SModel
	{
		/// <summary>
		/// 构造
		/// </summary>
		public SAnimation()
			: base()
		{
			States = new List<SAnimationState>();
		}



		/// <summary>
		/// 状态列表
		/// </summary>
		public List<SAnimationState> States { get; set; }

		
	}
}
