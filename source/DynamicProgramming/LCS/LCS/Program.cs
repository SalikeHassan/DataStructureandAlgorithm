/*
 Longest Common Subsequence | DP-4
LCS for input Sequences “ABCDGH” and “AEDFHR” is “ADH” of length 3. 
LCS for input Sequences “AGGTAB” and “GXTXAYB” is “GTAB” of length 4. 
 */

using System;

namespace LCS
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input1 = "AGGTAB";
            var input2 = "GXTXAYB";

            var charSet1 = input1.ToCharArray();
            var charSet2 = input2.ToCharArray();
            var lcs = new LongestCommonSequence();
            var longestSequence = lcs.GetLcs(charSet1, charSet2);
            Console.WriteLine($"Longest sequence = { longestSequence }");
        }
    }

    internal class LongestCommonSequence
    {
        internal int GetLcs(char[] charSet1, char[] charSet2)
        {
            var row = charSet1.Length;
            var colm = charSet2.Length;

            int[,] result = new int[row + 1, colm + 1];

            for (var i = 0; i < row; i++)
            {
                for (var j = 0; j < colm; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        result[i, j] = 0;
                    }
                }
            }

            for (var index1 = 1; index1 <= row; index1++)
            {
                for (var index2 = 1; index2 <= colm; index2++)
                {
                    if (charSet1[index1 - 1] == charSet2[index2 - 1])
                    {
                        result[index1, index2] = 1 + result[index1 - 1, index2 - 1];
                    }

                    else
                    {
                        result[index1, index2] = Math.Max(result[index1 - 1, index2], result[index1, index2 - 1]);
                    }
                }
            }

            return result[row, colm];
        }
    }
}
