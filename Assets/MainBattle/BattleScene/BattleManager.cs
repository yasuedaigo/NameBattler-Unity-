using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BattleScene.Chara;
using BattleScene.Tactics;

namespace  BattleScene
{
    
public class BattleManager : MonoBehaviour
{
    TextManager textmanager = null;
    BattleSceneManager battlescenemanager;
    public TacticsManager tacticsmanager;
    public List<Text> textlist;
    public List<Player> finalplayerlist;
    public ITactics itactics;
    public Text player1text;
    public Text player2text;
    public Text player3text;
    public Text player100text;
    public Text player200text;
    public Text player300text;
    public static Player player1;
    public static Player player2;
    public static Player player3;
    public static Player player100;
    public static Player player200;
    public static Player player300;
    public Party party;
    int turnNumber;
    // Start is called before the first frame update
    void Start()
    {
        turnNumber = 1;
        textmanager = GameObject.Find("battletext").GetComponent<TextManager>();
        tacticsmanager = GameObject.Find("Main Camera").GetComponent<TacticsManager>();
        battlescenemanager = GameObject.Find("Main Camera").GetComponent<BattleSceneManager>();
        textmanager.battleLog("バトル開始");
        //czcz   dada   teret   vnb   dasdas    dfsfs
        player1text = GameObject.Find("player1").GetComponent<Text>();
        player2text = GameObject.Find("player2").GetComponent<Text>();
        player3text = GameObject.Find("player3").GetComponent<Text>();
        player100text = GameObject.Find("player100").GetComponent<Text>();
        player200text = GameObject.Find("player200").GetComponent<Text>();
        player300text = GameObject.Find("player300").GetComponent<Text>();
        textlist = new List<Text>(){player1text,player2text,player3text,player100text,player200text,player300text};
        player1 = new Ninja("czcz");
        player2 = new Priest("dada");
        player3 = new Wizard("teret");
        player100 = new Fighter("vnb");
        player200 = new Ninja("dasdas");
        player300 = new Priest("dfsfs");
        player1.team = 1;
        player2.team = 1;
        player3.team = 1;
        player100.team = 2;
        player200.team = 2;
        player300.team = 2;
        finalplayerlist = new List<Player>(){player1,player2,player3,player100,player200,player300};
        statusText();
        party = new Party();
        party.addPlayer(player1); 
        party.addPlayer(player2);
        party.addPlayer(player3); 
        party.addPlayer(player100);
        party.addPlayer(player200); 
        party.addPlayer(player300);
    }

    public void nextTurn(){
        textmanager.battleLog(turnNumber+"ターン目");
        Player attacker;
        Player defender;
        int defenderint;
        for(int i=0; i<party.playerlist.Count;i++){
            if(party.playerlist[party.playerlist.Count-1].attackfinished == true){
                party.attackReset();
            }

            attacker = party.playerlist.Find(player => player.attackfinished == false);
            defenderint = tacticsmanager.choiceTactics.target(party.getPlayerlist(),attacker);
            defender = party.getPlayer(defenderint);
            
            attacker.Attack(defender,turnNumber);

            if(defender.hp <= 0){
                textmanager.battleLog(defender.playername+"は倒れた");
                defender.islive = false;
            }
            statusText();
            if(party.gameFinish() == true){
                textmanager.battleLog("ゲームセット！");
                if(party.playerlist[0].team == 1){
                    battlescenemanager.playerWin();
                }else{
                    battlescenemanager.playerLose();
                }
                break;
            }
        }
        if(party.gameFinish() != true){
            poisonDamage();
        }
        textmanager.battleLog("---------------------------------------");
        turnNumber++;
    }

    public void statusText(){
          for(int i=0;i<6;i++){
              finalplayerlist[i].playerstatusText(textlist[i]);
          }
    }

    public void poisonDamage(){
        for(int i=0; i<party.playerlist.Count;i++){
            Player poisonplayer = party.getPlayer(i);
            if(poisonplayer.islive == false){
                continue;
            }
        
            if(poisonplayer.abnormality == "poison"){
                poisonplayer.damage(20);
                textmanager.battleLog(poisonplayer.playername+"は毒によるダメージを受けた");
            }            

            if(poisonplayer.hp <= 0){
                textmanager.battleLog(poisonplayer.playername+"は倒れた");
                poisonplayer.islive = false;
            }

            statusText();
            if(party.gameFinish() == true){
                textmanager.battleLog("ゲームセット！");
                textmanager.gameFinish();
            }
        }
    }

}

}