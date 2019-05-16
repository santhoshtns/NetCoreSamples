using System;
using System.Configuration;

namespace SimpleCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            DateFormats();
            var flag = true;
            if (!bool.TryParse(ConfigurationManager.AppSettings["Setting21"],
                out flag))
            {
                flag = true;
            }

            Console.WriteLine(flag);
        }

        private static void DateFormats()
        {
            DateTime dt = new DateTime(1987,12,31);
            Console.WriteLine(dt.ToString("d MMM yyyy"));
        }
    }
}
