using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleScene.Chara;
using BattleScene;

namespace BattleScene.Tactics
{
//完全ランダム
public class BalanceTactics : ITactics
{
    public Player target(Party party,Player attacker){
        if((attacker.GetType() == typeof(Priest)) && (attacker.MP >= 20)){
            return party.getTargetofHealinBalanceTactics(attacker);
        }else{
            return party.getTargetofAttackinBalanceTactics(attacker);
        }
    }
}

}