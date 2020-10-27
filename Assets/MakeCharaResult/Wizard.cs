using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MakeCharaResult
{
    
public class Wizard : IFMakePlayer
{
    JobPlayer player;

    public JobPlayer makePlayer(string usename){
        player = new JobPlayer();
        player.HP = player.MakeStatusInt(0, 100,usename)+50;   
		player.STR = player.MakeStatusInt(1, 50,usename)+30;      
		player.DEF = player.MakeStatusInt(2, 50,usename)+30;       
		player.LUCK = player.MakeStatusInt(3,100,usename)+1;       
		player.AGI = player.MakeStatusInt(4,40,usename)+1;        
        player.MP = player.MakeStatusInt(4,50,usename)+30; 
		player.JOB = "魔法使い";
        return player;
    }
}

}