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
    SQLDate sqlDate;
    public static List<int> enemyintlist;

    void Start()
    {
        sqlDate = new SQLDate();
        for(int i=0;i<3;i++){
            myteampanellist.Add(myteampanel.transform.FindChild(i.ToString()).gameObject);
            enemypanellist.Add(enemypanel.transform.FindChild(i.ToString()).gameObject);
        }
        myteamtext();
        enemytext();
    }

    void myteamtext(){
        int count=0;
        foreach (var playerint in MakePartyBattleStart.playerintlist)
        {
            SQLPlayer sqlplayer = new SQLPlayer();
            sqlplayer = sqlDate.SQLPlayerList[playerint];
            myteampanellist[count].GetComponentsInChildren<Text>().First().text
               = $"{sqlplayer.PlayerName}   {sqlplayer.JOB}";
            myteampanellist[count].GetComponentsInChildren<Text>().Last().text
               = $"HP:{sqlplayer.HP} STR:{sqlplayer.STR} DEF:{sqlplayer.DEF} LUCK:{sqlplayer.LUCK} "+
                 $"AGI:{sqlplayer.AGI} MP:{sqlplayer.MP}";
            count++;
        }
    }

    public void enemytext(){
        List<int> databaseintlist = new List<int>();

        int enemyint;
        enemyintlist = new List<int>();
        for(int i=0; i<3; i++){
            do{
                enemyint = UnityEngine.Random.Range(0,sqlDate.Rowint);
            }while(MakePartyBattleStart.playerintlist.Contains(enemyint) == true || enemyintlist.Contains(enemyint) == true);
            enemyintlist.Add(enemyint);
        }

        int count = 0;
        foreach (var playerint in enemyintlist)
        {
            SQLPlayer sqlplayer = new SQLPlayer();
            sqlplayer = sqlDate.SQLPlayerList[playerint];
            enemypanellist[count].GetComponentsInChildren<Text>().First().text
                =$"{sqlplayer.PlayerName}   {sqlplayer.JOB}";
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