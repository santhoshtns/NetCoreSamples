using System;

namespace HashGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var newGuid = "18eVK7dW";

            var toString = ComputeHashWithBase64Encode(newGuid);

            Console.WriteLine(newGuid);
            Console.WriteLine(toString);

            var hashData = ReverseHash(toString);
            

        }

        static string ComputeHashWithBase64Encode(string input)
        {
            var convertedGuidToBytes = System.Text.Encoding.UTF8.GetBytes(input);
            var mySha256 = System.Security.Cryptography.SHA256.Create();
            var computeHash = mySha256.ComputeHash(convertedGuidToBytes);
            var toString = Convert.ToBase64String(computeHash);
            return toString;
        }

        static string ReverseHash(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            var decodebase64String = Convert.ToBase64String(inputBytes);
            var convertedGuidToBytes = System.Text.Encoding.UTF8.GetBytes(input);
            var mySha256 = System.Security.Cryptography.SHA256.Create();
            var computeHash = mySha256.ComputeHash(convertedGuidToBytes);
            var toString = Convert.ToBase64String(computeHash);
            return toString;
        }
    }
}
