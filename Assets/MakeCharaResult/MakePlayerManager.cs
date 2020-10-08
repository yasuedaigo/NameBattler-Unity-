using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputFieldManagernamespace;
using Togglejob;
using System;
using Job;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
  

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
                player.hp = player.MakeStatusInt(0, 200,usename)+100;   //100~300
		        player.str = player.MakeStatusInt(1, 70,usename)+30;      //30~100
		        player.def = player.MakeStatusInt(2, 70,usename)+30;          //30~100
		        player.luck = player.MakeStatusInt(3,99,usename)+1;       //1~100
		        player.agi = player.MakeStatusInt(4,49,usename)+1;        //1~50
                player.mp = 0;
		        player.job = "戦士";
		        player.abnormality = "健康";
                break;
            case Usejob.魔法使い:
                player.hp = player.MakeStatusInt(0, 100,usename)+50;   
		        player.str = player.MakeStatusInt(1, 50,usename)+30;      
		        player.def = player.MakeStatusInt(2, 50,usename)+30;       
		        player.luck = player.MakeStatusInt(3,100,usename)+1;       
		        player.agi = player.MakeStatusInt(4,40,usename)+1;        
                player.mp = player.MakeStatusInt(4,50,usename)+30; 
		        player.job = "魔法使い";
		        player.abnormality = "健康";
                break;
            case Usejob.僧侶:
                player.hp = player.MakeStatusInt(0, 120,usename)+80;   
		        player.str = player.MakeStatusInt(1, 60,usename)+10;      
		        player.def = player.MakeStatusInt(2, 60,usename)+10;       
		        player.luck = player.MakeStatusInt(3,99,usename)+1;       
		        player.agi = player.MakeStatusInt(4,40,usename)+20;        
                player.mp = player.MakeStatusInt(4,30,usename)+20; 
		        player.job = "僧侶";
		        player.abnormality = "健康";
                break;
            case Usejob.忍者:
                player.hp = player.MakeStatusInt(0, 100,usename)+100;   
		        player.str = player.MakeStatusInt(1, 50,usename)+20;      
		        player.def = player.MakeStatusInt(2, 70,usename)+20;       
		        player.luck = player.MakeStatusInt(3,99,usename)+1;       
		        player.agi = player.MakeStatusInt(4,40,usename)+40;        
                player.mp = 0;
		        player.job = "忍者";
		        player.abnormality = "健康";
                break;
            
        }
        var message = GameObject.Find("キャラ作成ステータス").GetComponent<Text>();
        Debug.Log(player.playername.ToString());
        message.text = player.playername.ToString()+"\r\n"+player.job.ToString()+"\r\n"+player.hp.ToString()+"\r\n"+player.str.ToString()+"\r\n"+player.def.ToString()+"\r\n"+player.luck.ToString()+"\r\n"+player.agi.ToString()+"\r\n"+player.mp.ToString(); ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void OnClickAddButton()
    {
        SqliteDatabase sqlDB = new SqliteDatabase("character.db");
        string query = "insert into status values('a', 'Yamada', 19, 20,5,6,7,8)";
        sqlDB.ExecuteNonQuery(query);
        
        string selectquery = "select * from status";

        SceneManager.LoadScene("MakeChara");
    }
}
