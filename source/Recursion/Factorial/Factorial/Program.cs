using System;

namespace Factorial
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = int.MinValue;
            Console.WriteLine("Enter number");
            if (int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine($"Factorial of {input} = {CaluclateFact(input)}");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        static int CaluclateFact(int num)
        {
            if (num == 0)
            {
                return 1;
            }

            else
            {
                return num * CaluclateFact(num - 1);
            }
        }
    }
}
