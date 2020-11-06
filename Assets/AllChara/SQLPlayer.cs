using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System;

namespace SQLManager
{

public class SQLPlayer
{
    public enum Profiles {Name,JOB,HP,MP,STR,DEF,AGI,LUCK,CREATE_AT}

    public enum JOBs {戦士,魔法使い,僧侶,忍者}

    public string PlayerName { get; set; }

    public JOBs JOB { get; set; }

    public int JOBInt { get; set; }
    
    public int HP { get; set; }
    
    public int STR { get; set; }
    
    public int DEF { get; set; }
    
    public int LUCK { get; set; }

    public int AGI { get; set; }

    public int MP { get; set; }

    public DateTime CreateDay { get; set; }

    string GetHash(string name){
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
            for (i=0;i < arrInput.Length -1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }

    public int MakeStatusInt(int index,int max,string name){
        byte[] tmpSource;
        byte[] tmpHash;
        tmpSource = ASCIIEncoding.ASCII.GetBytes(name);
        tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
        string hashname = ByteArrayToString(tmpHash);
        string hex = hashname.Substring(index*2,2);
        int val = int.Parse(hex,System.Globalization.NumberStyles.HexNumber);
        return val * max / 255;
    }

}

}
