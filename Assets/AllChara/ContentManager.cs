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
    // Start is called before the first frame update
    public static int charaNum;
    void Start()
    {
        List<GameObject> Buttonlist = new List<GameObject>();
        SQLDate sqlDate = new SQLDate();
        List<Text> nametextlist =　new List<Text>();
        List<Text> statustextlist =　new List<Text>();

        for(int i=0;i < this.transform.childCount; i++){
            Buttonlist.Add(this.transform.GetChild(i).gameObject);
            nametextlist.Add(Buttonlist[i].GetComponentsInChildren<Text>().First());
            statustextlist.Add(Buttonlist[i].GetComponentsInChildren<Text>().Last());
            nametextlist[i].text = i.ToString();
        }

        for(int i=0; i < sqlDate.Rowint; i++){
            SQLPlayer sqlplayer = sqlDate.SQLPlayerList[i];
            nametextlist[i].text = $"{sqlplayer.PlayerName}    {sqlplayer.JOB}";
            statustextlist[i].text 
              = $"HP{sqlplayer.HP} STR{sqlplayer.STR} DEF{sqlplayer.DEF}"+
                $" LUCK{sqlplayer.AGI} AGI{sqlplayer.AGI} MP{sqlplayer.MP}";
        }
        
    }

    
}

}