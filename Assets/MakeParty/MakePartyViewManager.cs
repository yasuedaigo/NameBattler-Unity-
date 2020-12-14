using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SQLManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ViewManager;

namespace MakeParty
{
    public class MakePartyViewManager : MonoBehaviour
    {
        public static List<int> myTeamPlayerIdList = new List<int>();
        public const int CHARA_NUMBER_OF_PARTY = 3;
        public GameObject playerTogglePrefab;
        public Button startButton;
        public Text startButtonText;
        public GameObject baseObject;
        List<Toggle> playerToggleList = new List<Toggle>();
        List<GameObject> playerObjectList = new List<GameObject>();
        List<Text> nameTextList = new List<Text>();
        List<Text> statusTextList = new List<Text>();
        MakePartyController makePartyController;
        List<PlayerDTO> allPlayerDTOList;
        int selectedNumber;
        PlayerButtonManager playerButtonManager;
        
        void Start()
        {
            playerButtonManager =
                GameObject.Find("Main Camera").GetComponent<PlayerButtonManager>();
            startButton.interactable = false;
            makePartyController =
                GameObject.Find("Content").GetComponent<MakePartyController>();
            playerButtonManager
                .createPlayerButton(playerTogglePrefab,
                makePartyController.countmyTeamTableRows(),
                baseObject);
            makeAllList();
            PlayerTextManager.drowNameAndJob (nameTextList, allPlayerDTOList);
            PlayerTextManager.drowStatus (statusTextList, allPlayerDTOList);
        }

        public void onLoadBattleStart()
        {
            makemyTeamPlayerIdList();
            SceneManager.LoadScene("BattleStart");
        }

        void makemyTeamPlayerIdList()
        {
            myTeamPlayerIdList.Clear();
            foreach (var playerToggle in playerToggleList)
            {
                if (playerToggle.isOn)
                {
                    myTeamPlayerIdList.Add(int.Parse(playerToggle.name));
                }
            }
        }

        public void changeStartButtonText()
        {
            selectedNumber = 0;
            foreach (var playerToggle in playerToggleList)
            {
                if (playerToggle.isOn) selectedNumber++;
            }
            startButtonText.text = $"このパーティーで開始({selectedNumber}/{CHARA_NUMBER_OF_PARTY}";
        }

        public void controllStartButtonActive()
        {
            if (selectedNumber == CHARA_NUMBER_OF_PARTY)
            {
                startButton.interactable = true;
            }
            else
            {
                startButton.interactable = false;
            }
        }

        void makeAllList()
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                playerObjectList.Add(this.transform.GetChild(i).gameObject);
                nameTextList
                    .Add(playerObjectList[i]
                        .GetComponentsInChildren<Text>().First());
                statusTextList
                    .Add(playerObjectList[i]
                        .GetComponentsInChildren<Text>().Last());
                playerToggleList
                    .Add(playerObjectList[i].GetComponent<Toggle>());
            }
            allPlayerDTOList = makePartyController.getmyTeamAllCharaList();
        }
    }
}
