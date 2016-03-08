using System.Drawing;

namespace Planner
{
	class Coord
	{
		decimal x;
		decimal y;

		public Coord()
		{
			x = 0;
			y = 0;
		}

		public Coord(decimal x, decimal y)
		{
			this.x = x;
			this.y = y;
		}

		decimal X
		{
			get { return x; }
			set { x = value; }
		}

		decimal Y
		{
			get { return y; }
			set { y = value; }
		}

		// Coordinates adjusted to current rendering surface (note y-coordinate progession is inverted in form!)
		public Point GetScaled(double scale, int xOffset, int yOffset)
		{
			return new Point((int)(x * (decimal)scale + xOffset), -(int)(y * (decimal)scale - yOffset));
		}

		public static Point GetScaled(decimal x, decimal y, double scale, int xOffset, int yOffset)
		{
			return new Point((int)(x * (decimal)scale + xOffset), -(int)(y * (decimal)scale - yOffset));
		}

		public static Point[] GetScaled(Coord[] input, double scale, int xOffset, int yOffset)
		{
			Point[] output = new Point[input.Length];
			for (int i = 0; i < input.Length; i++)
			{
				output[i] = new Point((int)(input[i].X * (decimal)scale + xOffset), -(int)(input[i].Y * (decimal)scale - yOffset));
			}
			return output;
		}
    }
}
