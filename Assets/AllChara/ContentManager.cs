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
    public static int charaNum;

    public GameObject contentButton;

    List<GameObject> Buttonlist;

    List<Text> nametextlist;

    List<Text> statustextlist;

    AllChara_Repo_Ctrl allChara_Repo_Ctrl;

    List<PlayerDTO> playerDTOList;

    void Start()
    {
        allChara_Repo_Ctrl = GameObject.Find("Content").GetComponent<AllChara_Repo_Ctrl>();
        Buttonlist = new List<GameObject>();
        nametextlist =　new List<Text>();
        statustextlist =　new List<Text>();

        createContentItem();
        
        this.ContentView(allChara_Repo_Ctrl.getmyTeamAllCharaList());
    }

    void ContentView(List<PlayerDTO> playerDTOList)
    {
        for(int i=0; i < playerDTOList.Count; i++)
        {
            PlayerDTO playerDTO = playerDTOList[i];
            nametextlist[i].text = $"{playerDTO.PlayerName}    {playerDTO.JOB.GetStringValue()}";
            statustextlist[i].text 
              = $"HP{playerDTO.HP} STR{playerDTO.STR} DEF{playerDTO.DEF}"+
                $" LUCK{playerDTO.AGI} AGI{playerDTO.AGI} MP{playerDTO.MP}";
        }
    }

    void createContentItem()
    {
        for(int i=0 ;i<allChara_Repo_Ctrl.getmyTeamRowint(); i++)
        {
            GameObject Obj = (GameObject)Instantiate (contentButton, this.transform.position, Quaternion.identity);
		    Obj.transform.parent = this.transform;
            Obj.name = i.ToString();
        }
        AddObjectForList();
    }

    void AddObjectForList()
    {
        for(int i=0;i < this.transform.childCount; i++)
        {
            Buttonlist.Add(this.transform.GetChild(i).gameObject);
            nametextlist.Add(Buttonlist[i].GetComponentsInChildren<Text>().First());
            statustextlist.Add(Buttonlist[i].GetComponentsInChildren<Text>().Last());
            nametextlist[i].text = i.ToString();
            statustextlist[i].text = "プレイヤーが登録されていません";    
        }
    }
    
}

}