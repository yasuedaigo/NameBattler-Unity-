using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.Chara{


public class Party
{
    public TextManager textmanager;
    public List<Player> playerlist;

    public  Party(){
        textmanager = GameObject.Find("battletext").GetComponent<TextManager>();
        playerlist = new List<Player>();
    }

    public void addPlayer(Player player)
    {
        playerlist.Add(player);
    }

    public Player getPlayer(int i){
        return playerlist[i];
    }

    public void removePlayer(Player player)
    {
        playerlist.Remove(player);

    }

    public List<Player> getPlayerlist(){
        return playerlist;
    }

    public bool gameFinish(){
        int count1 = 0;
        int count2 = 0;
        foreach(Player listplayer in playerlist) {
            if(listplayer.islive == true){
                if(listplayer.team == 1){
                    count1++;
                }else{
                    count2++;
                }
            }
        }
        if(count1 == 0 || count2 == 0){
             return true;
        }
        return false;
    }

    public void attackReset(){
        foreach(Player player in playerlist) {
            player.attackfinished = false;
        }
    }
     
}

}