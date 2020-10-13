using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BattleScene;

namespace BattleScene.Chara
{
    public enum WizardMagic {Fire,Thunder,Attack}


public class Wizard : Player
{
    TextManager textmanager;

    public Wizard(object usename) : base(usename){
        textmanager = GameObject.Find("battletext").GetComponent<TextManager>();
    }

    public override void Attack(Player defender,int turnNumber){
        int damage = calcDamage(defender);
        bool isParise = base.isParise();
        if(isParise == true){
            textmanager.battleLog(base.playername+"は麻痺した");
        }else{
            this.wizardAttack(defender,turnNumber);
        }
        base.attackfinished = true;
    }

    public void wizardAttack(Player defender,int turnNumber){
        WizardMagic choiceMagic = this.choiceMagic();
        switch(choiceMagic)
        {
            case WizardMagic.Fire    : this.fire(defender);
                                       break;
            case WizardMagic.Thunder : this.thunder(defender);
                                       break;
            case WizardMagic.Attack  : base.Attack(defender,turnNumber);
                                       break;
        }
    }

    public WizardMagic choiceMagic(){
        if(base.mp >= 20){
            if(UnityEngine.Random.Range(0,2) == 1){
                return WizardMagic.Fire;
            }else{
                return WizardMagic.Thunder;
            }
        }else if (base.mp < 20 && base.mp >= 10){
            return WizardMagic.Fire;
        }else{
            return WizardMagic.Attack;
        }
    }

    public void thunder(Player defender){
        int damage = UnityEngine.Random.Range(10,31);
        textmanager.battleLog(base.playername+"のサンダー！   "+defender.playername+"に"+damage+"のダメージ");
        base.mp = base.mp-20;          //mp消費-20
        defender.damage(damage);
	}

    public void fire(Player defender){
        int damage = UnityEngine.Random.Range(10,31);
        textmanager.battleLog(base.playername+"のファイア！   "+defender.playername+"に"+damage+"のダメージ");
        base.mp = base.mp-10;          //mp消費-20
        defender.damage(damage);
	}
}

}