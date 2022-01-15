//Subset Sum Problem | DP-25
/*
 
Given a set of non-negative integers, and a value sum, determine if there is a subset of the given set with sum equal to given sum. 

Example: 

Input: set[] = {3, 34, 4, 12, 5, 2}, sum = 9
Output: True  
There is a subset (4, 5) with sum 9.

Input: set[] = {3, 34, 4, 12, 5, 2}, sum = 30
Output: False
There is no subset that add up to 30.

*/

using System;

namespace SubSetSumDP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();

            int[] arr = { 2, 1, 7, 6, 10 };
            var sum = 8;
            var n = arr.Length;
            var hasSubset = program.HasSubSetSum(arr, sum, n);
            Console.WriteLine($"{hasSubset}");

            bool?[] dp = new bool?[n + 1];
            Array.Fill(dp, null);

            Console.WriteLine($"Has Subset {program.HasSubSetSum(arr, sum)}");
        }

        /// <summary>
        /// Recursion version
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sum"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        bool HasSubSetSum(int[] arr, int sum, int n)
        {
            if (sum == 0)
            {
                return true;
            }

            if (arr.Length == 0)
            {
                return false;
            }

            if (n <= 0)
            {
                return false;
            }

            if (arr[n - 1] <= sum)
            {
                return HasSubSetSum(arr, sum - arr[n - 1], n - 1) || HasSubSetSum(arr, sum, n - 1);
            }

            else
            {
                return HasSubSetSum(arr, sum, n - 1);
            }
        }

        bool HasSubSetSum(int[] set, int sum)
        {
            var n = set.Length + 1;
            bool[,] subSet = new bool[set.Length + 1, sum + 1];

            for (var i = 0; i < n; i++)
            {
                subSet[i, 0] = true;
            }

            for (var i = 1; i < n; i++)
            {
                for (var j = 1; j < sum; j++)
                {
                    if (j >= set[i - 1])
                    {
                        subSet[i, j] = subSet[i - 1, j - set[i - 1]] || subSet[i - 1, j];
                    }
                    else
                    {
                        subSet[i, j] = subSet[i - 1, j];
                    }
                }
            }

            return subSet[n - 1, sum];
        }
    }
}