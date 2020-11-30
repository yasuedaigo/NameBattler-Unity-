using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using SQLManager;
using UnityEngine;

namespace MakeCharaResult
{
    public abstract class BasePlayerMaker : IPlayerMaker
    {
        public abstract PlayerDTO makePlayer(string usename);

        public string GetHash(string name)
        {
            byte[] tmpSource;
            byte[] tmpHash;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(name);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            return ByteArrayToString(tmpHash);
        }

        public string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }

        public int MakeStatusInt(int index, int max, string name)
        {
            byte[] tmpSource;
            byte[] tmpHash;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(name);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            string hashname = ByteArrayToString(tmpHash);
            string hex = hashname.Substring(index * 2, 2);
            int val =
                int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            return val * max / 255;
        }
    }
}
