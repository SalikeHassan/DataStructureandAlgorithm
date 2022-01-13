using System;

namespace DPHouseRoberProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();

            // int[] houses = { 1, 2, 3, 1 };
            int[] houses = { 2, 7, 9, 3, 1, 8, 4 };

            //The below faied, need to review and corrcted
            // int[] houses = { 2,1,1,2 };

            var maxValue = program.RobHouseWithMaxValue(houses, houses.Length);

            Console.WriteLine($"Max values {maxValue}");
            int[] dp = new int[houses.Length];
            Array.Fill(dp, -1);

            var maxValueUsingDP = program.RobHouseWithMaxValue(houses, houses.Length, dp);
            Console.WriteLine($"Max values {maxValueUsingDP}");

            var max = program.RobHouseWithMaxValue(houses);

            Console.WriteLine($"Max values {max}");
        }

        /// <summary>
        /// Recursion approach
        /// </summary>
        /// <param name="houses"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        int RobHouseWithMaxValue(int[] houses, int n)
        {
            if (n <= 0)
            {
                return 0;
            }

            else
            {
                var taken = houses[n - 1] + RobHouseWithMaxValue(houses, n - 2);
                var left = RobHouseWithMaxValue(houses, n - 1);

                return Math.Max(taken, left);
            }
        }

        /// <summary>
        /// Recursion with Dynamic Programming
        /// </summary>
        /// <param name="houses"></param>
        /// <param name="n"></param>
        /// <param name="dp"></param>
        /// <returns></returns>
        int RobHouseWithMaxValue(int[] houses, int n, int[] dp)
        {
            if (n <= 0)
            {
                return 0;
            }

            if (dp[n - 1] != -1)
            {
                return dp[n - 1];
            }

            else
            {
                var taken = houses[n - 1] + RobHouseWithMaxValue(houses, n - 2);
                var left = RobHouseWithMaxValue(houses, n - 1);

                return dp[n - 1] = Math.Max(taken, left);
            }
        }

        /// <summary>
        /// Top Down Approach
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        int RobHouseWithMaxValue(int[] nums)
        {
            var n = nums.Length;
            int[] TD = new int[n];

            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return nums[0];
            }

            if (n == 2)
            {
                return Math.Max(nums[0], nums[1]);
            }

            TD[0] = nums[0];
            TD[1] = nums[1];

            for (var index = 2; index < n; index++)
            {
                var taken = nums[index] + TD[index - 2];
                var left = TD[index - 1];

                TD[index] = Math.Max(taken, left);
            }

            return TD[n - 1];
        }
    }
}
