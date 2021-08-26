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
using Tests;

namespace BattleSceneTests
{
    public class Tests_Priest
    {
        Text battletext = GameObject.Find("battletext").GetComponent<Text>();
        Testtool_Chara testtool_chara = new Testtool_Chara();
        
        [UnityTest]
        public IEnumerator test_firstturnAttack()
        {
            int poisoncount = 0;
            int parisecount = 0;
            String poisonText = "";
            String pariseText =  "";
            for(int i = 0; i <15; i++)
            {
                battletext.text = "バトルスタート！";
                Player attacker = testtool_chara.preparePriest("testattacker",5,5,5,0,5,50);
                Player defender = testtool_chara.prepareNinja("testdefender",100,5,1,1,5,0);
                attacker.Team = Teams.Player;
                defender.Team = Teams.Enemy;
                attacker.Attack(defender,1);
                poisonText = $"バトルスタート！\r\n{attacker.PlayerName}のポイズン！ ➡ {defender.PlayerName}は毒状態になった";
                pariseText = $"バトルスタート！\r\n{attacker.PlayerName}のパライズ！ ➡ {defender.PlayerName}は麻痺状態になった";
                if(battletext.text == poisonText)
                {
                    poisoncount++;
                    Assert.That(defender.Abnormality == Abnormalitys.Poison);
                    Assert.That(defender.HP == 100);
                    Assert.That(attacker.AttackFinished = true);
                    Assert.That(attacker.MP == 35);
                }else if(battletext.text == pariseText)
                {
                    parisecount++;
                    Assert.That(defender.Abnormality == Abnormalitys.Parise);
                    Assert.That(defender.HP == 100);
                    Assert.That(attacker.AttackFinished = true);
                    Assert.That(attacker.MP == 35);
                }else
                {
                    Debug.Log(battletext.text);
                    Debug.Log(attacker.JOB);
                    Debug.Log("priestのテスト");
                    Assert.True(false);
                }
            }
                Assert.That(poisoncount >= 1);
                Assert.That(parisecount >= 1);
                yield return null;
        }

        [UnityTest]
        public IEnumerator test_normalattack()
        {
            string normalattackText;
            int normaldamage = 4;
            battletext.text = "バトルスタート！";
            Player attacker = testtool_chara.preparePriest("testattacker",5,5,5,0,5,50);
            attacker.Team = Teams.Player;
            Player defender = testtool_chara.prepareNinja("testdefender",100,5,1,1,5,0);
            defender.Team = Teams.Enemy;
            attacker.Attack(defender,2);
            int damage = 4;
            normalattackText = $"バトルスタート！\r\n{attacker.PlayerName}の攻撃 ➡ {defender.PlayerName}に{damage}のダメージ";
            Assert.That(battletext.text == normalattackText);
            Assert.That(attacker.MP == 50);
            Assert.That(defender.HP == 96);
            Assert.That(attacker.AttackFinished = true);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator test_heal()
        {
            Player attacker = testtool_chara.preparePriest("testattacker",5,5,5,0,5,50);
            attacker.Team = Teams.Player; 
            Player defender = testtool_chara.prepareNinja("testdefender",100,5,1,1,5,0);
            defender.Team = Teams.Player;
            string healText = $"バトルスタート！\r\n{attacker.PlayerName}のヒール ➡ {defender.PlayerName}のHPを50回復" +
                $"({defender.HP}➡({defender.HP}+50))";
            attacker.Attack(defender,2);
            Assert.That(battletext.text == healText);
            Assert.That(attacker.MP == 25);
            Assert.That(defender.HP == 150);
            Assert.That(attacker.AttackFinished = true);
            yield return null;
        }
    }
}