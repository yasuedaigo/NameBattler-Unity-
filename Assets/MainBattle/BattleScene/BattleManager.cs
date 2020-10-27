using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BattleScene.Chara;
using BattleScene.Tactics;
using SQLManager;

namespace  BattleScene
{
    
public class BattleManager : MonoBehaviour
{
    SQLDate sqlDate;
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
        sqlDate = new SQLDate();
        playerintlist = MakeParty.MakePartyBattleStart.playerintlist;
        enemyintlist = BattleStart.ContentManager.enemyintlist;
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
        addPlayertoParty(playerintlist);
        addPlayertoParty(enemyintlist);
        setTeam();
        party.makeSortlist();
        statusText();
    }

    public void nextTurn(){
        textmanager.battleLog(turnNumber+"ターン目");
        Player attacker;
        Player defender;
        int defenderint;
        party.attackReset();

        while((party.isTurnFinish() == false) && (party.gameJudge() == false)){
            attacker = party.getAGIDescendinglist().Find(player => ((player.AttackFinished == false) && (player.isLive == true)));
            defenderint = tacticsmanager.choiceTactics.target(party,attacker);
            defender = party.getPlayer(defenderint);
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

    public void addPlayertoParty(List<int> intlist){
        foreach (int playerint in intlist)
        {
            SQLPlayer sqlplayer = sqlDate.getSQLPlayer(playerint);
            string playerjob = sqlplayer.JOB;
            string playername = sqlplayer.PlayerName;
            Player player = null;
            if(playerjob == "戦士"){
                player = new Fighter(playername);
            }else if(playerjob == "魔法使い"){
                player = new Wizard(playername);
            }else if(playerjob == "僧侶"){
                player = new Priest(playername);
            }else if(playerjob == "忍者"){
                player = new Ninja(playername);
            }
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