using System;
using System.Collections.Generic;

namespace Geometry
{
    public class Point:IComparable<Point>, ICloneable 
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public void Offset(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

        public void Offset(Vector v)
        {
            X += v.X;
            Y += v.Y;
        }

        public Point()
        {
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(System.Drawing.Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public Point(Vector v)
        {
            X = v.X;
            Y = v.Y;
        }

        public static implicit operator System.Drawing.Point(Point p) => new System.Drawing.Point(p.X, p.Y);
        public static explicit operator Point(System.Drawing.Point p) => new Point(p);
        public static explicit operator Point(Vector v) => new Point(v);

        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public int CompareTo(Point other)
        {
            return  X == other.X ? Y.CompareTo(other.Y) : X.CompareTo(other.X);
        }

        public static bool operator ==(Point left, Point right)
        {
            return EqualityComparer<Point>.Default.Equals(left, right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }

        public static bool operator < (Point left, Point right)
        {
            return left.CompareTo(right) == -1;
        }

        public static bool operator <=(Point left, Point right)
        {
            return left.CompareTo(right) != 1;
        }

        public static bool operator >(Point left, Point right)
        {
            return left.CompareTo(right) == 1;
        }

        public static bool operator >=(Point left, Point right)
        {
            return left.CompareTo(right) != -1;
        }

        public static Point operator -(Point p)
        {
            return new Point(-p.X, -p.Y);
        }

        public static Vector operator -(Point left, Point right)
        {
            return new Vector(left, right);
        }

        public static Point operator+(Point point, Vector offset)
        {
            return new Point(point.X + offset.X, point.Y + offset.Y);
        }

        public override string ToString()
        {
            return $"{{{X}, {Y}}}";
        }

        public object Clone()
        {
            return new Point(X, Y);
        }
    }
}