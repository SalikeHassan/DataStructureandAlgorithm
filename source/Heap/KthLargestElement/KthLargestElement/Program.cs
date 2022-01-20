/*
 Kth Largest Element in an Array
Given an integer array nums and an integer k, return the kth largest element in the array.
Note that it is the kth largest element in the sorted order, not the kth distinct element.

Example 1:
Input: nums = [3,2,1,5,6,4], k = 2
Output: 5

Example 2:
Input: nums = [3,2,3,1,2,4,5,5,6], k = 4
Output: 4
 
Constraints:
1 <= k <= nums.length <= 104
-104 <= nums[i] <= 104
 */

using System;
using System.Text;

namespace KthLargestElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var heap = new Heap(Convert.ToInt32(5));

            //heap.CreateMaxHeap(110);
            //heap.CreateMaxHeap(2);
            //heap.CreateMaxHeap(30);
            //heap.CreateMaxHeap(1);
            //heap.CreateMaxHeap(100);

            //Example 1
            //var size = 6;
            //var heap = new Heap(Convert.ToInt32(size));
            //heap.CreateMaxHeap(3);
            //heap.CreateMaxHeap(2);
            //heap.CreateMaxHeap(1);
            //heap.CreateMaxHeap(5);
            //heap.CreateMaxHeap(6);
            //heap.CreateMaxHeap(4);

            var size = 9;
            var heap = new Heap(Convert.ToInt32(size));
            heap.CreateMaxHeap(3);
            heap.CreateMaxHeap(2);
            heap.CreateMaxHeap(3);
            heap.CreateMaxHeap(1);
            heap.CreateMaxHeap(2);
            heap.CreateMaxHeap(4);
            heap.CreateMaxHeap(5);
            heap.CreateMaxHeap(5);
            heap.CreateMaxHeap(6);

            heap.PrintHeapData();

            for (var i = size; i > 1; i--)
            {
                heap.SortInDesc(i);
            }

            heap.PrintHeapData();

            Console.WriteLine("Enter Kth element for pop");
            var kth = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"kth Element {heap.GetKthElement(kth)}");
        }
    }

    internal class Heap
    {
        internal int[] heap;
        internal int currentIndex;
        internal int heapSize;

        internal Heap(int heapSize)
        {
            this.heapSize = heapSize;
            this.heap = new int[this.heapSize + 1];
            this.currentIndex = 0;
            this.heap[currentIndex] = 0;
        }

        internal string CreateMaxHeap(int data)
        {
            this.currentIndex++;
            if (this.currentIndex > this.heapSize)
            {
                return "Size exceed";
            }

            else
            {
                this.heap[this.currentIndex] = data;

                this.SwapElementForMin();

                return "Data added into max heap";
            }
        }

        private void SwapElementForMin()
        {
            var index = this.currentIndex;
            var parentIndex = index / 2;

            while (index > 1 && this.heap[index] < this.heap[parentIndex])
            {
                var temp = this.heap[index];
                this.heap[index] = this.heap[parentIndex];
                this.heap[parentIndex] = temp;
                index = parentIndex;
                parentIndex = index / 2;
            }
        }

        internal void PrintHeapData()
        {
            if (this.currentIndex < 1)
            {
                Console.WriteLine("Empty Heap");
            }

            else
            {
                var sb = new StringBuilder();
                sb.Append("[");
                for (var index = 1; index <= this.heapSize; index++)
                {
                    sb.Append(this.heap[index]);

                    if (index != this.heapSize)
                    {
                        sb.Append(",");
                    }
                }

                sb.Append("]");
                Console.WriteLine(sb.ToString());
            }
        }

        internal void SortInDesc(int n)
        {
            if (this.currentIndex < 1)
            {
                Console.WriteLine("Heap is empty");
            }
            else
            {
                var topElement = this.heap[1];
                var i = 1;
                var j = 2 * 1;
                this.heap[i] = this.heap[n];
                this.heap[n] = topElement;

                while (j <= n - 1)
                {
                    if (j < n - 1 && this.heap[j + 1] < this.heap[j])
                    {
                        j = j + 1;
                    }

                    if (this.heap[i] > this.heap[j])
                    {
                        var temp = this.heap[j];
                        this.heap[j] = this.heap[i];
                        this.heap[i] = temp;
                        i = j;
                        j = 2 * j;
                    }

                    else
                    {
                        break;
                    }
                }
            }
        }

        internal int GetKthElement(int kth)
        {
            if (kth > this.heapSize || kth < 1)
            {
                return -1;
            }

            else
            {
                return this.heap[kth];
            }
        }
    }
}
