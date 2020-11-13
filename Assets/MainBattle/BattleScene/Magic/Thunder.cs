using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleScene;
using BattleScene.Chara;

namespace BattleScene.Magic{

public class Thunder : IMagic
{
    TextManager textmanager = GameObject.Find("battletext").GetComponent<TextManager>();

    public void Use(Player attacker, Player defender){
        int damage = UnityEngine.Random.Range(10,31);
        textmanager.battleLog($"{attacker.PlayerName}のサンダー！   {defender.PlayerName}に{damage}のダメージ");
        attacker.MP = attacker.MP-20;          //mp消費-20
        defender.damage(damage);
        attacker.AttackFinished = true;
	}

}

}