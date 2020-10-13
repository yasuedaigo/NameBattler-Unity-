using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using BattleScene.Chara;
using BattleScene;

namespace BattleScene.Tactics
{

public class TacticsManager : MonoBehaviour
{
    public ITactics choiceTactics;
    public GameObject ganganbutton;
    public GameObject inotibutton;
    public GameObject battiributton;
    public ToggleGroup toggleGroup;
    // Start is called before the first frame update

    void Start(){
        choiceTactics = new Gangan();
    }

    public void changeToggle(){
        string selectedLabel = toggleGroup.ActiveToggles()
            .First().GetComponentsInChildren<Text>()
            .First(t => t.name == "Label").text;
        
        if(selectedLabel == "ガンガンいこうぜ"){
            choiceTactics = new Gangan();
        }else if(selectedLabel == "いのちだいじに"){
            choiceTactics = new Inotidaizini();
        }else{
            choiceTactics = new Battiriganbare();
        }
    }
}

}
