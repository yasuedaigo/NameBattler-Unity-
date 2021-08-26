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
    public class Tests_Player
    {
        Text battletext = GameObject.Find("battletext").GetComponent<Text>();
        Testtool_Chara testtool_chara = new Testtool_Chara();
        
        [UnityTest]
        public IEnumerator Test_Player()
        {
            PlayerDTO playerDTO = new PlayerDTO();
            playerDTO.PlayerName = "test";
            playerDTO.JOB = JOBs.Fighter;
            playerDTO.JOBInt = 1;
            playerDTO.HP = 5;
            playerDTO.STR = 5;
            playerDTO.DEF = 5;
            playerDTO.LUCK = 5;
            playerDTO.AGI = 5;
            playerDTO.MP = 5;
            Player player = new Player(playerDTO);
            Assert.That(player.PlayerName == "test");
            Assert.That(player.JOB == JOBs.Fighter);
            Assert.That(player.HP == 5);
            Assert.That(player.STR == 5);
            Assert.That(player.DEF == 5);
            Assert.That(player.LUCK == 5);
            Assert.That(player.AGI == 5);
            Assert.That(player.MP == 5);
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_calcDamage()
        {
            Player attacker = testtool_chara.prepareFighter("testattacker",5,5,5,0,5,5);
            Player defender = testtool_chara.prepareFighter("testdefender",100,5,1,0,0,0);
            int damage = attacker.calcDamage(defender);
            Assert.That(damage == 4);
            attacker.LUCK = 100;
            damage = attacker.calcDamage(defender);
            Assert.That(damage == 5);
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_criticalHit()
        {
            Player attacker = testtool_chara.prepareFighter("testattacker",5,5,5,0,5,5);
            Player defender = testtool_chara.prepareFighter("testdefender",100,5,1,0,0,0);
            bool criticalhit = attacker.criticalHit();
            Assert.That(criticalhit == false);
            attacker.LUCK = 100;
            criticalhit = attacker.criticalHit();
            Assert.That(criticalhit == true);
            attacker.LUCK = 50;
            int criticalcount = 0;
            int normalcount = 0;
            for(int i=0; i < 12; i++)
            {
                criticalhit = attacker.criticalHit();
                if(criticalhit)
                {
                    criticalcount++;
                }else
                {
                    normalcount++;
                }
            }
            Assert.That(criticalcount > 0);
            Assert.That(normalcount > 0);
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_isFreez()
        {
            Player attacker = testtool_chara.prepareFighter("testattacker",5,5,5,0,5,5);
            Player defender = testtool_chara.prepareFighter("testdefender",100,5,1,0,0,0);
            bool isFreez = attacker.isFreez();
            Assert.That(isFreez == false);
            attacker.Abnormality = Abnormalitys.Parise;
            int freezcount = 0;
            int nonfreezcount = 0;
            for(int i=0; i < 12; i++)
            {
                isFreez = attacker.isFreez();
                if(isFreez)
                {
                    freezcount++;
                }else
                {
                    nonfreezcount++;
                }
            }
            Assert.That(freezcount > 0);
            Assert.That(nonfreezcount > 0);
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_drowStatusText()
        {
            Player player = testtool_chara.prepareFighter("test",5,5,5,0,5,5);
            GameObject statuspanel = GameObject.Find("player1");
            player.drowStatusText(statuspanel);
            Text nametext = statuspanel.GetComponentsInChildren<Text>().First();
            Text statustext = statuspanel.GetComponentsInChildren<Text>().Last();
            Assert.That(nametext.text == $"{player.PlayerName}\r\n{player.JOB.GetStringValue()}");
            Assert.That(statustext.text == $"HP  {player.HP}/{player.FirstHP}\r\nMP  {player.MP}/{player.FirstMP}");
            player.Abnormality = Abnormalitys.Parise;
            player.drowStatusText(statuspanel);
            Assert.That(statustext.text == $"HP  {player.HP}/{player.FirstHP}\r\nMP  {player.MP}/{player.FirstMP}\r\n麻痺");
            player.Abnormality = Abnormalitys.Poison;
            player.drowStatusText(statuspanel);
            Assert.That(statustext.text == $"HP  {player.HP}/{player.FirstHP}\r\nMP  {player.MP}/{player.FirstMP}\r\n毒");
            player.HP = 0;
            player.drowStatusText(statuspanel);
            Assert.That(statustext.color == new Color(1, 0, 0, 1));
            Assert.That(nametext.color == new Color(1, 0, 0, 1));
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_poisonDamage()
        {
            Player player = testtool_chara.prepareFighter("test",50,5,5,0,5,5);
            player.Abnormality = Abnormalitys.Poison;
            player.poisonDamage();
            Assert.That(player.HP == 30);
            Assert.That(battletext.text == $"バトルスタート！\r\n{player.PlayerName}は毒によるダメージを受けた");
            battletext.text = "バトルスタート！";
            player.HP = 20;
            player.poisonDamage();
            Assert.That(player.HP == 0);
            Assert.That(battletext.text == $"バトルスタート！\r\n{player.PlayerName}は毒によるダメージを受けた\r\n{player.PlayerName}は倒れた");
            battletext.text = "バトルスタート！";
            player.HP = 0;
            player.poisonDamage();
            Assert.That(player.HP == 0);
            Assert.That(battletext.text == "バトルスタート！");
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_downJudge()
        {
            Player player = testtool_chara.prepareFighter("test",50,5,5,0,5,5);
            player.downJudge();
            Assert.That(battletext.text == "バトルスタート！");
            Assert.That(player.AttackFinished == false);
            player.HP = 0;
            player.downJudge();
            Assert.That(battletext.text == $"バトルスタート！\r\n{player.PlayerName}は倒れた");
            Assert.That(player.AttackFinished == true);
            yield return null;
        }
    }
}