using System.Collections;
using UnityEngine.TestTools;
using UnityEngine;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using SQLManager;
using MakeChara;
using MakeCharaResult;

namespace MakeCharaResultTests
{
    public class Tests_MakeCharaResult
    {
        MakeCharaResultViewManager makeCharaResultViewManager;
        JobSelectToggleManager jobselecttogglemanager;
        Text messageText;
        PlayerDTO playerDTO;
        CharacterRepository characterrepository;
        MakeCharaResultController makeCharaResultController;

        [UnityTest]
        public IEnumerator tests_makechara()
        {
            characterrepository = new CharacterRepository();
            makeCharaResultViewManager = GameObject.Find("キャラ作成ステータス").GetComponent<MakeCharaResultViewManager>();
            makeCharaResultController  = GameObject.Find("キャラ作成ステータス").GetComponent<MakeCharaResultController>();
            makeCharaResultController.Start();
            for (int i = 0; i < 50; i++)
            {
            InputFieldManager.charaName = i.ToString();
            JobSelectToggleManager.PlayerMaker = new Fighter();
            makeCharaResultViewManager.Start();
            DateTime dt = DateTime.Now;
            playerDTO = makeCharaResultViewManager.getplayerDTO();
            Assert.That(playerDTO.PlayerName == i.ToString());
            Assert.That(playerDTO.HP >= 100);
            Assert.That(playerDTO.HP <= 300);
            Assert.That(playerDTO.STR >= 30);
            Assert.That(playerDTO.STR <= 100);
            Assert.That(playerDTO.DEF >= 30);
            Assert.That(playerDTO.DEF <= 100);
            Assert.That(playerDTO.LUCK >= 1);
            Assert.That(playerDTO.LUCK <= 100);
            Assert.That(playerDTO.AGI >= 1);
            Assert.That(playerDTO.AGI <= 50);
            Assert.That(playerDTO.MP == 0);
            Assert.That(playerDTO.JOB == JOBs.Fighter);
            Assert.That(playerDTO.CreateDay == dt.ToString("yyyy-MM-dd"));
            int deleterow = characterrepository.countTableRows(TableNames.CHARACTER) - 1;
            characterrepository.deletemyTeamPlayer(deleterow);
            }
            for (int i = 0; i < 50; i++)
            {
            InputFieldManager.charaName = i.ToString();
            JobSelectToggleManager.PlayerMaker = new Priest();
            makeCharaResultViewManager.Start();
            DateTime dt = DateTime.Now;
            playerDTO = makeCharaResultViewManager.getplayerDTO();
            Assert.That(playerDTO.PlayerName == i.ToString());
            Assert.That(playerDTO.HP >= 80);
            Assert.That(playerDTO.HP <= 200);
            Assert.That(playerDTO.STR >= 10);
            Assert.That(playerDTO.STR <= 70);
            Assert.That(playerDTO.DEF >= 10);
            Assert.That(playerDTO.DEF <= 70);
            Assert.That(playerDTO.LUCK >= 1);
            Assert.That(playerDTO.LUCK <= 100);
            Assert.That(playerDTO.AGI >= 20);
            Assert.That(playerDTO.AGI <= 60);
            Assert.That(playerDTO.MP >= 20);
            Assert.That(playerDTO.MP <= 50);
            Assert.That(playerDTO.JOB == JOBs.Priest);
            Assert.That(playerDTO.CreateDay == dt.ToString("yyyy-MM-dd"));
            int deleterow = characterrepository.countTableRows(TableNames.CHARACTER) - 1;
            characterrepository.deletemyTeamPlayer(deleterow);
            }
            for (int i = 0; i < 50; i++)
            {
            InputFieldManager.charaName = i.ToString();
            JobSelectToggleManager.PlayerMaker = new Ninja();
            makeCharaResultViewManager.Start();
            DateTime dt = DateTime.Now;
            playerDTO = makeCharaResultViewManager.getplayerDTO();
            Assert.That(playerDTO.PlayerName == i.ToString());
            Assert.That(playerDTO.HP >= 100);
            Assert.That(playerDTO.HP <= 200);
            Assert.That(playerDTO.STR >= 20);
            Assert.That(playerDTO.STR <= 70);
            Assert.That(playerDTO.DEF >= 20);
            Assert.That(playerDTO.DEF <= 90);
            Assert.That(playerDTO.LUCK >= 1);
            Assert.That(playerDTO.LUCK <= 100);
            Assert.That(playerDTO.AGI >= 40);
            Assert.That(playerDTO.AGI <= 80);
            Assert.That(playerDTO.MP == 0);
            Assert.That(playerDTO.JOB == JOBs.Ninja);
            Assert.That(playerDTO.CreateDay == dt.ToString("yyyy-MM-dd"));
            int deleterow = characterrepository.countTableRows(TableNames.CHARACTER) - 1;
            characterrepository.deletemyTeamPlayer(deleterow);
            }
            for (int i = 0; i < 50; i++)
            {
            InputFieldManager.charaName = i.ToString();
            JobSelectToggleManager.PlayerMaker = new Wizard();
            makeCharaResultViewManager.Start();
            DateTime dt = DateTime.Now;
            playerDTO = makeCharaResultViewManager.getplayerDTO();
            Assert.That(playerDTO.PlayerName == i.ToString());
            Assert.That(playerDTO.HP >= 50);
            Assert.That(playerDTO.HP <= 150);
            Assert.That(playerDTO.STR >= 30);
            Assert.That(playerDTO.STR <= 80);
            Assert.That(playerDTO.DEF >= 30);
            Assert.That(playerDTO.DEF <= 80);
            Assert.That(playerDTO.LUCK >= 1);
            Assert.That(playerDTO.LUCK <= 100);
            Assert.That(playerDTO.AGI >= 1);
            Assert.That(playerDTO.AGI <= 40);
            Assert.That(playerDTO.MP >= 30);
            Assert.That(playerDTO.MP <= 80);
            Assert.That(playerDTO.JOB == JOBs.Wizard);
            Assert.That(playerDTO.CreateDay == dt.ToString("yyyy-MM-dd"));
            int deleterow = characterrepository.countTableRows(TableNames.CHARACTER) - 1;
            characterrepository.deletemyTeamPlayer(deleterow);
            }
            yield return null;
        }

    }
}