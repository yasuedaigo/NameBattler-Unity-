using System.Collections;
using System.Collections.Generic;
using BattleScene;
using BattleScene.Chara;
using BattleScene.Magic;
using UnityEngine;

namespace BattleScene.Tactics
{
    //完全ランダム
    public class BalanceTactics : ITactics
    {
        public Player target(Party party, Player attacker)
        {
            if (attacker.canUseHeal())
            {
                return party.getTargetOfHealInBalanceTactics(attacker);
            }
            else
            {
                return party.getTargetOfAttackInBalanceTactics(attacker);
            }
        }
    }
}
