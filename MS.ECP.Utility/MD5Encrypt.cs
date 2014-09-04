using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace MS.ECP.Utility
{
    public class MD5Encrypt
    {
        public static string Encrypt(string pwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            UTF8Encoding utf = new UTF8Encoding();
            byte[] pwd1 = utf.GetBytes(pwd);
            byte[] pwd2 = md5.ComputeHash(pwd1);
            return BitConverter.ToString(pwd2);
        }
    }
}
