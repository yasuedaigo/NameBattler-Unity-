using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BattleScene;
using SQLManager;
using BattleScene.Magic;

namespace BattleScene.Chara
{
    
public enum PriestMagic {Heal,Parise,Poison,Attack}

public class Priest : Player
{
    TextManager textmanager;

    public Priest(PlayerDTO playerDTO) : base(playerDTO){
        textmanager = GameObject.Find("battletext").GetComponent<TextManager>();
    }
    

    public override void Attack(Player defender,int turnNumber){
        if(base.isParise()){
            textmanager.battleLog($"{base.PlayerName}は麻痺した");
        }else{
            this.priestAttack(defender,turnNumber);
        }
        base.AttackFinished = true;
    }

    public void priestAttack(Player defender,int turnNumber){
        if(turnNumber == 1){
            this.firstTurnAttack(defender);
        }else if(defender.Team == base.Team){
            IMagic iMagic = new Heal();
            iMagic.Use(this,defender);
        }else{
            base.Attack(defender,turnNumber);
        }
    }

    public void firstTurnAttack(Player defender){
        IMagic iMagic;
        if(UnityEngine.Random.Range(0,2) == 1){
                iMagic = new Parise();
            }else{
                iMagic = new Poison();
        }
        iMagic.Use(this,defender);
    }
}

}