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
        [UnityTest]
        public IEnumerator test_Attack()
        {
            PlayerDTO attackerDTO = new PlayerDTO();
            attackerDTO.PlayerName = "testAttacker";
            attackerDTO.HP = 5;
            attackerDTO.STR = 5;
            attackerDTO.DEF = 5;
            attackerDTO.LUCK = 100;
            attackerDTO.AGI = 5;
            attackerDTO.MP = 0;
            attackerDTO.JOB = JOBs.Ninja;
            attackerDTO.CreateDay = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Player attacker = new Player(attackerDTO);
            attacker.textmanager.Start();
            PlayerDTO defenderDTO = new PlayerDTO();
            defenderDTO = new PlayerDTO();
            defenderDTO.PlayerName = "testDefender";
            defenderDTO.HP = 100;
            defenderDTO.STR = 5;
            defenderDTO.DEF = 1;
            defenderDTO.LUCK = 5;
            defenderDTO.AGI = 5;
            defenderDTO.MP = 0;
            defenderDTO.JOB = JOBs.Fighter;
            defenderDTO.CreateDay = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Player defender = new Player(defenderDTO);
            defender.textmanager.Start();
            Text battletext = GameObject.Find("battletext").GetComponent<Text>();
            /*PlayerDTO attackerDTO = new PlayerDTO();
            attackerDTO.PlayerName = "testAttacker";
            attackerDTO.HP = 5;
            attackerDTO.STR = 5;
            attackerDTO.DEF = 5;
            attackerDTO.LUCK = 100;
            attackerDTO.AGI = 5;
            attackerDTO.MP = 0;
            attackerDTO.JOB = JOBs.Fighter;
            attackerDTO.CreateDay = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Player attacker = new Player(attackerDTO);
            attacker.textmanager.Start();
            PlayerDTO defenderDTO = new PlayerDTO();
            defenderDTO = new PlayerDTO();
            defenderDTO.PlayerName = "testDefender";
            defenderDTO.HP = 100;
            defenderDTO.STR = 5;
            defenderDTO.DEF = 1;
            defenderDTO.LUCK = 5;
            defenderDTO.AGI = 5;
            defenderDTO.MP = 0;
            defenderDTO.JOB = JOBs.Fighter;
            defenderDTO.CreateDay = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Player defender = new Player(defenderDTO);
            defender.textmanager.Start();
            Text battletext = GameObject.Find("battletext").GetComponent<Text>();
            int criticaldamage = 5;
            int normaldamage = 4;
            string criticalattackText = $"バトルスタート！\r\n{attacker.PlayerName}の攻撃 ➡ {defender.PlayerName}に{criticaldamage}のダメージ";
            string normalattackText = $"バトルスタート！\r\n{attacker.PlayerName}の攻撃 ➡ {defender.PlayerName}に{normaldamage}のダメージ";
            attacker.Attack(defender,1);
            Assert.That(battletext.text == criticalattackText);
            Assert.That(defender.HP == 95);
            Assert.That(attacker.AttackFinished = true);
            attacker.LUCK = 0;
            attacker.AttackFinished = false;
            defender.HP = 100;
            battletext.text = "バトルスタート！";
            attacker.Attack(defender,1);
            Assert.That(battletext.text == normalattackText);
            Assert.That(defender.HP == 96);
            Assert.That(attacker.AttackFinished = true);
            yield return null;*/
        }
    }
}