using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using AllChara;

namespace SQLManager
{

public class SQLLiteRepository : IFRepository
{
    public SqliteDatabase sqlDB;

    public DataTable dataTable;

    public SQLLiteRepository(){
        sqlDB = new SqliteDatabase("SQLLite.db");
    }
    
    public DataTable getAllData(SQLController.TableNames table){
        string selectQuery = "select * from "+table;
        dataTable = sqlDB.ExecuteQuery(selectQuery);
        return dataTable;
    }

    public int getRowint(SQLController.TableNames table){
        dataTable = this.getAllData(table);  
        int Rowint = dataTable.Rows.Count;
        return Rowint;
    }

    public List<SQLPlayer> getSQLPlayerList(SQLController.TableNames table){
        List<SQLPlayer> sqlPlayerList = new List<SQLPlayer>();
        DataTable dataTable = this.getAllData(table);
        foreach(DataRow dr in dataTable.Rows){
            SQLPlayer sqlplayer = new SQLPlayer();
            sqlplayer.PlayerName = (string)dr["NAME"];
            int jobint = (int)dr["JOB"];
            sqlplayer.JOB = (SQLPlayer.JOBs)Enum.ToObject(typeof(SQLPlayer.JOBs),jobint);
            sqlplayer.HP = (int)dr["HP"];
            sqlplayer.MP = (int)dr["MP"];
            sqlplayer.STR = (int)dr["STR"];
            sqlplayer.DEF = (int)dr["DEF"];
            sqlplayer.AGI = (int)dr["AGI"];
            sqlplayer.LUCK = (int)dr["LUCK"];
            if(dr["CREATE_AT"] != null){
                sqlplayer.CreateDay = DateTime.Parse((string)dr["CREATE_AT"]);
            }
            sqlPlayerList.Add(sqlplayer);
        }
        return sqlPlayerList;
    }

    public void addData(SQLPlayer player,SQLController.TableNames table){
        string query
           = "insert into "+table.ToString()+" values('"+player.PlayerName+"', "+(int)player.JOB+", "+player.HP+", "+player.MP+","+player.STR+","+player.DEF+","+player.AGI+","+player.LUCK+",'"+player.CreateDay+"')";
        sqlDB.ExecuteNonQuery(query);
    }

    public SQLPlayer getSQLPlayer(string playername,SQLController.TableNames table){
        return this.getSQLPlayerList(table).Find(n => n.PlayerName == playername);
    }

    public SQLPlayer getSQLPlayer(int playerint,SQLController.TableNames table){
        return this.getSQLPlayerList(table)[playerint];
    }

    public void deletePlayer(int rowid,SQLController.TableNames table){
        string query = "delete from "+table.ToString()+" where NAME = (select NAME from "+table.ToString()+" limit 1 offset "+rowid.ToString()+")";
        sqlDB.ExecuteNonQuery(query);
    }

    public bool canAddCharaName(string name){
        bool nameOK = true;
        foreach (var player in getSQLPlayerList(SQLController.TableNames.CHARACTER))
        {
            if(player.PlayerName == name){
                nameOK = false;
            }
        }
        return nameOK;
    }

    public bool canAddCharaNumber(){
        bool numberOK = true;
        if(this.getRowint(SQLController.TableNames.CHARACTER) >= 10){
            numberOK = false;
        }
        return numberOK;
    }
}

}