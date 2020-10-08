using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleScene.Chara;
using BattleScene;

namespace BattleScene.Tactics
{

public class Gangan : ITactics
{
    //HPの多い敵を優先して攻撃
    public int target(List<Player> party,Player attacker){
        List<Player> sortlist = new List<Player>();
        foreach(Player player in party) {
            sortlist.Add(player);
        }
        sortlist.Sort((a, b) => a.hp - b.hp);
        Player targetplayer = sortlist.Find(n => n.team != attacker.team);
        int result = party.FindIndex(n => n.playername == targetplayer.playername);
        return result;
    }
}

}