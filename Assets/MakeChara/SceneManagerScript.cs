using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MakeChara{


public class SceneManagerScript : MonoBehaviour
{
    public InputFieldManager inputfieldmanager;
    public Text messagetext;
    
    void Start()
    {
        inputfieldmanager = GameObject.Find("InputField").GetComponent<InputFieldManager>();
    }

    
    public void loadAllChara()
{
    SceneManager.LoadScene("AllChara");
}

    public void makeChara(){
        if(InputFieldManager.charaname.Length > 20){
            messagetext.text = "プレイヤー名は20字以内にしてください";
            return;
        }

        if(inputfieldmanager.NameCheck()){
            SceneManager.LoadScene("MakeCharaResult");
        }
    }

}

}
