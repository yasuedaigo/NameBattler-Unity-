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
    public bool nameOk;

    
    void Start()
    {
        inputField = GameObject.Find("InputField").GetComponent<InputField>();
        nameOk = false;
        
    }

    public void NameEnter()
    {
        nameOk = false;
        charaname = inputField.text;
        if(charaname == null || charaname == "" || (charaname.Length > 20)){
            nameOk = false;
        }else{
            nameOk = true;
        }
    }

    public static string GetName(){
        return charaname;
    }

    public bool NameCheck(){
        if(nameOk == true){
           return true;
        }else{
            return false;
        }
    }
    
}

}