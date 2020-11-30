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

        public override PlayerDTO makePlayer(string usename)
        {
            playerDTO = new PlayerDTO();
            playerDTO.PlayerName = usename;
            playerDTO.HP = base.MakeStatusInt(0, 120, usename) + 80;
            playerDTO.STR = base.MakeStatusInt(1, 60, usename) + 10;
            playerDTO.DEF = base.MakeStatusInt(2, 60, usename) + 10;
            playerDTO.LUCK = base.MakeStatusInt(3, 99, usename) + 1;
            playerDTO.AGI = base.MakeStatusInt(4, 40, usename) + 20;
            playerDTO.MP = base.MakeStatusInt(4, 30, usename) + 20;
            playerDTO.JOB = JOBs.Priest;
            playerDTO.CreateDay = DateTime.Now;
            return playerDTO;
        }
    }
}
