using System.Drawing;

namespace Planner
{
	class StarChart
	{
		CelestialBody[] planets;
		TransferOrbit transfer;

		public StarChart()
		{
			planets = null;
			transfer = null;
			Visible = null;
		}

		// Provide a list of all planets
		public CelestialBody[] List
		{
			get { Update(); return planets; }
		}
		public TransferOrbit Transfer
		{
			get { return transfer; }
		}
		public bool[] Visible
		{
			get; set;
		}

		public void AddPlanet(CelestialBody planet)
		{
			if (planets == null)     // Initialize array of satellintes
			{
				planets = new CelestialBody[1];
				planets[0] = planet;
				Visible = new bool[1];
				Visible[0] = true;
			}
			else
			{
				int len = planets.Length + 1;
				CelestialBody[] temp = planets;
				bool[] tempv = Visible;
				planets = new CelestialBody[len];
				Visible = new bool[len];
				for (int i = 0; i < len - 1; i++)
				{
					planets[i] = temp[i];
					Visible[i] = tempv[i];
				}
				planets[len - 1] = planet;
				Visible[len - 1] = true;
			}
		}

		public void AddTransfer(TransferOrbit transfer)
		{
			this.transfer = transfer;
		}

		public void ShowTransfer()
		{
			transfer.Active = true;
		}

		public void UpdatePath()
		{
			foreach (CelestialBody planet in planets)
			{
				planet.UpdatePath();
			}
			transfer.UpdatePath();
		}

		// Update position of all bodies for given Epoch in seconds from T=0
		public void Advance(decimal seconds)
		{
			foreach (CelestialBody planet in planets)
			{
				planet.Advance(seconds);
			}
			transfer.Advance(seconds);
		}
		// Update position of all bodies for given Epoch in years and days from T=0
		public void Advance(decimal years, decimal days)
		{
			foreach (CelestialBody planet in planets)
			{
				planet.Advance(years, days);
			}
			transfer.Advance(years, days);
		}

		public void Project(decimal seconds)
		{
			foreach (CelestialBody planet in planets)
			{
				planet.Project(seconds);
			}
			transfer.Project(seconds);
		}
		public void Project(decimal years, decimal days)
		{
			foreach (CelestialBody planet in planets)
			{
				planet.Project(years, days);
			}
			transfer.Project(years, days);
		}

		// Update coordinates of all bodies for rendering
		public void Update()
		{
			foreach (CelestialBody planet in planets)
			{
				planet.Update();
			}
			transfer.Update();
		}
	}
}
