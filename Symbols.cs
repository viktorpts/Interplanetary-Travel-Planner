using System;
using System.Drawing;

namespace Planner
{
	static class Symbols
	{
		static Point[] _Ship(int x, int y)
		{
			return new Point[]{
				new Point(x, y),
				new Point(x + 6, y - 12),
				new Point(x - 6, y - 12),
				new Point(x, y)
			};
		}
		public static Point[] Ship(int x, int y) { return _Ship(x, y); }
		public static Point[] Ship(Point p) { return _Ship(p.X, p.Y); }

		static Point[] _Periapse(int x, int y)
		{
			int x1 = x - MainMap.Origin.X;
			int y1 = -(y - MainMap.Origin.Y);
			double phase = Math.Asin(y1 / Math.Sqrt(x1 * x1 + y1 * y1));
			return new Point[]{
				new Point(x, y),
				new Point((int)(x + 24 * Math.Cos(phase)), (int)(y + 24 * Math.Sin(phase)))
			};
		}
		public static Point[] Periapse(int x, int y) { return _Periapse(x, y); }
		public static Point[] Periapse(Point p) { return _Periapse(p.X, p.Y); }
	}
}
