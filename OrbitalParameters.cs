using System.Drawing;

namespace Planner
{
	static class REF
	{
		public const decimal YEARL = 9201600m, DAYL = 21600m;   // Length of each period in seconds
		public const int YEARD = 426;                           // Number of days in a year

		static public Orbit Kerbin
		{
			get
			{
				return new Orbit(
					13599840256.0,  // Semi-major axis
					0.0,            // Eccentricity
					0.0,            // Inclination (defunct)
					0.0,            // Longitude of the ascending node
					0.0,            // Argument of perisapsis
					9203545.0,      // Orbital period
					1.1723328E18,   // Standard gravitational parameter of parent body
					3.14);          // Mean anomaly at T = 0
			}
		}

		static public Orbit Eve
		{
			get
			{
				return new Orbit(
					9832684544.0,   // Semi-major axis
					0.01,           // Eccentricity
					0.0,            // Inclination (defunct)
					0.2618,         // Longitude of the ascending node
					0.0,            // Argument of perisapsis
					5657995.0,      // Orbital period
					1.1723328E18,   // Standard gravitational parameter of parent body
					3.14);          // Mean anomaly at T = 0
			}
		}

		static public Orbit Moho
		{
			get
			{
				return new Orbit(
					5263138304.0,   // Semi-major axis
					0.2,            // Eccentricity
					0.0,            // Inclination (defunct)
					0.2618,         // Longitude of the ascending node
					1.2217,            // Argument of perisapsis
					2215754.0,      // Orbital period
					1.1723328E18,   // Standard gravitational parameter of parent body
					3.14);          // Mean anomaly at T = 0
			}
		}

		static public Orbit Duna
		{
			get
			{
				return new Orbit(
					20726155264.0,   // Semi-major axis
					0.05,            // Eccentricity
					0.0,            // Inclination (defunct)
					2.3649,         // Longitude of the ascending node
					0.0,            // Argument of perisapsis
					17315400.0,      // Orbital period
					1.1723328E18,   // Standard gravitational parameter of parent body
					3.14);          // Mean anomaly at T = 0
			}
		}

		static public Orbit Dres
		{
			get
			{
				return new Orbit(
					40839348203.0,   // Semi-major axis
					0.14,            // Eccentricity
					0.0,            // Inclination (defunct)
					4.8869,         // Longitude of the ascending node
					1.5708,            // Argument of perisapsis
					47893063.0,      // Orbital period
					1.1723328E18,   // Standard gravitational parameter of parent body
					3.14);          // Mean anomaly at T = 0
			}
		}

		static public Orbit Jool
		{
			get
			{
				return new Orbit(
					68773560320.0,  // Semi-major axis
					0.05,            // Eccentricity
					0.0,            // Inclination (defunct)
					0.9076,         // Longitude of the ascending node
					0.0,            // Argument of perisapsis
					104661432.0,      // Orbital period
					1.1723328E18,   // Standard gravitational parameter of parent body
					0.1);          // Mean anomaly at T = 0
			}
		}

		static public Orbit Eeloo
		{
			get
			{
				return new Orbit(
					90118820000.0,   // Semi-major axis
					0.26,            // Eccentricity
					0.0,            // Inclination (defunct)
					0.8727,         // Longitude of the ascending node
					4.5379,            // Argument of perisapsis
					156992048.0,      // Orbital period
					1.1723328E18,   // Standard gravitational parameter of parent body
					3.14);          // Mean anomaly at T = 0
			}
		}

		// Systems
		static public StarChart Kerbol
		{
			get
			{
				StarChart Kerbol = new StarChart();
				Kerbol.AddPlanet(new CelestialBody("Moho", REF.Moho, Color.Brown));
				Kerbol.AddPlanet(new CelestialBody("Eve", REF.Eve, Color.Purple));
				Kerbol.AddPlanet(new CelestialBody("Kerbin", REF.Kerbin, Color.LightGreen));
				Kerbol.AddPlanet(new CelestialBody("Duna", REF.Duna, Color.DarkRed));
				Kerbol.AddPlanet(new CelestialBody("Dres", REF.Dres, Color.DarkOrange));
				Kerbol.AddPlanet(new CelestialBody("Jool", REF.Jool, Color.Green));
				Kerbol.AddPlanet(new CelestialBody("Eeloo", REF.Eeloo, Color.DarkGray));
				return Kerbol;
			}
		}
	}
}