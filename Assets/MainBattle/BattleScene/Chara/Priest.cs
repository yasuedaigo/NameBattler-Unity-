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
            textmanager.battleLog(base.PlayerName+"は麻痺した");
        }else{
            this.priestAttack(defender,turnNumber);
        }
        base.AttackFinished = true;
    }

    public void priestAttack(Player defender,int turnNumber){
        PriestMagic useMagic = PriestMagic.Attack;
        if(turnNumber == 1){
            if(UnityEngine.Random.Range(0,2) == 1){
                useMagic = PriestMagic.Parise;
            }else{
                useMagic = PriestMagic.Poison;
            }
        }else if(defender.Team == base.Team){
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
        defender.Abnormality = "parise";
        textmanager.battleLog(base.PlayerName+"のパライズ！ ➡ "+defender.PlayerName+"は麻痺した");
        base.AttackFinished = true;
    }

    public void poison(Player defender){
        defender.Abnormality = "poison";
        textmanager.battleLog(base.PlayerName+"のポイズン！ ➡ "+defender.PlayerName+"は毒状態になった");
        base.AttackFinished = true;
    }

    public void heal(Player defender){
        textmanager.battleLog(base.PlayerName+"のヒール ➡ "+defender.PlayerName+"のHPを50回復("+defender.HP+"➡"+(defender.HP+50)+")");
        defender.HP = defender.HP+50;
        base.MP = base.MP-20;
        base.AttackFinished = true;
    }
}

}