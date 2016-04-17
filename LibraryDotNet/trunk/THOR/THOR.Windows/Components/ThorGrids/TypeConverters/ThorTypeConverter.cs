/*
 * ThorTypeConverter
 * liuqiang@2015/11/24 14:45:33
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Attributes.Notes;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.TypeConverters
{
	/// <summary>
	/// 基础类型和枚举值的转换支持
	/// </summary>
	public class ThorTypeConverter : IThorTypeConverter
	{
		#region constants

		protected const string THOR_TYPE_CONVERTER_NULL = "";

		#endregion

		#region variables

		#endregion

		#region construct

		public ThorTypeConverter()
		{
		}

		#endregion

		#region methods

		public virtual bool AllowGetText(object data, Type type)
		{
			return true;
		}

		public virtual string GetText(object data, Type type)
		{
			if (data == null || type == null)
			{
				return THOR_TYPE_CONVERTER_NULL;
			}

			#region 枚举
			if (type.IsEnum)
			{
				return GetEnumText(data, type);
			}
			#endregion

			string typeName = type.ToString();
			switch (typeName)
			{
				#region 基础类型
				case "System.SByte":
				case "System.Int16":
				case "System.Int32":
				case "System.Int64":
					return Convert.ToInt64(data).ToString("###,###,###,###,###,###,###");

				case "System.Byte":
				case "System.UInt16":
				case "System.UInt32":
				case "System.UInt64":
					return Convert.ToUInt64(data).ToString("###,###,###,###,###,###,###");

				case "System.Single":
				case "System.Double":
					return Convert.ToDouble(data).ToString();

				case "System.Decimal":
					return Convert.ToDecimal(data).ToString("###,###,###,###,###,###,###,###,###,###");

				case "System.Boolean":
					return data.ToString();

				case "System.DateTime":
					return data.ToString();
				#endregion

				default:
					{
						if (data == null)
						{
							return THOR_TYPE_CONVERTER_NULL;
						}
						else
						{
							return GetGeomString(data, type);
						}
					}
			}
		}

		public virtual bool AllowGetObject(string text, Type type)
		{
			if (type.IsEnum) return true;

			string typeName = type.ToString();
			switch (typeName)
			{
				#region 基础类型
				case "System.SByte":
				case "System.Int16":
				case "System.Int32":
				case "System.Int64":


				case "System.Byte":
				case "System.UInt16":
				case "System.UInt32":
				case "System.UInt64":

				case "System.Single":
				case "System.Double":

				case "System.Decimal":

				case "System.Boolean":

				case "System.DateTime":

				case "System.String":
				case "System.Drawing.Point":
				case "System.Drawing.PointF":
				case "System.Drawing.Size":
				case "System.Drawing.SizeF":
				case "System.Drawing.Rectangle":
				case "System.Drawing.RectangleF":
				case "System.Windows.Forms.Padding":
					return true;
				#endregion

				default:
					return false;
			}
		}

		public virtual object GetObject(string text, Type type)
		{
			#region 枚举
			if (type.IsEnum)
			{
				return GetEnumData(text, type);
			}
			#endregion

			string typeName = type.ToString();
			switch (typeName)
			{
				#region 基础类型
				case "System.SByte":
					return Convert.ToSByte(CheckNumberString(text));

				case "System.Int16":
					return Convert.ToInt16(CheckNumberString(text));

				case "System.Int32":
					return Convert.ToInt32(CheckNumberString(text));

				case "System.Int64":
					return Convert.ToInt64(CheckNumberString(text));

				case "System.Byte":
					return Convert.ToByte(CheckNumberString(text));

				case "System.UInt16":
					return Convert.ToUInt16(CheckNumberString(text));

				case "System.UInt32":
					return Convert.ToUInt32(CheckNumberString(text));

				case "System.UInt64":
					return Convert.ToUInt64(CheckNumberString(text));

				case "System.Single":
					return Convert.ToSingle(CheckNumberString(text));

				case "System.Double":
					return Convert.ToDouble(CheckNumberString(text));

				case "System.Decimal":
					return Convert.ToDecimal(CheckNumberString(text));

				case "System.Boolean":
					return Convert.ToBoolean(text);

				case "System.DateTime":
					return Convert.ToDateTime(text);

				case "System.String":
					return text.ToString();
				#endregion


				#region 尺寸和边距
				case "System.Drawing.Point":
				case "System.Drawing.PointF":
				case "System.Drawing.Size":
				case "System.Drawing.SizeF":
				case "System.Drawing.Rectangle":
				case "System.Drawing.RectangleF":
				case "System.Windows.Forms.Padding":

					return GetGeomObject(text, type);
				#endregion
			}
			return null;
		}


		/// <summary>
		/// 检查数值字符串
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		protected virtual string CheckNumberString(string text)
		{
			return text.Replace(",", "");
		}

	

		#region 枚举
		protected string GetEnumText(object data, Type type)
		{
			return NoteAttribute.GetEnumValueName(data);
		}

		protected object GetEnumData(string text, Type type)
		{
			return NoteAttribute.GetEnumName(type, text);
		}
		#endregion

		#region 几何以及其它对象

		protected virtual string GetGeomString(object data, Type type)
		{
			if (data == null) return THOR_TYPE_CONVERTER_NULL;

			switch (type.ToString())
			{
				case "System.Drawing.Point":
					{
						System.Drawing.Point d = (System.Drawing.Point)data;
						return String.Format("{0}, {1}", d.X, d.Y);
					}

				case "System.Drawing.PointF":
					{
						System.Drawing.PointF d = (System.Drawing.PointF)data;
						return String.Format("{0}, {1}", d.X, d.Y);
					}

				case "System.Drawing.Size":
					{
						System.Drawing.Size d = (System.Drawing.Size)data;
						return String.Format("{0}, {1}", d.Width, d.Height);
					}

				case "System.Drawing.SizeF":
					{
						System.Drawing.SizeF d = (System.Drawing.SizeF)data;
						return String.Format("{0}, {1}", d.Width, d.Height);
					}

				case "System.Drawing.Rectangle":
					{
						System.Drawing.Rectangle d = (System.Drawing.Rectangle)data;
						return String.Format("{0}, {1}, {2}, {3}", d.X, d.Y, d.Width, d.Height);
					}

				case "System.Drawing.RectangleF":
					{
						System.Drawing.RectangleF d = (System.Drawing.RectangleF)data;
						return String.Format("{0}, {1}, {2}, {3}", d.X, d.Y, d.Width, d.Height);
					}

				case "System.Windows.Forms.Padding":
					{
						System.Windows.Forms.Padding d = (System.Windows.Forms.Padding)data;
						return String.Format("{0}, {1}, {2}, {3}", d.Left, d.Top, d.Right, d.Bottom);
					}
			}

			return (data == null) ? THOR_TYPE_CONVERTER_NULL : data.ToString();
		}

		protected virtual object GetGeomObject(string text, Type type)
		{
			string[] spans = text.Split(new char[1] { ',' });
			for (int i = 0; i < spans.Length; i++)
			{
				spans[i] = spans[i].Trim();
			}

			string typeName = type.ToString();
			switch (typeName)
			{
				case "System.Drawing.Point":
					{
						int x = Convert.ToInt32(spans[0]);
						int y = Convert.ToInt32(spans[1]);
						return new System.Drawing.Point(x, y);
					}
				case "System.Drawing.PointF":
					{
						float x = Convert.ToSingle(spans[0]);
						float y = Convert.ToSingle(spans[1]);
						return new System.Drawing.PointF(x, y);
					}
				case "System.Drawing.Size":
					{
						int w = Convert.ToInt32(spans[0]);
						int h = Convert.ToInt32(spans[1]);
						return new System.Drawing.Size(w, h);
					}
				case "System.Drawing.SizeF":
					{
						float w = Convert.ToSingle(spans[0]);
						float h = Convert.ToSingle(spans[1]);
						return new System.Drawing.SizeF(w, h);
					}
				case "System.Drawing.Rectangle":
					{
						int x = Convert.ToInt32(spans[0]);
						int y = Convert.ToInt32(spans[1]);
						int w = Convert.ToInt32(spans[2]);
						int h = Convert.ToInt32(spans[3]);
						return new System.Drawing.Rectangle(x, y, w, h);
					}
				case "System.Drawing.RectangleF":
					{
						float x = Convert.ToSingle(spans[0]);
						float y = Convert.ToSingle(spans[1]);
						float w = Convert.ToSingle(spans[2]);
						float h = Convert.ToSingle(spans[3]);
						return new System.Drawing.RectangleF(x, y, w, h);
					}
				case "System.Windows.Forms.Padding":
					{
						if (spans.Length < 4)
						{
							int a = Convert.ToInt32(spans[0]);
							return new System.Windows.Forms.Padding(a);
						}
						else
						{
							int l = Convert.ToInt32(spans[0]);
							int t = Convert.ToInt32(spans[1]);
							int r = Convert.ToInt32(spans[2]);
							int b = Convert.ToInt32(spans[3]);
							return new System.Windows.Forms.Padding(l, t, r, b);
						}
					}
			}

			return null;
		}

		#endregion

		#endregion

		#region properties

		#endregion

		#region events

		#endregion

	}
}
