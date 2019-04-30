using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryGap
{
    class Program
    {
        static void Main(string[] args)
        {
            solution(32);
        }

        public static int solution(int N)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            string binary = Convert.ToString(N, 2);
            var arr = binary.Split('1').ToList();
            arr.RemoveAt(arr.Count - 1);
            return arr.OrderByDescending(a => a.Length).First().Length;
        }
    }
}
