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

    // Start is called before the first frame update
    void Start()
    {
        inputField = GameObject.Find("InputField").GetComponent<InputField>();
        nameOk = false;
        
    }

    public void NameEnter()
    {
        charaname = inputField.text;
        if(charaname == null || charaname == ""){
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