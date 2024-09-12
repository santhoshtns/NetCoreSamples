using Azure.Messaging;
using Azure.Storage.Blobs;
using System.Reflection;
using System.Text.Json;

namespace BlobStorageSaveApp
{
    internal class Program
    {
        private const string blobConnectionString = "<Your_Blob_Storage_ConnectionString>";
        private const string containerName = "<Your_Container_Name>";
        private static readonly string[] keyIds = new string[10];
        private static int iteration = 1;

        static async Task Main(string[] args)
        {
            var blobServiceClient = new BlobServiceClient(blobConnectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync();

            // Generate 10 unique KeyIds
            for (int i = 0; i < 10; i++)
            {
                keyIds[i] = Guid.NewGuid().ToString();
            }

            for (int i = 1; i <= 100; i++)
            {
                var random = new Random();
                var keyId = keyIds[random.Next(keyIds.Length)];
                var messageBody = new { RequestId = Guid.NewGuid().ToString(), KeyId = keyId, Order = i };

                var blobName = $"request/{iteration}/{messageBody.Order}_{Guid.NewGuid()}";
                var blobClient = containerClient.GetBlobClient(blobName);

                // Upload message to Blob Storage
                await blobClient.UploadAsync(BinaryData.FromString(JsonSerializer.Serialize(messageBody)));

                Console.WriteLine($"Saved blob message {i}. {messageBody}");
            }
        }
    }
}
