using System;

namespace XmlSerializeDeserialize
{
    class Program
    {
        static void Main(string[] args)
        {
            var srcProject = GetSourceProjectModel("ABCD1234", "santhosh", "sgd");
            var xmlSerialize = new XmlSerialize();
            var xml = xmlSerialize.SerializeToString<SourcingProjectRequestEnvelope>(srcProject);
            Console.WriteLine(xml);
        }

        private static SourcingProjectRequestEnvelope GetSourceProjectModel(string friendlyId, string userId, string currencyCode)
        {
            var sourcingProject = new SourcingProjectRequestEnvelope();
            sourcingProject.Header.Headers.variant = "?";
            sourcingProject.Header.Headers.partition = "?";
            sourcingProject.Body.SourcingProjectImportRequest.WSSourcingProjectInputBean_Item.Item.Action = "Create";
            sourcingProject.Body.SourcingProjectImportRequest.WSSourcingProjectInputBean_Item.Item.OnBehalfUserId = userId;
            sourcingProject.Body.SourcingProjectImportRequest.WSSourcingProjectInputBean_Item.Item.ProjectHeaderFields.Commodity.Item.Domain = "Domain";
            sourcingProject.Body.SourcingProjectImportRequest.WSSourcingProjectInputBean_Item.Item.ProjectHeaderFields.Commodity.Item.UniqueName = 10;
            sourcingProject.Body.SourcingProjectImportRequest.WSSourcingProjectInputBean_Item.Item.ProjectHeaderFields.Currency.UniqueName = currencyCode;
            sourcingProject.Body.SourcingProjectImportRequest.WSSourcingProjectInputBean_Item.Item.ProjectHeaderFields.Description.DefaultStringTranslation = $"Chinsay {friendlyId}";
            sourcingProject.Body.SourcingProjectImportRequest.WSSourcingProjectInputBean_Item.Item.ProjectHeaderFields.Title.DefaultStringTranslation = $"Chinsay {friendlyId}";
            return sourcingProject;
        }
    }
}
