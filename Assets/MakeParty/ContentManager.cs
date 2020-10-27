using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using SQLManager;

namespace MakeParty{

public class ContentManager : MonoBehaviour
{
    public List<GameObject> objectlist = new List<GameObject>();
    List<Text> nametextlist = new List<Text>();
    List<Text> statustextlist = new List<Text>();
    List<Text> jobtextlist = new List<Text>();
    SQLDate sqlDate;
    // Start is called before the first frame update
    void Start()
    {
        sqlDate = new SQLDate();
        for(int i=0;i < this.transform.childCount; i++){
            objectlist.Add(this.transform.GetChild(i).gameObject);
            nametextlist.Add(objectlist[i].GetComponentsInChildren<Text>().First());
            statustextlist.Add(objectlist[i].GetComponentsInChildren<Text>().Last());
            nametextlist[i].text = i.ToString();
        }

        for(int i=0; i < sqlDate.Rowint; i++){
            SQLPlayer sqlplayer = new SQLPlayer();
            sqlplayer = sqlDate.SQLPlayerList[i];
            nametextlist[i].text = sqlplayer.PlayerName;
            statustextlist[i].text = 
             $"{sqlplayer.JOB} HP:{sqlplayer.HP} STR:{sqlplayer.STR} DEF:{sqlplayer.DEF}"+
             $"AGI:{sqlplayer.AGI} LUCK:{sqlplayer.LUCK} MP:{sqlplayer.MP}";
        }
    }

}

}
