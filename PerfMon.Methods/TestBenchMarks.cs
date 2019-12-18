using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace PerfMon.Methods
{
    [MemoryDiagnoser]
    public class TestBenchMarks
    {
        List<string> _x = new List<string>() { "ABC", "DEF", "GHI", "JKL" };
        List<string> _y = new List<string>() { "ABC", "DEF", "GHI", "JKL" };
        List<string> _z = new List<string>() { "ABC", "DEF", "GHI", "JKL" };

        //[Benchmark(Baseline = true)]
        //public void TestingMethodA()
        //{
        //    Test.A(_x, _y, _z);
        //}

        [Benchmark(Baseline = true)]
        public void TestingMethodB()
        {
            Test.B(_x, _y, _z);
        }
    }
}
