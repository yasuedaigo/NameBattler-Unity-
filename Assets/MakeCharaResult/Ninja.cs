using System;
using System.Collections;
using System.Collections.Generic;
using SQLManager;
using UnityEngine;

namespace MakeCharaResult
{
    public class Ninja : BasePlayerMaker
    {
        PlayerDTO playerDTO;

        public override PlayerDTO makePlayerDTO(string useName)
        {
            playerDTO = new PlayerDTO();
            playerDTO.PlayerName = useName;
            playerDTO.HP = base.MakeStatusInt(0, 100, useName) + 100;
            playerDTO.STR = base.MakeStatusInt(1, 50, useName) + 20;
            playerDTO.DEF = base.MakeStatusInt(2, 70, useName) + 20;
            playerDTO.LUCK = base.MakeStatusInt(3, 99, useName) + 1;
            playerDTO.AGI = base.MakeStatusInt(4, 40, useName) + 40;
            playerDTO.MP = 0;
            playerDTO.JOB = JOBs.Ninja;
            DateTime dt =  DateTime.Now;
            playerDTO.CreateDay = dt.ToString("yyyy-MM-dd");
            return playerDTO;
        }
    }
}
