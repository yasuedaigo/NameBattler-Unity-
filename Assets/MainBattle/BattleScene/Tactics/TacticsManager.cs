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
    public ToggleGroup toggleGroup;
    public Toggle attacktactics;
    public Toggle defensetactics;
    public Toggle balancetactics;
    // Start is called before the first frame update

    void Start(){
        choiceTactics = new AttackTactics();
    }

    public void AttackTacticsToggle(){
        if(attacktactics.isOn == true){
            choiceTactics = new AttackTactics();
        }
    }

    public void DefenseTacticsToggle(){
        if(defensetactics.isOn == true){
            choiceTactics = new DefenseTactics();
        }
    }

    public void BalanceTacticsToggle(){
        if(balancetactics.isOn == true){
            choiceTactics = new BalanceTactics();
        }
    }
}

}
