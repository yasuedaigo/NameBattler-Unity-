using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BattleScene;
using SQLManager;

namespace BattleScene.Chara
{
    
public class Ninja : Player
{
    TextManager textmanager;

    public Ninja(SQLPlayer usename) : base(usename){
        textmanager = GameObject.Find("battletext").GetComponent<TextManager>();
    }
    

    public override void Attack(Player defender,int turnNumber){
        int damage = calcDamage(defender);
        if(turnNumber == 1){
            damage = base.STR;
        }else if(defender.GetType() == typeof(Fighter)){
            int stockDEF = defender.DEF;
            defender.DEF = stockDEF/2;
            damage = calcDamage(defender);
            defender.DEF = stockDEF;
        }
        textmanager.battleLog($"{this.PlayerName}の攻撃 ➡ {defender.PlayerName}に{damage}のダメージ");
        defender.damage(damage);
        base.AttackFinished = true;
    }
}

}