using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AllCharaCharaStatus : MonoBehaviour
{
    public void OnClickButton()
{
    string charaNumstr = this.name.Substring(6, 1);
    ContentManager.charaNum = int.Parse(charaNumstr);
    
    Debug.Log(this.name);
    Debug.Log(ContentManager.charaNum);
    SceneManager.LoadScene("CharaStatus");
}
}
