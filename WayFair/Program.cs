using System;

namespace WayFair
{
    class Program
    {
        static void Main(string[] args)
        {
            FormatTelephoneNumber("0 -2 2 1985--324");
        }

        public static string FormatTelephoneNumber(string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var str1 = S.Replace(" ", "").Replace("-", "");
            if (str1.Length < 2 || str1.Length > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            var count = str1.Length / 3;
            var remainder = str1.Length % 3;
            string[] result = new string[count + 1];
            for (int i = 0; i < count + 1; i++)
            {
                if ((i == count || i == count - 1) && remainder == 1)
                {
                    result[i] = str1.Substring((count - 1) * 3 + (i - (count - 1)) * 2, 2);
                }
                else
                    result[i] = str1.Substring(i * 3, i == count ? 2 : 3);
            }

            return string.Join("-", result);
        }
    }
}
