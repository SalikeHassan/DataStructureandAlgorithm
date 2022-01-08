using System;
using System.Collections.Generic;

namespace CoinChange
{
    internal class Program
    {
        static int minCoins(int coinValue, int[] arrCoins, int[] computedResultDP)
        {
            if (coinValue == 0)
            {
                return 0;
            }

            var result = Int32.MaxValue;
            var len = arrCoins.Length;

            for (var index = 0; index < len; index++)
            {
                var subResult = 0;
                if (coinValue - arrCoins[index] >= 0)
                {
                    if (computedResultDP[coinValue - arrCoins[index]] != -1)
                    {
                        subResult = computedResultDP[coinValue - arrCoins[index]];
                    }
                    else
                    {
                        subResult = minCoins(coinValue - arrCoins[index], arrCoins, computedResultDP);
                    }

                    subResult = minCoins(coinValue - arrCoins[index], arrCoins, computedResultDP);

                    if (subResult != Int32.MaxValue && subResult + 1 < result)
                    {
                        result = subResult + 1;
                    }
                }
            }

            computedResultDP[coinValue] = result;
            return result;
        }

        static void Main(string[] args)
        {
            int coinValue = 23;
            int[] arrCoins = { 3, 6, 1 };
            int[] computedResultDP = new int[coinValue + 1];

            var result = minCoins(coinValue, arrCoins, computedResultDP);
            Console.WriteLine(result);
        }
    }
}
