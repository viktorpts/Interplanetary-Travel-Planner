using System.Drawing;

namespace Planner
{
	class CelestialBody
	{
		string name;
		protected Orbit orbit;
		Point[] path;               // Derived from member
		Point positionCurrent;      // Derived from member
		Point positionProjected;	// Derived from member
		Color color;
		CelestialBody[] satellites;

		// Constructors
		public CelestialBody(string name, Orbit orbit, Color color)
		{
			this.name = name;
			this.orbit = orbit;
			this.color = color;

			satellites = null;

			UpdatePath();
			Update();
		}

		// Properties
		public Color Color
		{
			get { return color; }
		}
		public Point[] Path
		{
			get { return path; }
		}
		public Point Current
		{
			get { return positionCurrent; }
		}
		public Point Projected
		{
			get { return positionProjected; }
		}
		public CelestialBody[] List
		{
			get { return satellites; }
		}
		public double SemiMajor
		{
			get { return orbit.SemiMajor; }
		}
		public string Name
		{
			get { return name; }
		}
		public Orbit Orbit
		{
			get { return orbit; }
		}

		// Methods
		public void Update()
		{
			positionCurrent = orbit.OutputPhase().GetScaled(MainMap.StarScale, MainMap.Origin.X, MainMap.Origin.Y);
			positionProjected = orbit.OutputProjected().GetScaled(MainMap.StarScale, MainMap.Origin.X, MainMap.Origin.Y);
		}

		public void UpdatePath()
		{
			orbit.GeneratePath();
			path = Coord.GetScaled(orbit.OutputPath, MainMap.StarScale, MainMap.Origin.X, MainMap.Origin.Y);
		}

		// Evaluate position for given Epoch in seconds from T=0
		public void Advance(decimal seconds)
		{
			orbit.Advance(seconds);
		}
		// Evaluate position for given Epoch in years and days from T=0
		public void Advance(decimal years, decimal days)
		{
			orbit.Advance(years, days);
		}
		public void Project(decimal seconds)
		{
			orbit.Project(seconds);
		}
		public void Project(decimal years, decimal days)
		{
			orbit.Project(years, days);
		}

		public void AddSatellite(CelestialBody satellite)
		{
			if (satellites == null)		// Initialize array of satellintes
			{
				satellites = new CelestialBody[1];
				satellites[0] = satellite;
			}
			else
			{
				int len = satellites.Length + 1;
				CelestialBody[] temp = satellites;
				satellites = new CelestialBody[len];
				for (int i = 0; i < len - 1; i++)
				{
					satellites[i] = temp[i];
				}
				satellites[len - 1] = satellite;
			}
		}

		public Point CurrentExt(double? radius)
		{
			return orbit.OutputPhase(radius).GetScaled(MainMap.StarScale, MainMap.Origin.X, MainMap.Origin.Y);
		}
		public Point ProjectedExt(double? radius)
		{
			return orbit.OutputProjected(radius).GetScaled(MainMap.StarScale, MainMap.Origin.X, MainMap.Origin.Y);
		}
	}
}
