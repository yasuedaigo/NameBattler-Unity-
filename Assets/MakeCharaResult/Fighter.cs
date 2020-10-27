using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MakeCharaResult
{
    
public class Fighter : IFMakePlayer
{
    JobPlayer player;

    public JobPlayer makePlayer(string usename){
        player = new JobPlayer();
        player.HP = player.MakeStatusInt(0, 200,usename)+100;   
		player.STR = player.MakeStatusInt(1, 70,usename)+30;      
		player.DEF = player.MakeStatusInt(2, 70,usename)+30;         
		player.LUCK = player.MakeStatusInt(3,99,usename)+1;      
		player.AGI = player.MakeStatusInt(4,49,usename)+1;       
        player.MP = 0;
		player.JOB = "戦士";
        return player;
    }
}

}