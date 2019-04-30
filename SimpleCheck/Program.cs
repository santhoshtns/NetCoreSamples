using System;
using System.Configuration;

namespace SimpleCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            var flag = true;
            if (!bool.TryParse(ConfigurationManager.AppSettings["Setting21"],
                out flag))
            {
                flag = true;
            }

            Console.WriteLine(flag);
        }
    }
}
