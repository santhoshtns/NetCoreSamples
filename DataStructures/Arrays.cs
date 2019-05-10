using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class Arrays
    {
        int[] arr = new int[10] { 12, 94, 6, -7, 11, 23, 242, 33, 456, 1 };

        public void Actions()
        {
            //read
            Console.WriteLine(arr[6]);

            //write
            Console.WriteLine(arr[6] = 49);

            // Insert
            // It will not resize the array but allocates a new array with the new size
            Array.Resize(ref arr, 12);
        }

        public void MergeTwosortedArray()
        {
            int[] arr1 = new int[4] { 2, 3, 6, 7 };
            int[] arr2 = new int[4] { 1, 3, 12, 13 };

            int len1 = arr1.Length;
            int len2 = arr2.Length;

            int[] arr3 = new int[len1 + len2];
            int i = 0, j = 0, k = 0;

            while (i < len1 && j < len2)
            {
                if (arr1[i] > arr2[j])
                {
                    arr3[k++] = arr2[j++];
                }
                else
                {
                    arr3[k++] = arr1[i++];
                }
            }

            while (i < len1)
                arr3[k++] = arr1[i++];

            // Store remaining elements 
            // of second array 
            while (j < len2)
                arr3[k++] = arr2[j++];
        }

        public int FirstNonRepeatingNumber()
        {
            int[] arr2 = new int[6] { 12, 13, 6, -7, 12, 13 };
            Dictionary<int, int> m = new Dictionary<int, int>();
            for (int i = 0; i < arr2.Length; i++)
            {
                if (m.ContainsKey(arr2[i]))
                    m[arr2[i]] = m[arr2[i]] + 1;
                else
                    m.Add(arr2[i], 1);
            }

            // Traverse array again and return 
            // first element with count 1. 
            for (int i = 0; i < arr2.Length; i++)
                if (m[arr2[i]] == 1)
                    return arr2[i];
            return -1;
        }

        public void FirstAndSecondSmallest()
        {
            int first = int.MaxValue;
            int second = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < first)
                {
                    second = first;
                    first = arr[i];
                }
                else if (arr[i] < second)
                {
                    second = arr[i];
                }
                Console.WriteLine($"{first} : {second}");
            }
        }
    }
}
