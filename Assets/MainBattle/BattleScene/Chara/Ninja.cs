using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BattleScene;

namespace BattleScene.Chara
{
    
public class Ninja : Player
{
    TextManager textmanager;

    public Ninja(object usename) : base(usename){
        textmanager = GameObject.Find("battletext").GetComponent<TextManager>();
    }

    public override void Attack(Player defender,int turnNumber){
        int damage = calcDamage(defender);
        if(turnNumber == 1){
            damage = base.str;
        }else if(defender.job == "戦士"){
            int stockDEF = defender.def;
            defender.def = stockDEF/2;
            damage = calcDamage(defender);
            defender.def = stockDEF;
        }
        textmanager.battleLog(this.playername+"の攻撃 ➡ "+defender.playername+"に"+damage+"のダメージ");
        defender.damage(damage);
        base.attackfinished = true;
    }
}

}