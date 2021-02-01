using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HLDCoreAPI
{
    public static class StringCipher
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string[] Base64DecodeValueInArray(string Data)
        {
            if (!string.IsNullOrEmpty(Data))
            {
                try
                {
                    return Base64Decode(Data).Split('|');
                }
                catch
                {

                }
                return Data.Split('|');
            }

            return new string[] { };

        }

        public static string[] GetValueInArray(string Data)
        {
            if (!string.IsNullOrEmpty(Data))
            {
                try
                {
                    return Data.Split('|');
                }
                catch
                {

                }
            }
            return new string[] { };
        }
    }
}