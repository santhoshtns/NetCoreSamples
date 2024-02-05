namespace CyclicRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = solution(new[] { 1, 2, 3, 4, 5 }, 8);
            Console.WriteLine("");

        }

        public static int[] solution(int[] A, int K)
        {
            var shift = K % A.Length;
            var r = new int[A.Length];
            if (r.Length > 0)
            {
                for (int i = -1, j = A.Length - shift; ++i < A.Length;)
                    r[i] = A[(j + i) % A.Length];
            }

            return r;
        }
    }
}
