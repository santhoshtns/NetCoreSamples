using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CustomTransformer
{
    class Program
    {
        private const string CollectionType = "Collection";
        private const string StructureType = "Structure";
        private const string MasterDataReference = "MasterDataReference";
        private const string DisplayName = "DisplayName";

        static void Main(string[] args)
        {
            string input = File.ReadAllText("DataPointsInput.json");
            var token = JsonConvert.DeserializeObject<DataPointModel>(input);

            var exportModel = new DataPointExport()
            {
                ProductName = token.ProductName,
                ChinsayFriendlyId = token.WorkspaceFriendlyId,
                Items = GetItems(token.Items)
            };

            var outputJson = JsonConvert.SerializeObject(exportModel);
            File.WriteAllText($@"datapointExport-{DateTime.Now:yyyyMMddHHmmsss}.json", outputJson);
        }

        private static List<Dictionary<string, object>> GetItems(List<Item> items)
        {
            var list = new List<Dictionary<string, object>>();
            foreach (var item in items)
            {
                var dict = new Dictionary<string, object>();

                if (item.TypeName == StructureType)
                {
                    //GetStructureItems(item, dict);
                    var structureDict = new Dictionary<string, object>();
                    GetStructureItems(item, structureDict);
                    dict.Add(item.GetKeyName(), structureDict);
                }
                else if (item.TypeName == CollectionType)
                {
                    var collectionItems = GetCollectionItems(item);
                    dict.Add(item.GetKeyName(), collectionItems);
                }
                else
                {
                    if (item.MasterDataExternalReference != null)
                        dict.Add(MasterDataReference, item.MasterDataExternalReference);
                    dict.Add(DisplayName, item.Title);
                    dict.Add(item.GetKeyName(), item.Value);
                }
                list.Add(dict);
            }
            return list;
        }

        private static List<Dictionary<string, object>> GetCollectionItems(Item item)
        {
            var collectionItems = new List<Dictionary<string, object>>();
            if (item.Value == null)
            {
                return collectionItems;
            }

            var values = (item.Value as Newtonsoft.Json.Linq.JArray).ToObject<List<Item>>();
            foreach (var value in values)
            {
                var dict = new Dictionary<string, object>();
                if (value.TypeName == StructureType)
                {
                    GetStructureItems(value, dict);
                }
                else
                {
                    throw new NotImplementedException();
                }
                collectionItems.Add(dict);
            }
            return collectionItems;
        }

        private static void GetStructureItems(Item item, Dictionary<string, object> dict)
        {
            if (item.MasterDataExternalReference != null)
                dict.Add(MasterDataReference, item.MasterDataExternalReference);
            dict.Add(DisplayName, item.Title);

            if (item.Value == null)
                return;

            var values = (item.Value as Newtonsoft.Json.Linq.JArray).ToObject<List<Item>>();
            foreach (var value in values)
            {
                if (value.TypeName == CollectionType)
                {
                    var collectionItems = GetCollectionItems(value);
                    dict.Add(value.GetKeyName(), collectionItems);
                }
                else if (value.TypeName == StructureType)
                {
                    var structureDict = new Dictionary<string, object>();
                    GetStructureItems(value, structureDict);
                    dict.Add(value.GetKeyName(), structureDict);
                }
                else
                {
                    dict.Add(value.GetKeyName(), value.Value);
                }
            }
        }
    }
}
