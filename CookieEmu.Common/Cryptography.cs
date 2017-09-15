using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CookieEmu.Common
{
    public static class Cryptography
    {
        public static string GetMD5Hash(string input)
        {
            var mD = MD5.Create();
            var array = mD.ComputeHash(Encoding.Default.GetBytes(input));
            var stringBuilder = new StringBuilder();
            var array2 = array;
            foreach (var b in array2)
            {
                stringBuilder.Append(b.ToString("x2", CultureInfo.CurrentCulture));
            }
            return stringBuilder.ToString();
        }

        public static string GetFileMD5Hash(string fileName)
        {
            var stringBuilder = new StringBuilder();
            var mD = MD5.Create();
            using (var fileStream = File.OpenRead(fileName))
            {
                var array = mD.ComputeHash(fileStream);
                foreach (var b in array)
                {
                    stringBuilder.Append(b.ToString("x2").ToLower());
                }
            }
            return stringBuilder.ToString();
        }

        public static string GetFileMD5HashBase64(string fileName)
        {
            string result;
            using (var mD = MD5.Create())
            {
                result = Convert.ToBase64String(mD.ComputeHash(File.ReadAllBytes(fileName)));
            }
            return result;
        }

        public static bool VerifyMD5Hash(string chaine, string hash)
        {
            var mD5Hash = Cryptography.GetMD5Hash(chaine);
            var ordinalIgnoreCase = StringComparer.OrdinalIgnoreCase;
            return ordinalIgnoreCase.Compare(mD5Hash, hash) == 0;
        }

        public static string EncryptRSA(string encryptValue, RSAParameters parameters)
        {
            var rSACryptoServiceProvider = new RSACryptoServiceProvider();
            rSACryptoServiceProvider.ImportParameters(parameters);
            var bytes = Encoding.UTF8.GetBytes(encryptValue);
            var inArray = rSACryptoServiceProvider.Encrypt(bytes, false);
            return Convert.ToBase64String(inArray);
        }

        public static string DecryptRSA(byte[] encryptedValue, RSAParameters parameters)
        {
            var rSACryptoServiceProvider = new RSACryptoServiceProvider();
            rSACryptoServiceProvider.ImportParameters(parameters);
            return Encoding.UTF8.GetString(rSACryptoServiceProvider.Decrypt(encryptedValue, false));
        }

        public static byte[] EncryptAES(byte[] data, byte[] key)
        {
            var iv = key.Take(16).ToArray();
            try
            {
                using (var rijndaelManaged = new RijndaelManaged { Key = key, IV = iv, Mode = CipherMode.CBC })
                {
                    var crypto = rijndaelManaged.CreateEncryptor();

                    return crypto.TransformFinalBlock(data, 0, data.Length);
                }
            }
            catch (CryptographicException e)
            {
                System.Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        public static byte[] EncryptAESCBC(byte[] data)
        {
            var key = new byte[16];
            var iv = key.Take(16).ToArray();
            try
            {
                using (var rijndaelManaged = new RijndaelManaged { Key = key, IV = iv, Mode = CipherMode.CBC })
                {
                    var crypto = rijndaelManaged.CreateEncryptor();

                    return crypto.TransformFinalBlock(data, 0, data.Length);
                }
            }
            catch (CryptographicException e)
            {
                System.Console.WriteLine(@"A Cryptographic error occurred: {0}", e.Message);
                return null;
            }


        }
    }
}