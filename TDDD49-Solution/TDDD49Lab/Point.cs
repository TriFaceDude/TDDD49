using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDD49Lab
{
    public class Point
    {
        int x;
        int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Point()
        {
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Point point = (Point)obj;

            return (this.X == point.X) && (this.Y == point.Y);
        }

        public override string ToString()
        {
            return "{ " + X + ", " + Y + " }";
        }


    }
}
