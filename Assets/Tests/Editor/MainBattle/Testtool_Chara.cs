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
using MakeCharaResult;
using UnityEditor;

namespace BattleSceneTests
{
    public class Testtool_Chara
    {
        //[UnityTest]
        public BattleScene.Chara.Fighter prepareFighter(string name,int hp,int str,int def,int luck,int agi,int mp)
        {
            PlayerDTO playerDTO = new PlayerDTO();
            playerDTO.PlayerName = name;
            playerDTO.HP = hp;
            playerDTO.STR = str;
            playerDTO.DEF = def;
            playerDTO.LUCK = luck;
            playerDTO.AGI = agi;
            playerDTO.MP = mp;
            playerDTO.JOB = JOBs.Fighter;
            playerDTO.CreateDay = "0000-00-00";
            BattleScene.Chara.Fighter player = new BattleScene.Chara.Fighter(playerDTO);
            player.textmanager.Start();
            return player;
        }

        public BattleScene.Chara.Ninja prepareNinja(string name,int hp,int str,int def,int luck,int agi,int mp)
        {
            PlayerDTO playerDTO = new PlayerDTO();
            playerDTO.PlayerName = name;
            playerDTO.HP = hp;
            playerDTO.STR = str;
            playerDTO.DEF = def;
            playerDTO.LUCK = luck;
            playerDTO.AGI = agi;
            playerDTO.MP = mp;
            playerDTO.JOB = JOBs.Ninja;
            playerDTO.CreateDay = "0000-00-00";
            BattleScene.Chara.Ninja player = new BattleScene.Chara.Ninja(playerDTO);
            player.textmanager.Start();
            return player;
        }

        public BattleScene.Chara.Wizard prepareWizard(string name,int hp,int str,int def,int luck,int agi,int mp)
        {
            PlayerDTO playerDTO = new PlayerDTO();
            playerDTO.PlayerName = name;
            playerDTO.HP = hp;
            playerDTO.STR = str;
            playerDTO.DEF = def;
            playerDTO.LUCK = luck;
            playerDTO.AGI = agi;
            playerDTO.MP = mp;
            playerDTO.JOB = JOBs.Wizard;
            playerDTO.CreateDay = "0000-00-00";
            BattleScene.Chara.Wizard player = new BattleScene.Chara.Wizard(playerDTO);
            player.textmanager.Start();
            return player;
        }

        public BattleScene.Chara.Priest preparePriest(string name,int hp,int str,int def,int luck,int agi,int mp)
        {
            PlayerDTO playerDTO = new PlayerDTO();
            playerDTO.PlayerName = name;
            playerDTO.HP = hp;
            playerDTO.STR = str;
            playerDTO.DEF = def;
            playerDTO.LUCK = luck;
            playerDTO.AGI = agi;
            playerDTO.MP = mp;
            playerDTO.JOB = JOBs.Priest;
            playerDTO.CreateDay = "0000-00-00";
            BattleScene.Chara.Priest player = new BattleScene.Chara.Priest(playerDTO);
            player.textmanager.Start();
            return player;
        }

        public SQLManager.PlayerDTO prepareFighterDTO(string name,int hp,int str,int def,int luck,int agi,int mp)
        {
            PlayerDTO playerDTO = new PlayerDTO();
            playerDTO.PlayerName = name;
            playerDTO.HP = hp;
            playerDTO.STR = str;
            playerDTO.DEF = def;
            playerDTO.LUCK = luck;
            playerDTO.AGI = agi;
            playerDTO.MP = mp;
            playerDTO.JOB = JOBs.Fighter;
            playerDTO.CreateDay = "0000-00-00";
            return playerDTO;
        }
    }
}