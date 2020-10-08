using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputFieldManagernamespace;
using Togglejob;
using System.Security.Cryptography;
using System.Text;
using System;


public class MakeCharaDate : MonoBehaviour
{
    public string usename;

    public string job;

    int Hp;
    
    int STR;

    int DEF;

    int LUCK;

    int AGI;

    int MP;

    public string hashname;

    // Start is called before the first frame update
    void Start()
    {
        usename = InputFieldManager.GetName();
        job = ToggleManager.Gettgljob();
        hashname = GetHash(usename);
        Debug.Log(MakeStatusInt(0,200));

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public int MakeStatusInt(int index,int max){
        string hex = hashname.Substring(index*2,2);
        int val = int.Parse(hex,System.Globalization.NumberStyles.HexNumber);
        return val * max / 255;
    }

}
