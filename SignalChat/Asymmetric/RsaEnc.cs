using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace Asymmetric
{
    class RsaEnc
    {
        private static RSACryptoServiceProvider csp=new RSACryptoServiceProvider(2048);
        private RSAParameters _privateKey;
        private RSAParameters _publicKey;

        public RsaEnc()
        {
            _privateKey = csp.ExportParameters(true);
            _publicKey = csp.ExportParameters(false);
        }

        public string getPublicKeyString()
        {
            var stringWriter = new StringWriter();
            var xmlSerializer = new XmlSerializer(typeof(RSAParameters));
            xmlSerializer.Serialize(stringWriter,_publicKey);
            return stringWriter.ToString();
        }

        public string getPrivateKeyString()
        {
            var stringWriter = new StringWriter();
            var xmlSerializer = new XmlSerializer(typeof(RSAParameters));
            xmlSerializer.Serialize(stringWriter, _privateKey);
            return stringWriter.ToString();
        }

        public string Encrypt(string plainText)
        {
            csp=new RSACryptoServiceProvider();
            csp.ImportParameters(_publicKey);

            var data = Encoding.Unicode.GetBytes(plainText);
            var cypher = csp.Encrypt(data, false);
            return Convert.ToBase64String(cypher);
        }

        public string Decrypt(string cypherText)
        {
            var dataBytes = Convert.FromBase64String(cypherText);
            csp.ImportParameters(_privateKey);
            var plainText = csp.Decrypt(dataBytes, false);
            return Encoding.Unicode.GetString(plainText);
        }
    }
}
