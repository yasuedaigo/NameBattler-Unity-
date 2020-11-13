using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleScene;
using BattleScene.Chara;

namespace BattleScene.Magic{

public class Heal : IMagic
{
    TextManager textmanager = GameObject.Find("battletext").GetComponent<TextManager>();
    
    public void Use(Player attacker, Player defender){
        textmanager.battleLog($"{attacker.PlayerName}のヒール ➡ {defender.PlayerName}のHPを50回復({defender.HP}➡({defender.HP}+50))");
        defender.HP = defender.HP+50;
        attacker.MP = attacker.MP-20;
        attacker.AttackFinished = true;
    }

}

}