using System;
using System.Threading.Tasks;

namespace TaskSample
{
    class Program
    {
        async static Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var instanceTask1 = SampleDelayAsync(2, "Instance1");
            var instanceTask2 = SampleDelayAsync(2, "Instance2");
            var instanceTask3 = SampleDelayExceptionAsync(2, "Instance3");
            Console.WriteLine(await instanceTask1);
            Console.WriteLine(await instanceTask2);
            Console.WriteLine(await instanceTask3);
            Console.Read();
        }

        public static async Task<string> SampleDelayAsync(int multiple, string instance)
        {
            await Task.Delay(multiple * 2000);
            Console.WriteLine("SampleDelayAsync: " + instance);
            return instance;
        }

        public static async Task<string> SampleDelayExceptionAsync(int multiple, string instance)
        {
            await Task.Delay(multiple * 2000);
            Console.WriteLine("SampleDelayExceptionAsync: " + instance);
            throw new ArgumentException("SampleDelayExceptionAsync: " + instance);
        }
    }
}
