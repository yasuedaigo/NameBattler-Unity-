using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleScene.Chara;
using BattleScene;

namespace BattleScene.Tactics
{

public class DefenceTactics : ITactics
{
    //僧侶は味方の中から選ぶ 他はHpの少ない敵を優先して攻撃
    public Player target(Party party,Player attacker){
        return party.getTargetinDefenceTactics(attacker);
    }
}

}