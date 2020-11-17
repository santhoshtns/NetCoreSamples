using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CustomTransformer
{
    public class Item
    {
        [JsonProperty("Value")]
        public object Value { get; set; }

        [JsonProperty("MasterDataExternalReference")]
        public object MasterDataExternalReference { get; set; }

        [JsonProperty("TypeName")]
        public string TypeName { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("OriginalTitle")]
        public string OriginalTitle { get; set; }

        public string GetKeyName()
        {
            return Regex.Replace(OriginalTitle, "[^a-zA-Z0-9]+", "", RegexOptions.Compiled);
        }

        public object ValueTrimmed => Value != null ? Value.ToString().Replace("\n", "") : Value;
    }

    public class DataPointModel
    {
        [JsonProperty("Version")]
        public int Version { get; set; }

        [JsonProperty("Created")]
        public DateTime Created { get; set; }

        [JsonProperty("Product Name")]
        public string ProductName { get; set; }

        [JsonProperty("WorkspaceFriendlyId")]
        public string WorkspaceFriendlyId { get; set; }

        [JsonProperty("Items")]
        public List<Item> Items { get; set; }
    }


    public class DataPointExport
    {
        [JsonProperty("ProductName")]
        public string ProductName { get; set; }

        [JsonProperty("WorkspaceFriendlyId")]
        public string ChinsayFriendlyId { get; set; }

        [JsonProperty("WorkspaceUrl")]
        public string WorkspaceUrl { get; set; }

        [JsonProperty("Items")]
        public List<Dictionary<string, object>> Items { get; set; }
    }
}
