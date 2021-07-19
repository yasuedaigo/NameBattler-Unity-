using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SQLManager;
using System.Linq;

namespace ViewManager
{

public class PlayerTextManager
{
    public static void drowNameAndJob(List<Text> TextList,List<PlayerDTO> playerDTOList){
        for(int i=0; i < playerDTOList.Count; i++)
        {
            PlayerDTO playerDTO = playerDTOList[i];
            TextList[i].text = $"{playerDTO.PlayerName}    {playerDTO.JOB.GetStringValue()}";
        }
    }

    public static void drowStatus(List<Text> TextList,List<PlayerDTO> playerDTOList){
        for(int i=0; i < playerDTOList.Count; i++)
        {
            PlayerDTO playerDTO = playerDTOList[i];
            TextList[i].text 
              = $"HP{playerDTO.HP} STR{playerDTO.STR} DEF{playerDTO.DEF}"+
                $" LUCK{playerDTO.AGI} AGI{playerDTO.AGI} MP{playerDTO.MP}";
        }
    }

    public static void drowNameAndStatus(Text playerText,PlayerDTO playerDTO){
        string statusText =
            $"名前： {playerDTO.PlayerName}\r\n職業： {playerDTO.JOB.GetStringValue()} \r\n"+
            $"HP  ： {playerDTO.HP}\r\nSTR ： {playerDTO.STR}" +
            $"\r\nDEF ： {playerDTO.DEF}\r\nLUCK： {playerDTO.LUCK}\r\n"+
            $"AGI ： {playerDTO.AGI}\r\nMP  ： {playerDTO.MP}\r\n作成日時{playerDTO.CreateDay.ToString()}";
            playerText.text = statusText;
    }
}

}
