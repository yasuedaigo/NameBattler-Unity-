using System;
using System.Collections;
using System.Collections.Generic;
using AllChara;
using BattleScene.Chara;
using BattleScene.Tactics;
using BattleStart;
using MakeParty;
using SQLManager;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene
{
    public class BattleManager : MonoBehaviour
    {
        TextManager textManager = null;
        BattleSceneManager battleSceneManager;
        public TacticsManager tacticsManager;
        public ITactics itactics;
        public GameObject statusPanel;
        public List<GameObject> statusPanelList;
        public Party party;
        int turnNumber;
        public List<int> playerIdList;
        public List<int> enemyIdList;

        void Start()
        {
            turnNumber = 1;
            textManager = GameObject.Find("battletext").GetComponent<TextManager>();
            tacticsManager = GameObject.Find("Main Camera").GetComponent<TacticsManager>();
            battleSceneManager =
                GameObject.Find("Main Camera").GetComponent<BattleSceneManager>();
            statusPanel = GameObject.Find("StatusPanel");
            foreach (Transform childTransform in statusPanel.transform)
            {
                statusPanelList.Add(childTransform.gameObject);
            }
            party = new Party();
            addPlayertoParty(BattleStartController.myTeamPlayerDTOList,Teams.Player);
            addPlayertoParty(BattleStartController.enemyPlayerDTOList,Teams.Enemy);
            party.makeSortList();
            drowStatus();
        }

        public void oneTurnProcedure()
        {
            textManager.battleLog($"{turnNumber}ターン目");
            Player attacker;
            Player defender;
            int defenderId;
            party.resetAttackFinished();

            while (party.isNotTurnFinished())
            {
                attacker = party.getAttacker();
                defender = tacticsManager.choiceTactics.target(party, attacker);
                attacker.Attack (defender, turnNumber);
                drowStatus();
            }

            if (party.isGameFinish())
            {
                gameFinish();
            }
            this.poisonDamage();
            textManager.battleLog("---------------------------------------");
            turnNumber++;
        }

        public void drowStatus()
        {
            for (int i = 0; i < party.playerList.Count; i++)
            {
                party.playerList[i].drowStatusText(statusPanelList[i]);
            }
        }

        public void poisonDamage()
        {
            foreach (Player player in party.playerList)
            {
                player.poisonDamage();
                drowStatus();
                if (party.isGameFinish())
                {
                    this.gameFinish();
                }
            }
        }

        public void addPlayertoParty(List<PlayerDTO> playerDTOList, Teams team)
        {
            foreach (PlayerDTO playerDTO in playerDTOList)
            {
                Player player = null;
                Type type = Type.GetType("BattleScene.Chara." +playerDTO.JOB.ToString());
                player = (Player) Activator.CreateInstance(type, playerDTO);
                player.Team = team;
                party.addPlayer (player);
            }
        }

        public void gameFinish()
        {
            Teams winTeam = party.getWinTeam();
            textManager.battleLog("ゲームセット！");
            if (winTeam == Teams.Player)
                battleSceneManager.loadWinScene();
            else
                battleSceneManager.loadLoseScene();
        }
    }
}
