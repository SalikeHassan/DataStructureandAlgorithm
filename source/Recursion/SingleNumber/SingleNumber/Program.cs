using System;
using System.Collections.Generic;

namespace SingleNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 9, 4, 9, 6, 7, 4,6 };

            var result = GetSingleOccurenceNum(nums);

            if (result == int.MinValue)
            {
                Console.WriteLine("No single occurence number present in array");
            }
            else
            {
                Console.WriteLine(result);
            }
        }

        private static int GetSingleOccurenceNum(int[] nums)
        {
            var arrLen = nums.Length;

            var lstData = new Dictionary<int, int>();

            for (int index = 0; index < arrLen; index++)
            {
                if (lstData.ContainsKey(nums[index]))
                {
                    var cnt = lstData[nums[index]];
                    lstData.Remove(nums[index]);
                    lstData.Add(nums[index], cnt + 1);
                }
                else
                {
                    lstData.Add(nums[index], 1);
                }
            }

            for (var index = 0; index < arrLen; index++)
            {
                if (lstData[nums[index]] == 1)
                {
                    return nums[index];
                }
            }

            return int.MinValue;
        }
    }
}
