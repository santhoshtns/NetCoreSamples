using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace AutoGenerateSqlConfigDataPoint
{
    public class AutoGenScript
    {
        public void SetDescription(DataPoint[] dataPoint)
        {
            foreach (var element in dataPoint)
            {
                SetDescriptionItem(element, "");
            }
        }

        private void SetDescriptionItem(DataPoint dataPoint, string parentName)
        {
            var parent = parentName;

            if (string.IsNullOrWhiteSpace(parent))
            {
                parent = dataPoint.Name;
            }
            else if (dataPoint.Name != parent)
            {
                parent = $"{parentName} - {dataPoint.Name}";
            }

            string description;
            switch (dataPoint.Type)
            {
                case DpType.Structure:
                case DpType.Collection:
                    description = $"{parent} - {dataPoint.Type.ToString()}";
                    break;
                default:
                    description = parent;
                    break;
            }
            if (string.IsNullOrWhiteSpace(dataPoint.Description))
            {
                dataPoint.Description = description;
            }

            switch (dataPoint.Type)
            {

                case DpType.Structure:
                case DpType.Collection:
                case DpType.Table:
                case DpType.TableHeader:
                case DpType.TableBody:
                case DpType.TableFooter:
                case DpType.TableRow:
                    if (dataPoint.Children?.Any() != true)
                    {
                        throw new Exception($"DataPoint {dataPoint.Name} is a {dataPoint.Type} but has no children");
                    }
                    foreach (var element in dataPoint.Children)
                    {
                        SetDescriptionItem(element, parent);
                    }
                    break;
                default:
                    if (dataPoint.Children?.Any() == true)
                    {
                        throw new Exception($"DataPoint {dataPoint.Name} is a {dataPoint.Type} and can not have children");
                    }
                    break;
            }
        }

        public List<string> GetAllDefinitionString(DataPoint dataPoint)
        {
            var returnList = new List<string>();

            if (dataPoint.ProductId.HasValue)
            {
                returnList.Add($"\t,(N'{dataPoint.DefinitionId}', N'{dataPoint.TypeId}', N'{dataPoint.ProductId}', N'{dataPoint.Name}')");
            }
            return returnList;
        }

        public List<string> GetAllTypeString(DataPoint dataPoint)
        {
            var returnList = new List<string>();
            if (dataPoint.Type == DpType.Clone && dataPoint.CloneId == null)
            {
                return returnList;
            }

            returnList.Add($"\t,(N'{dataPoint.TypeId}', N'{dataPoint.Name}', N'{dataPoint.Description}')");

            switch (dataPoint.Type)
            {
                case DpType.Structure:
                case DpType.Collection:
                case DpType.Table:
                case DpType.TableHeader:
                case DpType.TableBody:
                case DpType.TableRow:
                    foreach (var element in dataPoint.Children)
                    {
                        returnList.AddRange(GetAllTypeString(element));
                    }
                    break;
            }
            return returnList;
        }

        public List<string> GetAllTypeConfigString(DataPoint dataPoint)
        {
            var returnList = new List<string>();

            if (dataPoint.Type == DpType.Clone && dataPoint.CloneId == null)
            {
                return returnList;
            }

            returnList.Add($"\t,(N'{dataPoint.ConfigurationId}', N'{dataPoint.TypeId}', {dataPoint.ToConfig()} -- {dataPoint.Description}");

            switch (dataPoint.Type)
            {
                case DpType.Structure:
                case DpType.Collection:
                case DpType.Table:
                case DpType.TableHeader:
                case DpType.TableBody:
                case DpType.TableFooter:
                case DpType.TableRow:
                    foreach (var element in dataPoint.Children)
                    {
                        returnList.AddRange(GetAllTypeConfigString(element));
                    }
                    break;
            }
            return returnList;
        }

        private JsonSerializerOptions _jsonOption = new JsonSerializerOptions()
        {
            AllowTrailingCommas = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            WriteIndented = true,
            IgnoreNullValues = true
        };

        //private DataPoint[] GetValueFromClipbord()
        //{
        //    var clipboardValue = System.Windows.Clipboard.GetData("UnicodeText").ToString();
        //    DataPoint[] dataPointsToCreate = null;
        //    DataPoint dataPointToCreate = null;

        //    try
        //    {
        //        dataPointsToCreate = System.Text.Json.JsonSerializer.Deserialize<DataPoint[]>(clipboardValue, _jsonOption);
        //    }
        //    catch { }

        //    try
        //    {
        //        dataPointToCreate = System.Text.Json.JsonSerializer.Deserialize<DataPoint>(clipboardValue, _jsonOption);
        //    }
        //    catch { }

        //    if (dataPointToCreate != null)
        //    {
        //        return new[] { dataPointToCreate };
        //    }
        //    return dataPointsToCreate;
        //}

        public DataPoint[] GetValueFromFile(string pathToFile)
        {
            DataPoint[] dataPointsToCreate = null;
            DataPoint dataPointToCreate = null;

            if (File.Exists(pathToFile))
            {
                var fileData = File.ReadAllText(pathToFile);

                try
                {
                    if (dataPointsToCreate == null)
                    {
                        dataPointsToCreate = JsonSerializer.Deserialize<DataPoint[]>(fileData, _jsonOption);
                    }
                }
                catch { }
                try
                {
                    if (dataPointToCreate == null)
                    {
                        dataPointToCreate = JsonSerializer.Deserialize<DataPoint>(fileData, _jsonOption);
                    }
                }
                catch { }
            }

            return dataPointsToCreate ?? (dataPointToCreate == null ? null : new[] { dataPointToCreate });
        }

        public bool SaveFileToPath(DataPoint[] dataPoint, string pathToFile)
        {

            if (Directory.Exists(Path.GetDirectoryName(pathToFile)))
            {
                if (dataPoint.Count() == 1)
                {
                    File.WriteAllText(pathToFile, JsonSerializer.Serialize(dataPoint[0], typeof(DataPoint), _jsonOption));
                }
                else
                {
                    File.WriteAllText(pathToFile, JsonSerializer.Serialize(dataPoint, typeof(DataPoint[]), _jsonOption));
                }
                return true;
            }
            return false;

        }
    }
}
