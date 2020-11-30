using System;
using System.Collections;
using System.Collections.Generic;
using AllChara;
using SQLManager;
using UnityEngine;
using UnityEngine.UI;

namespace CharaStatus
{
    public class StatusView : MonoBehaviour
    {
        CharaStatus_Repo_Ctrl charaStatus_Repo_Ctrl;

        PlayerDTO textchara;

        void Start()
        {
            charaStatus_Repo_Ctrl =
                GameObject
                    .Find("CharaStatusText")
                    .GetComponent<CharaStatus_Repo_Ctrl>();
            if (
                AllChara.ContentManager.charaNum <=
                charaStatus_Repo_Ctrl.getmyTeamRowint() - 1
            )
            {
                textchara =
                    charaStatus_Repo_Ctrl
                        .getmyTeamPlayerDTO(AllChara.ContentManager.charaNum);
                statusView(textchara);
            }
        }

        public void statusView(PlayerDTO playerDTO)
        {
            string statustext =
                $"名前： {playerDTO.PlayerName}\r\n職業： {playerDTO.JOB.GetStringValue()} \r\nHP  ： {playerDTO.HP}\r\nSTR ： {playerDTO.STR}" +
                $"\r\nDEF ： {playerDTO.DEF}\r\nLUCK： {playerDTO.LUCK}\r\nAGI ： {playerDTO.AGI}\r\nMP  ： {playerDTO.MP}\r\n作成日時{playerDTO.CreateDay.ToString()}";
            this.GetComponent<Text>().text = statustext;
        }
    }
}
