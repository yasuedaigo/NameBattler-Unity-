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
    public GameObject baseObject;
    List<GameObject> charaButtonList;
    List<Text> nameTextList; 
    List<Text> statusTextList; 
    AllCharaController allCharaController;
    List<PlayerDTO> playerDTOList; 
    PlayerButtonManager playerButtonManager;

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
        PlayerTextManager.drowNameAndJob(nameTextList,playerDTOList);
        PlayerTextManager.drowStatus(statusTextList,playerDTOList);
    }

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