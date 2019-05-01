using System;
using System.Collections.Generic;

namespace GetPairsWithSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int cnt = solution(new[] { 1, 2, 5, 7, -1, 5 }, 6);
        }

        static int solution(int[] arr, int sum)
        {
            Dictionary<int, int> hm = new Dictionary<int, int>();

            // Store counts of all elements  
            // in map hm  
            for (int i = 0; i < arr.Length; i++)
            {

                // initializing value to 0,  
                // if key not found  
                if (!hm.ContainsKey(arr[i]))
                {
                    hm[arr[i]] = 0;
                }

                hm[arr[i]] = hm[arr[i]] + 1;
            }
            int twice_count = 0;

            // iterate through each element and   
            // increment the count (Notice that  
            // every pair is counted twice)  
            for (int i = 0; i < arr.Length; i++)
            {
                if (hm.ContainsKey(sum - arr[i]))
                {
                    twice_count += hm[sum - arr[i]];
                }

                // if (arr[i], arr[i]) pair satisfies  
                // the condition, then we need to ensure  
                // that the count is decreased by one  
                // such that the (arr[i], arr[i])  
                // pair is not considered  
                if (sum - arr[i] == arr[i])
                {
                    twice_count--;
                }
            }

            // return the half of twice_count  
            return twice_count / 2;
        }
    }
}
