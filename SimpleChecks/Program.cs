using System;

namespace SimpleChecks
{
    class Program
    {
        static void Main(string[] args)
        {

            var suffix = string.Empty;
            var filename = $"{Guid.NewGuid():D}{(string.IsNullOrEmpty(suffix) ? string.Empty : '-' + suffix)}.json";

            suffix = "1";
            filename = $"{Guid.NewGuid():D}{(suffix == string.Empty ? string.Empty : '-' + suffix)}.json";

            Console.WriteLine("Hello World!");

            ExceptionTestMethod();

            ParsingBehavior();
        }

        private static void ParsingBehavior()
        {
            int abv = 25;
            int.TryParse("sadfasd", out abv);
            Console.WriteLine(abv);
        }

        private static void ExceptionTestMethod()
        {
            try
            {
                Console.WriteLine("Hello World!");

                Method1();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.StackTrace);
            }
        }

        private static void Method1()
        {
            Method2();
        }

        private static void Method2()
        {
            Method3();
        }

        private static void Method3()
        {
            try
            {
                throw new NotSupportedException("From Method 3");
            }
            finally
            {

            }
        }
    }
}
