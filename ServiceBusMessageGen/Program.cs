using Azure.Messaging.ServiceBus;
using System;
using System.Text.Json;

namespace ServiceBusMessageGen
{
    internal class Program
    {
        private const string connectionString = "<Your_ServiceBus_ConnectionString>";
        private const string queueName = "<Your_Queue_Name>";
        private static readonly string[] keyIds = new string[10];

        static async Task Main(string[] args)
        {
            // Generate 10 unique KeyIds
            for (int i = 0; i < 10; i++)
            {
                keyIds[i] = Guid.NewGuid().ToString();
            }

            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(queueName);


            for (int i = 0; i < 100; i++)
            {
                var random = new Random();
                var keyId = keyIds[random.Next(keyIds.Length)];
                var messageBody = new { RequestId = Guid.NewGuid().ToString(), KeyId = "433697c1-d172-44fe-bd7a-8e954caea580", Order = i };
                var message = new ServiceBusMessage(JsonSerializer.Serialize(messageBody))
                {
                    SessionId = messageBody.KeyId
                };

                await sender.SendMessageAsync(message);
                Console.WriteLine($"Sent message {i + 1}");
            }

            await sender.DisposeAsync();
            await client.DisposeAsync();
        }
    }
}
