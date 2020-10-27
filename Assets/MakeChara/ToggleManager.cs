using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MakeCharaResult;

namespace MakeChara
{

public class ToggleManager : MonoBehaviour
{
    public Toggle fighterToggle;
    public Toggle ninjaToggle;
    public Toggle wizardToggle;
    public Toggle priestToggle;
    public static IFMakePlayer ifMakePlayer;
    
    void Start()
    {
        ifMakePlayer = new Ninja();
    }
    
    public void FighterToggle(){
        if(fighterToggle.isOn == true){
            ifMakePlayer = new Fighter();
        }
    }

    public void NinjaToggle(){
        if(ninjaToggle.isOn == true){
            ifMakePlayer = new Ninja();
        }
    }

    public void WizardToggle(){
        if(wizardToggle.isOn == true){
            ifMakePlayer = new Wizard();
        }
    }

    public void PriestToggle(){
        if(priestToggle.isOn == true){
            ifMakePlayer = new Priest();
        }
    }

    public static IFMakePlayer getSelectJob(){
       return ifMakePlayer;
    }
}

}