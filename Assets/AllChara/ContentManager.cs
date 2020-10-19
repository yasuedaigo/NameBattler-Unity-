using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SQLManager;

namespace AllChara{

public class ContentManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int charaNum;
    void Start()
    {
        List<GameObject> Buttonlist = new List<GameObject>();
        SQLDate sqlDate = new SQLDate();

        for(int i=0;i < this.transform.childCount; i++){
            Buttonlist.Add(this.transform.GetChild(i).gameObject);
            Buttonlist[i].GetComponentInChildren<Text>().text = i.ToString();
        }

        for(int i=0; i < sqlDate.Rowint; i++){
            SQLPlayer sqlplayer = sqlDate.SQLPlayerList[i];
            Buttonlist[i].GetComponentInChildren<Text>().text = sqlplayer.PlayerName +"  "+sqlplayer.JOB+" str "+ sqlplayer.STR +"  def "+sqlplayer.DEF;
        }
        
    }

    
}

}