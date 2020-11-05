using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MakeParty;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SQLManager;
using System.Linq;
using AllChara;

namespace BattleStart{

public class BattleStartSQLManager : MonoBehaviour
{
    ContentManager contentManager;
    SQLController sqlController;
    public static List<SQLPlayer> enemyPlayerList;
    public static List<SQLPlayer> myteamPlayerList;

    void Start()
    {
        enemyPlayerList = new List<SQLPlayer>();
        myteamPlayerList = new List<SQLPlayer>();
        contentManager = GameObject.Find("Canvas").GetComponent<ContentManager>();
        sqlController = new SQLController();
        
        foreach(int playerint in  MakeParty.ContentManager.playerintlist)
        {
            SQLPlayer sqlplayer = sqlController.getSQLPlayer(playerint,SQLController.TableNames.CHARACTER);
            myteamPlayerList.Add(sqlplayer);
        }
        
        contentManager.myteamtext(myteamPlayerList);
        contentManager.enemytext(this.makeEnemyList());
    }
    
    public void clickRetake(){
        contentManager.enemytext(makeEnemyList());
    }
    
    public List<SQLPlayer> makeEnemyList(){
        enemyPlayerList = new List<SQLPlayer>();
        int enemyint;
        List<int> enemyintlist = new List<int>();
        for(int i=0; i<3; i++){
            do{
                enemyint = UnityEngine.Random.Range(0,sqlController.getRowint(SQLController.TableNames.ENEMY));
            }while(enemyintlist.Contains(enemyint));
            enemyintlist.Add(enemyint);
        }
        foreach(int num in enemyintlist){
            SQLPlayer sqlplayer = sqlController.getSQLPlayer(num,SQLController.TableNames.ENEMY);
            enemyPlayerList.Add(sqlplayer);
        }
        return enemyPlayerList;
    }
}

}