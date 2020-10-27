using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MakeCharaResult;


namespace SQLManager
{

public class SQLDate
{
    public SqliteDatabase sqlDB;
    public DataTable newdataTable;
    public int Rowint { get; set;}
    public List<SQLPlayer> SQLPlayerList = new List<SQLPlayer>();

    public SQLDate(){
        sqlDB = new SqliteDatabase("character.db");
        string selectQuery = "select playername,job,hp,str,def,luck,agi,mp from status";
        newdataTable = sqlDB.ExecuteQuery(selectQuery);
        Rowint = newdataTable.Rows.Count;

        for(int i=0; i < Rowint; i++){
            SQLPlayer sqlplayer = new SQLPlayer();
            sqlplayer.PlayerName = (string)newdataTable.Rows[i]["playername"];
            sqlplayer.JOB = (string)newdataTable.Rows[i]["job"];
            sqlplayer.HP = (int)newdataTable.Rows[i]["hp"];
            sqlplayer.STR = (int)newdataTable.Rows[i]["str"];
            sqlplayer.DEF = (int)newdataTable.Rows[i]["def"];
            sqlplayer.LUCK = (int)newdataTable.Rows[i]["luck"];
            sqlplayer.AGI = (int)newdataTable.Rows[i]["agi"];
            sqlplayer.MP = (int)newdataTable.Rows[i]["mp"];
            SQLPlayerList.Add(sqlplayer);
        }
    }

    public void addDate(JobPlayer player){
        string query
           = "insert into status values('"+player.PlayerName+"', '"+player.JOB+"', "+player.HP+", "+player.STR+","+player.DEF+","+player.LUCK+","+player.AGI+","+player.MP+")";
        sqlDB.ExecuteNonQuery(query);
    }

    public SQLPlayer getSQLPlayer(string playername){
        return SQLPlayerList.Find(n => n.PlayerName == playername);
    }

    public SQLPlayer getSQLPlayer(int playerint){
        return SQLPlayerList[playerint];
    }

}

}
