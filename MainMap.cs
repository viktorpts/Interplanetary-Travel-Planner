using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planner
{
	public partial class MainMap : Form
	{
		public MainMap()
		{
			InitializeComponent();
			GInit();
		}

		private void StarChart_Paint(object sender, PaintEventArgs e)
		{
			Output();
		}

		private void DateDaysChanged(object sender, EventArgs e)
		{
			// Change days
			if (DateDaysSpinner.Value == 0m) 
			{
				if (DateYearsSpinner.Value > 1m)
				{
					DateDaysSpinner.Value = REF.YEARD;
					DateYearsSpinner.Value--;
				}
				else
				{
					DateDaysSpinner.Value = 1m;
				}
			}
			else if (DateDaysSpinner.Value > REF.YEARD)
			{
				DateDaysSpinner.Value = 1m;
				if (DateYearsSpinner.Value < 500m)
				{
					DateYearsSpinner.Value++;
				}
			}
			_Advance(DateYearsSpinner.Value, DateDaysSpinner.Value);
			_Project(ProjectedYearsSpinner.Value, ProjectedDaysSpinner.Value);

			Output();
		}

		private void DateYearsChanged(object sender, EventArgs e)
		{
			// Change years
			_Advance(DateYearsSpinner.Value, DateDaysSpinner.Value);
			_Project(ProjectedYearsSpinner.Value, ProjectedDaysSpinner.Value);

			Output();
		}

		private void ProjectedYearsChanged(object sender, EventArgs e)
		{
			// Change years
			_Project(ProjectedYearsSpinner.Value, ProjectedDaysSpinner.Value);
			Output();
		}

		private void ProjectedDaysChanged(object sender, EventArgs e)
		{
			// Change days
			if (ProjectedDaysSpinner.Value < 0)
			{
				if (ProjectedYearsSpinner.Value > 0m)
				{
					ProjectedDaysSpinner.Value = REF.YEARD - 1;
					ProjectedYearsSpinner.Value--;
				}
				else
				{
					ProjectedDaysSpinner.Value = 0m;
				}
			}
			else if (ProjectedDaysSpinner.Value > REF.YEARD - 1)
			{
				if (ProjectedYearsSpinner.Value < 500m)
				{
					ProjectedDaysSpinner.Value = 0m;
					ProjectedYearsSpinner.Value++;
				}
			}
			_Project(ProjectedYearsSpinner.Value, ProjectedDaysSpinner.Value);
			Output();
		}

		private void CheckChanged(object sender, EventArgs e)
		{
			if (sender == CheckMoho) System.Visible[0] = CheckMoho.Checked;
			if (sender == CheckEve) System.Visible[1] = CheckEve.Checked;
			if (sender == CheckKerbin) System.Visible[2] = CheckKerbin.Checked;
			if (sender == CheckDuna) System.Visible[3] = CheckDuna.Checked;
			if (sender == CheckDres) System.Visible[4] = CheckDres.Checked;
			if (sender == CheckJool) System.Visible[5] = CheckJool.Checked;
			if (sender == CheckEeloo) System.Visible[6] = CheckEeloo.Checked;

			GetScale();
			System.UpdatePath();
			Output();
		}

		private void ExtendPhaseChecked(object sender, EventArgs e)
		{
			MainMap.ExtendPhase = ExtendPhaseCheck.Checked;
			Output();
		}

		private void Transfer_Combo_Changed(object sender, EventArgs e)
		{
			UpdateTransfer(Transfer_Combo_StartingBody.SelectedIndex);
			Output();
		}

		private void DeltaV_Changed(object sender, EventArgs e)
		{
			double deltaV = 0.0;
			if (!double.TryParse(DeltaV_Box.Text, out deltaV))
			{
				return;
			}
			//Transfer_List.Items.Add("deltaV= " + deltaV.ToString("F2") + " m/s");
			System.Transfer.ModifyOrbit(double.Parse(DeltaV_Box.Text));
			System.Transfer.Project(ProjectedYearsSpinner.Value, ProjectedDaysSpinner.Value);
			Output();
		}

		private void DeltaV_Step(object sender, EventArgs e)
		{
			double deltaV = 0.0;
			if (!double.TryParse(DeltaV_Box.Text, out deltaV))
			{
				deltaV = System.Transfer.DeltaV;
			}
			if (sender == Button_DeltaV_R1) { deltaV -= 1.0; }
			if (sender == Button_DeltaV_R2) { deltaV -= 10.0; }
			if (sender == Button_DeltaV_R3) { deltaV -= 100.0; }
			if (sender == Button_DeltaV_P1) { deltaV += 1.0; }
			if (sender == Button_DeltaV_P2) { deltaV += 10.0; }
			if (sender == Button_DeltaV_P3) { deltaV += 100.0; }
			DeltaV_Box.Text = deltaV.ToString("F1");
		}

		private void FocusChanged(object sender, EventArgs e)
		{
			SetFocus(FocusControl.SelectedIndex);
		}
	}
}
