namespace MissingNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            solution(new int[] { 3, 4, 6, 8, 5 });
            solution(new int[] { 1, 2, 3, 4, 6 });
            Console.WriteLine("Hello, World!");
        }

        public static int solution(int[] A)
        {
            int l = A.Length + 1;
            int min = A.Min();

            //int expectedSum = (int)Math.Ceiling(l / 2.0) * (l + (l + 1) % 2);
            int expectedSum = (int)(l * (min + (l - 1) / 2.0));
            int sum = 0;
            for (int i = -1; ++i < A.Length;)
                sum += A[i];
            return expectedSum - sum;
        }
    }
}
