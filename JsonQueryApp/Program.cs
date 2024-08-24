using Newtonsoft.Json.Linq;

namespace JsonQueryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            {
                string json = File.ReadAllText("jsonsample.json");
                JObject obj = JObject.Parse(json);

                //Steelmet Trade Recap (Buy)/Agent Commission Value
                var rootPath = "da81fdf0-e17c-445c-839e-431925f50661/52ad2580-bbd0-44f8-b8c1-054baedc235c/0ce0d2a2-65fa-4153-9a4c-0a9581835cba";
                SearchByFlatPath(obj, rootPath, "RootPath");

                //Steelmet Trade Recap (Buy)/Agent Commission Value/Value
                var firstLevelChildPath = "da81fdf0-e17c-445c-839e-431925f50661/0e5fa5f1-9d55-4ea1-8abd-7bc458656e51/52ad2580-bbd0-44f8-b8c1-054baedc235c/5efc34d3-1998-4d30-99ba-03e30d354f28";
                SearchByFlatPath(obj, firstLevelChildPath, "firstLevelChildPath");

                //Steelmet Trade Recap (Buy)/Agent Commission Value/Currency/Name
                var secondLevelChildPath = "da81fdf0-e17c-445c-839e-431925f50661/af337f02-0ac6-443f-90ee-1751f65483cc/9ef953ec-e30d-4fce-99f0-126b68a84487/52ad2580-bbd0-44f8-b8c1-054baedc235c/84ac1335-7a42-4965-aa29-072418fb3b6e";
                SearchByFlatPath(obj, secondLevelChildPath, "secondLevelChildPath");

                //Steelmet Trade Recap (Buy)/Materials
                var rootCollectionPath = "52056e24-53cf-453f-be3c-81a238acbab4/5484bd2c-aa96-41ef-80ac-45af26bceed0";
                SearchByFlatPath(obj, rootCollectionPath, "rootCollectionPath");

                //Steelmet Trade Recap (Buy)/Materials/Material
                var firstLevelInCollectionPath = "52056e24-53cf-453f-be3c-81a238acbab4/c5710818-37bc-4fb8-b5e9-ac2617432fab/5484bd2c-aa96-41ef-80ac-45af26bceed0/c3c96ae5-0f6c-4c7a-90d9-9890482b36bd";
                SearchByFlatPath(obj, firstLevelInCollectionPath, "firstLevelInCollectionPath");

                //Steelmet Trade Recap (Buy)/Materials/Material/Product Name shown in Contract
                var secondLevelInCollectionPath = "52056e24-53cf-453f-be3c-81a238acbab4/c5710818-37bc-4fb8-b5e9-ac2617432fab/854dca98-9366-4970-afab-bc836bdca22c/5484bd2c-aa96-41ef-80ac-45af26bceed0/1e613fba-fc71-41af-bbbe-872877583b99";
                SearchByFlatPath(obj, secondLevelInCollectionPath, "secondLevelInCollectionPath");

                //Steelmet Trade Recap (Buy)/Materials/Material/Mills
                var secondLevelCollectionInCollectionPath = "52056e24-53cf-453f-be3c-81a238acbab4/c5710818-37bc-4fb8-b5e9-ac2617432fab/2cd429bd-c889-4582-8b29-a4cfea30a90d/5484bd2c-aa96-41ef-80ac-45af26bceed0";
                SearchByFlatPath(obj, secondLevelCollectionInCollectionPath, "secondLevelCollectionInCollectionPath", "3844b633-ba3e-485f-a035-3c13c0f91174");
            }
        }

        private static void SearchByFlatPath(JObject obj, string path, string searchName, string id="")
        {
            string query = id == string.Empty ?
                $"$..[?(@.FlatPath=='{path}')]" :
                $"$..[?(@.FlatPath=='{path}' && @.Id=='{id}')]";
            var values = obj.SelectTokens(query).ToList();
            Console.WriteLine($"Search {searchName} Count: {values.Count}");
        }
    }
}
