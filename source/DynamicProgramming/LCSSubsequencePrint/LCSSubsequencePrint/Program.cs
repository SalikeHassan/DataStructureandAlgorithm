/*
 https://www.geeksforgeeks.org/printing-longest-common-subsequence/
 Printing Longest Common Subsequence

Given two sequences, print the longest subsequence present in both of them. 
Examples: 
LCS for input Sequences “ABCDGH” and “AEDFHR” is “ADH” of length 3. 
LCS for input Sequences “AGGTAB” and “GXTXAYB” is “GTAB” of length 4.
We have discussed Longest Common Subsequence (LCS) problem in a previous post. The function discussed there was mainly to find the length of LCS. To find length of LCS, a 2D table L[][] was constructed. In this post, the function to construct and print LCS is discussed.
Following is detailed algorithm to print the LCS. It uses the same 2D table L[][].
1) Construct L[m+1][n+1] using the steps discussed in previous post.
2) The value L[m][n] contains length of LCS. Create a character array lcs[] of length equal to the length of lcs plus 1 (one extra to store \0).
2) Traverse the 2D array starting from L[m][n]. Do following for every cell L[i][j] 
…..a) If characters (in X and Y) corresponding to L[i][j] are same (Or X[i-1] == Y[j-1]), then include this character as part of LCS. 
…..b) Else compare values of L[i-1][j] and L[i][j-1] and go in direction of greater value.
The following table (taken from Wiki) shows steps (highlighted) followed by the above algorithm.
 */

using System;

namespace LCSSubsequencePrint
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input1 = "AGGTAB";
            var input2 = "GXTXAYB";

            var charSet1 = input1.ToCharArray();
            var charSet2 = input2.ToCharArray();
            var lcs = new LCSSubstring();
            var lcsSubStr = lcs.GetLcsSubStrLen(charSet1, charSet2);

            for (var i = 0; i < lcsSubStr.Length; i++)
            {
                Console.Write(lcsSubStr[i]);
            }
        }
    }

    internal class LCSSubstring
    {
        internal char[] GetLcsSubStrLen(char[] charSet1, char[] charSet2)
        {
            var row = charSet1.Length;
            var colm = charSet2.Length;

            int[,] mat = new int[row + 1, colm + 1];

            for (var r = 0; r <= row; r++)
            {
                for (var c = 0; c <= colm; c++)
                {
                    if (r == 0 || c == 0)
                    {
                        mat[r, c] = 0;
                    }

                    else if (charSet1[r - 1] == charSet2[c - 1])
                    {
                        mat[r, c] = 1 + mat[r - 1, c - 1];
                    }

                    else
                    {
                        mat[r, c] = Math.Max(mat[r - 1, c], mat[r, c - 1]);
                    }
                }
            }

            var index = mat[row, colm];
            char[] subStr = new char[index + 1];

            while (row > 0 && colm > 0)
            {
                if (charSet1[row - 1] == charSet2[colm - 1])
                {
                    subStr[index - 1] = charSet1[row - 1];

                    row--;
                    colm--;
                    index--;
                }

                else if (mat[row, colm - 1] > mat[row - 1, colm])
                {
                    colm--;
                }
                else
                {
                    row--;
                }
            }

            return subStr;
        }
    }
}
