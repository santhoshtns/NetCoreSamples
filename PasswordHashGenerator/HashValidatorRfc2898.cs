using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace PasswordHashGenerator
{
    public static class HashValidatorRfc2898
    {
        private const int Iterations = 1000;
        private const int HashSize = 32;
        private const int SaltSize = 32;

        public static bool ValidatePassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var rdb = new Rfc2898DeriveBytes(password, passwordSalt, Iterations);

            var hash = rdb.GetBytes(HashSize);
            return IsSameByteArray(passwordHash, hash);
        }

        public static void HashPassword(string password, out byte[] salt, out byte[] hash)
        {
            var rdb = new Rfc2898DeriveBytes(password, SaltSize, Iterations);

            salt = rdb.Salt;
            hash = rdb.GetBytes(HashSize);
        }

        private static bool IsSameByteArray(IReadOnlyCollection<byte> a, IReadOnlyList<byte> b)
        {
            if (a.Count != b.Count)
            {
                return false;
            }

            return !a.Where((t, i) => t != b[i]).Any();
        }
    }
}