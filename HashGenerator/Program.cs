using System;

namespace HashGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var newGuid = Guid.NewGuid().ToString();

            var convertedGuidToBytes = System.Text.Encoding.UTF8.GetBytes(newGuid);
            var mySha256 = System.Security.Cryptography.SHA256.Create();
            var toString = Convert.ToBase64String(mySha256.ComputeHash(convertedGuidToBytes));

            Console.WriteLine(newGuid);
            Console.WriteLine(toString);
        }
    }
}
