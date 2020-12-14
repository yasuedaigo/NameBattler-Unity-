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
    public class MakeCharaResultViewManager : MonoBehaviour
    {
        public Text messageText;
        string useName;
        PlayerDTO playerDTO;
        MakeCharaResultController makeCharaResultController;

        void Start()
        {
            makeCharaResultController = this.GetComponent<MakeCharaResultController>();
            acquireUseName();
            makeplayerDTO();
            if(CanAddChara())
            {
                makeCharaResultController.addmyTeamChara (playerDTO);
            }
            drowStatusText();
        }

        void acquireUseName()
        {
            useName = InputFieldManager.GetName();
        }

        void makeplayerDTO()
        {
            playerDTO = JobSelectToggleManager.PlayerMaker.makePlayerDTO(useName);
        }

        bool CanAddChara()
        {
            if(makeCharaResultController.charaNumberIsFull()){
                messageText.text = $"！作成できるキャラクターは{makeCharaResultController.getMaxCharaNumber()}人までです";
                return false;
            }else if(makeCharaResultController.canNotAddName(useName)){
                messageText.text = "！同名キャラクターは作成できません";
                return false;
            }
            return true;
        }

        void drowStatusText(){
            var message = this.GetComponent<Text>();
            message.text =
                $"名前： {playerDTO.PlayerName}\r\n職業： {playerDTO.JOB.GetStringValue()} \r\nHP  ： {playerDTO.HP}\r\nSTR ： {playerDTO.STR}" +
                $"\r\nDEF ： {playerDTO.DEF}\r\nLUCK： {playerDTO.LUCK}\r\nAGI ： {playerDTO.AGI}" +
                $"\r\nMP  ： {playerDTO.MP}\r\n作成日時  :  {playerDTO.CreateDay}";
        }
    }
}
