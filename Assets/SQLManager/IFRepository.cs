using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLManager;
using AllChara;

namespace SQLManager{

public interface IFRepository
{
    DataTable getAllData(SQLController.TableNames table);

    int getRowint(SQLController.TableNames table);

    List<SQLPlayer> getSQLPlayerList(SQLController.TableNames table);

    void addData(SQLPlayer player,SQLController.TableNames table);

    SQLPlayer getSQLPlayer(string playername,SQLController.TableNames table);

    SQLPlayer getSQLPlayer(int playerint,SQLController.TableNames table);

    void deletePlayer(int rowid,SQLController.TableNames table);

    bool canAddCharaName(string name);

    bool canAddCharaNumber();
}

}
