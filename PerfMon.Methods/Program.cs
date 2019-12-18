using System;
using BenchmarkDotNet.Running;

namespace PerfMon.Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<TestBenchMarks>();

            Console.WriteLine(summary.ToString());

            Console.ReadLine();
        }
    }
}
