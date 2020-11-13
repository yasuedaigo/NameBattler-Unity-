using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MakeCharaResult;
using SQLManager;
using System;
using System.Linq;
using MakeCharaResult;
using System.Reflection;

namespace MakeChara
{

public class ToggleManager : MonoBehaviour
{
    public static IFMakePlayer ifMakePlayer;
    public GameObject jobtoggle;
    public ToggleGroup togglegroup;
    void Start()
    {
        foreach(JOBs job in Enum.GetValues(typeof(JOBs))){
            GameObject Obj = (GameObject)Instantiate (jobtoggle,this.transform.position, Quaternion.identity);
            Obj.transform.parent = this.transform;
            Obj.name = job.ToString();
            Text jobtext = Obj.transform.Find("Text").gameObject.GetComponent<Text>();
            jobtext.text = job.GetStringValue();
            Obj.GetComponent<Toggle>().group = togglegroup;
        }
        Toggle firsttoggle = transform.GetChild(0).gameObject.GetComponent<Toggle>();
        firsttoggle.isOn = true;
        setActiveToggle();
    }

    public void setActiveToggle(){
        Toggle activeToggle = togglegroup.ActiveToggles().FirstOrDefault();
        Type type = Type.GetType("MakeCharaResult."+activeToggle.name);
        ifMakePlayer = (IFMakePlayer)Activator.CreateInstance(type);
    }
}

}