using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BattleScene.Chara;
using BattleScene.Tactics;
using SQLManager;
using System;
using MakeParty;
using AllChara;
using BattleStart;

namespace  BattleScene
{
    
public class BattleManager : MonoBehaviour
{
    TextManager textmanager = null;
    BattleSceneManager battlescenemanager;
    public TacticsManager tacticsmanager;
    public ITactics itactics;
    public GameObject statuspanel;
    public List<GameObject> statuspanellist;
    public Party party;
    int turnNumber; 
    public List<int> playerintlist;
    public List<int> enemyintlist;
    
    void Start()
    {
        turnNumber = 1;
        textmanager = GameObject.Find("battletext").GetComponent<TextManager>();
        tacticsmanager = GameObject.Find("Main Camera").GetComponent<TacticsManager>();
        battlescenemanager = GameObject.Find("Main Camera").GetComponent<BattleSceneManager>();
        statuspanel = GameObject.Find("StatusPanel");
        foreach (Transform childTransform in statuspanel.transform)
        {
            statuspanellist.Add(childTransform.gameObject);
        }
        party = new Party();
        addPlayertoParty(BattleStartRepositoryManager.myteamPlayerDTOList);
        addPlayertoParty(BattleStartRepositoryManager.enemyPlayerDTOList);
        setTeam();
        party.makeSortlist();
        statusText();
    }

    public void nextTurn(){
        textmanager.battleLog($"{turnNumber}ターン目");
        Player attacker;
        Player defender;
        int defenderint;
        party.attackReset();

        while((party.isTurnFinish() == false) && (party.gameJudge() == false)){
            attacker = party.getAttacker();
            defender = tacticsmanager.choiceTactics.target(party,attacker);
            attacker.Attack(defender,turnNumber);
            statusText();
        }

        this.poisonDamage();
        textmanager.battleLog("---------------------------------------");
        turnNumber++;
    }

    public void statusText(){
        for(int i=0;i<6;i++){
            party.playerlist[i].playerstatusText(statuspanellist[i]);
        }
    }

    public void poisonDamage(){
        foreach(Player poisonplayer in party.playerlist){
            poisonplayer.poisonDamage();
            statusText();
            party.gameJudge();
        }
    }
    
    public void addPlayertoParty(List<PlayerDTO> playerDTOList){
        foreach (PlayerDTO playerDTO in playerDTOList)
        {
            Player player = null;
            Type type = Type.GetType("BattleScene.Chara." + playerDTO.JOB.ToString());
            player = (Player)Activator.CreateInstance(type,playerDTO);
            party.addPlayer(player);
        }
    }


    public void setTeam(){
        int count = 0;
        foreach(Player player in party.playerlist){
            if(count <3){
                player.Team = 1;
            }else{
                player.Team = 2;
            }
            count++;
        }
    }
}

}