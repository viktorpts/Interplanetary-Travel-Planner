using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace Planner
{
	public partial class MainMap : Form
	{
		// Rendergin parameters
		public static double StarScale = 1.4E-8;
		// Position of the sun, essentially center of the rendering area, used for offsetting coordinates
		public static Point Origin = new Point(320, 320);
		public static Point Offset = new Point(0, 0);

		public static bool ExtendPhase = false;
		public static int FocusBody = -1;

		// Graphical settings
		Graphics graphics;

		// Star chart to display
		StarChart System;

		private void GInit()
		{
			// Initialize star system and add celestial objects
			System = REF.Kerbol;
			AddPlanet("Moho");
			AddPlanet("Eve");
			AddPlanet("Kerbin");
			AddPlanet("Duna");
			AddPlanet("Dres");
			AddPlanet("Jool");
			AddPlanet("Eeloo");

			System.AddTransfer(new TransferOrbit("Transfer", REF.Moho, Color.Yellow));

			GetScale();
			System.UpdatePath();

			graphics = PanelStarChart.CreateGraphics();
			graphics.Clear(Color.Black);

			// DEBUG
			//UpdateTransfer(0);
			// END DEBUG
		}

		private void Output()
		{
			graphics.Clear(Color.Black);

			for (int i = 0; i < System.List.Length; i++)
			{
				if (System.Visible[i]) RenderBody(System.List[i], ExtendPhase);
			}

			// Draw transfer orbit if set
			if (System.Transfer.Active == true)
			{
				RenderBody(System.Transfer, ExtendPhase);
				UpdateTransferInfo();
			}

			// Draw focus body
			if (FocusBody == -1)
			{
				// Draw sun
				graphics.FillEllipse(Brushes.Yellow, new Rectangle(Origin.X - 10, Origin.Y - 10, 20, 20));
			}
			else
			{
				// Draw planet
				graphics.FillEllipse(new SolidBrush(System.List[FocusBody].Color), new Rectangle(Origin.X - 10, Origin.Y - 10, 20, 20));
			}
		}

		// Render planetary orbit
		void RenderBody(CelestialBody body, bool extend = false)
		{
			double? radius = null;
			if (extend)
			{
				radius = Origin.X / StarScale * 1.4;
			}
			Pen penOrbit = new Pen(body.Color, 1.0f);           //TEMP
																//penOrbit.DashPattern = new float[] { 4.0f, 2.0f };  //TEMP

			SolidBrush brushOrbit = new SolidBrush(body.Color);

			// Orbital ellipse
			graphics.DrawClosedCurve(penOrbit, body.Path);
			// Current position
			if (radius != null) { graphics.DrawLine(penOrbit, Origin, body.CurrentExt(radius)); }
			else { graphics.DrawLine(penOrbit, Origin, body.Current); }
			graphics.FillEllipse(brushOrbit, new Rectangle(body.Current.X - 6, body.Current.Y - 6, 12, 12));
			// Projected position
			penOrbit.DashPattern = new float[] { 2.0f, 2.0f };  //TEMP
			if (radius != null) { graphics.DrawLine(penOrbit, Origin, body.ProjectedExt(radius)); }
			else { graphics.DrawLine(penOrbit, Origin, body.Projected); }
			graphics.DrawEllipse(penOrbit, new Rectangle(body.Projected.X - 6, body.Projected.Y - 6, 12, 12));
			// Periapse
			penOrbit.DashPattern = new float[] { 12.0f, (float)Origin.X };
			graphics.DrawLine(penOrbit, body.Path[0], Origin);
		}
		// Render orbit as transfer
		void RenderBody(TransferOrbit transfer, bool extend = false)
		{
			double? radius = null;
			if (extend)
			{
				radius = Origin.X / StarScale * 1.4;
			}
			Pen penOrbit = new Pen(transfer.Color, 2.0f);
			penOrbit.DashPattern = new float[] { 1.0f, 1.0f };  //TEMP

			SolidBrush brushOrbit = new SolidBrush(transfer.Color);

			// Orbital ellipse
			graphics.DrawClosedCurve(penOrbit, transfer.Path);
			// Current position
			if (radius != null) { graphics.DrawLine(penOrbit, Origin, transfer.CurrentExt(radius)); }
			else { graphics.DrawLine(penOrbit, Origin, transfer.Current); }

			// Projected position
			penOrbit.DashPattern = new float[] { 1.0f, 4.0f };  //TEMP
			if (radius != null) { graphics.DrawLine(penOrbit, Origin, transfer.ProjectedExt(radius)); }
			else { graphics.DrawLine(penOrbit, Origin, transfer.Projected); }
			// Periapse
			penOrbit.DashPattern = new float[] { 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, (float)Origin.X };
			graphics.DrawLine(penOrbit, transfer.Path[0], Origin);

			// Ship symbols
			SolidBrush penBrush = new SolidBrush(Color.Red);
			Pen penShip = new Pen(Color.Red, 2.0f);
			penShip.DashPattern = new float[] { 1.0f, 0.5f };

			graphics.FillPolygon(penBrush, Symbols.Ship(transfer.Current));
			graphics.DrawLines(penShip, Symbols.Ship(transfer.Projected));

			#region DEBUG
			// DEBUG
			// Display vectors
			//Pen penVector = new Pen(Color.Blue, 2.0f);
			//penVector.Color = Color.Green;

			//Point[] vector1 = VGD.VectorLine(transfer.PositionVector);
			//Point[] vector2 = VGD.VectorLine(transfer.PositionVector, VGD.Scale(transfer.VelocityVector, Sun.X / 2));
			//Point[] vector3 = VGD.VectorLine(VGD.Scale(transfer.EccentricityVector, Sun.X));
			//graphics.DrawLine(penVector, vector1[0], vector1[1]);
			//penVector.Color = Color.Red;
			//graphics.DrawLine(penVector, vector2[0], vector2[1]);
			//penVector.Color = Color.Blue;
			//graphics.DrawLine(penVector, vector3[0], vector3[1]);

			// Verify angles
			//Point[] anomaly = VGD.Ray(transfer.Orbit.PhaseCurrent.EccAnomaly);
			//penVector.Color = Color.Pink;
			//penVector.DashPattern = new float[] { 1.0f, 1.0f };
			//graphics.DrawLine(penVector, anomaly[0], anomaly[1]);

			//anomaly = VGD.Ray(transfer.Orbit.PhaseCurrent.TrueAnomaly);
			//penVector.Color = Color.Blue;
			//graphics.DrawLine(penVector, anomaly[0], anomaly[1]);
			#endregion
		}

		public double GetScale()
		{
			int nOfOrbits = System.List.Length;
			double[] axes = new double[nOfOrbits];
			for (int i = 0; i < nOfOrbits; i++)
			{
				if (System.Visible[i]) axes[i] = System.List[i].SemiMajor;
				else axes[i] = REF.Moho.SemiMajor;  // Set unassigned vaues to the smallest orbit, to avoid exceptions
			}
			StarScale = (double)Origin.X / axes.Max() * 0.84;
			return StarScale;
		}

		void UpdateTransfer(int input)
		{
			// Get orbital parameters of selcted body
			CelestialBody RefBody = System.List[input];
			System.AddTransfer(new TransferOrbit(RefBody.Name, RefBody.Orbit, Color.Yellow));
			System.Transfer.Active = true;
			DeltaV_Box.Text = "0.0";

			UpdateTransferInfo();
		}

		void UpdateTransferInfo()
		{
			// Clear previous contents
			Transfer_List.BeginUpdate();
			Transfer_List.Items.Clear();

			Transfer_List.Items.Add(System.Transfer.Name + " orbital parameters at Epoch:");
			Transfer_List.Items.Add("v= " + (System.Transfer.Velocity).ToString("N0") + " m/s");
			Transfer_List.Items.Add("r= " + (System.Transfer.Orbit.GetRadius() / 1000).ToString("N0") + " km");
			Transfer_List.Items.Add("");
			Transfer_List.Items.Add("Mean Anomaly=\t" + System.Transfer.Orbit.PhaseCurrent.MeanAnomaly.ToString("F4") + " radians");
			Transfer_List.Items.Add("Ecc Anomaly=\t" + System.Transfer.Orbit.PhaseCurrent.EccAnomaly.ToString("F4") + " radians");
			Transfer_List.Items.Add("True Anomaly=\t" + System.Transfer.Orbit.PhaseCurrent.TrueAnomaly.ToString("F4") + " radians");


			// Paint element
			Transfer_List.EndUpdate();
		}

		public void ClearPlanets()
		{
			Transfer_Combo_StartingBody.Items.Clear();
		}

		public void AddPlanet(string name)
		{
			Transfer_Combo_StartingBody.Items.Add(name);
		}

		void _Project(decimal years, decimal days)
		{
			System.Project(years, days);
		}

		void _Advance(decimal years, decimal days)
		{
			System.Advance(years, days);
		}

		void SetFocus(int index)
		{
			switch (index)
			{
				case 0:
					// Sun
					FocusBody = -1;
					break;
				case 1:
					// Kerbin
					FocusBody = 2;
					break;
				case 2:
					// Eve
					FocusBody = 1;
					break;
				case 3:
					// Duna
					FocusBody = 3;
					break;
				case 4:
					// Jool
					FocusBody = 5;
					break;
			}
			Output();
		}
	}
}
