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
    SQLPlayer player;
    MakeCharaResultSQLController makeCharaReusultSQLController;
    
    void Start()
    {
        makeCharaReusultSQLController = this.GetComponent<MakeCharaResultSQLController>();
        usename = InputFieldManager.GetName();
        player = ToggleManager.getSelectJob().makePlayer(usename);


        var message = this.GetComponent<Text>();
        message.text
           = $"名前： {player.PlayerName}\r\n職業： {player.JOB} \r\nHP  ： {player.HP}\r\nSTR ： {player.STR}"+
             $"\r\nDEF ： {player.DEF}\r\nLUCK： {player.LUCK}\r\nAGI ： {player.AGI}"+
             $"\r\nMP  ： {player.MP}\r\n作成日時  :  {player.CreateDay}";
    }

    public SQLPlayer getMakePlayer(){
        return player;
    }
    
    public void cannotAddNametext(){
        GameObject.Find("message").GetComponent<Text>().text
              = "同名キャラクターは作成できません";
    }

    public void cannotAddNumbertext(){
        GameObject.Find("message").GetComponent<Text>().text
              = "作成できるキャラクターは10人までです";
    }
    
}

}