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

        public override PlayerDTO makePlayerDTO(string useName)
        {
            playerDTO = new PlayerDTO();
            playerDTO.PlayerName = useName;
            playerDTO.HP = base.MakeStatusInt(0, 200, useName) + 100;
            playerDTO.STR = base.MakeStatusInt(1, 70, useName) + 30;
            playerDTO.DEF = base.MakeStatusInt(2, 70, useName) + 30;
            playerDTO.LUCK = base.MakeStatusInt(3, 99, useName) + 1;
            playerDTO.AGI = base.MakeStatusInt(4, 49, useName) + 1;
            playerDTO.MP = 0;
            playerDTO.JOB = JOBs.Fighter;
            playerDTO.CreateDay = DateTime.Now;
            return playerDTO;
        }
    }
}
