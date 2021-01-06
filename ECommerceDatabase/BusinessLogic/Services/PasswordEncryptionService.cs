using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace ECommerceDatabase.BusinessLogic
{
    public class PasswordEncryptionService : IPasswordEncryptionService
    {
        // set permutations
        private string strPermutation = "ouiveyxaqtd";
        private const Int32 bytePermutation2 = 0x59;
        private const Int32 bytePermutation3 = 0x17;
        private const Int32 bytePermutation4 = 0x41;
        private const Int32 bytePermutation1 = 0x19;

        /// <summary>
        /// Takes the raw password and converts to Base64 string after Cypto Encoding UTF-8 Bytes from string.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string SetPassword(string password)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(password)));
        }

        private byte[] Encrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes = new PasswordDeriveBytes(strPermutation,
                new byte[] { bytePermutation1,
                             bytePermutation2,
                             bytePermutation3,
                             bytePermutation4
                });

            using (var memstream = new MemoryStream())
            {
                Aes aes = new AesManaged();
                aes.Key = passbytes.GetBytes(aes.KeySize / 8);
                aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

                using (var cryptostream = new CryptoStream(memstream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptostream.Write(strData, 0, strData.Length);
                }

                return memstream.ToArray();
            }
        }

        public string Decrypt(string strData)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(strData)));
        }

        private byte[] Decrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes = new PasswordDeriveBytes(strPermutation,
            new byte[] { bytePermutation1,
                         bytePermutation2,
                         bytePermutation3,
                         bytePermutation4
            });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateDecryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }
    }
}