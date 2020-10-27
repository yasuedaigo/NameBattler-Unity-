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
    SQLDate sqlDate;
    SQLPlayer sqlPlayer;
    // Start is called before the first frame update
    void Start()
    {
        sqlDate = new SQLDate();
        sqlPlayer = new SQLPlayer();
        sqlPlayer = sqlDate.SQLPlayerList[ContentManager.charaNum];

        string statustext = 
            $"名前： {sqlPlayer.PlayerName}\r\n職業： {sqlPlayer.JOB} \r\nHP  ： {sqlPlayer.HP}\r\nSTR ： {sqlPlayer.STR}"+
            $"\r\nDEF ： {sqlPlayer.DEF}\r\nLUCK： {sqlPlayer.LUCK}\r\nAGI ： {sqlPlayer.AGI}\r\nMP  ： {sqlPlayer.MP}";
        this.GetComponent<Text>().text = statustext;
    }

}

}