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
        public GameObject playerTogglePrefab;
        public Button startButton;
        public Text startButtonText;
        List<Toggle> playerToggleList = new List<Toggle>();
        List<GameObject> playerObjectList = new List<GameObject>();
        List<Text> nameTextList = new List<Text>();
        List<Text> statusTextList = new List<Text>();
        /*List<Text> jobTextList = new List<Text>();*/  
        MakePartyController makePartyController;
        List<PlayerDTO> allPlayerDTOList;
        public const int CHARANUMBEROFPARTY = 3;
        int selectedNumber;

        PlayerButtonManager playerButtonManager;
        public GameObject baseObject;

        void Start()
        {
           playerButtonManager = GameObject.Find("Main Camera").GetComponent<PlayerButtonManager>();
           startButton.interactable = false;
           makePartyController =GameObject.Find("Content").GetComponent<MakePartyController>();
           playerButtonManager.createPlayerButton(playerTogglePrefab,makePartyController.countmyTeamTableRows(),baseObject);
           makeAllList();
           TextManager.drowNameAndJob(nameTextList,allPlayerDTOList);
           TextManager.drowStatus(statusTextList,allPlayerDTOList);
           /*makePlayerToggle();
           makeAllList();
           drowPlayerToggleText();*/
        }

        public void onLoadBattleStart(){
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
                if (playerToggle.isOn)  selectedNumber++;
            }
            startButtonText.text = $"このパーティーで開始({selectedNumber}/{CHARANUMBEROFPARTY}";
        }

        public void controllStartButtonActive(){
            if (selectedNumber == CHARANUMBEROFPARTY)
            {
                startButton.interactable = true;
            }
            else
            {
                startButton.interactable = false;
            }
        }

        /*void drowPlayerToggleText()
        {
            for (int i = 0; i < allPlayerDTOList.Count; i++)
            {
                PlayerDTO playerDTO = new PlayerDTO();
                playerDTO = allPlayerDTOList[i];
                nameTextList[i].text = playerDTO.PlayerName;
                statusTextList[i].text =
                    $"{playerDTO.JOB.GetStringValue()} HP:{playerDTO.HP} STR:{playerDTO.STR} DEF:{playerDTO.DEF}" +
                    $"AGI:{playerDTO.AGI} LUCK:{playerDTO.LUCK} MP:{playerDTO.MP}";
            }
        }

        void makePlayerToggle()
        {
            for (int i = 0; i < makePartyController.countmyTeamTableRows(); i++)
            {
                GameObject playerToggle =
                    (GameObject)
                    Instantiate(playerTogglePrefab,
                    this.transform.position,
                    Quaternion.identity);
                playerToggle.transform.parent = this.transform;
                playerToggle.name = i.ToString();
            }
        }*/

        void makeAllList()
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                playerObjectList.Add(this.transform.GetChild(i).gameObject);
                nameTextList.Add(playerObjectList[i].GetComponentsInChildren<Text>().First());
                statusTextList.Add(playerObjectList[i].GetComponentsInChildren<Text>().Last());
                playerToggleList.Add(playerObjectList[i].GetComponent<Toggle>());
            }
            allPlayerDTOList = makePartyController.getmyTeamAllCharaList();
        }
    }
}
