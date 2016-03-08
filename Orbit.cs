using static System.Math;

namespace Planner
{
	class Orbit
	{
		#region Parameters
		// Static parameters
		double semiMajor;       // Length of semimajor axis
		double eccentricity;    // Elliptical eccentricity (0 - circle)
		double inclination;     // Inclination of periapsis
		double longitude;       // Longitude of the ascending node
		double argument;        // Argument of periapsis
		double period;          // Sidereal orbital period
		double gm;              // Standard gravitational parameter of parent body

		// Dynamic parameters
		Phase phaseStarting;         // Phase at T = 0
		Phase phaseCurrent;          // Phase at Epoch
		Phase phaseProjected;       // Phase at Epoch + T

		Coord[] path = new Coord[18];   // Graphical representation
		#endregion

		#region Constructor
		public Orbit(
			double semiMajor,
			double eccentricity,
			double inclination,
			double longitude,
			double argument,
			double period,
			double GM,
			double mean)
		{
			this.semiMajor = semiMajor;
			this.eccentricity = eccentricity;
			this.inclination = inclination;
			this.longitude = longitude;
			this.argument = argument;
			this.period = period;
			this.gm = GM;
			phaseStarting = new Phase(eccentricity, mean);
			phaseCurrent = phaseStarting;
			phaseProjected = phaseStarting;
			GeneratePath();
		}
		#endregion

		#region Properties
		// Change true anomaly
		public double SemiMajor
		{
			get { return semiMajor; }
		}

		public double Eccentricity
		{
			get { return eccentricity; }
		}

		public double Inclination
		{
			get { return inclination; }
		}

		public double Longitude
		{
			get { return longitude; }
		}

		public double Argument
		{
			get { return argument; }
		}

		public double Period
		{
			get { return period; }
		}

		public double GM
		{
			get { return gm; }
		}

		// Returns array of cartesian coordinates for rendering of orbital path
		public Coord[] OutputPath
		{
			get { return path; }
		}

		internal Phase PhaseStarting
		{
			get { return phaseStarting; }
		}

		internal Phase PhaseCurrent
		{
			get { return phaseCurrent; }
		}

		internal Phase PhaseProjected
		{
			get { return phaseProjected; }
		}
		#endregion

		#region Internal methods
		Coord GetCoords(double rotation, double phase, double latus)
		{
			// Find radius at phase
			double currentRadius = latus / (1 - eccentricity * Cos(phase - rotation));
			// Convert polar to cartesian
			decimal x = (decimal)(currentRadius * Cos(phase));
			decimal y = (decimal)(currentRadius * Sin(phase));
			return new Coord(x, y);
		}
		Coord GetCoords(double phase, double? radius)    // Get extended phase indicator
		{
			// Convert polar to cartesian
			decimal x = (decimal)(radius * Cos(phase));
			decimal y = (decimal)(radius * Sin(phase));
			return new Coord(x, y);
		}

		void _Advance(decimal seconds)
		{
			decimal rateOfRotation = (decimal)(2 * PI / period);
			decimal progress = (decimal)phaseStarting.MeanAnomaly + rateOfRotation * seconds;
			phaseCurrent = new Phase(eccentricity, (double)progress);
		}

		void _Project(decimal seconds)
		{
			decimal rateOfRotation = (decimal)(2 * PI / period);
			decimal progress = (decimal)phaseCurrent.MeanAnomaly + rateOfRotation * seconds;
			phaseProjected = new Phase(eccentricity, (double)progress);
		}
		#endregion

		#region Public Methods
		// Produces array of points for rendering
		public void GeneratePath()
		{
			double totalArgument = longitude + argument;
			double angularCoordinate = totalArgument - PI;
			double latus = semiMajor * (1 - eccentricity * eccentricity);
			for (int i = 0; i < 18; i++)
			{
				// Find radius at phase
				double currentPhase = totalArgument + i * PI / 9;
				path[i] = GetCoords(angularCoordinate, currentPhase, latus);
			}
		}

		// Returns cartesian location of object at current anomaly
		public Coord OutputPhase(double? radius = null)  // Current phase
		{
			double totalArgument = longitude + argument;
			double angularCoordinate = totalArgument - PI;
			double currentPhase = phaseCurrent.TrueAnomaly + totalArgument;
			double latus = semiMajor * (1 - eccentricity * eccentricity);

			if (radius != null) { return GetCoords(currentPhase, radius); }
			else { return GetCoords(angularCoordinate, currentPhase, latus); }
		}
		public Coord OutputProjected(double? radius = null)  // Projected phase
		{
			double totalArgument = longitude + argument;
			double angularCoordinate = totalArgument - PI;
			double projectedPhase = phaseProjected.TrueAnomaly + totalArgument;
			double latus = semiMajor * (1 - eccentricity * eccentricity);

			if (radius != null) { return GetCoords(projectedPhase, radius); }
			else { return GetCoords(angularCoordinate, projectedPhase, latus); }
		}

		public double GetRadius()
		{
			double totalArgument = longitude + argument;
			double angularCoordinate = totalArgument - PI;
			double currentPhase = phaseCurrent.TrueAnomaly + totalArgument;
			double latus = semiMajor * (1 - eccentricity * eccentricity);
			double currentRadius = latus / (1 - eccentricity * Cos(currentPhase - angularCoordinate));

			return currentRadius;
		}

		// Evaluate position for given Epoch from T=0
		public void Advance(decimal seconds)
		{
			_Advance(seconds);
		}
		public void Advance(decimal years, decimal days)
		{
			// Starting Epoch (T=0) is Year 1, Day 1, hence we subtract one from each
			decimal seconds = (years - 1) * REF.YEARL + (days - 1) * REF.DAYL;
			_Advance(seconds);
		}

		// Evaluate projected position for given time since Epoch
		public void Project(decimal seconds)
		{
			_Project(seconds);
		}
		public void Project(decimal years, decimal days)
		{
			decimal seconds = years * REF.YEARL + days * REF.DAYL;
			_Project(seconds);
		}
		#endregion
	}
}
