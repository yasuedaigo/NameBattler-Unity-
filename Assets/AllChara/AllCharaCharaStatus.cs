using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace AllChara{

public class AllCharaCharaStatus : MonoBehaviour
{
    public void OnClickButton()
{
    string charaNumstr = this.name;
    ContentManager.charaNum = int.Parse(charaNumstr);
    
    Debug.Log(ContentManager.charaNum);
    SceneManager.LoadScene("CharaStatus");
}
}

}
