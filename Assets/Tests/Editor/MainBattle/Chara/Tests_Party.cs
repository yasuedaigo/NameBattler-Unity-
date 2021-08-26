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
    public class Tests_Party
    {
        Text battletext = GameObject.Find("battletext").GetComponent<Text>();
        Testtool_Chara testtool_chara = new Testtool_Chara();
        
        [UnityTest]
        public IEnumerator Test_controllParty()
        {
            Party party = new Party();
            Player testplayer = testtool_chara.prepareFighter("あ",50,5,5,0,5,5);
            party.addPlayer(testplayer);
            Player getplayer = party.getPlayer(0);
            Assert.That(getplayer.PlayerName == "あ");
            party.removePlayer(getplayer);
            List<Player> playerlist = party.getPlayerList();
            Assert.That(playerlist.Count() == 0);
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_isGameFinish()
        {
            Party party = new Party();
            for(int i=0;i<6;i++)
            {
                Player player = testtool_chara.prepareFighter(i.ToString(),50,5,5,0,5,5);
                if(i < 3)
                {
                    player.Team = Teams.Player;
                }else
                {
                    player.Team = Teams.Enemy;
                }
                party.addPlayer(player);
            }
            List<Player> playerlist = party.getPlayerList();
            Assert.That(party.isGameFinish() == false);
            for(int i=0;i<3;i++)
            {
                Player player = party.getPlayer(i);
                player.HP = 0;
            }
            Assert.That(party.isGameFinish() == true);
            for(int i=0;i<6;i++)
            {
                Player player = party.getPlayer(i);
                if(i < 3)
                {
                    player.HP = 50;
                }else
                {
                    player.HP = 0;
                }
            }
            Assert.That(party.isGameFinish() == true);
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_resetAttackFinished()
        {
            Party party = new Party();
            for(int i=0;i<6;i++)
            {
                Player player = testtool_chara.prepareFighter(i.ToString(),50,5,5,0,5,5);
                party.addPlayer(player);
                player.AttackFinished = true;
            }
            party.resetAttackFinished();
            List<Player> playerlist = party.getPlayerList();
            foreach (Player listPlayer in playerlist)
            {
                Assert.That(listPlayer.AttackFinished == false);
            }
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_isNotTurnFinished()
        {
            Party party = new Party();
            for(int i=0;i<6;i++)
            {
                Player player = testtool_chara.prepareFighter(i.ToString(),0,5,5,0,5,5);
                player.AttackFinished = false;
                if(i < 3)
                {
                    player.Team = Teams.Player;
                }else
                {
                    player.Team = Teams.Enemy;
                }
                party.addPlayer(player);
            }
            Assert.That(party.isNotTurnFinished() == false);
            List<Player> playerlist = party.getPlayerList();
            foreach (Player listPlayer in playerlist)
            {
                listPlayer.HP = 50;
            }
            Assert.That(party.isNotTurnFinished() == true);
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_getWinTeam()
        {
            Party party = new Party();
            for(int i=0;i<6;i++)
            {
                Player player = testtool_chara.prepareFighter(i.ToString(),0,5,5,0,5,5);
                if(i < 3)
                {
                    player.Team = Teams.Player;
                }else
                {
                    player.Team = Teams.Enemy;
                    player.HP = 50;
                }
                party.addPlayer(player);
            }
            Assert.That(party.getWinTeam() == Teams.Enemy);
            List<Player> playerlist = party.getPlayerList();
            for(int i=0;i<6;i++)
            {
                Player player =  party.getPlayer(i);
                if(i < 3)
                {
                    player.HP = 50;
                }else
                {
                    player.HP = 0;
                }
            }
            Assert.That(party.getWinTeam() == Teams.Player);
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_getAttacker()
        {
            Party party = new Party();
            for(int i=0;i<6;i++)
            {
                Player player = testtool_chara.prepareFighter(i.ToString(),50,5,5,0,5,5);
                player.AttackFinished = false;
                if(i < 3)
                {
                    player.Team = Teams.Player;
                }else
                {
                    player.Team = Teams.Enemy;
                }
                party.addPlayer(player);
            }
            party.makeSortList();
            List<Player> playerlist = party.getPlayerList();
            party.getPlayer(0).HP = 0;
            party.getPlayer(1).AttackFinished = true;
            Assert.That(party.getAttacker().PlayerName == "2");
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_makeSortList()
        {
            Party party = new Party();
            Player player1 = testtool_chara.prepareFighter("0",10,5,5,0,0,10);
            party.addPlayer(player1);
            Player player2 = testtool_chara.prepareFighter("1",20,5,5,0,0,20);
            party.addPlayer(player2);
            Player player3 = testtool_chara.prepareFighter("2",30,5,5,0,0,30);
            party.addPlayer(player3);
            Player player4 = testtool_chara.prepareFighter("3",25,5,5,0,0,25);
            party.addPlayer(player4);
            Player player5 = testtool_chara.prepareFighter("4",15,5,5,0,0,15);
            party.addPlayer(player5);
            Player player6 = testtool_chara.prepareFighter("5",5,5,5,0,0,5);
            party.addPlayer(player6);
            party.makeSortList();
            List<Player> HPascendingList = party.getHPAscendingList();
            List<Player> HPdescendingList = party.getHPDescendingList();
            List<Player> AGIdescendingList = party.getAGIDescendingList();
            for(int i=0;i<5;i++)
            {
                Assert.That(HPascendingList[i].HP >= HPascendingList[i+1].HP);
                Assert.That(HPdescendingList[i].HP <= HPdescendingList[i+1].HP);
                Assert.That(AGIdescendingList[i].AGI <= AGIdescendingList[i+1].AGI);
            }
            yield return null;
        }
    }
}