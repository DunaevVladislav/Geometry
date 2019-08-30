using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Vector:IComparable<Vector>, ICloneable
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public long Dot(Vector v)
        {
            return ((long)X) * v.X + ((long)Y) * v.Y;
        }

        public static long Dot(Vector vector1, Vector vector2)
        {
            return ((long)vector1.X) * vector2.X + ((long)vector2.Y) * vector2.Y;
        }

        public long Cross(Vector v)
        {
            return ((long)X) * v.Y - ((long)Y) * v.X;
        }

        public static long Cross(Vector left, Vector right)
        {
            return ((long)left.X) * right.Y - ((long)left.Y) * right.X;
        }

        public double Length => Math.Sqrt(Dot(this));

        public double Angle(Vector vector)
        {
            return Math.Acos(Dot(vector) / (Length * vector.Length));
        }
        public static double Angle(Vector vector1, Vector vector2)
        {
            return Math.Acos(Dot(vector1, vector2) / (vector1.Length * vector2.Length));
        }

        public Vector()
        {
        }

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public Vector(Point from, Point to)
        {
            X = to.X - from.X;
            Y = to.Y - from.Y;
        }

        public Vector(System.Drawing.Point from, System.Drawing.Point to)
        {
            X = to.X - from.X;
            Y = to.Y - from.Y;
        }

        public Vector(System.Drawing.Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public static explicit operator Vector(Point p) => new Vector(p);
        public static explicit operator Vector(System.Drawing.Point p) => new Vector(p);

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

        public int CompareTo(Vector other)
        {
            return X == other.X ? Y.CompareTo(other.Y) : X.CompareTo(other.X);
        }

        public static bool operator ==(Vector left, Vector right)
        {
            return EqualityComparer<Vector>.Default.Equals(left, right);
        }

        public static bool operator !=(Vector left, Vector right)
        {
            return !(left == right);
        }

        public static bool operator <(Vector left, Vector right)
        {
            return left.CompareTo(right) == -1;
        }

        public static bool operator <=(Vector left, Vector right)
        {
            return left.CompareTo(right) != 1;
        }

        public static bool operator >(Vector left, Vector right)
        {
            return left.CompareTo(right) == 1;
        }

        public static bool operator >=(Vector left, Vector right)
        {
            return left.CompareTo(right) != -1;
        }

        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y);
        }

        public static Vector operator +(Vector left, Vector right)
        {
            return new Vector(left.X + right.X, left.Y + right.X);
        }

        public static Vector operator -(Vector left, Vector right)
        {
            return new Vector(left.X - right.X, left.Y - right.X);
        }

        public static Vector operator *(Vector vector, int multiplier)
        {
            return new Vector(vector.X * multiplier, vector.Y * multiplier);
        }

        public static Vector operator /(Vector vector, int divider)
        {
            return new Vector(vector.X / divider, vector.Y / divider);
        }

        public override string ToString()
        {
            return $"{{{X}, {Y}}}";
        }

        public object Clone()
        {
            return new Vector(X, Y);
        }
    }
}
