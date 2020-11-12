using System;
using System.IO;

namespace JsonTransform
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("DataPointsInput.json");
            string transformer = File.ReadAllText("DataPointsTransformer.json"); ;
            var jsonTransformer = new JUST.JsonTransformer();
            string transformedString = jsonTransformer.Transform(transformer, input);
            Console.WriteLine(transformedString);
        }
    }
}
