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
    public static List<int> enemyintlist;
    public BattleStartRepositoryManager battleStartRepositoryManager;

    void Start()
    {
        battleStartRepositoryManager = GameObject.Find("Canvas").GetComponent<BattleStartRepositoryManager>();
        for(int i=0;i<3;i++){
            myteampanellist.Add(myteampanel.transform.FindChild(i.ToString()).gameObject);
            enemypanellist.Add(enemypanel.transform.FindChild(i.ToString()).gameObject);
        }
        List<PlayerDTO> enemyPlayerDTOList = battleStartRepositoryManager.makeEnemyDTOList();
        List<PlayerDTO> myteamPlayerDTOList =　battleStartRepositoryManager.makemyTeamDTOList(MakeParty.ContentManager.playerintlist);
        myteamtext(myteamPlayerDTOList);
        enemytext(enemyPlayerDTOList);
    }

    public void myteamtext(List<PlayerDTO> playerDTOlist){
        int count=0;
        foreach (PlayerDTO playerDTO in playerDTOlist)
        {
            myteampanellist[count].GetComponentsInChildren<Text>().First().text
               = $"{playerDTO.PlayerName}   {playerDTO.JOB.GetStringValue()}";
            myteampanellist[count].GetComponentsInChildren<Text>().Last().text
               = $"HP:{playerDTO.HP} STR:{playerDTO.STR} DEF:{playerDTO.DEF} LUCK:{playerDTO.LUCK} "+
                 $"AGI:{playerDTO.AGI} MP:{playerDTO.MP}";
            count++;
        }
    }

    public void enemytext(List<PlayerDTO> playerDTOList){
        int count = 0;
        foreach (var playerDTO in playerDTOList)
        {
            enemypanellist[count].GetComponentsInChildren<Text>().First().text
                =$"{playerDTO.PlayerName}   {playerDTO.JOB.GetStringValue()}";
            enemypanellist[count].GetComponentsInChildren<Text>().Last().text
                =$"HP:{playerDTO.HP} STR:{playerDTO.STR} DEF:{playerDTO.DEF} "+
                $"LUCK:{playerDTO.LUCK} AGI{playerDTO.AGI} MP:{playerDTO.MP}";
            count++;
        }
    }
    
    public void clickRetake(){
        List<PlayerDTO> enemyPlayerDTOList = battleStartRepositoryManager.makeEnemyDTOList();
        enemytext(enemyPlayerDTOList);
    }

    public void clickBattleStart(){
        SceneManager.LoadScene("MainBattle");
    }
}

}