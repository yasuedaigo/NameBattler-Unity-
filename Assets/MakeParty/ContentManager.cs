using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using SQLManager;
using UnityEngine.SceneManagement;

namespace MakeParty{

public class ContentManager : MonoBehaviour
{
    public static List<int> playerintlist = new List<int>();
    public List<Toggle> togglelist = new List<Toggle>();
    public List<GameObject> objectlist = new List<GameObject>();
    List<Text> nametextlist = new List<Text>();
    List<Text> statustextlist = new List<Text>();
    List<Text> jobtextlist = new List<Text>();
    MakePartyRepositoryController makePartyRepositoryController;
    List<PlayerDTO> playerDTOList;
    public GameObject contentobject;
    public Button startButton;
    public Text startButtonText;
    
    void Start()
    {
        startButton.interactable = false;
        makePartyRepositoryController = GameObject.Find("Content").GetComponent<MakePartyRepositoryController>();

        for(int i=0 ;i<makePartyRepositoryController.getmyTeamRowint(); i++){
            GameObject Obj = (GameObject)Instantiate (contentobject, this.transform.position, Quaternion.identity);
		    Obj.transform.parent = this.transform;
            Obj.name = i.ToString();
        }

        for(int i=0;i < this.transform.childCount; i++){
            objectlist.Add(this.transform.GetChild(i).gameObject);
            nametextlist.Add(objectlist[i].GetComponentsInChildren<Text>().First());
            statustextlist.Add(objectlist[i].GetComponentsInChildren<Text>().Last());
            nametextlist[i].text = i.ToString();
        }

        foreach (var toggleobject in objectlist)
        {
            togglelist.Add(toggleobject.GetComponent<Toggle>());
        }

        playerDTOList = makePartyRepositoryController.getmyTeamAllCharaList();
        contentText();
    }

    public void contentText(){
        for(int i=0; i < playerDTOList.Count; i++){
            PlayerDTO playerDTO = new PlayerDTO();
            playerDTO = playerDTOList[i];
            nametextlist[i].text = playerDTO.PlayerName;
            statustextlist[i].text = 
             $"{playerDTO.JOB.GetStringValue()} HP:{playerDTO.HP} STR:{playerDTO.STR} DEF:{playerDTO.DEF}"+
             $"AGI:{playerDTO.AGI} LUCK:{playerDTO.LUCK} MP:{playerDTO.MP}";
        }
    }

    public void pushBattleStart(){
        playerintlist.Clear();
        foreach (var playertoggle in togglelist)
        {
            if(playertoggle.isOn){
                playerintlist.Add(int.Parse(playertoggle.name));
            }
        }
        SceneManager.LoadScene("BattleStart");
    }

    public void makeButtonText(){
        int number = 0;
        foreach (var playertoggle in togglelist)
        {
            if(playertoggle.isOn){
                number++;
            }
        }
        startButtonText.text = $"このパーティーで開始({number}/3";
        if(number == 3){
            startButton.interactable = true;
        }else{
            startButton.interactable = false;
        }
    }
}

}
