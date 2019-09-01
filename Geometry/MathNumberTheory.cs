using System.Linq;

namespace Geometry
{
    internal static class MathNumberTheory
    {
        public static int Gcd(params int[] numbers)
        {
            int g = 0;
            foreach(var number in numbers)
            {
                int a = number;
                while(a != 0)
                {
                    g %= a;
                    a ^= g;
                    g ^= a;
                    a ^= g;
                }
            }
            return g;
        }

        public static long Gcd(params long[] numbers)
        {
            long gcd = 0;
            foreach (var number in numbers)
            {
                long a = number;
                while (a != 0)
                {
                    gcd %= a;
                    a ^= gcd;
                    gcd ^= a;
                    a ^= gcd;
                }
            }
            return gcd;
        }

        public static int Lcm(params int[] numbers)
        {
            if (numbers.Length == 0) return 0;
            if (numbers.Contains(0)) return 0;
            int lcm = 1;
            foreach (int number in numbers)
            {
                int gcd = Gcd(lcm, number);
                lcm = lcm / gcd * number;
            }
            return lcm;
        }

        public static long Lcm(params long[] numbers)
        {
            if (numbers.Length == 0) return 0;
            if (numbers.Contains(0)) return 0;
            long lcm = 1;
            foreach (var number in numbers)
            {
                long a = number;
                long gcd = Gcd(lcm, number);
                lcm = lcm / gcd * number;
            }
            return lcm;
        }

        public static void Reduce(ref int number1, ref int number2)
        {
            int gcd = Gcd(number1, number2);
            if (gcd == 0) return;
            number1 /= gcd;
            number2 /= gcd;
        }

        public static void Reduce(ref long number1, ref long number2)
        {
            long gcd = Gcd(number1, number2);
            if (gcd == 0) return;
            number1 /= gcd;
            number2 /= gcd;
        }

    }
}
