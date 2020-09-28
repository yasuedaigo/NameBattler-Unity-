using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputFieldManagernamespace;
using Togglejob;
using System.Security.Cryptography;
using System.Text;
using System;

namespace Job
{

public class Player : MonoBehaviour
{
    protected string PlayerName;
    
    public string playername
    {
        set{PlayerName = value;}
        get{return PlayerName;}
    }

    protected string Job;
    
    public string job
    {
        set{Job = value;}
        get{return Job;}
    }
    
    protected int Hp;
    
    public int hp
    {
        set{Hp = value;}
        get{return Hp;}
    }

    protected int STR;
    
    public int str
    {
        set{STR = value;}
        get{return STR;}
    }

    protected int DEF;
    
    public int def
    {
        set{DEF = value;}
        get{return DEF;}
    }

    protected int LUCK;
    
    public int luck
    {
        set{LUCK = value;}
        get{return LUCK;}
    }

    protected int AGI;
    
    public int agi
    {
        set{AGI = value;}
        get{return AGI;}
    }

    protected int MP;
    
    public int mp
    {
        set{MP = value;}
        get{return MP;}
    }

    protected string ABNORMALITY;
    
    public string abnormality
    {
        set{ABNORMALITY = value;}
        get{return ABNORMALITY;}
    }

    protected int TEAM;
    
    public int team
    {
        set{TEAM = value;}
        get{return TEAM;}
    }

    public void MakeCharacter(string usename){

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
