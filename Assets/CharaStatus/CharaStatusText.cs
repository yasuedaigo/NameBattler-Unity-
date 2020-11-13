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
    CharaStatusRepositoryController charaStatusRepositoryController;
    PlayerDTO textchara;
    
    void Start()
    {
        charaStatusRepositoryController = GameObject.Find("CharaStatusText").GetComponent<CharaStatusRepositoryController>();
        if(AllChara.ContentManager.charaNum <= charaStatusRepositoryController.getmyTeamRowint()-1){
            textchara = charaStatusRepositoryController.getmyTeamPlayerDTO(AllChara.ContentManager.charaNum);
            charastatustext(textchara);
        }
    }

    public void charastatustext(PlayerDTO playerDTO){
        string statustext = 
            $"名前： {playerDTO.PlayerName}\r\n職業： {playerDTO.JOB.GetStringValue()} \r\nHP  ： {playerDTO.HP}\r\nSTR ： {playerDTO.STR}"+
            $"\r\nDEF ： {playerDTO.DEF}\r\nLUCK： {playerDTO.LUCK}\r\nAGI ： {playerDTO.AGI}\r\nMP  ： {playerDTO.MP}\r\n作成日時{playerDTO.CreateDay.ToString()}";
        this.GetComponent<Text>().text = statustext;
    }

}

}