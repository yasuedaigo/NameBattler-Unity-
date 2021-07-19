using System.Collections;
using System.Collections.Generic;
using BattleScene;
using BattleScene.Chara;
using UnityEngine;

namespace BattleScene.Tactics
{
    public class DefenceTactics : ITactics
    {
        //僧侶は味方の中から選ぶ 他はHpの少ない敵を優先して攻撃
        public Player target(Party party, Player attacker)
        {
            return party.getTargetInDefenceTactics(attacker);
        }
    }
}
