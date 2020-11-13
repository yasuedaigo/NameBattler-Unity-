using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BattleScene;
using SQLManager;
using BattleScene.Magic;

namespace BattleScene.Chara
{

public class Wizard : Player
{
    TextManager textmanager;

    public Wizard(PlayerDTO playerDTO) : base(playerDTO){
        textmanager = GameObject.Find("battletext").GetComponent<TextManager>();
    }
    
    public override void Attack(Player defender,int turnNumber){
        int damage = calcDamage(defender);
        if(base.isParise()){
            textmanager.battleLog($"{base.PlayerName}は麻痺した");
        }else{
            this.wizardAttack(defender,turnNumber);
        }
        base.AttackFinished = true;
    }

    public void wizardAttack(Player defender,int turnNumber){
        IMagic iMagic = this.choiceMagic();
        if(iMagic == null){
            base.Attack(defender,turnNumber);
        }else{
            iMagic.Use(this,defender);
        }
        /*WizardMagic choiceMagic = this.choiceMagic();
        switch(choiceMagic)
        {
            case Magics.Fire    : this.fire(defender);
                                       break;
            case Magics.Thunder : this.thunder(defender);
                                       break;
            case Magics.Invalid  : base.Attack(defender,turnNumber);
                                       break;
        }*/
    }

    public IMagic choiceMagic(){
        if(base.MP >= 20){
            if(UnityEngine.Random.Range(0,2) == 1){
                return new Fire();
            }else{
                return new Thunder();
            }
        }else if (base.MP < 20 && base.MP >= 10){
            return new Fire();
        }else{
            return null;
        }
    }
}

}