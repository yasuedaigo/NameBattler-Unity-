using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


namespace AllChara{

public class AllCharaCharaStatus : MonoBehaviour
{
    public void OnClickButton()
{
    string charaNumstr = this.name;
    ALLCharaSQLController.charaNum = int.Parse(charaNumstr);
    
    SceneManager.LoadScene("CharaStatus");
}
}

}
