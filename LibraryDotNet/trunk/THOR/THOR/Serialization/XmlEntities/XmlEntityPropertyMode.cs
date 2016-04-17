/*
 * XmlEntityPropertyMode
 * liuqiang@2015/11/1 17:33:26
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Serialization.XmlEntities
{
	/// 实体对象属性的xml组织模式
	/// </summary>
	public enum XmlEntityPropertyMode
	{
		/// <summary>
		/// 属性值直接以文本形式处理
		/// </summary>
		Value,
		/// <summary>
		/// 将属性扩展为对象节点
		/// </summary>
		Object,
		/// <summary>
		/// 将属性扩展为集合形式的文本形式
		/// </summary>
		CollectionValue,
		/// <summary>
		/// 将属性扩展为集合形式的对象节点, 例如: &lt;&gt;
		/// </summary>
		CollectionObject,
		/// <summary>
		/// 将属性值以枚举值处理, 例如: 256
		/// </summary>
		EnumValue,
		/// <summary>
		/// 将属性值以枚举名称进行处理,并以逗号分隔, 例如: tag1,tag2,tag3
		/// </summary>
		EnumTags
	}
}
