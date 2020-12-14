using System.Collections;
using System.Collections.Generic;
using BattleScene.Chara;
using BattleScene.Tactics;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.Chara
{
    public class Party
    {
        public TextManager textManager;
        public List<Player> playerList;
        public List<Player> HPascendingList;
        public List<Player> HPdescendingList;
        public List<Player> AGIdescendingList;
        BattleSceneManager battleSceneManager;

        public Party()
        {
            textManager = GameObject.Find("battletext").GetComponent<TextManager>();
            battleSceneManager =
                GameObject.Find("Main Camera").GetComponent<BattleSceneManager>();
            playerList = new List<Player>();
        }

        public void makeSortList()
        {
            HPascendingList = new List<Player>();
            HPdescendingList = new List<Player>();
            AGIdescendingList = new List<Player>();
            foreach (Player player in this.playerList)
            {
                HPascendingList.Add (player);
                HPdescendingList.Add (player);
                AGIdescendingList.Add (player);
            }
            HPascendingList = getHPAscendingList();
            HPdescendingList = getHPDescendingList();
            AGIdescendingList = getAGIDescendingList();
        }

        public void addPlayer(Player player)
        {
            playerList.Add (player);
        }

        public Player getPlayer(int i)
        {
            return playerList[i];
        }

        public void removePlayer(Player player)
        {
            playerList.Remove (player);
        }

        public List<Player> getPlayerList()
        {
            return playerList;
        }

        public bool isGameFinish()
        {
            int liveNumberOnMyTeam = countLivePlayer(Teams.Player);
            int liveNumberOnEnemy = countLivePlayer(Teams.Enemy);
            if ((liveNumberOnMyTeam == 0) || (liveNumberOnEnemy == 0))
            {
                return true;
            }
            return false;
        }

        public int countLivePlayer(Teams team)
        {
            int livePlayerNumber = 0;

            foreach (Player listPlayer in playerList)
            {
                bool isSameTeam = listPlayer.isSameTeam(team);
                bool isLive = listPlayer.isLive();
                if (isSameTeam && isLive)
                {
                    livePlayerNumber++;
                }
            }
            return livePlayerNumber;
        }

        public void resetAttackFinished()
        {
            foreach (Player player in playerList)
            {
                if (player.isLive()) player.AttackFinished = false;
            }
        }

        public List<Player> getHPAscendingList()
        {
            HPascendingList.Sort((a, b) => b.HP - a.HP);
            return HPascendingList;
        }

        public List<Player> getHPDescendingList()
        {
            HPdescendingList.Sort((a, b) => a.HP - b.HP);
            return HPdescendingList;
        }

        public List<Player> getAGIDescendingList()
        {
            AGIdescendingList.Sort((a, b) => a.HP - b.HP);
            return AGIdescendingList;
        }

        public bool isNotTurnFinished()
        {
            if (isGameFinish())
            {
                return false;
            }
            bool isTurnFinished = false;
            foreach (Player player in playerList)
            {
                if (player.canAttack()) isTurnFinished = true;
            }
            return isTurnFinished;
        }

        public Teams getWinTeam()
        {
            int liveNumberOnMyTeam = countLivePlayer(Teams.Player);
            if (liveNumberOnMyTeam == 0)
            {
                return Teams.Enemy;
            }
            return Teams.Player;
        }

        public Player getTargetInAttackTactics(Player attacker)
        {
            getHPDescendingList();
            Player targetPlayer = HPdescendingList.Find(n => ((n.canReceiveAttack(attacker))));
            return targetPlayer;
        }

        public Player getTargetOfHealInBalanceTactics(Player attacker)
        {
            Player targetPlayer;
            do
            {
                targetPlayer = playerList[UnityEngine.Random.Range(0, playerList.Count)];
            }
            while (targetPlayer.isDown());
            return targetPlayer;
        }

        public Player getTargetOfAttackInBalanceTactics(Player attacker)
        {
            Player targetPlayer;
            do
            {
                targetPlayer = playerList[UnityEngine.Random.Range(0, playerList.Count)];
            }
            while (targetPlayer.canNotReceiveAttack(attacker));
            return targetPlayer;
        }

        public Player getTargetInDefenceTactics(Player attacker)
        {
            getHPAscendingList();
            Player targetPlayer = HPascendingList.Find(n => (n.canReceiveAttack(attacker)));
            if (attacker.canUseHeal())
            {
                targetPlayer = HPascendingList.Find(n => (n.canReceiveHeal(attacker)));
            }
            return targetPlayer;
        }

        public Player getAttacker()
        {
            Player attacker = getAGIDescendingList().Find(player => ((player.canAttack())));
            return attacker;
        }
    }
}
