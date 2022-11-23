namespace EncryptionDecryption
{
    public interface IEncryptDecrypt
    {
        public string Encrypt(string clearText, string encryptionDecryptionKey);
        public string Decrypt(string cipherText, string encryptionDecryptionKey);
    }
}