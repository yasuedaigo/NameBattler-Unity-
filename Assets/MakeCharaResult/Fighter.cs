using System;
using System.Collections;
using System.Collections.Generic;
using SQLManager;
using UnityEngine;

namespace MakeCharaResult
{
    public class Fighter : BasePlayerMaker
    {
        PlayerDTO playerDTO;

        public override PlayerDTO makePlayer(string usename)
        {
            playerDTO = new PlayerDTO();
            playerDTO.PlayerName = usename;
            playerDTO.HP = base.MakeStatusInt(0, 200, usename) + 100;
            playerDTO.STR = base.MakeStatusInt(1, 70, usename) + 30;
            playerDTO.DEF = base.MakeStatusInt(2, 70, usename) + 30;
            playerDTO.LUCK = base.MakeStatusInt(3, 99, usename) + 1;
            playerDTO.AGI = base.MakeStatusInt(4, 49, usename) + 1;
            playerDTO.MP = 0;
            playerDTO.JOB = JOBs.Fighter;
            playerDTO.CreateDay = DateTime.Now;
            return playerDTO;
        }
    }
}
