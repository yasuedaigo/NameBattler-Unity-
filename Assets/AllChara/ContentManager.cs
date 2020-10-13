﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace AllChara{

public class ContentManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int charaNum;
    void Start()
    {
        List<GameObject> Buttonlist = new List<GameObject>();
        
        for(int i=0;i < this.transform.childCount; i++){
            Buttonlist.Add(this.transform.GetChild(i).gameObject);
            Buttonlist[i].GetComponentInChildren<Text>().text = i.ToString();
        }

        SqliteDatabase sqlDB = new SqliteDatabase("character.db");
        string getintRowQuery = "select count(*) from status";
        DataTable dataTable = sqlDB.ExecuteQuery(getintRowQuery);
        int rowint = (int)dataTable.Rows[0]["count(*)"];
        Debug.Log(rowint);

        string selectQuery = "select playername,job,str,def from status";
        DataTable newdataTable = sqlDB.ExecuteQuery(selectQuery);

        string playername;
        string job;
        int str;
        int def;
        for(int i=0; i < rowint; i++){
            playername = (string)newdataTable.Rows[i]["playername"];
            job = (string)newdataTable.Rows[i]["job"];
            str = (int)newdataTable.Rows[i]["str"];
            def = (int)newdataTable.Rows[i]["def"];

            Buttonlist[i].GetComponentInChildren<Text>().text = playername +"  "+job+" str "+ str +"  def "+def;
        }
        
    }

    
}

}