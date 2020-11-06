using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using SQLManager;

namespace MakeCharaResult
{
    
public class Priest : IFMakePlayer
{
    SQLPlayer player;

    public SQLPlayer makePlayer(string usename){
        player = new SQLPlayer();
        player.PlayerName = usename;
        player.HP = player.MakeStatusInt(0, 120,usename)+80;   
		player.STR = player.MakeStatusInt(1, 60,usename)+10;      
		player.DEF = player.MakeStatusInt(2, 60,usename)+10;       
		player.LUCK = player.MakeStatusInt(3,99,usename)+1;       
		player.AGI = player.MakeStatusInt(4,40,usename)+20;        
        player.MP = player.MakeStatusInt(4,30,usename)+20; 
		player.JOB = SQLPlayer.JOBs.僧侶;
        player.CreateDay = DateTime.Now;
        return player;
    }
}

}