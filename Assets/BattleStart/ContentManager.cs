using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MakeParty;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SQLManager;
using System.Linq;

namespace BattleStart
{

public class ContentManager : MonoBehaviour
{
    public GameObject enemypanel;
    public GameObject myteampanel;
    public List<GameObject> myteampanellist = new List<GameObject>();
    public List<GameObject> enemypanellist= new List<GameObject>();
    SQLController sqlController;
    public static List<int> enemyintlist;

    void Start()
    {
        sqlController = new SQLController();
        for(int i=0;i<3;i++){
            myteampanellist.Add(myteampanel.transform.FindChild(i.ToString()).gameObject);
            enemypanellist.Add(enemypanel.transform.FindChild(i.ToString()).gameObject);
        }
    }

    public void myteamtext(List<SQLPlayer> sqlplayerlist){
        int count=0;
        foreach (SQLPlayer sqlplayer in sqlplayerlist)
        {
            myteampanellist[count].GetComponentsInChildren<Text>().First().text
               = $"{sqlplayer.PlayerName}   {sqlplayer.JOB.ToString()}";
            myteampanellist[count].GetComponentsInChildren<Text>().Last().text
               = $"HP:{sqlplayer.HP} STR:{sqlplayer.STR} DEF:{sqlplayer.DEF} LUCK:{sqlplayer.LUCK} "+
                 $"AGI:{sqlplayer.AGI} MP:{sqlplayer.MP}";
            count++;
        }
    }

    public void enemytext(List<SQLPlayer> sqlPlayerList){
        int count = 0;
        foreach (var sqlplayer in sqlPlayerList)
        {
            enemypanellist[count].GetComponentsInChildren<Text>().First().text
                =$"{sqlplayer.PlayerName}   {sqlplayer.JOB.ToString()}";
            enemypanellist[count].GetComponentsInChildren<Text>().Last().text
                =$"HP:{sqlplayer.HP} STR:{sqlplayer.STR} DEF:{sqlplayer.DEF} "+
                $"LUCK:{sqlplayer.LUCK} AGI{sqlplayer.AGI} MP:{sqlplayer.MP}";
            count++;
        }
    }
    

    public void clickBattleStart(){
        SceneManager.LoadScene("MainBattle");
    }
}

}