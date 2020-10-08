using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleScene.Chara;
using BattleScene;

namespace BattleScene.Tactics
{

public class Battiriganbare : ITactics
{
    //完全ランダム
    public int target(List<Player> party,Player attacker){
        Player targetplayer;
        if(attacker.job == "僧侶" && attacker.mp >= 20){
            targetplayer = party[UnityEngine.Random.Range(0,party.Count)];
        }else{
            do{           
                targetplayer = party[UnityEngine.Random.Range(0,party.Count)];
            }
            while(targetplayer.team == attacker.team);
        }
        int result = party.FindIndex(n => n.playername == targetplayer.playername);
        return result;
    }
}

}