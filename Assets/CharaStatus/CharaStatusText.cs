using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using AllChara;

namespace CharaStatus
{

public class CharaStatusText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SqliteDatabase sqlDB = new SqliteDatabase("character.db");
        string selectQuery = "select playername,job,hp,str,def,luck,agi,mp from status LIMIT 1 OFFSET "+ContentManager.charaNum.ToString()+"-1";
        DataTable dataTable = sqlDB.ExecuteQuery(selectQuery);

        string playername = (string)dataTable.Rows[0]["playername"];
        string job = (string)dataTable.Rows[0]["job"];
        int hp = (int)dataTable.Rows[0]["hp"];
        int str = (int)dataTable.Rows[0]["str"];
        int def = (int)dataTable.Rows[0]["def"];
        int luck = (int)dataTable.Rows[0]["luck"];
        int agi = (int)dataTable.Rows[0]["agi"];
        int mp = (int)dataTable.Rows[0]["mp"];

        string statustext = "playername    "+playername+"\r\n職業    "+job+"\r\nhp    "+hp+"\r\nstr    "+str+"\r\ndef    "+def+"\r\nluck    "+luck+"\r\nagi    "+agi+"\r\nmp    "+mp;
        this.GetComponent<Text>().text = statustext;
    }

}

}