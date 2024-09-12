using Azure.Messaging.ServiceBus;

namespace ServiceBusListenerApp
{
    class Program
    {
        private const string connectionString = "<Your_ServiceBus_ConnectionString>";
        private const string queueName = "<Your_Queue_Name>";
        private static ServiceBusClient client;
        private static ServiceBusSessionProcessor processor;

        static async Task Main(string[] args)
        {
            client = new ServiceBusClient(connectionString);
            processor = client.CreateSessionProcessor(queueName, new ServiceBusSessionProcessorOptions
            {
                MaxConcurrentSessions = 4,
                AutoCompleteMessages = false
            });

            processor.ProcessMessageAsync += MessageHandler;
            processor.ProcessErrorAsync += ErrorHandler;

            await processor.StartProcessingAsync();

            Console.WriteLine("Press any key to stop the application");
            Console.ReadKey();

            await processor.StopProcessingAsync();
            await processor.DisposeAsync();
            await client.DisposeAsync();
        }

        static async Task MessageHandler(ProcessSessionMessageEventArgs args)
        {
            var body = args.Message.Body.ToString();
            Console.WriteLine($"Received: {body}");

            // Simulate processing time
            var random = new Random();
            int sleepTime = random.Next(1000, 5000);
            await Task.Delay(sleepTime);

            // Complete the message
            await args.CompleteMessageAsync(args.Message);
            Console.WriteLine($"Completed: {body}");
        }

        static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine($"Error: {args.Exception.ToString()}");
            return Task.CompletedTask;
        }
    }
}
