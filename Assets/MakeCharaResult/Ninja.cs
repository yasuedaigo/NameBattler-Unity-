using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using SQLManager;

namespace MakeCharaResult
{
    
public class Ninja : BaseMakePlayer
{
    PlayerDTO playerDTO;

    public override PlayerDTO makePlayer(string usename){
        playerDTO = new PlayerDTO();
        playerDTO.PlayerName = usename;
        playerDTO.HP = base.MakeStatusInt(0, 100,usename)+100;   
		playerDTO.STR = base.MakeStatusInt(1, 50,usename)+20;      
		playerDTO.DEF = base.MakeStatusInt(2, 70,usename)+20;       
		playerDTO.LUCK = base.MakeStatusInt(3,99,usename)+1;       
		playerDTO.AGI = base.MakeStatusInt(4,40,usename)+40;        
        playerDTO.MP = 0;
		playerDTO.JOB = JOBs.Ninja;
        playerDTO.CreateDay = DateTime.Now;
        return playerDTO;
    }
}

}