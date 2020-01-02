using System;

namespace PasswordHashGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var password = args.Length > 0 ? args[0] : Console.ReadLine();
            HashValidatorRfc2898.HashPassword(password, out var salt, out var hash);
            Console.WriteLine($"Password: {password}");
            Console.WriteLine($"PasswordHash: 0x{hash.ConvertByteToString()}");
            Console.WriteLine($"PasswordSalt: 0x{salt.ConvertByteToString()}");
            Console.Read();
        }
    }

    public static class Extensions
    {
        public static string ConvertByteToString(this byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", string.Empty);
        }
    }
}
