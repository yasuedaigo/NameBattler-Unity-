using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BattleScene;

namespace BattleScene.Chara
{
    
public enum PriestMagic {Heal,Parise,Poison,Attack}

public class Priest : Player
{
    TextManager textmanager;

    public Priest(object usename) : base(usename){
        textmanager = GameObject.Find("battletext").GetComponent<TextManager>();
    }

    public override void Attack(Player defender,int turnNumber){
        bool isParise = base.isParise();
        if(isParise == true){
            textmanager.battleLog(base.playername+"は麻痺した");
        }else{
            this.priestAttack(defender,turnNumber);
        }
        base.attackfinished = true;
    }

    public void priestAttack(Player defender,int turnNumber){
        PriestMagic useMagic = PriestMagic.Attack;
        if(turnNumber == 1){
            if(UnityEngine.Random.Range(0,2) == 1){
                useMagic = PriestMagic.Parise;
            }else{
                useMagic = PriestMagic.Poison;
            }
        }else if(defender.team == base.team){
            useMagic = PriestMagic.Heal;
        }

        switch(useMagic)
        {
            case PriestMagic.Parise : parise(defender);
                                      break;
            case PriestMagic.Poison : poison(defender);
                                      break;
            case PriestMagic.Heal   : heal(defender);
                                      break;
            case PriestMagic.Attack : base.Attack(defender,turnNumber);
                                      break;
        }
    }

    public void parise(Player defender){
        defender.abnormality = "parise";
        textmanager.battleLog(base.playername+"のパライズ！ ➡ "+defender.playername+"は麻痺した");
    }

    public void poison(Player defender){
        defender.abnormality = "poison";
        textmanager.battleLog(base.playername+"のポイズン！ ➡ "+defender.playername+"は毒状態になった");
    }

    public void heal(Player defender){
        textmanager.battleLog(base.playername+"のヒール ➡ "+defender.playername+"のHPを50回復("+defender.hp+"➡"+(defender.hp+50)+")");
        defender.hp = defender.hp+50;
        base.mp = base.mp-20;
    }
}

}