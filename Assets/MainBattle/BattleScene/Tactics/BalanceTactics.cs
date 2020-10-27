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
    int debugcount;
    List<Player> originallist;
    Player targetplayer;
    public int target(Party party,Player attacker){
        originallist = party.getPlayerlist();
        if((attacker.GetType() == typeof(Priest)) && (attacker.MP >= 20)){
            getTargetofHeal(party,attacker);
        }else{
            getTargetofAttack(party,attacker);
        }
        int result = originallist.FindIndex(n => (n.PlayerName == targetplayer.PlayerName));
        return result;
    }

    public void getTargetofHeal(Party party,Player attacker){
        debugcount = 0;
        do{
            targetplayer = originallist[UnityEngine.Random.Range(0,originallist.Count)];
            debugcount++;
            if(debugcount > 50){
                Debug.Log("getTargetofHeal");
                break;
            }
        }while(targetplayer.isLive == false);
    }

    public void getTargetofAttack(Party party,Player attacker){
        do{
            targetplayer = originallist[UnityEngine.Random.Range(0,originallist.Count)];
        }while((targetplayer.isLive == false) || (targetplayer.Team == attacker.Team));
    }
}

}