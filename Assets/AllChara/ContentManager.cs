using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SQLManager;
using System.Linq;

namespace AllChara{

public class ContentManager : MonoBehaviour
{
    List<GameObject> Buttonlist;
    List<Text> nametextlist;
    List<Text> statustextlist;
    public static int charaNum;
    AllCharaRepositoryController allCharaRepositoryController;
    List<PlayerDTO> playerDTOList;
    public GameObject contentButton;

    void Start()
    {
        allCharaRepositoryController = GameObject.Find("Content").GetComponent<AllCharaRepositoryController>();
        Buttonlist = new List<GameObject>();
        nametextlist =　new List<Text>();
        statustextlist =　new List<Text>();

        for(int i=0 ;i<allCharaRepositoryController.getmyTeamRowint(); i++){
            GameObject Obj = (GameObject)Instantiate (contentButton, this.transform.position, Quaternion.identity);
		    Obj.transform.parent = this.transform;
            Obj.name = i.ToString();
        }
        

        for(int i=0;i < this.transform.childCount; i++){
            Buttonlist.Add(this.transform.GetChild(i).gameObject);
            nametextlist.Add(Buttonlist[i].GetComponentsInChildren<Text>().First());
            statustextlist.Add(Buttonlist[i].GetComponentsInChildren<Text>().Last());
            nametextlist[i].text = i.ToString();
            statustextlist[i].text = "プレイヤーが登録されていません";     
        }
        
        this.viewContent(allCharaRepositoryController.getmyTeamAllCharaList());
    }

    public void viewContent(List<PlayerDTO> playerDTOList){
        for(int i=0; i < playerDTOList.Count; i++){
            PlayerDTO playerDTO = playerDTOList[i];
            nametextlist[i].text = $"{playerDTO.PlayerName}    {playerDTO.JOB.GetStringValue()}";
            statustextlist[i].text 
              = $"HP{playerDTO.HP} STR{playerDTO.STR} DEF{playerDTO.DEF}"+
                $" LUCK{playerDTO.AGI} AGI{playerDTO.AGI} MP{playerDTO.MP}";
        }
    }
    
}

}