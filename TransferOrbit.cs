using System.Drawing;
using static System.Math;
using System.Windows.Media.Media3D;

namespace Planner
{
	struct RotationMatrix
	{
		#region Default matrices
		public static Matrix3D X(double A)
		{
			return new Matrix3D(
				1.0, 0.0, 0.0, 0.0,
				0.0, Cos(A), -Sin(A), 0.0,
				0.0, Sin(A), Cos(A), 0.0,
				0.0, 0.0, 0.0, 0.0
				);
		}
		public static Matrix3D Y(double A)
		{
			return new Matrix3D(
				Cos(A), 0.0, -Sin(A), 0.0,
				0.0, 1.0, 0.0, 0.0,
				Sin(A), 0.0, Cos(A), 0.0,
				0.0, 0.0, 0.0, 0.0
				);
		}
		public static Matrix3D Z(double A)
		{
			return new Matrix3D(
				Cos(A), Sin(A), 0.0, 0.0,
				-Sin(A), Cos(A), 0.0, 0.0,
				0.0, 0.0, 1.0, 0.0,
				0.0, 0.0, 0.0, 0.0
				);
		}
		#endregion

		#region Operation
		public static Vector3D RotateX(Vector3D v, double A)
		{
			return Vector3D.Multiply(v, X(A));
		}
		public static Vector3D RotateY(Vector3D v, double A)
		{
			return Vector3D.Multiply(v, Y(A));
		}
		public static Vector3D RotateZ(Vector3D v, double A)
		{
			return Vector3D.Multiply(v, Z(A));
		}
		#endregion
	}

	class TransferOrbit : CelestialBody
	{
		Orbit referenceOrbit;
		Vector3D velocityVector;
		Vector3D positionVector;
		double deltaV;

		public TransferOrbit(string name, Orbit orbit, Color color) : base(name, orbit, color)
		{
			Active = false;
			referenceOrbit = orbit;
			velocityVector = new Vector3D();
			positionVector = new Vector3D();
			deltaV = 0.0;
			DeriveStateVectors();
			DeriveOrbitalelements();
			UpdatePath();
			Update();
		}

		#region Properties
		public bool Active
		{
			get; set;
		}

		public double Velocity
		{
			get { return Sqrt(Orbit.GM * (2 / Orbit.GetRadius() - 1 / Orbit.SemiMajor)); }
		}

		public Vector3D VelocityVector
		{
			get
			{
				Vector3D newVelocity = velocityVector;
				newVelocity.Normalize();
				newVelocity *= deltaV;
				return velocityVector + newVelocity;
			}
		}

		public Vector3D PositionVector
		{
			get { return positionVector; }
		}

		public Vector3D OrbitalMomentum
		{
			get
			{
				return Vector3D.CrossProduct(PositionVector, VelocityVector);
			}
		}

		public Vector3D EccentricityVector
		{
			get { return ((Vector3D.CrossProduct(VelocityVector, OrbitalMomentum) / Orbit.GM) - (PositionVector / PositionVector.Length)); }
		}

		public Vector3D AscendingVector
		{
			get { return Vector3D.CrossProduct(new Vector3D(0.0, 0.0, 1.0), OrbitalMomentum); }
		}

		public double DeltaV
		{
			get { return deltaV; }
		}
		#endregion

		#region Derive state vectors
		public void DeriveStateVectors()
		{
			double radius = referenceOrbit.GetRadius();
			double[] vector = new double[3];
			vector[0] = Sqrt(referenceOrbit.GM * referenceOrbit.SemiMajor) / radius * (-Sin(referenceOrbit.PhaseCurrent.EccAnomaly));
			vector[1] = Sqrt(referenceOrbit.GM * referenceOrbit.SemiMajor) / radius * (Sqrt(1 - referenceOrbit.Eccentricity * referenceOrbit.Eccentricity) * Cos(referenceOrbit.PhaseCurrent.EccAnomaly));
			vector[2] = 0;

			velocityVector = new Vector3D(vector[0], vector[1], vector[2]);
			velocityVector = RotationMatrix.RotateZ(velocityVector, referenceOrbit.Argument);
			velocityVector = RotationMatrix.RotateX(velocityVector, referenceOrbit.Inclination);
			velocityVector = RotationMatrix.RotateZ(velocityVector, referenceOrbit.Longitude);

			vector[0] = radius * Cos(referenceOrbit.PhaseCurrent.TrueAnomaly);
			vector[1] = radius * Sin(referenceOrbit.PhaseCurrent.TrueAnomaly);
			vector[2] = 0;

			positionVector = new Vector3D(vector[0], vector[1], vector[2]);
			positionVector = RotationMatrix.RotateZ(positionVector, referenceOrbit.Argument);
			positionVector = RotationMatrix.RotateX(positionVector, referenceOrbit.Inclination);
			positionVector = RotationMatrix.RotateZ(positionVector, referenceOrbit.Longitude);
		}
		#endregion

		#region Derive orbital parameters
		public double Eccentricity()
		{
			return Round(EccentricityVector.Length, 9);
		}

		public double SemiMajor2()
		{
			return (1 / ((2 / PositionVector.Length) - (VelocityVector.LengthSquared / Orbit.GM)));
		}

		public double TrueAnomaly()
		{
			// Circular orbit
			if (Eccentricity() == 0)
			{
				// True longitude
				double angle = Acos(PositionVector.X / PositionVector.Length);
				if (PositionVector.Y < 0) angle = 2 * PI - angle;
				return angle;
			}
			else
			{
				double cosine = Vector3D.DotProduct(EccentricityVector, PositionVector) / (EccentricityVector.Length * PositionVector.Length);
				if (cosine < -1) cosine = -1;
				if (cosine > 1) cosine = 1;
				if (Vector3D.DotProduct(PositionVector, VelocityVector) >= 0)
				{
					return Acos(cosine);
				}
				else
					return (2 * PI - Acos(cosine));
			}
		}

		public double MeanAnomaly()
		{
			double ecc = Eccentricity();
			double eccAnomaly = 2 * Atan(Tan(TrueAnomaly() / 2) / Sqrt((1 + ecc) / (1 - ecc)));
			return eccAnomaly - ecc * Sin(eccAnomaly);
		}

		public double OrbitalPeriod()
		{
			return Round(2 * PI * Sqrt(Pow(SemiMajor2(), 3.0) / Orbit.GM), 0);
		}

		public double Longitude()
		{
			if (AscendingVector.X == 0 || AscendingVector.Length == 0) return 0.0;
			double angle = Round(Acos(AscendingVector.X / AscendingVector.Length), 12);
			if (AscendingVector.Y >= 0)
			{
				return angle;
			}
			else
				return 2 * PI - angle;
		}

		public double Argument()
		{
			double angle = 0.0;
			if (AscendingVector.Length == 0)
			{
				// Determine longitude of periapsis instead
				if (Eccentricity() == 0) return 0.0;
				else
				{
					angle = Acos(EccentricityVector.X / EccentricityVector.Length);
					if (EccentricityVector.Y < 0) angle = 2 * PI - angle;
					return angle;
				}
			}
			angle = Round(Acos(Vector3D.DotProduct(AscendingVector, EccentricityVector) / (AscendingVector.Length * EccentricityVector.Length)), 12);
			if (EccentricityVector.Z >= 0)
			{
				return angle;
			}
			else
				return 2 * PI - angle;
		}

		public void DeriveOrbitalelements()
		{
			double ecc = Eccentricity();
			if (ecc == 0)
			{
				orbit = new Orbit(
					SemiMajor2(),       // Semi-major axis
					Eccentricity(),     // Eccentricity
					0.0,                // Inclination (defunct)
					0.0,                // Longitude of the ascending node
					0.0,                // Argument of perisapsis
					OrbitalPeriod(),    // Orbital period
					Orbit.GM,           // Standard gravitational parameter of parent body
					TrueAnomaly());     // Mean anomaly at T = 0
			}
			else
			{
				orbit = new Orbit(
					SemiMajor2(),       // Semi-major axis
					Eccentricity(),     // Eccentricity
					0.0,                // Inclination (defunct)
					Longitude(),        // Longitude of the ascending node
					Argument(),         // Argument of perisapsis
					OrbitalPeriod(),    // Orbital period
					Orbit.GM,           // Standard gravitational parameter of parent body
					MeanAnomaly());     // Mean anomaly at T = 0
			}
		}
		#endregion

		public void ModifyOrbit(double deltav)
		{
			deltaV = deltav;
			DeriveOrbitalelements();
			UpdatePath();
			Update();
		}

		#region Extend timekeeping methods
		// Evaluate position for given Epoch in seconds from T=0
		new public void Advance(decimal seconds)
		{
			referenceOrbit.Advance(seconds);
			DeriveStateVectors();
			DeriveOrbitalelements();
			UpdatePath();
			Update();
		}
		// Evaluate position for given Epoch in years and days from T=0
		new public void Advance(decimal years, decimal days)
		{
			referenceOrbit.Advance(years, days);
			DeriveStateVectors();
			DeriveOrbitalelements();
			UpdatePath();
			Update();
		}
		new public void Project(decimal seconds)
		{
			referenceOrbit.Project(seconds);
			orbit.Project(seconds);
			DeriveStateVectors();
		}
		new public void Project(decimal years, decimal days)
		{
			referenceOrbit.Project(years, days);
			orbit.Project(years, days);
			DeriveStateVectors();
		}
		#endregion
	}
}
