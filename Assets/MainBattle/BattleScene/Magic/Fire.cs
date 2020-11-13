using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleScene;
using BattleScene.Chara;

namespace BattleScene.Magic{

public class Fire : IMagic
{
    TextManager textmanager = GameObject.Find("battletext").GetComponent<TextManager>();

    public void Use(Player attacker,Player defender){
        int damage = UnityEngine.Random.Range(10,31);
        textmanager.battleLog($"{attacker.PlayerName}のファイア！   {defender.PlayerName}に{damage}のダメージ");
        attacker.MP = attacker.MP-10;          //mp消費-20
        defender.damage(damage);
        attacker.AttackFinished = true;
	}
}

}