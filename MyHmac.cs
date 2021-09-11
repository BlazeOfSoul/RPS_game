using System;
using System.Security.Cryptography;

namespace itransition_labs_3
{
    public class MyHmac : RandomNumberGenerator
    {
        public RNGCryptoServiceProvider rnd = new RNGCryptoServiceProvider();

        private byte[] key = new byte[16];

        public MyHmac()
        {
            rnd.GetBytes(key);
        }
        private string CreateToken(string message)
        {
            var encoding = new System.Text.ASCIIEncoding();
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(key))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }

        public string returnHMAC(string message)
        {
            return CreateToken(message);
        }

        public string returnCharKey()
        {
            return Convert.ToBase64String(key); ;
        }

        public override void GetBytes(byte[] data)
        {
            rnd.GetBytes(data);
        }
    }
}
