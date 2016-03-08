using static System.Math;

namespace Planner
{
	class Phase
	{
		double ecc;
		double trueAnomaly;
		double eccAnomaly;
		double meanAnomaly;

		public Phase(double ecc)
		{
			this.ecc = ecc;
			trueAnomaly = 0.0;
			eccAnomaly = 0.0;
			meanAnomaly = 0.0;
		}
		public Phase(double ecc, double mean)
		{
			this.ecc = ecc;
			meanAnomaly = mean;
			UpdateAnomaly();
		}

		public double TrueAnomaly
		{
			get { return trueAnomaly; }
		}
		public double MeanAnomaly
		{
			get { return meanAnomaly; }
			set
			{
				meanAnomaly = value;
				UpdateAnomaly();
			}
		}
		public double EccAnomaly
		{
			get { return eccAnomaly; }
		}

		// Convert mean anomaly to true anomaly based on eccentricity
		void UpdateAnomaly()
		{
			double E = meanAnomaly;
			double eps = 1;
			int failsafe = 0;
			while ((eps > 1e-7) && (failsafe < 200))
			{
				E = E - (E - ecc * Sin(E) - meanAnomaly) / (1 - ecc * Cos(E));
				eps = Abs(meanAnomaly - (E - ecc * Sin(E)));
				failsafe++;
			}
			eccAnomaly = E;
			trueAnomaly = Acos((Cos(eccAnomaly) - ecc) / (1 - ecc * Cos(eccAnomaly)));
			// Quadrant correction
			if (meanAnomaly < 0) { trueAnomaly = 2 * PI - trueAnomaly; }
			if (meanAnomaly % (2 * PI) > PI) { trueAnomaly = 2 * PI - trueAnomaly; }
		}
	}
}
