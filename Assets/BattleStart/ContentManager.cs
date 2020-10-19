using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MakeParty;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SQLManager;

namespace BattleStart
{

public class ContentManager : MonoBehaviour
{
    public GameObject enemypanel;
    public GameObject myteampanel;
    public List<Text> myteamtextlist = new List<Text>();
    public List<Text> enemytextlist = new List<Text>();
    SQLDate sqlDate;
    public static List<int> enemyintlist;

    void Start()
    {
        sqlDate = new SQLDate();
        for(int i=0;i<3;i++){
            myteamtextlist.Add(myteampanel.transform.FindChild(i.ToString()).gameObject.GetComponent<Text>());
            enemytextlist.Add(enemypanel.transform.FindChild(i.ToString()).gameObject.GetComponent<Text>());
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
            myteamtextlist[count].GetComponentInChildren<Text>().text = sqlplayer.PlayerName +"  "+sqlplayer.JOB+" str "+ sqlplayer.STR +"  def "+sqlplayer.DEF;
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
            enemytextlist[count].GetComponentInChildren<Text>().text = sqlplayer.PlayerName +"  "+sqlplayer.JOB+" str "+ sqlplayer.STR +"  def "+sqlplayer.DEF;
            count++;
        }
    }
    

    public void clickBattleStart(){
        SceneManager.LoadScene("MainBattle");
    }
}

}