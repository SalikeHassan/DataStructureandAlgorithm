/*
 Partition problem | DP-18
 Partition problem is to determine whether a given set can be partitioned into two subsets such that the sum of elements in both subsets is the same. 

Examples: 

arr[] = {1, 5, 11, 5}
Output: true 
The array can be partitioned as {1, 5, 5} and {11}

arr[] = {1, 5, 3}
Output: false 
The array cannot be partitioned into equal sum sets.
 */


using System;

namespace SubSetSumProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Positive test case
            //int[] set = { 1, 5, 11, 5 };

            int[] set = { 1, 2, 2, 1 };

            //Negative test case
            //int[] set = { 1, 5, 3 };

            var program = new Program();
            var setSum = program.GetSetSum(set);

            if (setSum % 2 == 0)
            {
                var isSubSetSumEqual = program.IsSubSetSumEqual(set, setSum / 2);

                Console.WriteLine($"{isSubSetSumEqual}");
            }
            else
            {
                Console.WriteLine("Guven set can not have equal sum sub sets");
            }
        }

        int GetSetSum(int[] set)
        {
            var sum = 0;
            var length = set.Length;
            for (var index = 0; index < length; index++)
            {
                sum += set[index];
            }

            return sum;
        }

        bool IsSubSetSumEqual(int[] set, int sum)
        {
            var row = set.Length + 1;
            var colm = sum + 1;

            bool[,] result = new bool[row, colm];

            //Fill the default value
            for (var index = 0; index < row; index++)
            {
                result[index, 0] = true;
            }

            for (var rowIndex = 1; rowIndex < row; rowIndex++)
            {
                for (var columnIndex = 1; columnIndex < colm; columnIndex++)
                {
                    if (columnIndex >= set[rowIndex - 1])
                    {
                        var take = result[rowIndex - 1, columnIndex - set[rowIndex - 1]];
                        var loose = result[rowIndex - 1, columnIndex];
                        result[rowIndex, columnIndex] = take || loose;
                    }

                    else
                    {
                        result[rowIndex, columnIndex] = result[rowIndex - 1, columnIndex];
                    }
                }
            }

            return result[row - 1, colm - 1];
        }
    }
}
