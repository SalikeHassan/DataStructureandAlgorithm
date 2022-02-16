using System;

namespace Power
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var num = double.MinValue;
            var pow = int.MinValue;
            Console.WriteLine("Input number");
            num = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input power");
            pow = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"{CalculatePow(num, pow)}");
        }

        static double CalculatePow(double num, int pow)
        {

            if (pow < 0)
            {
                num = 1 / num;
                pow = -pow;
            }

            return GetPow(num, pow);
        }

        private static double GetPow(double num, int pow)
        {
            if (pow == 0)
            {
                return 1;
            }

            else
            {
                return num * GetPow(num, pow - 1);
            }
        }
    }
}
