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
    JobPlayer player;
    int rowint;
    SQLDate sqlDate;
    // Start is called before the first frame update
    void Start()
    {
        sqlDate = new SQLDate();
        usename = InputFieldManager.GetName();
        player = ToggleManager.getSelectJob().makePlayer(usename);
        player.PlayerName = usename;

        var message = this.GetComponent<Text>();
        message.text
           = $"名前： {player.PlayerName}\r\n職業： {player.JOB} \r\nHP  ： {player.HP}\r\nSTR ： {player.STR}"+
             $"\r\nDEF ： {player.DEF}\r\nLUCK： {player.LUCK}\r\nAGI ： {player.AGI}\r\nMP  ： {player.MP}";
    }

    
    public void OnClickAddButton()
    {   
        bool nameIsUsed = false;
        foreach (var sqlPlayer in sqlDate.SQLPlayerList)
        {
            if(sqlPlayer.PlayerName == player.PlayerName){
                nameIsUsed = true;
            }else{
                nameIsUsed = false;
            }
        }

        if(nameIsUsed == true){
            GameObject.Find("message").GetComponent<Text>().text
              = "同名キャラクターは作成できません";
        }else if(sqlDate.Rowint >= 10){
            GameObject.Find("message").GetComponent<Text>().text
              = "作成できるキャラクターは10人までです";
        }else{
            sqlDate.addDate(player);
            SceneManager.LoadScene("MakeChara");
        }
    }
}

}