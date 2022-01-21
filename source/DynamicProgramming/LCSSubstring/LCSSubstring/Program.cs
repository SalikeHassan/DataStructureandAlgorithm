/*
 https://www.geeksforgeeks.org/longest-common-substring-dp-29/

Longest Common Substring | DP-29
Given two strings ‘X’ and ‘Y’, find the length of the longest common substring. 

Examples : 
Input : X = “GeeksforGeeks”, y = “GeeksQuiz” 
Output : 5 
Explanation:
The longest common substring is “Geeks” and is of length 5.

Input : X = “abcdxyz”, y = “xyzabcd” 
Output : 4 
Explanation:
The longest common substring is “abcd” and is of length 4.

Input : X = “zxabcdezy”, y = “yzabcdezx” 
Output : 6 
Explanation:
The longest common substring is “abcdez” and is of length 6.


 */
using System;

namespace LCSSubstring
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input1 = "zxabcdezy";
            var input2 = "yzabcdezx";

            var charSet1 = input1.ToCharArray();
            var charSet2 = input2.ToCharArray();
            var lcs = new LCSSubstring();
            var longestSequence = lcs.GetLcsSubStrLen(charSet1, charSet2);
            Console.WriteLine($"Longest sequence = { longestSequence }");
        }
    }

    internal class LCSSubstring
    {
        internal int GetLcsSubStrLen(char[] charSet1, char[] charSet2)
        {
            var row = charSet1.Length;
            var colm = charSet2.Length;
            var res = 0;
            int[,] result = new int[row + 1, colm + 1];

            for (var index1 = 0; index1 <= row; index1++)
            {
                for (var index2 = 0; index2 <= colm; index2++)
                {
                    if (index1 == 0 || index2 == 0)
                    {
                        result[index1, index2] = 0;
                    }

                    else if (charSet1[index1 - 1] == charSet2[index2 - 1])
                    {
                        result[index1, index2] = 1 + result[index1 - 1, index2 - 1];

                        res = Math.Max(res, result[index1, index2]);
                    }

                    else
                    {
                        result[index1, index2] = 0;
                    }
                }
            }

            return res;
        }
    }
}
