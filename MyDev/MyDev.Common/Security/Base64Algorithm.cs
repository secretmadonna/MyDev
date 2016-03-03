using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Common.Security
{
    public class Base64Algorithm
    {
        private const string code = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
        public static string Encrypt(string plainStr)
        {
            var plainByteList = Encoding.Default.GetBytes(plainStr).ToList();

            var groupCount = plainByteList.Count / 3;
            var remainCount = plainByteList.Count % 3;

            var emptyByte = (byte)0;

            if (remainCount > 0)
            {
                groupCount++;
                for (int i = 0; i < 3 - remainCount; i++)
                {
                    plainByteList.Add(emptyByte);
                }
            }

            var result = new StringBuilder(groupCount * 4);
            for (int i = 0; i < groupCount; i++)
            {
                var ThreeByte = new byte[3] { plainByteList[i * 3], plainByteList[i * 3 + 1], plainByteList[i * 3 + 2] };

                var FourInt = new int[4];
                FourInt[0] = ThreeByte[0] >> 2;
                FourInt[1] = ((ThreeByte[0] & 0x03) << 4) ^ (ThreeByte[1] >> 4);
                if (ThreeByte[1].Equals(emptyByte))
                {
                    FourInt[2] = 64;
                }
                else
                {
                    FourInt[2] = ((ThreeByte[1] & 0x0f) << 2) ^ (ThreeByte[2] >> 6);
                }
                if (ThreeByte[2].Equals(emptyByte))
                {
                    FourInt[3] = 64;
                }
                else
                {
                    FourInt[3] = (ThreeByte[2] & 0x3f);
                }
                result.Append(code[FourInt[0]]);
                result.Append(code[FourInt[1]]);
                result.Append(code[FourInt[2]]);
                result.Append(code[FourInt[3]]);
            }
            return result.ToString();
        }

        public static string Decrypt(string encryptStr)
        {
            var result = new List<byte>();

            var encryptCharArray = encryptStr.ToCharArray();
            var groupCount = encryptStr.Length / 4;
            for (int i = 0; i < groupCount; i++)
            {
                var FourByte = new byte[4] {
                    (byte)code.IndexOf(encryptCharArray[i * 4]),
                    (byte)code.IndexOf(encryptCharArray[i * 4 + 1]),
                    (byte)code.IndexOf(encryptCharArray[i * 4 + 2]),
                    (byte)code.IndexOf(encryptCharArray[i * 4 + 3])
                };

                var ThreeByte = new byte[3];
                ThreeByte[0] = (byte)((FourByte[0] << 2) ^ ((FourByte[1] & 0x30) >> 4));
                if (FourByte[2] == 64)
                {
                    ThreeByte[2] = 0;
                }
                else
                {
                    ThreeByte[1] = (byte)((FourByte[1] << 4) ^ ((FourByte[2] & 0x3c) >> 2));
                }
                if (FourByte[3] == 64)
                {
                    ThreeByte[2] = 0;
                }
                else
                {
                    ThreeByte[2] = (byte)((FourByte[2] << 6) ^ FourByte[3]);
                }

                result.Add(ThreeByte[0]);
                if (ThreeByte[1] != 0)
                {
                    result.Add(ThreeByte[1]);
                }
                if (ThreeByte[2] != 0)
                {
                    result.Add(ThreeByte[2]);
                }
            }
            return Encoding.Default.GetString(result.ToArray());
        }
    }
}
