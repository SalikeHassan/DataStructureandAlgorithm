/*
 Coin Change | DP-7 
 */


using System;

namespace CoinChangeNoOfWays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();

            var value = 4;
            int[] coins = { 1, 2, 3 };

            var totalWays = program.NoOfWays(value, coins);

            Console.WriteLine(totalWays);
        }

        int NoOfWays(int value, int[] coins)
        {
            var n = coins.Length;
            int[,] result = new int[n + 1, value + 1];

            for (var row = 1; row <= n; row++)
            {

                result[row, 0] = 1;
            }

            for (var i = 1; i <= n; i++)
            {
                for (var j = 1; j <= value; j++)
                {
                    if (j >= coins[i - 1])
                    {
                        result[i, j] = result[i - 1, j] + result[i, j - coins[i - 1]];
                    }
                    else
                    {
                        result[i, j] = result[i - 1, j];
                    }
                }
            }

            return result[n, value];
        }
    }
}
