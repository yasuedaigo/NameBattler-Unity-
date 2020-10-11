using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleScene.Chara;
using BattleScene;

namespace BattleScene.Tactics
{

public class Inotidaizini : ITactics
{
    //僧侶は味方の中から選ぶ 他はHpの少ない敵を優先して攻撃
    public int target(List<Player> party,Player attacker){
        List<Player> sortlist = new List<Player>();
        foreach(Player player in party) {
            sortlist.Add(player);
        }
        sortlist.Sort((a, b) => b.hp - a.hp);
        Player targetplayer = sortlist.Find(n => n.team != attacker.team);
        if(attacker.job == "僧侶" && attacker.mp >= 20){
            targetplayer = sortlist.Find(n => ((n.team == attacker.team) && (n.islive == true)));
        }
        int result = party.FindIndex(n => n.playername == targetplayer.playername);
        return result;
    }
}

}