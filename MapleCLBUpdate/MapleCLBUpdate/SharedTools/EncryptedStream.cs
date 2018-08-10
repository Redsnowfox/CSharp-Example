using System;
using System.IO;
using System.Security.Cryptography;

namespace SharedTools {
    public static class EncryptedStream {
        private const int KEY_SIZE = 128;
        private const int IV_SIZE = 16;

        public static CryptoStream CreateEncryptionStream(byte[] key, Stream outputStream) {
            byte[] iv = new byte[IV_SIZE];

            using (var rng = new RNGCryptoServiceProvider()) {
                // Using a cryptographic random number generator
                rng.GetNonZeroBytes(iv);
            }

            // Write IV to the start of the stream
            outputStream.Write(iv, 0, iv.Length);

            Rijndael rijndael = new RijndaelManaged();
            rijndael.KeySize = KEY_SIZE;

            var encryptor = new CryptoStream( outputStream, rijndael.CreateEncryptor(key, iv),
                CryptoStreamMode.Write);
            return encryptor;
        }

        public static CryptoStream CreateDecryptionStream(byte[] key, Stream inputStream) {
            byte[] iv = new byte[IV_SIZE];

            if (inputStream.Read(iv, 0, iv.Length) != iv.Length) {
                throw new ApplicationException("Failed to read IV from stream.");
            }

            Rijndael rijndael = new RijndaelManaged();
            rijndael.KeySize = KEY_SIZE;

            var decryptor = new CryptoStream(inputStream, rijndael.CreateDecryptor(key, iv),
                CryptoStreamMode.Read);
            return decryptor;
        }
    }
}
