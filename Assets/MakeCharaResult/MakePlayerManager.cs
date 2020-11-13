using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MakeChara;
using AllChara;
using SQLManager;
using System.Linq;

namespace MakeCharaResult{
  

public class MakePlayerManager : MonoBehaviour
{
    string usename;
    PlayerDTO playerDTO;
    MakeCharaResultRepositoryController makeCharaReusultRepositoryController;
    
    void Start()
    {
        makeCharaReusultRepositoryController = this.GetComponent<MakeCharaResultRepositoryController>();
        usename = InputFieldManager.GetName();
        playerDTO = ToggleManager.ifMakePlayer.makePlayer(usename);

        bool numberOK = makeCharaReusultRepositoryController.canAddCharaNumber();
        bool nameOk = makeCharaReusultRepositoryController.canAddCharaName(usename);
        if(!numberOK){
            cannotAddNumbertext();
        }else if(!nameOk){
            cannotAddNametext();
        }else{
            makeCharaReusultRepositoryController.addmyTeamData(playerDTO);
        }


        var message = this.GetComponent<Text>();
        message.text
           = $"名前： {playerDTO.PlayerName}\r\n職業： {playerDTO.JOB.GetStringValue()} \r\nHP  ： {playerDTO.HP}\r\nSTR ： {playerDTO.STR}"+
             $"\r\nDEF ： {playerDTO.DEF}\r\nLUCK： {playerDTO.LUCK}\r\nAGI ： {playerDTO.AGI}"+
             $"\r\nMP  ： {playerDTO.MP}\r\n作成日時  :  {playerDTO.CreateDay}";
    }

    public PlayerDTO getMakePlayer(){
        return playerDTO;
    }
    
    public void cannotAddNametext(){
        GameObject.Find("message").GetComponent<Text>().text
              = "！同名キャラクターは作成できません";
    }

    public void cannotAddNumbertext(){
        GameObject.Find("message").GetComponent<Text>().text
              = "！作成できるキャラクターは20人までです";
    }
}

}