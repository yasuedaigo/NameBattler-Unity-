using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SQLManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MakeParty
{
    public class ContentManager : MonoBehaviour
    {
        public static List<int> playerintlist = new List<int>();

        public GameObject playertoggle;

        public Button startButton;

        public Text startButtonText;

        List<Toggle> togglelist = new List<Toggle>();

        List<GameObject> objectlist = new List<GameObject>();

        List<Text> nametextlist = new List<Text>();

        List<Text> statustextlist = new List<Text>();

        List<Text> jobtextlist = new List<Text>();

        MakeParty_Repo_Ctrl makeParty_Repo_Ctrl;

        List<PlayerDTO> playerDTOList;

        void Start()
        {
            startButton.interactable = false;
            makeParty_Repo_Ctrl =
                GameObject
                    .Find("Content")
                    .GetComponent<MakeParty_Repo_Ctrl>();
            makePlayerToggle();
            makeAllList();
            makeContentText();
        }

        public void pushBattleStart()
        {
            playerintlist.Clear();
            foreach (var playertoggle in togglelist)
            {
                if (playertoggle.isOn)
                {
                    playerintlist.Add(int.Parse(playertoggle.name));
                }
            }
            SceneManager.LoadScene("BattleStart");
        }

        public void makeButtonText()
        {
            int number = 0;
            foreach (var playertoggle in togglelist)
            {
                if (playertoggle.isOn)  number++;
            }
            startButtonText.text = $"このパーティーで開始({number}/3";
            if (number == 3)
            {
                startButton.interactable = true;
            }
            else
            {
                startButton.interactable = false;
            }
        }

        void makeContentText()
        {
            for (int i = 0; i < playerDTOList.Count; i++)
            {
                PlayerDTO playerDTO = new PlayerDTO();
                playerDTO = playerDTOList[i];
                nametextlist[i].text = playerDTO.PlayerName;
                statustextlist[i].text =
                    $"{playerDTO.JOB.GetStringValue()} HP:{playerDTO.HP} STR:{playerDTO.STR} DEF:{playerDTO.DEF}" +
                    $"AGI:{playerDTO.AGI} LUCK:{playerDTO.LUCK} MP:{playerDTO.MP}";
            }
        }

        void makePlayerToggle()
        {
            for (int i = 0; i < makeParty_Repo_Ctrl.getmyTeamRowint(); i++)
            {
                GameObject Obj =
                    (GameObject)
                    Instantiate(playertoggle,
                    this.transform.position,
                    Quaternion.identity);
                Obj.transform.parent = this.transform;
                Obj.name = i.ToString();
            }
        }

        void makeAllList()
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                objectlist.Add(this.transform.GetChild(i).gameObject);
                nametextlist
                    .Add(objectlist[i].GetComponentsInChildren<Text>().First());
                statustextlist
                    .Add(objectlist[i].GetComponentsInChildren<Text>().Last());
                nametextlist[i].text = i.ToString();
            }
            foreach (var toggleobject in objectlist)
            {
                togglelist.Add(toggleobject.GetComponent<Toggle>());
            }
            playerDTOList = makeParty_Repo_Ctrl.getmyTeamAllCharaList();
        }
    }
}
