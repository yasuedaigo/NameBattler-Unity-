using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Collections;

namespace MakeChara
{
    
public class ToggleManager : MonoBehaviour
{
    ToggleGroup togglegroup;
    public static string tgljob;


    public void Start()
    {
       
    }

    public void settgljob(string job){
       tgljob = job;
    }

    public static string Gettgljob(){
       return tgljob;
    }

    public void debug(){
        Debug.Log("Togglemanagerのメソッド tgljob="+tgljob);
    }
}

}