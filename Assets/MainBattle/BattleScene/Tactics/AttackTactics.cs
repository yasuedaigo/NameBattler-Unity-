using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleScene.Chara;
using BattleScene;

namespace BattleScene.Tactics
{

public class AttackTactics : ITactics
{
    //HPの多い敵を優先して攻撃
    public int target(Party party,Player attacker){
        List<Player> HPdescendinglist = party.getHPDescendinglist();
        Player targetplayer = HPdescendinglist.Find(n => ((n.Team != attacker.Team) && (n.isLive == true)));
        int result = party.playerlist.FindIndex(n => n.PlayerName == targetplayer.PlayerName);
        return result;
    }
}

}