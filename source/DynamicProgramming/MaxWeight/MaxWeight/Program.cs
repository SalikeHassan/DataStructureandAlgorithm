using System;

namespace MaxWeight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] weight = { 1, 4, 3, 3 };
            int[] values = { 2, 6, 7, 1 };
            int maxWt = 7;
            int sizeOfWtArray = weight.Length;

            var maxValue = GetMaxWeight(weight, values, maxWt, sizeOfWtArray);

            Console.WriteLine($"Max value {maxValue}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="weight">weight.</param>
        /// <param name="values">values.</param>
        /// <param name="maxWt">maxWt.</param>
        /// <param name="n">sizeOfWtArray.</param>
        /// <returns></returns>
        static int GetMaxWeight(int[] weight, int[] values, int maxWt, int n)
        {
            //Base Condition to terminate recursion

            if (maxWt == 0 || n == 0)
            {
                return 0;
            }

            else if (weight[n - 1] <= maxWt)
            {
                //Pick or Loose
                return Math.Max(values[n - 1] + GetMaxWeight(weight, values, maxWt - weight[n - 1], n - 1),
                    GetMaxWeight(weight, values, maxWt, n - 1));
            }

            else
            {
                return GetMaxWeight(weight, values, maxWt, n - 1);
            }
        }
    }
}
