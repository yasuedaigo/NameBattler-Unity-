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

        public override PlayerDTO makePlayerDTO(string useName)
        {
            playerDTO = new PlayerDTO();
            playerDTO.PlayerName = useName;
            playerDTO.HP = base.MakeStatusInt(0, 100, useName) + 50;
            playerDTO.STR = base.MakeStatusInt(1, 50, useName) + 30;
            playerDTO.DEF = base.MakeStatusInt(2, 50, useName) + 30;
            playerDTO.LUCK = base.MakeStatusInt(3, 100, useName) + 1;
            playerDTO.AGI = base.MakeStatusInt(4, 40, useName) + 1;
            playerDTO.MP = base.MakeStatusInt(4, 50, useName) + 30;
            playerDTO.JOB = JOBs.Wizard;
            playerDTO.CreateDay = DateTime.Now;
            return playerDTO;
        }
    }
}
