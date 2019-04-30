using System.Linq;

namespace OddOccurrencesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            solution(new[] { 9, 3, 9, 3, 7 });
        }

        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A.Length == 1)
                return A[0];
            int unpaired = -1;
            A = A.OrderByDescending(x => x).ToArray();
            for (int i = 0; i < A.Length - 1; i += 2)
            {
                if ((i + 1 == A.Length) ||
                (A[i] != A[i + 1]))
                {
                    unpaired = A[i]; break;
                }
            }
            return unpaired;
        }
    }
}
