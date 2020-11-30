using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AllChara;
using MakeChara;
using SQLManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MakeCharaResult
{
    public class MakePlayerManager : MonoBehaviour
    {
        string usename;

        PlayerDTO playerDTO;

        MakeCharaResult_Repo_Ctrl makeCharaResult_Repo_Ctrl;

        void Start()
        {
            makeCharaResult_Repo_Ctrl = this.GetComponent<MakeCharaResult_Repo_Ctrl>();
            usename = InputFieldManager.GetName();
            playerDTO = ToggleManager.PlayerMaker.makePlayer(usename);

            bool numberOK = makeCharaResult_Repo_Ctrl.canAddCharaNumber();
            bool nameOk = makeCharaResult_Repo_Ctrl.canAddCharaName(usename);
            if (!numberOK)
            {
                cannotAddNumbertext();
            }
            else if (!nameOk)
            {
                cannotAddNametext();
            }
            else
            {
                makeCharaResult_Repo_Ctrl.addmyTeamData (playerDTO);
            }

            var message = this.GetComponent<Text>();
            message.text =
                $"名前： {playerDTO.PlayerName}\r\n職業： {playerDTO.JOB.GetStringValue()} \r\nHP  ： {playerDTO.HP}\r\nSTR ： {playerDTO.STR}" +
                $"\r\nDEF ： {playerDTO.DEF}\r\nLUCK： {playerDTO.LUCK}\r\nAGI ： {playerDTO.AGI}" +
                $"\r\nMP  ： {playerDTO.MP}\r\n作成日時  :  {playerDTO.CreateDay}";
        }

        public PlayerDTO getMakePlayer()
        {
            return playerDTO;
        }

        public void cannotAddNametext()
        {
            GameObject.Find("message").GetComponent<Text>().text =
                "！同名キャラクターは作成できません";
        }

        public void cannotAddNumbertext()
        {
            GameObject.Find("message").GetComponent<Text>().text =
                "！作成できるキャラクターは20人までです";
        }
    }
}
