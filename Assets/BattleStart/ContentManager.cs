using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MakeParty;
using SQLManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BattleStart
{
    public class ContentManager : MonoBehaviour
    {
        public static List<int> enemyintlist;

        public BattleStart_Repo_Ctrl battleStart_Repo_Ctrl;

        public GameObject enemypanel;

        public GameObject myteampanel;

        List<GameObject> myteampanellist = new List<GameObject>();

        List<GameObject> enemypanellist = new List<GameObject>();

        void Start()
        {
            battleStart_Repo_Ctrl =
                GameObject.Find("Canvas").GetComponent<BattleStart_Repo_Ctrl>();
            for (int i = 0; i < 3; i++)
            {
                myteampanellist
                    .Add(myteampanel
                        .transform
                        .FindChild(i.ToString())
                        .gameObject);
                enemypanellist
                    .Add(enemypanel
                        .transform
                        .FindChild(i.ToString())
                        .gameObject);
            }
            List<PlayerDTO> enemyPlayerDTOList =
                battleStart_Repo_Ctrl.makeEnemyDTOList();
            List<PlayerDTO> myteamPlayerDTOList =
                　battleStart_Repo_Ctrl
                    .makemyTeamDTOList(MakeParty.ContentManager.playerintlist);
            makemyTeamText (myteamPlayerDTOList);
            makeEnemyText (enemyPlayerDTOList);
        }

        void makemyTeamText(List<PlayerDTO> playerDTOlist)
        {
            int count = 0;
            foreach (PlayerDTO playerDTO in playerDTOlist)
            {
                myteampanellist[count]
                    .GetComponentsInChildren<Text>()
                    .First()
                    .text =
                    $"{playerDTO.PlayerName}   {playerDTO.JOB.GetStringValue()}";
                myteampanellist[count]
                    .GetComponentsInChildren<Text>()
                    .Last()
                    .text =
                    $"HP:{playerDTO.HP} STR:{playerDTO.STR} DEF:{playerDTO.DEF} LUCK:{playerDTO.LUCK} " +
                    $"AGI:{playerDTO.AGI} MP:{playerDTO.MP}";
                count++;
            }
        }

        void makeEnemyText(List<PlayerDTO> playerDTOList)
        {
            int count = 0;
            foreach (var playerDTO in playerDTOList)
            {
                enemypanellist[count]
                    .GetComponentsInChildren<Text>()
                    .First()
                    .text =
                    $"{playerDTO.PlayerName}   {playerDTO.JOB.GetStringValue()}";
                enemypanellist[count]
                    .GetComponentsInChildren<Text>()
                    .Last()
                    .text =
                    $"HP:{playerDTO.HP} STR:{playerDTO.STR} DEF:{playerDTO.DEF} " +
                    $"LUCK:{playerDTO.LUCK} AGI{playerDTO.AGI} MP:{playerDTO.MP}";
                count++;
            }
        }

        public void pushRetakeButton()
        {
            List<PlayerDTO> enemyPlayerDTOList =
                battleStart_Repo_Ctrl.makeEnemyDTOList();
            makeEnemyText (enemyPlayerDTOList);
        }

        public void pushStartButton()
        {
            SceneManager.LoadScene("MainBattle");
        }
    }
}
