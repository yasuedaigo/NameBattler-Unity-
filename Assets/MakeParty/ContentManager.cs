using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MakeParty{

public class ContentManager : MonoBehaviour
{
    public static List<GameObject> togglelist = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i < this.transform.childCount; i++){
            togglelist.Add(this.transform.GetChild(i).gameobject);
            togglelist[i].GetComponentInChildren<Text>().text = i.ToString();
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

            togglelist[i].GetComponentInChildren<Text>().text = playername +"  "+job+" str "+ str +"  def "+def;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

}
