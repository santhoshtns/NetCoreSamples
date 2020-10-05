using System;
using System.Linq;

namespace AutoGenerateSqlConfigDataPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            const string pathToFile = @"DataPoint.json";

            var autoGenScript = new AutoGenScript();
            var dataPointsToCreate = //GetValueFromClipbord() ?? 
                autoGenScript.GetValueFromFile(pathToFile);
            if (dataPointsToCreate == null)
            {
                Console.WriteLine("There is not dataPointToCreate");
                return;
            }

            autoGenScript.SetDescription(dataPointsToCreate);

            var dataPointDefinition = dataPointsToCreate.SelectMany(x => autoGenScript.GetAllDefinitionString(x)).ToArray();
            var dataPointType = dataPointsToCreate.SelectMany(x => autoGenScript.GetAllTypeString(x)).ToArray();
            var dataPointTypeConfig = dataPointsToCreate.SelectMany(x => autoGenScript.GetAllTypeConfigString(x)).ToArray();


            var pasteData =
            $"-- DataPointDefinition{Environment.NewLine}" +
            $"{string.Join(Environment.NewLine, dataPointDefinition)}{Environment.NewLine}{Environment.NewLine}" +
            $"-- DataPointType{Environment.NewLine}" +
            $"{string.Join(Environment.NewLine, dataPointType)}{Environment.NewLine}{Environment.NewLine}" +
            $"-- DataPointTypeConfig{Environment.NewLine}" +
            $"{string.Join(Environment.NewLine, dataPointTypeConfig)}{Environment.NewLine}";

            Console.WriteLine(pasteData);
            var dateTime = DateTime.Now.ToString("yyyyddMMhhmmss");
            System.IO.File.WriteAllText($"DataPointType-config-{dateTime}.txt", pasteData);
            autoGenScript.SaveFileToPath(dataPointsToCreate, $"DataPointSave-{dateTime}.Json");
        }
    }
}
