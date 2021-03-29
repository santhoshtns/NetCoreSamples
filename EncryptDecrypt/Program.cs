using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EncryptDecrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            var cryptString = new CryptString();
            var input = "ariba@123123";
            var encryptedString1 = cryptString.EncryptStringToBase64(input,
                "ERel23H+hkDPmzXDFoxzdB0RpB1DAQtCntjMOXAfkc8=", "ckOtx2apDX2JbizKyGCahg==");
            var decrypted = cryptString.DecryptStringFromBase64(encryptedString1, "ERel23H+hkDPmzXDFoxzdB0RpB1DAQtCntjMOXAfkc8=", "ckOtx2apDX2JbizKyGCahg==");
            Console.WriteLine($"{input.Equals(decrypted)}");
            var key = "b14ca5898a4e4133bbce2ea2315a1916";

            //Console.WriteLine("Please enter a secret key for the symmetric algorithm.");  
            //var key = Console.ReadLine();  

            Console.WriteLine("Please enter a string for encryption");
            var str = Console.ReadLine();
            var encryptedString = AesOperation.EncryptString(key, str);
            Console.WriteLine($"encrypted string = {encryptedString}");

            var decryptedString = AesOperation.DecryptString(key, encryptedString);
            Console.WriteLine($"decrypted string = {decryptedString}");

            Console.ReadKey();
        }

        public class CryptString
        {
            private readonly string _encryptionKey = "ERel23H+hkDPmzXDFoxzdB0RpB1DAQtCntjMOXAfkc8=";
            private readonly string _ivKey = "1fuzR+xhuxuyW8oFfxQEoQ==";
            public CryptString()
            {

            }

            public string EncryptStringToBase64(string plainText, out string IV)
            {
                using (var myRijndael = Rijndael.Create())
                {
                    var key = Convert.FromBase64String(_encryptionKey);
                    IV = Convert.ToBase64String(myRijndael.IV);
                    var encrypted = EncryptStringToBytes(plainText, key, myRijndael.IV);
                    return Convert.ToBase64String(encrypted);
                }
            }

            public string EncryptStringToBase64(string plainText, string keybase64, string ivbase64)
            {
                var key = Convert.FromBase64String(keybase64);
                var iv = Convert.FromBase64String(ivbase64);
                var encrypted = EncryptStringToBytes(plainText, key, iv);
                return Convert.ToBase64String(encrypted);
            }

            public string DecryptStringFromBase64(string encryptedText, string IV)
            {
                var IVbyte = Convert.FromBase64String(IV);
                var cipherText = Convert.FromBase64String(encryptedText);
                var key = Convert.FromBase64String(_encryptionKey);

                return DecryptStringFromBytes(cipherText, key, IVbyte);
            }

            public string DecryptStringFromBase64(string encryptedText, string keybase64, string ivbase64)
            {
                var ivByte = Convert.FromBase64String(ivbase64);
                var cipherText = Convert.FromBase64String(encryptedText);
                var key = Convert.FromBase64String(_encryptionKey);
                return DecryptStringFromBytes(cipherText, key, ivByte);
            }

            //https://msdn.microsoft.com/en-us/library/system.security.cryptography.cryptostream(v=vs.110).aspx
            private byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
            {
                // Check arguments.
                if (plainText == null || plainText.Length <= 0)
                    throw new ArgumentNullException("plainText");
                if (Key == null || Key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (IV == null || IV.Length <= 0)
                    throw new ArgumentNullException("IV");
                byte[] encrypted;
                // Create an Rijndael object
                // with the specified key and IV.
                using (var rijAlg = Rijndael.Create())
                {
                    rijAlg.Key = Key;
                    rijAlg.IV = IV;

                    // Create an encryptor to perform the stream transform.
                    var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                    // Create the streams used for encryption.
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (var swEncrypt = new StreamWriter(csEncrypt))
                            {
                                //Write all data to the stream.
                                swEncrypt.Write(plainText);
                            }

                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }

                // Return the encrypted bytes from the memory stream.
                return encrypted;
            }

            private string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
            {
                // Check arguments.
                if (cipherText == null || cipherText.Length <= 0)
                    throw new ArgumentNullException("cipherText");
                if (Key == null || Key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (IV == null || IV.Length <= 0)
                    throw new ArgumentNullException("IV");

                // Declare the string used to hold
                // the decrypted text.
                string plaintext = null;

                // Create an Rijndael object
                // with the specified key and IV.
                using (var rijAlg = Rijndael.Create())
                {
                    rijAlg.Key = Key;
                    rijAlg.IV = IV;

                    // Create a decryptor to perform the stream transform.
                    var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                    // Create the streams used for decryption.
                    using (var msDecrypt = new MemoryStream(cipherText))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }

                return plaintext;
            }
        }

        public class AesOperation
        {
            public static string EncryptString(string key, string plainText)
            {
                byte[] iv = new byte[16];
                byte[] array;

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                            {
                                streamWriter.Write(plainText);
                            }

                            array = memoryStream.ToArray();
                        }
                    }
                }

                return Convert.ToBase64String(array);
            }

            public static string DecryptString(string key, string cipherText)
            {
                byte[] iv = new byte[16];
                byte[] buffer = Convert.FromBase64String(cipherText);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                            {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }
    }
}
