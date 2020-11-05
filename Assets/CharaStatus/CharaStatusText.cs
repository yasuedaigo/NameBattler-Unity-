using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using AllChara;
using SQLManager;

namespace CharaStatus
{

public class CharaStatusText : MonoBehaviour
{
    SQLPlayer sqlPlayer;
    
    void Start()
    {

    }

    public void charastatustext(SQLPlayer sqlPlayer){
        string statustext = 
            $"名前： {sqlPlayer.PlayerName}\r\n職業： {sqlPlayer.JOB.ToString()} \r\nHP  ： {sqlPlayer.HP}\r\nSTR ： {sqlPlayer.STR}"+
            $"\r\nDEF ： {sqlPlayer.DEF}\r\nLUCK： {sqlPlayer.LUCK}\r\nAGI ： {sqlPlayer.AGI}\r\nMP  ： {sqlPlayer.MP}\r\n作成日時{sqlPlayer.CreateDay.ToString()}";
        this.GetComponent<Text>().text = statustext;
    }

}

}