using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Common.Security
{
    public class HashAlgorithm
    {
        public static string Encrypt(string plainText, HashWay way,Encoding encoding, bool toBase64 = true)
        {
            string cipherText = string.Empty;
            var plainTextBytes = encoding.GetBytes(plainText);
            switch (way)
            {
                case HashWay.md5:
                    using (var hash = System.Security.Cryptography.HashAlgorithm.Create("MD5"))
                    { 
                        var tempBytes = hash.ComputeHash(plainTextBytes);
                        var sb = new StringBuilder();
                        foreach (var item in tempBytes)
                        {
                            sb.Append(item.ToString("x").PadLeft(2, '0'));
                        }
                        cipherText = sb.ToString();
                    }
                    break;
                case HashWay.sha1:
                    using (var hash = System.Security.Cryptography.HashAlgorithm.Create("SHA1"))
                    {
                        var tempBytes = hash.ComputeHash(plainTextBytes);
                        if (toBase64)
                        {
                            cipherText = Convert.ToBase64String(tempBytes);
                        }
                        else
                        {
                            cipherText = BitConverter.ToString(tempBytes).Replace("-", "");
                        }
                    }
                    break;
                case HashWay.sha256:
                    using (var hash = System.Security.Cryptography.HashAlgorithm.Create("SHA256"))
                    {
                        var tempBytes = hash.ComputeHash(plainTextBytes);
                        if (toBase64)
                        {
                            cipherText = Convert.ToBase64String(tempBytes);
                        }
                        else
                        {
                            cipherText = BitConverter.ToString(tempBytes).Replace("-", "");
                        }
                    }
                    break;
                case HashWay.sha384:
                    using (var hash = System.Security.Cryptography.HashAlgorithm.Create("SHA384"))
                    {
                        var tempBytes = hash.ComputeHash(plainTextBytes);
                        if (toBase64)
                        {
                            cipherText = Convert.ToBase64String(tempBytes);
                        }
                        else
                        {
                            cipherText = BitConverter.ToString(tempBytes).Replace("-", "");
                        }
                    }
                    break;
                case HashWay.sha512:
                    using (var hash = System.Security.Cryptography.HashAlgorithm.Create("SHA512"))
                    {
                        var tempBytes = hash.ComputeHash(plainTextBytes);
                        if (toBase64)
                        {
                            cipherText = Convert.ToBase64String(tempBytes);
                        }
                        else
                        {
                            cipherText = BitConverter.ToString(tempBytes).Replace("-", "");
                        }
                    }
                    break;
                default:
                    cipherText = string.Empty;
                    break;
            }
            return cipherText;
        }
    }
}
