/*
 * SerialicationTypes
 * liuqiang@2015/11/1 17:40:41
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Serialization
{
	/// <summary>
	/// 序列化类型
	/// </summary>
	public class SerialicationTypes
	{
		#region constants

		#endregion

		#region variables

		protected List<Assembly> Assemblies = new List<Assembly>();

		#endregion

		#region construct

		static public SerialicationTypes Current { get; protected set; }
		static SerialicationTypes()
		{
			Current = new SerialicationTypes();
		}

		private SerialicationTypes()
		{
			AddCurrentApplication();
		}

		#endregion

		#region methods

		/// <summary>
		/// 获取类型
		/// </summary>
		/// <param name="typeName"></param>
		/// <returns></returns>
		public Type GetType(string typeName)
		{
			Type type = null;

			type = Type.GetType(typeName);

			if (type == null)
			{
				foreach (Assembly a in Assemblies)
				{
					type = a.GetType(typeName);
					if (type != null) return type;
				}
			}

			return type;
		}

		/// <summary>
		/// 添加程序集
		/// </summary>
		/// <param name="assembly"></param>
		public void Add(Assembly assembly)
		{
			if (Assemblies.Contains(assembly)) return;

			Assemblies.Add(assembly);
		}

		/// <summary>
		/// 添加程序集
		/// </summary>
		/// <param name="type"></param>
		public void Add(Type type)
		{
			Assembly assembly = Assembly.GetAssembly(type);
			Add(assembly);
		}

		/// <summary>
		/// 添加程序集
		/// </summary>
		/// <param name="obj"></param>
		public void Add(Object obj)
		{
			if (obj == null) return;
			Add(obj.GetType());
		}


		/// <summary>
		/// 添加路径下的所有程序集(exe, dll)
		/// </summary>
		public void AddAssemblies(string path)
		{
			if (!Directory.Exists(path)) return;

			string[] exeFiles = Directory.GetFiles(path, "*.exe");
			string[] dllFiles = Directory.GetFiles(path, "*.dll");

			List<string> files = new List<string>();
			files.AddRange(exeFiles);
			files.AddRange(dllFiles);

			foreach (string file in files)
			{
				try
				{
					Assembly assembly = Assembly.LoadFrom(file);
					Add(assembly);
				}
				catch (Exception ex)
				{
					Debug.WriteLine(String.Format("(Warning){0}", ex.Message));
				}
			}
		}

		/// <summary>
		/// 添加当前应用程序的所有程序集
		/// </summary>
		protected void AddCurrentApplication()
		{
			AddApplicationDomain(AppDomain.CurrentDomain);
		}

		/// <summary>
		/// 添加应用程序域的所有程序集
		/// </summary>
		/// <param name="domain"></param>
		public void AddApplicationDomain(AppDomain domain)
		{
			Assembly[] assemblies = domain.GetAssemblies();

			foreach (Assembly assembly in assemblies)
			{
				Add(assembly);
			}
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
