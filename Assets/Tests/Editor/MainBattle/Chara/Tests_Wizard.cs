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
    public class Tests_Wizard
    {
        Text battletext = GameObject.Find("battletext").GetComponent<Text>();
        Testtool_Chara testtool_chara = new Testtool_Chara();
        
        [UnityTest]
        public IEnumerator test_Attackfirst()
        {
            int firecount = 0;
            int thundercount = 0;
            String fireText = "";
            String thunderText =  "";
            for(int i = 0; i <12; i++)
            {
                battletext.text = "バトルスタート！";
                Player attacker = testtool_chara.prepareWizard("testattacker",5,5,5,0,5,25);
                Player defender = testtool_chara.prepareNinja("testdefender",100,5,1,1,5,0);
                int normaldamage = 4;
                attacker.Attack(defender,1);
                int damage = 100 - defender.HP;
                fireText = $"バトルスタート！\r\n{attacker.PlayerName}のファイア！   {defender.PlayerName}に{damage}のダメージ";
                thunderText = $"バトルスタート！\r\n{attacker.PlayerName}のサンダー！   {defender.PlayerName}に{damage}のダメージ";
                if(battletext.text == fireText)
                {
                    firecount++;
                    Assert.That(defender.HP >= 70);
                    Assert.That(defender.HP <= 90);
                    Assert.That(attacker.AttackFinished = true);
                    Assert.That(attacker.MP == 5);
                }else if(battletext.text == thunderText)
                {
                    
                    thundercount++;
                    Assert.That(defender.HP >= 70);
                    Assert.That(defender.HP <= 80);
                    Assert.That(attacker.AttackFinished = true);
                    Assert.That(attacker.MP == 0);
                }
            }
                Assert.That((firecount+thundercount) == 12);
                Assert.That(firecount >= 1);
                Assert.That(thundercount >= 1);
                yield return null;
        }

        [UnityTest]
        public IEnumerator test_Attacksecond()
        {
            int firecount = 0;
            int normalcount = 0;
            string fireText = "";
            string normalattackText;
            int normaldamage = 4;
            for(int i = 0; i <24; i++)
            {
                battletext.text = "バトルスタート！";
                Player attacker = testtool_chara.prepareWizard("testattacker",5,5,5,0,5,20);
                if(i >= 12)
                {
                    attacker.MP = 24;
                }
                Player defender = testtool_chara.prepareNinja("testdefender",100,5,1,1,5,0);
                attacker.Attack(defender,1);
                int damage = 100 - defender.HP;
                fireText = $"バトルスタート！\r\n{attacker.PlayerName}のファイア！   {defender.PlayerName}に{damage}のダメージ";
                normalattackText = $"バトルスタート！\r\n{attacker.PlayerName}の攻撃 ➡ {defender.PlayerName}に{normaldamage}のダメージ";
                if(battletext.text == fireText)
                {
                    firecount++;
                    Assert.That(defender.HP >= 70);
                    Assert.That(defender.HP <= 90);
                    Assert.That(attacker.AttackFinished = true);
                    if(i<12)
                    {
                        Assert.That(attacker.MP == 0);
                    }else
                    {
                        Assert.That(attacker.MP == 4);
                    }
                    
                }else if(battletext.text == normalattackText)
                {
                    normalcount++;
                    Assert.That(defender.HP == 96);
                    if(i<12)
                    {
                        Assert.That(attacker.MP == 20);
                    }else
                    {
                        Assert.That(attacker.MP == 24);
                    }
                    Assert.That(attacker.AttackFinished = true);
                }else
                {
                    Assert.True(false);
                }
            }
            Assert.That(firecount >= 1);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator test_Attackthird()
        {
            string normalattackText;
            int normaldamage = 4;
            for(int i = 0; i <24; i++)
            {
                battletext.text = "バトルスタート！";
                Player attacker = testtool_chara.prepareWizard("testattacker",5,5,5,0,5,19);
                Player defender = testtool_chara.prepareNinja("testdefender",100,5,1,1,5,0);
                attacker.Attack(defender,1);
                normalattackText = $"バトルスタート！\r\n{attacker.PlayerName}の攻撃 ➡ {defender.PlayerName}に{normaldamage}のダメージ";
                if(battletext.text == normalattackText)
                {
                    Assert.That(attacker.MP == 19);
                    Assert.That(defender.HP == 96);
                    Assert.That(attacker.AttackFinished = true);
                }else
                {
                    Assert.True(false);
                }
            }
            yield return null;
        }
    }
}