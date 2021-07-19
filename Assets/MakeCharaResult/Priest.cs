using System;
using System.Collections;
using System.Collections.Generic;
using SQLManager;
using UnityEngine;

namespace MakeCharaResult
{
    public class Priest : BasePlayerMaker
    {
        PlayerDTO playerDTO;

        public override PlayerDTO makePlayerDTO(string useName)
        {
            playerDTO = new PlayerDTO();
            playerDTO.PlayerName = useName;
            playerDTO.HP = base.MakeStatusInt(0, 120, useName) + 80;
            playerDTO.STR = base.MakeStatusInt(1, 60, useName) + 10;
            playerDTO.DEF = base.MakeStatusInt(2, 60, useName) + 10;
            playerDTO.LUCK = base.MakeStatusInt(3, 99, useName) + 1;
            playerDTO.AGI = base.MakeStatusInt(4, 40, useName) + 20;
            playerDTO.MP = base.MakeStatusInt(4, 30, useName) + 20;
            playerDTO.JOB = JOBs.Priest;
            DateTime dt =  DateTime.Now;
            playerDTO.CreateDay = dt.ToString("yyyy-MM-dd HH:mm:ss");
            return playerDTO;
        }
    }
}
