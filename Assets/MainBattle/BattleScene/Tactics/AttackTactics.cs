using System.Collections;
using System.Collections.Generic;
using BattleScene;
using BattleScene.Chara;
using UnityEngine;

namespace BattleScene.Tactics
{
    public class AttackTactics : ITactics
    {
        //HPの多い敵を優先して攻撃
        public Player target(Party party, Player attacker)
        {
            return party.getTargetInAttackTactics(attacker);
        }
    }
}
