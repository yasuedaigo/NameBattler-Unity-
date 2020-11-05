using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using SQLManager;

namespace MakeCharaResult
{
    
public class Ninja : IFMakePlayer
{
    SQLPlayer player;

    public SQLPlayer makePlayer(string usename){
        player = new SQLPlayer();
        player.PlayerName = usename;
        player.HP = player.MakeStatusInt(0, 100,usename)+100;   
		player.STR = player.MakeStatusInt(1, 50,usename)+20;      
		player.DEF = player.MakeStatusInt(2, 70,usename)+20;       
		player.LUCK = player.MakeStatusInt(3,99,usename)+1;       
		player.AGI = player.MakeStatusInt(4,40,usename)+40;        
        player.MP = 0;
		player.JOB = SQLPlayer.JOBs.忍者;
        player.CreateDay = DateTime.Now;
        return player;
    }
}

}