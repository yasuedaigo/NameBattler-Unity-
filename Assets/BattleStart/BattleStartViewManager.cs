using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MakeParty;
using SQLManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ViewManager;

namespace BattleStart
{
    public class BattleStartViewManager : MonoBehaviour
    {
        public static List<int> enemyIdList;
        public BattleStartController battleStartController;
        public GameObject enemyBasePanel;
        public GameObject myTeamBasePanel;
        public GameObject playerButton;
        PlayerButtonManager playerButtonManager;
        List<Text> myTeamNameTextList = new List<Text>();
        List<Text> myTeamStatusTextList = new List<Text>();
        List<Text> enemyNameTextList = new List<Text>();
        List<Text> enemyStatusTextList = new List<Text>();
        List<PlayerDTO> myTeamPlayerDTOList = new List<PlayerDTO>();
        List<PlayerDTO> enemyPlayerDTOList = new List<PlayerDTO>();
        List<GameObject> myTeamButtonList = new List<GameObject>();
        List<GameObject> enemyButtonList = new List<GameObject>();

        void Start()
        {
            playerButtonManager = GameObject.Find("Main Camera").GetComponent<PlayerButtonManager>();
            battleStartController = GameObject.Find("Canvas").GetComponent<BattleStartController>();
            enemyPlayerDTOList = battleStartController.makeEnemyDTOList();
            myTeamPlayerDTOList = battleStartController
                .makeMyTeamDTOList(MakeParty.MakePartyViewManager.myTeamPlayerIdList);
            playerButtonManager
                .createPlayerButton(playerButton,MakePartyViewManager.CHARA_NUMBER_OF_PARTY,myTeamBasePanel);
            playerButtonManager
                .createPlayerButton(playerButton,MakePartyViewManager.CHARA_NUMBER_OF_PARTY,enemyBasePanel);
            makeList();
            PlayerTextManager.drowNameAndJob (myTeamNameTextList,myTeamPlayerDTOList);
            PlayerTextManager.drowStatus (myTeamStatusTextList, myTeamPlayerDTOList);
            PlayerTextManager.drowNameAndJob (enemyNameTextList, enemyPlayerDTOList);
            PlayerTextManager.drowStatus (enemyStatusTextList, enemyPlayerDTOList);
            this.buttonInteractable(myTeamButtonList);
            this.buttonInteractable(enemyButtonList);
        }

        public void reselectEnemy()
        {
            List<PlayerDTO> enemyPlayerDTOList = battleStartController.makeEnemyDTOList();
            PlayerTextManager.drowNameAndJob (enemyNameTextList, enemyPlayerDTOList);
            PlayerTextManager.drowStatus (enemyStatusTextList, enemyPlayerDTOList);
            this.buttonInteractable(enemyButtonList);
        }

        void makeList()
        {
            for (int i = 0; i < MakePartyViewManager.CHARA_NUMBER_OF_PARTY; i++)
            {
                myTeamButtonList.Add(myTeamBasePanel.transform.GetChild(i).gameObject);
                enemyButtonList.Add(enemyBasePanel.transform.GetChild(i).gameObject);
            }
            for (int i = 0; i < MakePartyViewManager.CHARA_NUMBER_OF_PARTY; i++)
            {
                myTeamNameTextList
                    .Add(myTeamButtonList[i].GetComponentsInChildren<Text>().First());
                myTeamStatusTextList
                    .Add(myTeamButtonList[i].GetComponentsInChildren<Text>().Last());
                enemyNameTextList
                    .Add(enemyButtonList[i].GetComponentsInChildren<Text>().First());
                enemyStatusTextList
                    .Add(enemyButtonList[i].GetComponentsInChildren<Text>().Last());
            }
        }

        void buttonInteractable(List<GameObject> objectList)
        {
            for (int i = 0; i < objectList.Count; i++)
            {
                objectList[i].GetComponent<Button>().interactable = false;
            }
        }
    }
}
