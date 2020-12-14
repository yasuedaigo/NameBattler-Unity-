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

        /*List<GameObject> myTeamPanelList = new List<GameObject>();
        List<GameObject> enemyPanelList = new List<GameObject>();*/

        PlayerButtonManager playerButtonManager;
        List<Text> myTeamNameTextList = new List<Text>();
        List<Text> myTeamStatusTextList = new List<Text>();
        List<Text> enemyNameTextList = new List<Text>();
        List<Text> enemyStatusTextList = new List<Text>();
        List<PlayerDTO> myTeamPlayerDTOList = new List<PlayerDTO>();
        List<PlayerDTO> enemyPlayerDTOList = new List<PlayerDTO>();
        List<GameObject> myTeamButtonList = new List<GameObject>();
        List<GameObject> enemyButtonList = new List<GameObject>();
        public GameObject playerButton;

        void Start()
        {
            playerButtonManager = GameObject.Find("Main Camera").GetComponent<PlayerButtonManager>();
            battleStartController = GameObject.Find("Canvas").GetComponent<BattleStartController>();
            enemyPlayerDTOList =
                battleStartController.makeEnemyDTOList();
            myTeamPlayerDTOList =
                　battleStartController
                    .makeMyTeamDTOList(MakeParty.MakePartyViewManager.myTeamPlayerIdList);
            playerButtonManager.createPlayerButton(playerButton,MakePartyViewManager.CHARANUMBEROFPARTY,myTeamBasePanel);
            playerButtonManager.createPlayerButton(playerButton,MakePartyViewManager.CHARANUMBEROFPARTY,enemyBasePanel);
            makeList();
            TextManager.drowNameAndJob(myTeamNameTextList,myTeamPlayerDTOList);
            TextManager.drowStatus(myTeamStatusTextList,myTeamPlayerDTOList);
            TextManager.drowNameAndJob(enemyNameTextList,enemyPlayerDTOList);
            TextManager.drowStatus(enemyStatusTextList,enemyPlayerDTOList);
            for(int i=0;i<MakePartyViewManager.CHARANUMBEROFPARTY;i++){
                myTeamButtonList[i].GetComponent<Button>().interactable = false;
            }
            for(int i=0;i<MakePartyViewManager.CHARANUMBEROFPARTY;i++){
                enemyButtonList[i].GetComponent<Button>().interactable = false;
            }
            
            /*TextManager.nameAndJobText(nameTextList,allPlayerDTOList);
            TextManager.statusText(statusTextList,allPlayerDTOList);*/

            /*battleStartController = GameObject.Find("Canvas").GetComponent<BattleStartController>();
            makePanelList(myTeamBasePanel,myTeamPanelList);
            makePanelList(enemyBasePanel,enemyPanelList);
            List<PlayerDTO> enemyPlayerDTOList =
                battleStartController.makeEnemyDTOList();
            List<PlayerDTO> myTeamPlayerDTOList =
                　battleStartController
                    .makeMyTeamDTOList(MakeParty.MakePartyViewManager.myTeamPlayerIdList);
            drowmyTeamStatusText (myTeamPlayerDTOList);
            drowEnemyStatusText (enemyPlayerDTOList);*/
        }

        /*void drowmyTeamStatusText(List<PlayerDTO> playerDTOList)
        {
            int count = 0;
            foreach (PlayerDTO playerDTO in playerDTOList)
            {
                myTeamPanelList[count]
                    .GetComponentsInChildren<Text>()
                    .First()
                    .text =
                    $"{playerDTO.PlayerName}   {playerDTO.JOB.GetStringValue()}";
                myTeamPanelList[count]
                    .GetComponentsInChildren<Text>()
                    .Last()
                    .text =
                    $"HP:{playerDTO.HP} STR:{playerDTO.STR} DEF:{playerDTO.DEF} LUCK:{playerDTO.LUCK} " +
                    $"AGI:{playerDTO.AGI} MP:{playerDTO.MP}";
                count++;
            }
        }

        void drowEnemyStatusText(List<PlayerDTO> playerDTOList)
        {
            int count = 0;
            foreach (var playerDTO in playerDTOList)
            {
                enemyPanelList[count]
                    .GetComponentsInChildren<Text>()
                    .First()
                    .text =
                    $"{playerDTO.PlayerName}   {playerDTO.JOB.GetStringValue()}";
                enemyPanelList[count]
                    .GetComponentsInChildren<Text>()
                    .Last()
                    .text =
                    $"HP:{playerDTO.HP} STR:{playerDTO.STR} DEF:{playerDTO.DEF} " +
                    $"LUCK:{playerDTO.LUCK} AGI{playerDTO.AGI} MP:{playerDTO.MP}";
                count++;
            }
        }*/

        public void reselectEnemy()
        {
            List<PlayerDTO> enemyPlayerDTOList =
                battleStartController.makeEnemyDTOList();
            TextManager.drowNameAndJob(enemyNameTextList,enemyPlayerDTOList);
            TextManager.drowStatus(enemyStatusTextList,enemyPlayerDTOList);
            for(int i=0;i<MakePartyViewManager.CHARANUMBEROFPARTY;i++){
                enemyButtonList[i].GetComponent<Button>().interactable = false;
            }
            /*drowEnemyStatusText (enemyPlayerDTOList);*/
        }

        /*public void makePanelList(GameObject basePanel,List<GameObject> panelList){
            for(int i = 0; i < MakePartyViewManager.CHARANUMBEROFPARTY; i++){
                panelList
                    .Add(basePanel
                        .transform
                        .FindChild(i.ToString())
                        .gameObject);
            }
                
        }*/

        void makeList(){
            for(int i=0;i<MakePartyViewManager.CHARANUMBEROFPARTY;i++){
                myTeamButtonList.Add(myTeamBasePanel.transform.GetChild(i).gameObject);
                enemyButtonList.Add(enemyBasePanel.transform.GetChild(i).gameObject);
            }
            for(int i=0;i<MakePartyViewManager.CHARANUMBEROFPARTY;i++){
                myTeamNameTextList.Add(myTeamButtonList[i].GetComponentsInChildren<Text>().First());
                myTeamStatusTextList.Add(myTeamButtonList[i].GetComponentsInChildren<Text>().Last());
                enemyNameTextList.Add(enemyButtonList[i].GetComponentsInChildren<Text>().First());
                enemyStatusTextList.Add(enemyButtonList[i].GetComponentsInChildren<Text>().Last());
            }
        }
    }
}
