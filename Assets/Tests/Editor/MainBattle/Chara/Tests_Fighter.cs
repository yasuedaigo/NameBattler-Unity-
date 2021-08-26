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

namespace BattleSceneTests
{
    public class Tests_Fighter
    {
        Text battletext = GameObject.Find("battletext").GetComponent<Text>();
        Testtool_Chara testtool_chara = new Testtool_Chara();

        [UnityTest]
        public IEnumerator test_criticalAttack()
        {
            Player attacker = testtool_chara.prepareFighter("testattacker",5,5,5,100,5,0);
            Player defender = testtool_chara.prepareFighter("testdefender",100,5,1,5,5,0);
            int criticaldamage = 5;
            string criticalattackText = $"バトルスタート！\r\n{attacker.PlayerName}の攻撃 ➡ {defender.PlayerName}に{criticaldamage}のダメージ";
            attacker.Attack(defender,1);
            Assert.That(battletext.text == criticalattackText);
            Assert.That(defender.HP == 95);
            Assert.That(attacker.AttackFinished = true);
            yield return null;
        }

        [UnityTest]
        public IEnumerator test_normalAttack()
        {
            Player attacker = testtool_chara.prepareFighter("testattacker",5,5,5,0,5,0);
            Player defender = testtool_chara.prepareFighter("testdefender",100,5,1,5,5,0);
            int normaldamage = 4;
            string normalattackText = $"バトルスタート！\r\n{attacker.PlayerName}の攻撃 ➡ {defender.PlayerName}に{normaldamage}のダメージ";
            attacker.Attack(defender,1);
            Assert.That(battletext.text == normalattackText);
            Assert.That(defender.HP == 96);
            Assert.That(attacker.AttackFinished = true);
            yield return null;
        }


        [UnityTest]
        public IEnumerator test_pariseAttack()
        {   
            int parisecount = 0;
            int normalcount = 0;
            for(int i = 0; i <12; i++)
            {
                battletext.text = "バトルスタート！";
                Player attacker = testtool_chara.prepareFighter("testattacker",5,5,5,0,5,0);
                Player defender = testtool_chara.prepareFighter("testdefender",100,5,1,5,5,0);
                int normaldamage = 4;
                string normalattackText = $"バトルスタート！\r\n{attacker.PlayerName}の攻撃 ➡ {defender.PlayerName}に{normaldamage}のダメージ";
                string parisetext = $"バトルスタート！\r\n{attacker.PlayerName}は麻痺した";
                attacker.Abnormality = Abnormalitys.Parise;
                attacker.Attack(defender,1);
                if(battletext.text == parisetext)
                {
                    Assert.That(defender.HP == 100);
                    Assert.That(attacker.AttackFinished = true);
                    parisecount++;
                }
                else if(battletext.text == normalattackText)
                {
                    Assert.That(defender.HP == 96);
                    Assert.That(attacker.AttackFinished = true);
                    normalcount++;
                }
            }
            Assert.That((parisecount + normalcount) == 12);
            Assert.That(parisecount >= 1);
            yield return null;
        }
    }
}