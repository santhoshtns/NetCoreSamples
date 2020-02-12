using System;

namespace HashGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var newGuid = "postman12345";

            var toString = ComputeHashWithBase64Encode(newGuid);

            Console.WriteLine(newGuid);
            Console.WriteLine(toString);
        }

        static string ComputeHashWithBase64Encode(string input)
        {
            var convertedGuidToBytes = System.Text.Encoding.UTF8.GetBytes(input);
            var mySha256 = System.Security.Cryptography.SHA256.Create();
            var toString = Convert.ToBase64String(mySha256.ComputeHash(convertedGuidToBytes));
            return toString;
        }
    }
}
