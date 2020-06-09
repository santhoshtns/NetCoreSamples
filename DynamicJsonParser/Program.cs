using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace DynamicJsonParser
{
    class Program
    {
        static void Main(string[] args)
        {
            JToken jTokenRoot = JToken.Parse(JsonData.Sample1);

            Console.WriteLine($"{jTokenRoot.Path}");

            JObject jObjectInner = jTokenRoot["vesselExportFull"].Value<JObject>();

            var keys = jTokenRoot.Children().ToList().Select(x => x.Path);

            Console.WriteLine($"{jObjectInner.Path}");

            //List<string> keys = jObjectInner.Properties().Select(p => p.Name).ToList();

            //foreach (var key in keys)
            //{
            //    Console.WriteLine($"{key}");
            //}

            LoopThroughJObject(jObjectInner);

            //JObject jobjects = JObject.Parse(JsonData.Sample1);
            //JToken jToken = JToken.Parse(JsonData.Sample2);
            //foreach (var child in jToken)
            //{
            //    Console.WriteLine($"{child.Path}:{child.Value<string>()}");
            //}

            //dynamic json = JValue.Parse(JsonData.Sample1);
            //var vesselGeneral = jToken["vesselGeneral"];
            //Console.WriteLine("test");
        }

        private static void LoopThroughJObject(JObject jObject)
        {
            foreach (var property in jObject.Properties())
            {
                switch (property.Value.Type)
                {
                    case JTokenType.Object:
                        Console.WriteLine("==========================================");
                        Console.WriteLine($"{property.Name}");
                        Console.WriteLine("==========================================");
                        LoopThroughJObject((JObject)property.Value);
                        break;
                    case JTokenType.Array:
                        {
                            JArray array = JArray.FromObject(property.Value);
                            foreach (var item in array)
                            {
                                Console.WriteLine("------------------------------------------");
                                LoopThroughJObject((JObject)item);
                                Console.WriteLine("------------------------------------------");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine($"{property.Name} : {property.Value.ToString()} - {property.Value.Type.ToString()}");
                        break;
                }
            }
        }
    }
}
