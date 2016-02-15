using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace StudentManagement.Infrustructure
{

    public static class Cryptography
    {
        private static string KEY_64 = "12345678";
        private static string IV_64 = "98765432";

        public static string Encrypt(string data)
        {
            byte[] byKey = ASCIIEncoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = ASCIIEncoding.ASCII.GetBytes(IV_64);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey,

byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }

        public static string Decrypt(string data)
        {
            byte[] byKey = ASCIIEncoding.ASCII.GetBytes(KEY_64);

            byte[] byIV = ASCIIEncoding.ASCII.GetBytes(IV_64);

            byte[] byEnc;

            byEnc = Convert.FromBase64String(data);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();

            MemoryStream ms = new MemoryStream(byEnc);

            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);

            StreamReader sr = new StreamReader(cst);

            return sr.ReadToEnd();
        }
    }
}
