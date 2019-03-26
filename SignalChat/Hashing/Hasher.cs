using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Hashing
{
    class Hasher
    {
        private static SHA256CryptoServiceProvider csp = new SHA256CryptoServiceProvider();

        public static byte[] hashText(string plainText)
        {
            var data = Encoding.Unicode.GetBytes(plainText);
            return csp.ComputeHash(data);
        }

        public static byte[] hashBytes(byte[] bytes)
        {
            return csp.ComputeHash(bytes);
        }
    }
}
