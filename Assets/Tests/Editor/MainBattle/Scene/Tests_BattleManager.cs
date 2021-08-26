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
using BattleStart;

namespace BattleSceneTests
{
    public class Tests_BattleManager
    {
        Text battletext = GameObject.Find("battletext").GetComponent<Text>();
        Testtool_Chara testtool_chara = new Testtool_Chara();
        BattleManager battlemanager = GameObject.Find("battletext").GetComponent<BattleManager>();
        TextManager textmanager = GameObject.Find("battletext").GetComponent<TextManager>();
        TacticsManager tacticsmanager = GameObject.Find("Main Camera").GetComponent<TacticsManager>();

        
        [UnityTest]
        public IEnumerator Test_oneTurnProcedure()
        {
            textmanager.Start();
            tacticsmanager.choiceTactics = new DefenceTactics();
            PlayerDTO player0 = testtool_chara.prepareFighterDTO("0",10,5,0,0,50,0);
            PlayerDTO player1 = testtool_chara.prepareFighterDTO("1",0,5,0,0,0,0);
            PlayerDTO player2 = testtool_chara.prepareFighterDTO("2",0,5,0,0,0,0);
            PlayerDTO player3 = testtool_chara.prepareFighterDTO("3",10,5,0,0,1,0);
            PlayerDTO player4 = testtool_chara.prepareFighterDTO("4",0,5,0,0,0,0);
            PlayerDTO player5 = testtool_chara.prepareFighterDTO("5",0,5,0,0,0,0);
            BattleStartController.enemyPlayerDTOList = new List<PlayerDTO>();
            BattleStartController.myTeamPlayerDTOList = new List<PlayerDTO>();
            BattleStartController.myTeamPlayerDTOList.Add(player0);
            BattleStartController.myTeamPlayerDTOList.Add(player1);
            BattleStartController.myTeamPlayerDTOList.Add(player2);
            BattleStartController.enemyPlayerDTOList.Add(player3);
            BattleStartController.enemyPlayerDTOList.Add(player4);
            BattleStartController.enemyPlayerDTOList.Add(player5);
            battlemanager.Start();
            battlemanager.oneTurnProcedure();
            Assert.That(battletext.text == "バトルスタート！\r\n1ターン目\r\n0の攻撃 ➡ 3に5のダメージ\r\n3の攻撃 ➡ 0に5のダメージ\r\n---------------------------------------");
            battletext.text = "";
            battlemanager.oneTurnProcedure();
            Debug.Log(battletext.text);
            Assert.That(battletext.text == "\r\n2ターン目\r\n0の攻撃 ➡ 3に5のダメージ\r\n3は倒れた");
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_poisonDamage()
        {
            textmanager.Start();
            tacticsmanager.choiceTactics = new DefenceTactics();
            PlayerDTO player0 = testtool_chara.prepareFighterDTO("0",10,0,0,0,50,0);
            PlayerDTO player1 = testtool_chara.prepareFighterDTO("1",0,0,0,0,0,0);
            PlayerDTO player2 = testtool_chara.prepareFighterDTO("2",0,0,0,0,0,0);
            PlayerDTO player3 = testtool_chara.prepareFighterDTO("3",10,0,0,0,1,0);
            PlayerDTO player4 = testtool_chara.prepareFighterDTO("4",0,0,0,0,0,0);
            PlayerDTO player5 = testtool_chara.prepareFighterDTO("5",0,0,0,0,0,0);
            BattleStartController.enemyPlayerDTOList = new List<PlayerDTO>();
            BattleStartController.myTeamPlayerDTOList = new List<PlayerDTO>();
            BattleStartController.myTeamPlayerDTOList.Add(player0);
            BattleStartController.myTeamPlayerDTOList.Add(player1);
            BattleStartController.myTeamPlayerDTOList.Add(player2);
            BattleStartController.enemyPlayerDTOList.Add(player3);
            BattleStartController.enemyPlayerDTOList.Add(player4);
            BattleStartController.enemyPlayerDTOList.Add(player5);
            battlemanager.Start();
            battlemanager.party.getPlayer(3).Abnormality = Abnormalitys.Poison;
            battlemanager.oneTurnProcedure();
            Debug.Log(battletext.text);
            Assert.That(battletext.text == "バトルスタート！\r\n1ターン目\r\n0の攻撃 ➡ 3に0のダメージ\r\n3の攻撃 ➡ 0に0のダメージ\r\n3は毒によるダメージを受けた\r\n3は倒れた\r\n---------------------------------------");
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_tacticsButton()
        {
            tacticsmanager.choiceTactics = new DefenceTactics();
            GameObject tacticsobject = GameObject.Find("Main Camera").transform.Find("Tacticsobject").gameObject;
            tacticsobject.SetActive(true);
            Toggle attacktoggle = GameObject.Find("attacktoggle").GetComponent<Toggle>();
            attacktoggle.isOn = true;
            tacticsmanager.selectAttackTactics();
            Debug.Log(tacticsmanager.choiceTactics);
            Assert.That(tacticsmanager.choiceTactics.GetType() == typeof(BattleScene.Tactics.AttackTactics));
            Toggle balancetoggle = GameObject.Find("balancetoggle").GetComponent<Toggle>();
            balancetoggle.isOn = true;
            tacticsmanager.selectBalanceTactics();
            Assert.That(tacticsmanager.choiceTactics.GetType() == typeof(BattleScene.Tactics.BalanceTactics));
            Toggle defencetoggle = GameObject.Find("defensetoggle").GetComponent<Toggle>();
            defencetoggle.isOn = true;
            tacticsmanager.selectDefenceTactics();
            Assert.That(tacticsmanager.choiceTactics.GetType() == typeof(BattleScene.Tactics.DefenceTactics));
            yield return null;
        }
    }
}