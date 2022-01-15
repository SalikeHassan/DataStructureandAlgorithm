
/*
    Count of subsets with sum equal to X
    Given an array arr[] of length N and an integer X, 
    the task is to find the number of subsets with a sum equal to X.
    Examples: 

    Input: arr[] = {1, 2, 3, 3}, X = 6 
    Output: 3 
    All the possible subsets are {1, 2, 3}, 
    {1, 2, 3} and {3, 3}

    Input: arr[] = {1, 1, 1, 1}, X = 1 
    Output: 4
 */
using System;

namespace CountSubsetEqualtoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] set = { 1, 1, 1, 1 };
            var sum = 1;

            var cntSubSets = new Program().GetCntOfSubSetMakesSum(set, sum);

            Console.WriteLine($"{cntSubSets}");
        }

        int GetCntOfSubSetMakesSum(int[] set, int sum)
        {
            var row = set.Length + 1;
            var colm = sum + 1;
            int[,] result = new int[row, colm];

            //Fill the result array with default values
            for (var i = 0; i < row; i++)
            {
                result[i, 0] = 1;
            }

            for (var i = 1; i < colm; i++)
            {
                result[0, i] = 0;
            }

            for (var i = 1; i < row; i++)
            {
                for (var j = 1; j < colm; j++)
                {
                    if (j >= set[i - 1])
                    {
                        result[i, j] = result[i - 1, j] + result[i - 1, j - set[i - 1]];
                    }

                    else
                    {
                        result[i, j] = result[i - 1, j];
                    }
                }
            }

            return result[row - 1, colm - 1];
        }
    }
}
