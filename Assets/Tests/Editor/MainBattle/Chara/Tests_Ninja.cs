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
    public class Tests_Ninja
    {
        Text battletext = GameObject.Find("battletext").GetComponent<Text>();
        Testtool_Chara testtool_chara = new Testtool_Chara();

        [UnityTest]
        public IEnumerator test_firstturnAttack()
        {
            Player attacker = testtool_chara.prepareNinja("testattacker",5,10,5,0,5,0);
            Player defender = testtool_chara.prepareNinja("testdefender",100,5,2,1,5,0);
            attacker.Abnormality = Abnormalitys.Parise;
            int criticaldamage = 10;
            string criticalattackText = $"バトルスタート！\r\n{attacker.PlayerName}の攻撃 ➡ {defender.PlayerName}に{criticaldamage}のダメージ";
            attacker.Attack(defender,1);
            Assert.That(battletext.text == criticalattackText);
            Assert.That(defender.HP == 90);
            Assert.That(attacker.AttackFinished = true);
            yield return null;
        }

        [UnityTest]
        public IEnumerator test_Attacktofighter()
        {
            Player attacker = testtool_chara.prepareNinja("testattacker",5,10,5,0,5,0);
            Player defender = testtool_chara.prepareFighter("testdefender",100,5,2,1,5,0);
            attacker.Abnormality = Abnormalitys.Parise;
            int normaldamage = 9;
            string normalattackText = $"バトルスタート！\r\n{attacker.PlayerName}の攻撃 ➡ {defender.PlayerName}に{normaldamage}のダメージ";
            attacker.Attack(defender,2);
            Assert.That(battletext.text == normalattackText);
            Assert.That(defender.HP == 91);
            Assert.That(attacker.AttackFinished = true);
            Assert.That(defender.DEF == 2);
            yield return null;
        }

        [UnityTest]
        public IEnumerator test_secondturnAttack()
        {
            int normalcount = 0;
            int criticalcount = 0;
            for(int i = 0; i <12; i++){
                battletext.text = "バトルスタート！";
                Player attacker = testtool_chara.prepareNinja("testattacker",5,10,5,50,5,0);
                Player defender = testtool_chara.prepareWizard("testdefender",100,5,2,1,5,0);
                attacker.Abnormality = Abnormalitys.Parise;
                int normaldamage = 8;
                int criticaldamage = 10;
                string normalattackText = $"バトルスタート！\r\n{attacker.PlayerName}の攻撃 ➡ {defender.PlayerName}に{normaldamage}のダメージ";
                string criticalattackText = $"バトルスタート！\r\n{attacker.PlayerName}の攻撃 ➡ {defender.PlayerName}に{criticaldamage}のダメージ";
                attacker.Attack(defender,2);
                if(battletext.text == normalattackText)
                {
                    Assert.That(defender.HP == 92);
                    Assert.That(attacker.AttackFinished = true);
                    normalcount++;
                }else if(battletext.text == criticalattackText)
                {
                    Assert.That(defender.HP == 90);
                    Assert.That(attacker.AttackFinished = true);
                    criticalcount++;
                }
            }
            Assert.That((criticalcount + normalcount) == 12);
            Assert.That(criticalcount >= 1);
            Assert.That(normalcount >= 1);
            yield return null;
        }
    }
}