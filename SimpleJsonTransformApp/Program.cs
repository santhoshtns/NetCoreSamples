using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace SimpleJsonTransformApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("DataPointsInput.json");
            JsonTransformer jsonTransformer = new JsonTransformer();
            var token = JsonConvert.DeserializeObject<JToken>(input);

            string output = jsonTransformer.Transform(token.Children<JToken>());
            Console.WriteLine("Hello World!");
        }
    }
}
