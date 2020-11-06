using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleScene.Chara;
using BattleScene;

namespace BattleScene.Tactics
{

public class DefenseTactics : ITactics
{
    //僧侶は味方の中から選ぶ 他はHpの少ない敵を優先して攻撃
    public int target(Party party,Player attacker){
        List<Player> HPascendinglist = party.getHPAscendinglist();
        Player targetplayer = HPascendinglist.Find(n => (n.Team != attacker.Team) && (n.isLive()));
        if((attacker.GetType() == typeof(Priest)) && attacker.MP >= 20){
            targetplayer = HPascendinglist.Find(n => ((n.Team == attacker.Team) && (n.isLive())));
        }
        int result = party.playerlist.FindIndex(n => n.PlayerName == targetplayer.PlayerName);
        return result;
    }
}

}