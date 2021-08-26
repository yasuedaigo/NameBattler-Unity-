using System.Collections;
using UnityEngine.TestTools;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BattleScene.Magic;
using UnityEngine;
using UnityEngine.UI;
using SQLManager;
using BattleScene;
using BattleScene.Chara;
using BattleScene.Tactics;
using BattleScene.Magic;

namespace BattleSceneTests
{
    public class Tests_Tactics
    {
        Text battletext = GameObject.Find("battletext").GetComponent<Text>();
        Testtool_Chara testtool_chara = new Testtool_Chara();
        AttackTactics attacktactics = new AttackTactics();
        BalanceTactics balancetactics = new BalanceTactics();
        DefenceTactics defencetactics = new DefenceTactics();
        
        [UnityTest]
        public IEnumerator Test_attackTactics()
        {
            Party party = new Party();
            Player player1 = testtool_chara.prepareFighter("0",10,5,5,0,0,10);
            player1.Team = Teams.Player;
            party.addPlayer(player1);
            Player player2 = testtool_chara.prepareFighter("1",20,5,5,0,0,20);
            player2.Team = Teams.Enemy;
            party.addPlayer(player2);
            Player player3 = testtool_chara.prepareFighter("2",30,5,5,0,0,30);
            player3.Team = Teams.Player;
            party.addPlayer(player3);
            Player player4 = testtool_chara.prepareFighter("3",25,5,5,0,0,25);
            player4.Team = Teams.Enemy;
            party.addPlayer(player4);
            Player player5 = testtool_chara.prepareFighter("4",15,5,5,0,0,15);
            player5.Team = Teams.Enemy;
            party.addPlayer(player5);
            Player player6 = testtool_chara.prepareFighter("5",5,5,5,0,0,5);
            player6.Team = Teams.Enemy;
            party.addPlayer(player6);
            party.makeSortList();
            Player attacker = player1;
            Assert.That(attacktactics.target(party,attacker).PlayerName == "3");
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_defencetactics()
        {
            Party party = new Party();
            Player player1 = testtool_chara.prepareFighter("0",10,5,5,0,0,10);
            player1.Team = Teams.Player;
            party.addPlayer(player1);
            Player player2 = testtool_chara.preparePriest("1",20,5,5,0,0,50);
            player2.Team = Teams.Enemy;
            party.addPlayer(player2);
            Player player3 = testtool_chara.prepareFighter("2",30,5,5,0,0,30);
            player3.Team = Teams.Player;
            party.addPlayer(player3);
            Player player4 = testtool_chara.prepareFighter("3",25,5,5,0,0,25);
            player4.Team = Teams.Enemy;
            party.addPlayer(player4);
            Player player5 = testtool_chara.prepareFighter("4",15,5,5,0,0,15);
            player5.Team = Teams.Player;
            party.addPlayer(player5);
            Player player6 = testtool_chara.prepareFighter("5",5,5,5,0,0,5);
            player6.Team = Teams.Enemy;
            party.addPlayer(player6);
            party.makeSortList();
            Player attacker = player1;
            Assert.That(defencetactics.target(party,attacker).PlayerName == "5");
            attacker = player2;
            Assert.That(defencetactics.target(party,attacker).PlayerName == "5");
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_balancetactics()
        {
            Party party = new Party();
            Player player1 = testtool_chara.prepareFighter("0",10,5,5,0,0,10);
            player1.Team = Teams.Player;
            party.addPlayer(player1);
            Player player2 = testtool_chara.preparePriest("1",20,5,5,0,0,50);
            player2.Team = Teams.Enemy;
            party.addPlayer(player2);
            Player player3 = testtool_chara.prepareFighter("2",30,5,5,0,0,30);
            player3.Team = Teams.Player;
            party.addPlayer(player3);
            Player player4 = testtool_chara.prepareFighter("3",25,5,5,0,0,25);
            player4.Team = Teams.Enemy;
            party.addPlayer(player4);
            Player player5 = testtool_chara.prepareFighter("4",15,5,5,0,0,15);
            player5.Team = Teams.Player;
            party.addPlayer(player5);
            Player player6 = testtool_chara.prepareFighter("5",5,5,5,0,0,5);
            player6.Team = Teams.Enemy;
            party.addPlayer(player6);
            party.makeSortList();
            Player attacker = player1;
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            for(int i=0;i<50;i++)
            {
                Player targetplayer = balancetactics.target(party,attacker);
                if(targetplayer.PlayerName == "1") count1++;
                if(targetplayer.PlayerName == "3") count2++;
                if(targetplayer.PlayerName == "5") count3++;
            }
            Assert.That(count1 > 0);
            Assert.That(count2 > 0);
            Assert.That(count3 > 0);
            Assert.That((count1 + count2 + count3) == 50);
            attacker = player2;
            count1 = 0;
            count2 = 0;
            count3 = 0;
            int count4 = 0;
            int count5 = 0;
            int count6 = 0;
            for(int i=0;i<50;i++)
            {
                Player targetplayer = balancetactics.target(party,attacker);
                if(targetplayer.PlayerName == "0") count1++;
                if(targetplayer.PlayerName == "1") count2++;
                if(targetplayer.PlayerName == "2") count3++;
                if(targetplayer.PlayerName == "3") count4++;
                if(targetplayer.PlayerName == "4") count5++;
                if(targetplayer.PlayerName == "5") count6++;
            }
            Assert.That(count1 > 0);
            Assert.That(count2 > 0);
            Assert.That(count3 > 0);
            Assert.That(count4 > 0);
            Assert.That(count5 > 0);
            Assert.That(count6 > 0);
            Assert.That((count1 + count2 + count3 + count4 + count5 + count6) == 50);
            yield return null;
        }
    }
}