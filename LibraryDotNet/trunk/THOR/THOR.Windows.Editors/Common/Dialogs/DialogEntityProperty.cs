using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using THOR.Windows.Editors.Common.Data;
using THOR.Windows.Languages;

namespace THOR.Windows.Editors.Common.Dialogs
{
	public partial class DialogEntityProperty : THOR.Windows.Dialogs.FlatDialog
	{

		protected CEntity CurrentEntity;

		public DialogEntityProperty()
		{
			InitializeComponent();
			InitLanguages();

			canResize = false;
		}

		protected virtual void InitLanguages()
		{
			this.Text = ThorLanguages.Current.GetText("/language/dialogs/entity.property/title", "Property");

			lblID.Text = ThorLanguages.Current.GetText("/language/dialogs/entity.property/id", "ID:");
			lblName.Text = ThorLanguages.Current.GetText("/language/dialogs/entity.property/name", "Name:");
			lblPrefix.Text = ThorLanguages.Current.GetText("/language/dialogs/entity.property/prefix", "Prefix:");
			lblSuffix.Text = ThorLanguages.Current.GetText("/language/dialogs/entity.property/suffix", "Suffix:");
			lblCategory.Text = ThorLanguages.Current.GetText("/language/dialogs/entity.property/category", "Category:");
			lblDescription.Text = ThorLanguages.Current.GetText("/language/dialogs/entity.property/description", "Description:");
		}

		public virtual void SetEntity(CEntity entity)
		{
			CurrentEntity = entity;

			txtID.TextBox.Text = entity.Id;
			txtName.TextBox.Text = entity.EditorName;
			txtDescription.TextBox.Text = entity.EditorDescription;
			txtCategory.TextBox.Text = entity.EditorCategory;
			txtPrefix.TextBox.Text = entity.EditorPrefix;
			txtSuffix.TextBox.Text = entity.EditorSuffix;
		}

		protected override bool OnClickDialogButtonOK()
		{
			if (CurrentEntity != null)
			{
				bool isNew = (CurrentEntity.Id.Trim().Length == 0);

				string szId = txtID.TextBox.Text;
				string szName = txtName.TextBox.Text;
				string szDescription = txtDescription.TextBox.Text;
				string szCategory = txtCategory.TextBox.Text;
				string szPrefix = txtPrefix.TextBox.Text;
				string szSuffix = txtSuffix.TextBox.Text;

				if (!CEntityPool.Current.VerifyID(szId))
				{
					//TODO: 提示ID不合法
					return false;
				}

				if (isNew)
				{
					if (CEntityPool.Current.ContainId(CurrentEntity.GetFullID(szId)))
					{
						//TODO: 提示ID重复
						return false;
					}

					if (CEntityPool.Current.ContainEntity(CurrentEntity))
					{
						//不应该发生此情况
						return false;
					}

					CurrentEntity.Id = szId;

					CEntityPool.Current.Add(CurrentEntity);
				}
				else
				{
					if (!CEntityPool.Current.ContainId(CurrentEntity.GetFullID(szId)))
					{
						//不应该发生此情况
						return false;
					}

					if (!CEntityPool.Current.ContainEntity(CurrentEntity))
					{
						//不应该发生此情况
						return false;
					}

					CEntityPool.Current.Remove(CurrentEntity);

					CurrentEntity.Id = szId;

					CEntityPool.Current.Add(CurrentEntity);
				}

				CurrentEntity.EditorName = szName;
				CurrentEntity.EditorDescription = szDescription;
				CurrentEntity.EditorCategory = szCategory;
				CurrentEntity.EditorPrefix = szPrefix;
				CurrentEntity.EditorSuffix = szSuffix;
			}

			return true;
		}
	}
}
