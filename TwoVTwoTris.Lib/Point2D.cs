using System.Numerics;

namespace TwoVTwoTris.Lib
{
    public struct Point2D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void operator +=(Point2D other)
        {
            X += other.X;
            Y += other.Y;
        }
        public void operator -=(Point2D other)
        {
            X -= other.X;
            Y -= other.Y;
        }

        public static Point2D operator +(Point2D a, Point2D b)
        {
            return new Point2D(a.X + b.X, a.Y + b.Y);
        }
    }
}