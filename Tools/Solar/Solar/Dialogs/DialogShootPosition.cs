using Solar.Animations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Solar.Dialogs
{
	public partial class DialogShootPosition : THOR.Windows.UI.Forms.ToolBoxBase
	{
		static public DialogShootPosition Instance { get; private set; }

		static DialogShootPosition()
		{
			Instance = new DialogShootPosition();
		}

		public DialogShootPosition()
		{
			InitializeComponent();
		}

		public void UpdateUI()
		{
			listShootPositions.Items.Clear();

			if (currentDirection == null) return;

			for (int i = 0; i < currentDirection.ShootPosition.Count; i++)
			{
				SAnimationPoint p = currentDirection.ShootPosition[i];

				ListViewItem item = new ListViewItem();
				item.Text = String.Format("{0}", i);
				item.SubItems.Add(p.X.ToString());
				item.SubItems.Add(p.Y.ToString());
				item.Tag = p;

				listShootPositions.Items.Add(item);
			}
		}

		protected SAnimationDirection currentDirection;
		public SAnimationDirection CurrentDirection
		{
			get
			{
				return currentDirection;
			}
			set
			{
				currentDirection = value;
				UpdateUI();
			}
		}

		public SAnimationPoint CurrentPoint
		{
			get
			{
				if (listShootPositions.SelectedItems.Count > 0)
				{
					if (listShootPositions.SelectedItems[0].Tag is SAnimationPoint)
					{
						SAnimationPoint p = (SAnimationPoint)listShootPositions.SelectedItems[0].Tag;

						return p;
					}
				}
				return null;
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (currentDirection == null) return;

			currentDirection.ShootPosition.Add(new SAnimationPoint());
			UpdateUI();
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (currentDirection == null) return;
			if (CurrentPoint == null) return;

			//TODO: 确认

			if (listShootPositions.SelectedItems.Count > 0)
			{
				currentDirection.ShootPosition.Remove(CurrentPoint);
				listShootPositions.SelectedItems[0].Remove();
			}

		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			if (currentDirection == null) return;
			if (CurrentPoint == null) return;

			CurrentPoint.Y--;
			listShootPositions.SelectedItems[0].SubItems[2].Text = CurrentPoint.Y.ToString();
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			if (currentDirection == null) return;
			if (CurrentPoint == null) return;

			CurrentPoint.Y++;
			listShootPositions.SelectedItems[0].SubItems[2].Text = CurrentPoint.Y.ToString();
		}

		private void btnLeft_Click(object sender, EventArgs e)
		{
			if (currentDirection == null) return;
			if (CurrentPoint == null) return;

			CurrentPoint.X--;
			listShootPositions.SelectedItems[0].SubItems[1].Text = CurrentPoint.X.ToString();
		}

		private void btnRight_Click(object sender, EventArgs e)
		{
			if (currentDirection == null) return;
			if (CurrentPoint == null) return;

			CurrentPoint.X++;
			listShootPositions.SelectedItems[0].SubItems[1].Text = CurrentPoint.X.ToString();
		}

		private void DialogShootPosition_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}
	}
}
