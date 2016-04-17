using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Data.Serialization
{
	/// <summary>
	/// 统一的序列化接口
	/// </summary>
	public interface ISModeSerialization
	{
		/// <summary>
		/// 序列化
		/// </summary>
		/// <param name="key"></param>
		/// <param name="models"></param>
		void Deserialize(string key, List<SModel> models);

		/// <summary>
		/// 反序列化
		/// </summary>
		/// <param name="key"></param>
		/// <param name="models"></param>
		void Serialize(string key, List<SModel> models);
	}
}
