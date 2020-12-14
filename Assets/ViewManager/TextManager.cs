using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SQLManager;
using System.Linq;

namespace ViewManager
{

public class TextManager
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
}

}
