using System.Collections.Generic;
using System.Linq;

namespace PerfMon.Methods
{
    public class Test
    {
        //static void Main()
        //{

        //    Console.WriteLine(string.Join(",", A(x, y, z)));
        //    Console.WriteLine(string.Join(",", B(x, y, z)));
        //}

        public static List<string> A(IEnumerable<string> x, IEnumerable<string> y, IEnumerable<string> z)
        {
            return x.Concat(y).Concat(z).ToList();
        }

        public static List<string> B(params IEnumerable<string>[] lists)
        {
            return lists.SelectMany(x => x).ToList();
        }
    }
}
