using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BattleScene.Chara;

namespace BattleScene{

public class TextManager : MonoBehaviour
{
    public Text targettext;

    void Start(){
        targettext = GameObject.Find("battletext").GetComponent<Text>();
        targettext.text = "OK";
    }

    public void battleLog(object message){
        targettext.text = targettext.text.ToString()+"\r\n" + message;
    }

    public void gameFinish(){}
}

}
