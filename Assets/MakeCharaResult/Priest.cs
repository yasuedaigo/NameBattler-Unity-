using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MakeCharaResult
{
    
public class Priest : IFMakePlayer
{
    JobPlayer player;

    public JobPlayer makePlayer(string usename){
        player = new JobPlayer();
        player.HP = player.MakeStatusInt(0, 120,usename)+80;   
		player.STR = player.MakeStatusInt(1, 60,usename)+10;      
		player.DEF = player.MakeStatusInt(2, 60,usename)+10;       
		player.LUCK = player.MakeStatusInt(3,99,usename)+1;       
		player.AGI = player.MakeStatusInt(4,40,usename)+20;        
        player.MP = player.MakeStatusInt(4,30,usename)+20; 
		player.JOB = "僧侶";
        return player;
    }
}

}