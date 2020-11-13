using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MakeChara
{

public class InputFieldManager:MonoBehaviour
{
    InputField inputField;
    public static string charaname;
    public bool isNameOk;
    public Button addButton;
    public Text messagetext;

    
    void Start()
    {
        inputField = GameObject.Find("InputField").GetComponent<InputField>();
    }

    public void NameEnter()
    {
        isNameOk = false;
        charaname = inputField.text;
        if(charaname == null || charaname == ""){
            isNameOk = false;
            addButton.interactable = false;
        }else if(charaname.Length > 20){
            messagetext.text = "プレイヤー名は20字以内にしてください";
            addButton.interactable = false; 
        }else{
            isNameOk = true;
            addButton.interactable = true;
        }
    }

    public static string GetName(){
        return charaname;
    }

}

}