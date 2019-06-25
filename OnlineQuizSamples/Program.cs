using System;
using System.Linq;

namespace OnlineQuizSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //empty array
            byte[] abd = new byte[0];
            // array is not instantiated.
            byte[] abc = null;

            ReverseAndPrintString("Hello World".ToArray());

            string s1 = "geeksforgeeks", s2 = "platformforgeeks";
            int n1 = s1.Length, n2 = s2.Length;
            Console.WriteLine(countPairs(s1, n1, s2, n2));

            int[] A = { 2, 2, 1, 7, 5, 3 };
            int n = 6;
            int K = 4;
            Console.WriteLine(countKdivPairs(A, n, K));

            int[] ar1 = { 1, 4, 5, 7 };
            int[] ar2 = { 10, 20, 30, 40 };
            int x = 38;

            PrintClosestPair(ar1, ar2, x);
            //Console.WriteLine("Hello World!");
            //IsPESEL();

            MathOp();
        }

        private static void ReverseAndPrintString(char[] input)
        {
            var reversedString = (new String(input)).Reverse();
            Console.WriteLine(reversedString);

            var len = input.Length / 2;
            for (int i = 0; i < len / 2; i++)
            {
                ; var temp = input[i];
                input[i] = input[len - 1];
                input[len - 1] = temp;
            }
            Console.WriteLine(new string(input));
        }

        // Function to return the count of
        // valid indices pairs
        static int countPairs(string s1, int n1, string s2, int n2)
        {
            // To store the frequencies of
            // characters of string s1 and s2
            int[] freq1 = new int[26];
            int[] freq2 = new int[26];
            Array.Fill(freq1, 0);
            Array.Fill(freq2, 0);

            // To store the count of valid pairs
            int i, count = 0;

            // Update the frequencies of
            // the characters of string s1
            for (i = 0; i < n1; i++)
                freq1[s1[i] - 'a']++;

            // Update the frequencies of 
            // the characters of string s2 
            for (i = 0; i < n2; i++)
                freq2[s2[i] - 'a']++;

            // Find the count of valid pairs 
            for (i = 0; i < 26; i++)
                count += (Math.Min(freq1[i], freq2[i]));
            return count;
        }

        public static int countKdivPairs(int[] A, int n, int K)
        {
            // Create a frequency array to count 
            // occurrences of all remainders when 
            // divided by K 
            int[] freq = new int[K];

            // Count occurrences of all remainders 
            for (int i = 0; i < n; i++)
                ++freq[A[i] % K];

            // If both pairs are divisible by 'K' 
            int sum = freq[0] * (freq[0] - 1) / 2;

            // count for all i and (k-i) 
            // freq pairs 
            for (int i = 1; i <= K / 2 && i != (K - i); i++)
                sum += freq[i] * freq[K - i];

            // If K is even 
            if (K % 2 == 0)
                sum += (freq[K / 2] * (freq[K / 2] - 1) / 2);
            return sum;
        }

        private static void PrintClosestPair(int[] arr1, int[] arr2, int x)
        {
            int len1 = arr1.Length;
            int len2 = arr2.Length;
            int left = 0, right = len2 - 1;
            Tuple<int, int> output = new Tuple<int, int>(left, right);
            int diff = int.MaxValue;

            while (left < len1 && right >= 0)
            {
                int curDiff = Math.Abs(arr1[left] + arr2[right] - x);
                if (curDiff < diff)
                {
                    output = new Tuple<int, int>(left, right);
                    diff = curDiff;
                }

                if (arr1[left] + arr2[right] > x)
                    right--;
                else
                    left++;
            }

            Console.WriteLine($"Closest Pair: {arr1[output.Item1]},{arr2[output.Item2]} difference:{diff}");
        }

        public static void IsPESEL()
        {
            var myInput = Console.ReadLine().Trim();
            Console.WriteLine(myInput);

            if (string.IsNullOrEmpty(myInput))
            {
                return;
            }

            var count = Convert.ToInt16(myInput);

            while (count > 0)
            {
                myInput = Console.ReadLine().Trim();
                if (myInput.Length != 11)
                {
                    Console.WriteLine("N");
                }
                else
                {
                    var sum = myInput[0].ToInt() + myInput[10].ToInt() +
                        myInput[4].ToInt() + myInput[8].ToInt() +
                        (myInput[1].ToInt() + myInput[9].ToInt() + myInput[5].ToInt()) * 3 +
                        (myInput[2].ToInt() + myInput[6].ToInt()) * 7 +
                        (myInput[3].ToInt() + myInput[7].ToInt()) * 9;
                    if (sum % 10 == 0)
                        Console.WriteLine("Y");
                    else
                        Console.WriteLine("N");
                }
                count--;
            }
        }

        public static void MathOp()
        {
            while (true)
            {
                var myInput = System.Console.ReadLine().Trim();
                System.Console.WriteLine(myInput);

                var subStr = myInput.Split(' ');
                int result = 0;
                if (subStr.Length == 3)
                {
                    var op = subStr[0];
                    if (string.IsNullOrEmpty(subStr[0]) ||
                        string.IsNullOrEmpty(subStr[1]))
                    {
                        continue;
                    }
                    switch (op)
                    {
                        case "+":
                            result = subStr[1].ToInt() + subStr[2].ToInt();
                            break;
                        case "-":
                            result = subStr[1].ToInt() - subStr[2].ToInt();
                            break;
                        case "*":
                            result = subStr[1].ToInt() * subStr[2].ToInt();
                            break;
                        case "/":
                            result = subStr[1].ToInt() / subStr[2].ToInt();
                            break;
                        case "%":
                            result = subStr[1].ToInt() % subStr[2].ToInt();
                            break;
                    }
                    Console.WriteLine(result);
                }
            }
        }

        public static int[][] SumSubsets(int[] arr, int num)
        {
            int[][] final = new int[100][];
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (num == arr[i] + arr[j])
                    {
                        final[count] = new int[2];
                        final[count][0] = arr[i];
                        final[count][1] = arr[j];
                        count++;
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (num == arr[i])
                {
                    final[count] = new int[1];
                    final[count][0] = arr[i];
                    count++;
                }
            }
            return final.Take(count).ToArray();
        }
    }
}
