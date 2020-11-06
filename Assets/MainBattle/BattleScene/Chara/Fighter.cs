using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BattleScene;
using SQLManager;

namespace BattleScene.Chara
{
    

public class Fighter : Player
{
    TextManager textmanager;

    public Fighter(SQLPlayer sqlplayer) : base(sqlplayer){
        textmanager = GameObject.Find("battletext").GetComponent<TextManager>();
    }
    

    public override void Attack(Player defender,int turnNumber){
        int damage = calcDamage(defender);
        if(base.isParise()){
            textmanager.battleLog($"{base.PlayerName}は麻痺した");
        }else{
            textmanager.battleLog($"{this.PlayerName}の攻撃 ➡ {defender.PlayerName}に{damage}のダメージ");
            defender.damage(damage);
        }
        base.AttackFinished = true;
    }
}

}
