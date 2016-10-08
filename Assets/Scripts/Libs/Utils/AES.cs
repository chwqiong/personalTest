using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace Utils
{
    class AES
    {
        private static byte[] AES_KEY = UTF8Encoding.UTF8.GetBytes("I amVeryHandsome");
        private static byte[] AES_IV = UTF8Encoding.UTF8.GetBytes("Y'reVeryHandsome");

        #region encrypt
        /**
         * AES Encrypt, fast, security
         * 
         * toEncrypt: encrypt value
         * key: encrypt key
         **/
        public static byte[] Encrypt(byte[] toEncrypt)
        {
            using (RijndaelManaged crypto = new RijndaelManaged())
            {
                crypto.BlockSize = 128;
                crypto.Key = AES_KEY;
                crypto.IV = AES_IV;
                crypto.Mode = CipherMode.ECB;
                crypto.Padding = PaddingMode.Zeros;

                ICryptoTransform encryptor = crypto.CreateEncryptor(crypto.Key, crypto.IV);
                Debug.Log("Encrypt: " + Convert.ToBase64String(toEncrypt, 0, toEncrypt.Length));
                byte[] resultArray = encryptor.TransformFinalBlock(toEncrypt, 0, toEncrypt.Length);
                Debug.Log("Encrypt end...");
                return resultArray;
            }
            // return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        #endregion

        #region decrypt
        /**
         * AES Decrypt
         *
         * toDecrypt: decrypt value
         * key: decrypt key
         **/
        public static byte[] Decrypt(byte[] toDecrypt)
        {
            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = AES_KEY;
            rDel.IV = AES_IV;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.Zeros;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toDecrypt, 0, toDecrypt.Length);

            return resultArray;
            // return UTF8Encoding.UTF8.GetString(resultArray);
        }
        #endregion
    }
}
