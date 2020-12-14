using System;
using System.Collections;
using System.Collections.Generic;
using AllChara;
using SQLManager;
using UnityEngine;
using UnityEngine.UI;

namespace CharaStatus
{
    public class CharaStatusViewManager : MonoBehaviour
    {
        CharaStatusController charaStatusController;

        PlayerDTO selectedCharaDTO;

        void Start()
        {
            charaStatusController =
                GameObject
                    .Find("CharaStatusText")
                    .GetComponent<CharaStatusController>();
            
            selectedCharaDTO =
                charaStatusController
                    .getmyTeamPlayerDTO(AllChara.AllCharaViewManager.selectedCharaNum);
                drowStatus(selectedCharaDTO);
            
        }

        public void drowStatus(PlayerDTO playerDTO)
        {
            string statustext =
                $"名前： {playerDTO.PlayerName}\r\n職業： {playerDTO.JOB.GetStringValue()} \r\nHP  ： {playerDTO.HP}\r\nSTR ： {playerDTO.STR}" +
                $"\r\nDEF ： {playerDTO.DEF}\r\nLUCK： {playerDTO.LUCK}\r\nAGI ： {playerDTO.AGI}\r\nMP  ： {playerDTO.MP}\r\n作成日時{playerDTO.CreateDay.ToString()}";
            this.GetComponent<Text>().text = statustext;
        }

    }
}
