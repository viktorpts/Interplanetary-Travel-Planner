using System.Drawing;
using static System.Math;
using System.Windows.Media.Media3D;

namespace Planner
{
	static class VGD
	{
		#region Vectors
		public static Point[] VectorLine(Vector3D vector)
		{
			return new Point[]{
				MainMap.Origin,
                Coord.GetScaled((decimal)vector.X, (decimal)vector.Y, MainMap.StarScale, MainMap.Origin.X, MainMap.Origin.Y)
			};
		}
		public static Point[] VectorLine(Vector3D vector1, Vector3D vector2)
		{
			return new Point[]{
				Coord.GetScaled((decimal)vector1.X, (decimal)vector1.Y, MainMap.StarScale, MainMap.Origin.X, MainMap.Origin.Y),
				Coord.GetScaled((decimal)(vector1.X + vector2.X), (decimal)(vector1.Y + vector2.Y), MainMap.StarScale, MainMap.Origin.X, MainMap.Origin.Y)
			};
		}

		public static Vector3D Scale(Vector3D vector, double minSize)
		{
			// Scale up the vector so that it is visible (magnitude = minSize)
			double scalar = minSize / (vector.Length * MainMap.StarScale);
			return (vector * scalar);
		}
		#endregion

		#region Angles
		public static Point[] Ray(double angle)
		{
			return new Point[]{
				MainMap.Origin,
				new Point((int)(MainMap.Origin.X * Cos(angle)) + MainMap.Origin.X, -(int)(MainMap.Origin.X * Sin(angle)) + MainMap.Origin.Y)
			};
		}
		#endregion
	}
}
