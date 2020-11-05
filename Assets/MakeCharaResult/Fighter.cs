using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using SQLManager;

namespace MakeCharaResult
{
    
public class Fighter : IFMakePlayer
{
    SQLPlayer player;

    public SQLPlayer makePlayer(string usename){
        player = new SQLPlayer();
        player.PlayerName = usename;
        player.HP = player.MakeStatusInt(0, 200,usename)+100;   
		player.STR = player.MakeStatusInt(1, 70,usename)+30;      
		player.DEF = player.MakeStatusInt(2, 70,usename)+30;         
		player.LUCK = player.MakeStatusInt(3,99,usename)+1;      
		player.AGI = player.MakeStatusInt(4,49,usename)+1;       
        player.MP = 0;
		player.JOB = SQLPlayer.JOBs.戦士;
        player.CreateDay = DateTime.Now;
        return player;
    }
}

}