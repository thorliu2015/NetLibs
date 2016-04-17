/*
 * EditorModuleDataProvider
 * liuqiang@2015/12/6 18:51:31
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.Editors.Common.Data;


//---- 8< ------------------

namespace THOR.Windows.Editors.Common.Core
{
	public class EditorModuleDataProvider
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		static public void GetEntities(EditorModule module, List<CEntity> result)
		{
			List<Type> types = new List<Type>();

			foreach (EditorModuleEntityType setting in module.Types)
			{
				foreach (Type type in setting.Types)
				{
					if (!types.Contains(type))
					{
						types.Add(type);
					}
				}
			}

			Type[] typesArgs = new Type[types.Count];

			for (int i = 0; i < types.Count; i++)
			{
				typesArgs[i] = types[i];
			}

			CEntityPool.Current.GetEntities(result, typesArgs);


		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
