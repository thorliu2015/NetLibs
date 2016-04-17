/*
 * ThorPropertyGridDataTableBuilder
 * liuqiang@2015/11/23 17:53:11
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using THOR.Attributes.Notes;
using THOR.Windows.Components.ThorGrids.Models;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.ThorPropertyGrid
{
	public class ThorPropertyGridDataTableBuilder
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public ThorPropertyGridDataTableBuilder()
		{
		}

		#endregion

		#region methods

		public virtual ThorDataTable GetDataTable(object data)
		{
			if (data == null) return null;

			ThorDataTable table = new ThorDataTable();

			GetObjectProperties(data, table);



			return table;
		}

		protected virtual void GetObjectProperties(object data, ThorDataTable table)
		{
			table.Columns.Add(new ThorDataTableColumn() { Width = 200 });
			table.Columns.Add(new ThorDataTableColumn() { Width = 100 });

			Type type = data.GetType();
			PropertyInfo[] properties = type.GetProperties();
			List<ThorPropertyGridRowInfo> rows = new List<ThorPropertyGridRowInfo>();

			foreach (PropertyInfo property in properties)
			{
				//browse
				Attribute browsable = property.GetCustomAttribute(typeof(BrowsableAttribute));
				if (browsable is BrowsableAttribute)
				{
					BrowsableAttribute browsableAttribute = (BrowsableAttribute)browsable;
					if (!browsableAttribute.Browsable) continue;
				}

				//note
				NoteAttribute note = null;
				Attribute attribute = property.GetCustomAttribute(typeof(NoteAttribute));
				if (attribute is NoteAttribute)
				{
					note = (NoteAttribute)attribute;
				}

				ThorPropertyGridRowInfo row = new ThorPropertyGridRowInfo(data, property, note);


				//category
				Attribute categoryAttributeObj = property.GetCustomAttribute(typeof(CategoryAttribute));
				if (categoryAttributeObj is CategoryAttribute)
				{
					row.CategoryAttribute = (CategoryAttribute)categoryAttributeObj;
				}

				//displayName
				Attribute displayNameAttributeObj = property.GetCustomAttribute(typeof(DisplayNameAttribute));
				if (displayNameAttributeObj is DisplayNameAttribute)
				{
					row.DisplayNameAttribute = (DisplayNameAttribute)displayNameAttributeObj;
				}

				rows.Add(row);
			}

			//----

			rows.Sort();


			Dictionary<string, ThorDataTableRow> rowCategories = new Dictionary<string, ThorDataTableRow>();
			foreach (ThorPropertyGridRowInfo row in rows)
			{
				ThorDataTableRow r = new ThorDataTableRow();

				ThorDataTableCell cName = new ThorDataTableCell();
				ThorDataTableCell cValue = new ThorDataTableCell();

				string rCategory = row.DisplayCategory.Trim();


				cName.Text = row.DisplayName;
				cValue.Data = row.DisplayValue;
				cValue.DataType = row.PropertyInfo.PropertyType;
				cValue.CellBindPropertyInfo = row.PropertyInfo;
				cValue.CellBindPropertyObject = row.Data;
				//cValue.Text = (row.DisplayValue == null ? "" : row.DisplayValue.ToString());

				r.Cells.Add(cName);
				r.Cells.Add(cValue);

				if (!rowCategories.ContainsKey(rCategory))
				{
					ThorDataTableRow rowCategory = new ThorDataTableRow();
					ThorDataTableCell cellCategoryName = new ThorDataTableCell();
					cellCategoryName.Text = rCategory;
					rowCategory.Cells.Add(cellCategoryName);
					rowCategories[rCategory] = rowCategory;
					table.Rows.Add(rowCategory);
				}

				rowCategories[rCategory].Rows.Add(r);

			}
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}

	public class ThorPropertyGridRowInfo : IComparable<ThorPropertyGridRowInfo>
	{
		public ThorPropertyGridRowInfo(object data, PropertyInfo propertyInfo, NoteAttribute noteAttribute)
		{
			this.Data = data;
			this.PropertyInfo = propertyInfo;
			this.NoteAttribute = noteAttribute;
		}

		public override string ToString()
		{
			string sCategory = "";
			string sName = "";

			if (this.NoteAttribute != null)
			{
				sCategory = this.NoteAttribute.Category;
				sName = this.NoteAttribute.Name;
			}
			else
			{
				sName = this.PropertyInfo.Name;
			}

			return String.Format("{{{0} {1}}}", sCategory, sName);
		}

		public Object Data { get; set; }
		public PropertyInfo PropertyInfo { get; set; }
		public NoteAttribute NoteAttribute { get; set; }

		public CategoryAttribute CategoryAttribute { get; set; }
		public DisplayNameAttribute DisplayNameAttribute { get; set; }


		public string DisplayName
		{
			get
			{
				if (NoteAttribute != null)
				{
					return NoteAttribute.Name;
				}

				else if (DisplayNameAttribute != null)
				{
					return DisplayNameAttribute.DisplayName;
				}

				return PropertyInfo.Name;
			}
		}

		public string DisplayCategory
		{
			get
			{
				if (NoteAttribute != null)
				{
					return NoteAttribute.Category;
				}
				else if (CategoryAttribute != null)
				{
					return CategoryAttribute.Category;
				}
				return "";
			}

		}

		public object DisplayValue
		{
			get
			{
				return PropertyInfo.GetValue(Data);
			}
		}

		//----

		/// <summary>
		/// 比较
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public virtual int CompareTo(ThorPropertyGridRowInfo other)
		{
			int ret = 0;

			if (other == this)
			{
				ret = 0;
			}
			else if (other == null)
			{
				ret = 1;
			}
			else
			{
				string pCategoryThis = "";
				string pNameThis = "";
				int nSortThis = 0;
				int nSortCategoryThis = 0;

				string pCategoryOther = "";
				string pNameOther = "";
				int nSortOther = 0;
				int nSortCategoryOther = 0;

				//this
				pCategoryThis = this.DisplayCategory;
				pNameThis = this.DisplayName;
				if (this.NoteAttribute != null)
				{
					nSortThis = this.NoteAttribute.SortIndex;
					nSortCategoryThis = this.NoteAttribute.CategorySortIndex;
				}


				//other
				pCategoryOther = other.DisplayCategory;
				pNameOther = other.DisplayName;
				if (other.NoteAttribute != null)
				{
					nSortOther = other.NoteAttribute.SortIndex;
					nSortCategoryOther = other.NoteAttribute.CategorySortIndex;
				}


				if (pCategoryThis != pCategoryOther)
				{
					//if (pCategoryThis.Trim().Length == 0 || pCategoryOther.Trim().Length == 0)
					//{
					//	Debug.WriteLine("?");
					//}

					if (pCategoryOther.Trim().Length == 0)
					{
						ret = -1;
					}
					else if (pCategoryThis.Trim().Length == 0)
					{
						ret = 1;
					}
					else
					{
						if (nSortCategoryThis != nSortCategoryOther)
						{
							ret = CompareInt(nSortCategoryThis, nSortCategoryOther);
						}
						else
						{

							ret = String.Compare(pCategoryThis, pCategoryOther);
						}
					}
				}
				else
				{
					if (nSortThis != nSortOther)
					{
						ret = CompareInt(nSortThis, nSortOther);
					}
					else
					{
						ret = String.Compare(pNameThis, pNameOther);
					}
				}
			}

			return ret;
		}

		/// <summary>
		/// 数值比较s
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		static public int CompareInt(int a, int b)
		{
			if (a > b)
			{
				return 1;
			}
			else if (a < b)
			{
				return -1;
			}
			else
			{
				return 0;
			}
		}
	}
}
