using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Fraction:IComparable<Fraction>, ICloneable
    {
        public long Numerator { get; private set; }
        public long Denominator { get; private set; }

        private bool reduce;

        public bool IsProper => Numerator < Denominator;

        public Fraction Reverse()
        {
            return new Fraction(Denominator, Numerator, reduce);
        }

        public static Fraction Reverse(Fraction fraction)
        {
            return new Fraction(fraction.Denominator, fraction.Numerator, fraction.reduce);
        }

        public void Reduce()
        {
            if (!reduce)
            {
                long gcd = MathNumberTheory.Gcd(Numerator, Denominator);
                Numerator /= gcd;
                Denominator /= gcd;
            }
        }

        public Fraction(long numerator, long denominator, bool reduce = true)
        {
            this.reduce = reduce;
            if (reduce)
            {
                MathNumberTheory.Reduce(ref numerator, ref denominator);
            }
            Numerator = numerator;
            Denominator = denominator;
        }

        public override bool Equals(object obj)
        {
            return obj is Fraction fraction &&
                   Numerator == fraction.Numerator &&
                   Denominator == fraction.Denominator;
        }

        public override int GetHashCode()
        {
            var hashCode = -1534900553;
            hashCode = hashCode * -1521134295 + Numerator.GetHashCode();
            hashCode = hashCode * -1521134295 + Denominator.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Fraction left, Fraction right)
        {
            return EqualityComparer<Fraction>.Default.Equals(left, right);
        }

        public static bool operator !=(Fraction left, Fraction right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public int CompareTo(Fraction other)
        {
            try
            {
                checked
                {
                    long a = Numerator * other.Denominator;
                    long b = other.Numerator * Denominator;
                    return a.CompareTo(b);
                }
            }
            catch
            {
                if (Numerator == other.Numerator && Denominator == other.Denominator) return 0;
                if (Numerator >= other.Numerator && Denominator <= other.Denominator) return 1;
                if (Numerator <= other.Numerator && Denominator >= other.Denominator) return -1;
                decimal d1 = this;
                return d1.CompareTo(other);
            }

        }

        public object Clone()
        {
            return new Fraction(Numerator, Denominator, reduce);
        }

        public static bool operator <(Fraction left, Fraction right)
        {
            return left.CompareTo(right) == -1;
        }

        public static bool operator <=(Fraction left, Fraction right)
        {
            return left.CompareTo(right) != 1;
        }

        public static bool operator >(Fraction left, Fraction right)
        {
            return left.CompareTo(right) == 1;
        }

        public static bool operator >=(Fraction left, Fraction right)
        {
            return left.CompareTo(right) != -1;
        }

        public static Fraction operator -(Fraction fraction)
        {
            return new Fraction(-fraction.Numerator, fraction.Denominator, fraction.reduce);
        }

        public static Fraction operator +(Fraction left, Fraction right)
        {
            long gcd = MathNumberTheory.Gcd(left.Denominator, right.Denominator);
            return new Fraction(
                    left.Numerator * (right.Denominator / gcd) + right.Numerator * (left.Denominator / gcd),
                    left.Denominator * (right.Denominator / gcd),
                    left.reduce || right.reduce
                );
        }

        public static Fraction operator -(Fraction left, Fraction right)
        {
            long gcd = MathNumberTheory.Gcd(left.Denominator, right.Denominator);
            return new Fraction(
                    left.Numerator * (right.Denominator / gcd) - right.Numerator * (left.Denominator / gcd),
                    left.Denominator * (right.Denominator / gcd),
                    left.reduce || right.reduce
                );
        }

        public static Fraction operator *(Fraction left, Fraction right)
        {
            long gcd1 = 1, gcd2 = 1;
            if (left.reduce || right.reduce)
            {
                gcd1 = MathNumberTheory.Gcd(left.Numerator, right.Denominator);
                gcd2 = MathNumberTheory.Gcd(left.Denominator, right.Numerator);
            }
            return new Fraction(
                    (left.Numerator / gcd1) * (right.Numerator / gcd2),
                    (left.Denominator / gcd2) * (right.Denominator / gcd1),
                    left.reduce || right.reduce
                ); 
        }
        public static Fraction operator /(Fraction left, Fraction right)
        {
            return left * right.Reverse();
        }

        public static implicit operator float(Fraction fraction) => (float)(fraction.Numerator) / fraction.Denominator;
        public static implicit operator double(Fraction fraction) => (double)(fraction.Numerator) / fraction.Denominator;
        public static implicit operator decimal(Fraction fraction) => (decimal)(fraction.Numerator) / fraction.Denominator;
    }
}
