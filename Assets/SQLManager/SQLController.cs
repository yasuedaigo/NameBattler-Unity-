using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SQLManager
{

public class SQLController 
{
    SQLLiteRepository sqlLiteRepository;

    public enum TableNames {CHARACTER,ENEMY}

    public IFRepository sqliteRepository = new SQLLiteRepository();

    public SQLController(){
        sqlLiteRepository = new SQLLiteRepository();
    }

    public DataTable getAllData(TableNames table){
        return sqlLiteRepository.getAllData(table);
    }

    public int getRowint(TableNames table){
        return sqlLiteRepository.getRowint(table);
    }

    public List<SQLPlayer> getSQLPlayerList(TableNames table){
        return sqlLiteRepository.getSQLPlayerList(table);
    }

    public void addData(SQLPlayer player,TableNames table){
        sqlLiteRepository.addData(player,table);
    }

    public SQLPlayer getSQLPlayer(string playername,TableNames table){
        return sqlLiteRepository.getSQLPlayer(playername,table);
    }

    public SQLPlayer getSQLPlayer(int playerint,TableNames table){
        return sqlLiteRepository.getSQLPlayer(playerint,table);
    }

    public void deletePlayer(int rowid,TableNames table){
        sqlLiteRepository.deletePlayer(rowid,table);
    }

    public bool canAddCharaName(string name){
        return sqlLiteRepository.canAddCharaName(name);
    }

    public bool canAddCharaNumber(){
        return sqlLiteRepository.canAddCharaNumber();
    }
}

}