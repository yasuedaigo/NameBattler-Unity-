using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SQLManager;
using System.Linq;
using ViewManager;

namespace AllChara{

public class AllCharaViewManager : MonoBehaviour
{
    public static int selectedCharaNum; 
    public GameObject charaButtonPrefab; 
    List<GameObject> charaButtonList;
    List<Text> nameTextList; 
    List<Text> statusTextList; 
    AllCharaController allCharaController;
    List<PlayerDTO> playerDTOList; 
    PlayerButtonManager playerButtonManager;
    public GameObject baseObject;

    void Start()
    {
        allCharaController = GameObject.Find("Content").GetComponent<AllCharaController>();
        charaButtonList = new List<GameObject>();
        nameTextList =　new List<Text>();
        statusTextList =　new List<Text>();
        playerButtonManager = GameObject.Find("Main Camera").GetComponent<PlayerButtonManager>();

        playerDTOList = allCharaController.getmyTeamAllCharaList();
        playerButtonManager.createPlayerButton(charaButtonPrefab,allCharaController.countmyTeamTableRows(),baseObject);
        makeList();
        TextManager.drowNameAndJob(nameTextList,playerDTOList);
        TextManager.drowStatus(statusTextList,playerDTOList);
        
        /*createItemOnScrollView();
        
        this.drowButtonText(allCharaController.getmyTeamAllCharaList());*/
    }

    /*void drowButtonText(List<PlayerDTO> playerDTOList)
    {
        for(int i=0; i < playerDTOList.Count; i++)
        {
            PlayerDTO playerDTO = playerDTOList[i];
            nameTextList[i].text = $"{playerDTO.PlayerName}    {playerDTO.JOB.GetStringValue()}";
            statusTextList[i].text 
              = $"HP{playerDTO.HP} STR{playerDTO.STR} DEF{playerDTO.DEF}"+
                $" LUCK{playerDTO.AGI} AGI{playerDTO.AGI} MP{playerDTO.MP}";
        }
    }*/

    /*void createItemOnScrollView()
    {
        for(int i=0 ;i<allCharaController.countmyTeamTableRows(); i++)
        {
            GameObject charaButton = (GameObject)Instantiate (charaButtonPrefab, this.transform.position, Quaternion.identity);
		    charaButton.transform.parent = this.transform;
            charaButton.name = i.ToString();
        }
        AddCharaButtonElementsToList();
    }*/

    void makeList()
    {
        for(int i=0;i < this.transform.childCount; i++)
        {
            charaButtonList.Add(this.transform.GetChild(i).gameObject);
            nameTextList.Add(charaButtonList[i].GetComponentsInChildren<Text>().First());
            statusTextList.Add(charaButtonList[i].GetComponentsInChildren<Text>().Last());
            nameTextList[i].text = i.ToString();  
        }
    }
    
}

}