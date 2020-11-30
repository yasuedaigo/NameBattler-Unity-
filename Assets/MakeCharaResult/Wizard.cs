using System;
using System.Collections;
using System.Collections.Generic;
using SQLManager;
using UnityEngine;

namespace MakeCharaResult
{
    public class Wizard : BasePlayerMaker
    {
        PlayerDTO playerDTO;

        public override PlayerDTO makePlayer(string usename)
        {
            playerDTO = new PlayerDTO();
            playerDTO.PlayerName = usename;
            playerDTO.HP = base.MakeStatusInt(0, 100, usename) + 50;
            playerDTO.STR = base.MakeStatusInt(1, 50, usename) + 30;
            playerDTO.DEF = base.MakeStatusInt(2, 50, usename) + 30;
            playerDTO.LUCK = base.MakeStatusInt(3, 100, usename) + 1;
            playerDTO.AGI = base.MakeStatusInt(4, 40, usename) + 1;
            playerDTO.MP = base.MakeStatusInt(4, 50, usename) + 30;
            playerDTO.JOB = JOBs.Wizard;
            playerDTO.CreateDay = DateTime.Now;
            return playerDTO;
        }
    }
}
