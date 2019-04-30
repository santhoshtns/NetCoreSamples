using System.Collections.Generic;

namespace TheaterTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(solution(new[] { 2, 2, 1, 2, 2 }));
        }

        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length < 3)
            {
                return 0;
            }

            List<string> combinations = new List<string>();

            for (int a = 0; a < A.Length - 2; a++)
            {
                for (int b = a + 1; b < A.Length - 1; b++)
                {
                    for (int c = b + 1; c < A.Length; c++)
                    {
                        var combination = $"{A[a]},{A[b]},{A[c]}";
                        if (!combinations.Contains(combination))
                        {
                            combinations.Add(combination);
                        }
                    }
                }
            }

            return combinations.Count;
        }
    }
}
