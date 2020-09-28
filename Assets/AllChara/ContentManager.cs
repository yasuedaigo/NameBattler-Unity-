using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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
        string selectQuery = "select playername,job,str,def from status";
        DataTable dataTable = sqlDB.ExecuteQuery(selectQuery);

        string playername;
        string job;
        int str;
        int def;
        for(int i=0; i <this.transform.childCount; i++){
            playername = (string)dataTable.Rows[i]["playername"];
            job = (string)dataTable.Rows[i]["job"];
            str = (int)dataTable.Rows[i]["str"];
            def = (int)dataTable.Rows[i]["def"];

            Buttonlist[i].GetComponentInChildren<Text>().text = playername +"  "+job+" str "+ str +"  def "+def;
        }
        
    }

    
}
