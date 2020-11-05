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


public class MakeCharaResultSQLController : MonoBehaviour
{
    MakePlayerManager makePlayerManager;
    SQLController sqlController;
    void Start()
    {
        makePlayerManager = this.GetComponent<MakePlayerManager>();
        sqlController = new SQLController();
    }

    public void OnClickAddButton()
    {   
        SQLPlayer player = makePlayerManager.getMakePlayer();
        bool nameOK = sqlController.canAddCharaName(player.PlayerName);
        bool numberOK = sqlController.canAddCharaNumber();
        if(!nameOK){
            makePlayerManager.cannotAddNametext();
        }else if(!numberOK){
            makePlayerManager.cannotAddNumbertext();
        }else{
            sqlController.addData(player,SQLController.TableNames.CHARACTER);
            SceneManager.LoadScene("MakeChara");
        }
    }
}

}
