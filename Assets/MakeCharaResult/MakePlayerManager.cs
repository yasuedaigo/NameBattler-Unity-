using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MakeChara;

namespace MakeCharaResult{
  

public class MakePlayerManager : MonoBehaviour
{
    string usename;
    enum Usejob {戦士,魔法使い,僧侶,忍者,}
    Usejob usejob;
    JobPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        usename = InputFieldManager.GetName();
        var getusejob = ToggleManager.Gettgljob();
        var usejob = (Usejob)Enum.Parse(typeof(Usejob), getusejob, true);
        player = new JobPlayer();
        player.playername = usename;

        switch (usejob)
        {
            case Usejob.戦士:
                player.hp = player.MakeStatusInt(0, 200,usename)+100;   
		        player.str = player.MakeStatusInt(1, 70,usename)+30;      
		        player.def = player.MakeStatusInt(2, 70,usename)+30;         
		        player.luck = player.MakeStatusInt(3,99,usename)+1;      
		        player.agi = player.MakeStatusInt(4,49,usename)+1;       
                player.mp = 0;
		        player.job = "戦士";
                break;
            case Usejob.魔法使い:
                player.hp = player.MakeStatusInt(0, 100,usename)+50;   
		        player.str = player.MakeStatusInt(1, 50,usename)+30;      
		        player.def = player.MakeStatusInt(2, 50,usename)+30;       
		        player.luck = player.MakeStatusInt(3,100,usename)+1;       
		        player.agi = player.MakeStatusInt(4,40,usename)+1;        
                player.mp = player.MakeStatusInt(4,50,usename)+30; 
		        player.job = "魔法使い";
                break;
            case Usejob.僧侶:
                player.hp = player.MakeStatusInt(0, 120,usename)+80;   
		        player.str = player.MakeStatusInt(1, 60,usename)+10;      
		        player.def = player.MakeStatusInt(2, 60,usename)+10;       
		        player.luck = player.MakeStatusInt(3,99,usename)+1;       
		        player.agi = player.MakeStatusInt(4,40,usename)+20;        
                player.mp = player.MakeStatusInt(4,30,usename)+20; 
		        player.job = "僧侶";
                break;
            case Usejob.忍者:
                player.hp = player.MakeStatusInt(0, 100,usename)+100;   
		        player.str = player.MakeStatusInt(1, 50,usename)+20;      
		        player.def = player.MakeStatusInt(2, 70,usename)+20;       
		        player.luck = player.MakeStatusInt(3,99,usename)+1;       
		        player.agi = player.MakeStatusInt(4,40,usename)+40;        
                player.mp = 0;
		        player.job = "忍者";
                break;
            
        }
        var message = this.GetComponent<Text>();
        message.text = player.playername.ToString()+"\r\n"+player.job.ToString()+"\r\n"+player.hp.ToString()+"\r\n"+player.str.ToString()+"\r\n"+player.def.ToString()+"\r\n"+player.luck.ToString()+"\r\n"+player.agi.ToString()+"\r\n"+player.mp.ToString(); ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void OnClickAddButton()
    {
        SqliteDatabase sqlDB = new SqliteDatabase("character.db");
        string query = "insert into status values('a', 'Yamada', 19, 4,5,6,7,8)";
        sqlDB.ExecuteNonQuery(query);
        
        SceneManager.LoadScene("MakeChara");
    }
}

}