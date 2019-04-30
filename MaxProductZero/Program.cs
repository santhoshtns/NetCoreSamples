using System.Linq;

namespace MaxProductZero
{
    class Program
    {
        static void Main(string[] args)
        {
            solution(new[] { 1, 2, 1, 1 });
        }

        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int maxZeroCount = 0;
            if (A.Length < 3 && A.Length > 100000)
            {
                return 0;
            }

            var temp = A.Where(x => x >= 1 && x <= 1000000000 &&
            (x % 2 == 0 || x % 5 == 0)).ToArray();
            if (temp.Length >= 3)
                A = temp;
            else
            {
                ulong product = 1;
                for (int i = 0; i < temp.Length; i++)
                {
                    product *= (ulong)temp[i];
                }
                int remainder = 0;
                return findTrailingZeros(product, ref remainder);
            }

            for (int a = 0; a < A.Length - 2; a++)
            {
                for (int b = a + 1; b < A.Length - 1; b++)
                {
                    for (int c = b + 1; c < A.Length; c++)
                    {
                        ulong product = ((ulong)A[a] * (ulong)A[b]);
                        int remainder = 0;
                        var zeroes = findTrailingZeros(product, ref remainder);
                        zeroes += findTrailingZeros(((ulong)remainder * (ulong)A[c]), ref remainder);
                        if (zeroes > maxZeroCount)
                            maxZeroCount = zeroes;
                    }
                }
            }

            return maxZeroCount;
        }

        //public static int solution_old1(int[] A)
        //{
        //    // write your code in C# 6.0 with .NET 4.5 (Mono)
        //    int maxZeroCount = 0;
        //    if (A.Length < 3 && A.Length > 100000)
        //    {
        //        return 0;
        //    }

        //    var temp = A.Where(x => x % 2 == 0 || x % 5 == 0).ToArray();
        //    if (temp.Length >= 3)
        //        A = temp;

        //    List<System.Tuple<int, int, int>> combinations = new List<System.Tuple<int, int, int>>();
        //    for (int a = 0; a < A.Length - 2; a++)
        //    {
        //        for (int b = a + 1; b < A.Length - 1; b++)
        //        {
        //            for (int c = b + 1; c < A.Length && c != b; c++)
        //            {
        //                combinations.Add(System.Tuple.Create(A[a], A[b], A[c]));
        //            }
        //        }
        //    }

        //    foreach (var triplet in combinations)
        //    {
        //        var product = triplet.Item1 * triplet.Item2 * triplet.Item3;
        //        var zeroes = findTrailingZeros(product);
        //        if (zeroes > maxZeroCount)
        //            maxZeroCount = zeroes;
        //    }

        //    return maxZeroCount;
        //}

        static int findTrailingZeros(ulong n, ref int remainder)
        {
            if (n == 0)
            {
                remainder = 0;
                return 0;
            }
            int count = 0;
            while (n % 10 == 0)
            {
                n /= 10;
                count++;
            }
            remainder = (int)(n);
            return count;
        }
    }
}
