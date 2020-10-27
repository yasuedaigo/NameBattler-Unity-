using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BattleScene.Chara;
using BattleScene.Tactics;

namespace BattleScene.Chara{


public class Party
{
    public TextManager textmanager;
    public List<Player> playerlist;
    public List<Player> HPascendinglist;
    public List<Player> HPdescendinglist;
    public List<Player> AGIdescendinglist;
    BattleSceneManager battlescenemanager;

    public  Party(){
        textmanager = GameObject.Find("battletext").GetComponent<TextManager>();
        battlescenemanager = GameObject.Find("Main Camera").GetComponent<BattleSceneManager>();
        playerlist = new List<Player>();
    }

    public void makeSortlist(){
        HPascendinglist = new List<Player>();
        HPdescendinglist = new List<Player>();
        AGIdescendinglist = new List<Player>();
        foreach(Player player in this.playerlist) {
            HPascendinglist.Add(player);
            HPdescendinglist.Add(player);
            AGIdescendinglist.Add(player);
        }
        HPascendinglist = getHPAscendinglist();
        HPdescendinglist = getHPDescendinglist();
        AGIdescendinglist = getAGIDescendinglist();
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
        foreach(Player listplayer in playerlist){
            if(listplayer.isLive == true){
                if(listplayer.Team == 1){
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
            if(player.isLive == true){
                player.AttackFinished = false;
            }
        }
    }

    public List<Player> getHPAscendinglist(){
        HPascendinglist.Sort((a, b) => b.HP - a.HP);
        return HPascendinglist;
    }

    public List<Player> getHPDescendinglist(){
        HPdescendinglist.Sort((a, b) => a.HP - b.HP);
        return HPdescendinglist;
    }

    public List<Player> getAGIDescendinglist(){
        AGIdescendinglist.Sort((a, b) => a.HP - b.HP);
        return AGIdescendinglist;
    }

    public bool isTurnFinish(){
        bool isturnfinish = true;
        foreach(Player player in playerlist) {
            if((player.AttackFinished == false) && (player.isLive == true)){
                isturnfinish = false;
            }
        }
        return isturnfinish;
    }

    public bool gameJudge(){
        int livePlayerTeam = this.playerlist.Find(player => (player.isLive == true)).Team;
        if(this.gameFinish() == true){
            textmanager.battleLog("ゲームセット！");
            if(livePlayerTeam == 1){
                battlescenemanager.playerWin();
            }else{
                battlescenemanager.playerLose();
            }
        }
        return this.gameFinish();

    }
     
}

}