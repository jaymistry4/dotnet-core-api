using System.Security.Cryptography;
using System.Text;

namespace EncryptionDecryption
{
    public class EncryptDecrypt: IEncryptDecrypt
    {
        public string Encrypt(string clearText, string encryptionDecryptionKey)
        {
            if (string.IsNullOrWhiteSpace(encryptionDecryptionKey))
                throw new Exception("Encryption Decryption Key is missing.");

            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);

            using (Aes aesEncryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionDecryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aesEncryptor.Key = pdb.GetBytes(32);
                aesEncryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aesEncryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }

                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }

            return clearText;
        }

        public string Decrypt(string cipherText, string encryptionDecryptionKey)
        {
            if (string.IsNullOrWhiteSpace(encryptionDecryptionKey))
                throw new Exception("Encryption Decryption Key is missing.");

            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using (Aes aesEncryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionDecryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aesEncryptor.Key = pdb.GetBytes(32);
                aesEncryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aesEncryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }

                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }

            return cipherText;
        }
    }
}
