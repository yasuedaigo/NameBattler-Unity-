using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SQLManager;
using System.Linq;

namespace AllChara{

public class ContentManager : MonoBehaviour
{
    List<GameObject> Buttonlist;
    SQLLiteRepository sqlliteRepository;
    List<Text> nametextlist;
    List<Text> statustextlist;

    void Start()
    {
        Buttonlist = new List<GameObject>();
        sqlliteRepository = new SQLLiteRepository();
        nametextlist =　new List<Text>();
        statustextlist =　new List<Text>();

        for(int i=0;i < this.transform.childCount; i++){
            Buttonlist.Add(this.transform.GetChild(i).gameObject);
            nametextlist.Add(Buttonlist[i].GetComponentsInChildren<Text>().First());
            statustextlist.Add(Buttonlist[i].GetComponentsInChildren<Text>().Last());
            nametextlist[i].text = i.ToString();
            statustextlist[i].text = "プレイヤーが登録されていません";     
            }
    }

    public void viewContent(List<SQLPlayer> sqlPlayerList){
        for(int i=0; i < sqlPlayerList.Count; i++){
            SQLPlayer sqlplayer = sqlPlayerList[i];
            nametextlist[i].text = $"{sqlplayer.PlayerName}    {sqlplayer.JOB}";
            statustextlist[i].text 
              = $"HP{sqlplayer.HP} STR{sqlplayer.STR} DEF{sqlplayer.DEF}"+
                $" LUCK{sqlplayer.AGI} AGI{sqlplayer.AGI} MP{sqlplayer.MP}";
        }
    }
    
}

}