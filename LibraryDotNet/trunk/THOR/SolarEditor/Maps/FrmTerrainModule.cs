using SolarEditor.Maps.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using THOR.Windows.Editors.Common.Data;

namespace SolarEditor.Maps
{
	public partial class FrmTerrainModule : THOR.Windows.Editors.Common.Dialogs.FrmAbstractModule
	{
		#region construct
		/// <summary>
		/// 构造
		/// </summary>
		public FrmTerrainModule()
		{
			InitializeComponent();
		} 
		#endregion

		#region methods
		/// <summary>
		/// 选定数据时
		/// </summary>
		/// <param name="entity"></param>
		protected override void OnEntitySelectionChanged(CEntity entity)
		{
			base.OnEntitySelectionChanged(entity);

			treeTerrain.DataTable = CTerrainController.GetDataTable(CurrentTerrain);
		}





		#endregion

		#region properties

		public CTerrain CurrentTerrain
		{
			get
			{
				if (modelsNavigation.SelectedEntity is CTerrain)
				{
					return (CTerrain)modelsNavigation.SelectedEntity;
				}
				return null;
			}
		}
	
		#endregion

		
	}
}
