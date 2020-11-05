using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using SQLManager;
using UnityEngine.SceneManagement;

namespace MakeParty{

public class ContentManager : MonoBehaviour
{
    public static List<int> playerintlist = new List<int>();
    public List<Toggle> togglelist = new List<Toggle>();
    public Text messagetext;
    public List<GameObject> objectlist = new List<GameObject>();
    List<Text> nametextlist = new List<Text>();
    List<Text> statustextlist = new List<Text>();
    List<Text> jobtextlist = new List<Text>();
    MakePartySQLController makePartySQLController;
    SQLController sqlController;
    
    void Start()
    {
        sqlController = new SQLController();
        makePartySQLController = GameObject.Find("Content").GetComponent<MakePartySQLController>();
        for(int i=0;i < this.transform.childCount; i++){
            objectlist.Add(this.transform.GetChild(i).gameObject);
            nametextlist.Add(objectlist[i].GetComponentsInChildren<Text>().First());
            statustextlist.Add(objectlist[i].GetComponentsInChildren<Text>().Last());
            nametextlist[i].text = i.ToString();
        }

        foreach (var toggleobject in objectlist)
        {
            togglelist.Add(toggleobject.GetComponent<Toggle>());
        }
    }

    public void contentText(List<SQLPlayer> sqlPlayerList){
        for(int i=0; i < sqlPlayerList.Count; i++){
            SQLPlayer sqlplayer = new SQLPlayer();
            sqlplayer = sqlPlayerList[i];
            nametextlist[i].text = sqlplayer.PlayerName;
            statustextlist[i].text = 
             $"{sqlplayer.JOB.ToString()} HP:{sqlplayer.HP} STR:{sqlplayer.STR} DEF:{sqlplayer.DEF}"+
             $"AGI:{sqlplayer.AGI} LUCK:{sqlplayer.LUCK} MP:{sqlplayer.MP}";
        }
    }

    public void pushBattleStart(){
        playerintlist.Clear();
        int SQLCharaNum = sqlController.getRowint(SQLController.TableNames.CHARACTER);

        foreach (var playertoggle in togglelist)
        {
            if(playertoggle.isOn && int.Parse(playertoggle.name) < SQLCharaNum){
                playerintlist.Add(int.Parse(playertoggle.name));
            }
        }
        if(playerintlist.Count != 3){
            messagetext.text = "プレイヤーが"+playerintlist.Count+"人選ばれています。パーティ人数は３人です";
        }else{
            SceneManager.LoadScene("BattleStart");
        }
    }

}

}
