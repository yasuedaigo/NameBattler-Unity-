using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MakeChara;
using AllChara;

namespace MakeCharaResult{
  

public class MakePlayerManager : MonoBehaviour
{
    string usename;
    enum Usejob {戦士,魔法使い,僧侶,忍者,}
    Usejob usejob;
    JobPlayer player;
    int rowint;
    // Start is called before the first frame update
    void Start()
    {
        usename = InputFieldManager.GetName();
        var getusejob = ToggleManager.Gettgljob();
        var usejob = (Usejob)Enum.Parse(typeof(Usejob), getusejob, true);
        player = new JobPlayer();
        player.PlayerName = usename;

        switch (usejob)
        {
            case Usejob.戦士:
                player.HP = player.MakeStatusInt(0, 200,usename)+100;   
		        player.STR = player.MakeStatusInt(1, 70,usename)+30;      
		        player.DEF = player.MakeStatusInt(2, 70,usename)+30;         
		        player.LUCK = player.MakeStatusInt(3,99,usename)+1;      
		        player.AGI = player.MakeStatusInt(4,49,usename)+1;       
                player.MP = 0;
		        player.JOB = "戦士";
                break;
            case Usejob.魔法使い:
                player.HP = player.MakeStatusInt(0, 100,usename)+50;   
		        player.STR = player.MakeStatusInt(1, 50,usename)+30;      
		        player.DEF = player.MakeStatusInt(2, 50,usename)+30;       
		        player.LUCK = player.MakeStatusInt(3,100,usename)+1;       
		        player.AGI = player.MakeStatusInt(4,40,usename)+1;        
                player.MP = player.MakeStatusInt(4,50,usename)+30; 
		        player.JOB = "魔法使い";
                break;
            case Usejob.僧侶:
                player.HP = player.MakeStatusInt(0, 120,usename)+80;   
		        player.STR = player.MakeStatusInt(1, 60,usename)+10;      
		        player.DEF = player.MakeStatusInt(2, 60,usename)+10;       
		        player.LUCK = player.MakeStatusInt(3,99,usename)+1;       
		        player.AGI = player.MakeStatusInt(4,40,usename)+20;        
                player.MP = player.MakeStatusInt(4,30,usename)+20; 
		        player.JOB = "僧侶";
                break;
            case Usejob.忍者:
                player.HP = player.MakeStatusInt(0, 100,usename)+100;   
		        player.STR = player.MakeStatusInt(1, 50,usename)+20;      
		        player.DEF = player.MakeStatusInt(2, 70,usename)+20;       
		        player.LUCK = player.MakeStatusInt(3,99,usename)+1;       
		        player.AGI = player.MakeStatusInt(4,40,usename)+40;        
                player.MP = 0;
		        player.JOB = "忍者";
                break;
            
        }
        var message = this.GetComponent<Text>();
        message.text = player.PlayerName.ToString()+"\r\n"+player.JOB.ToString()+"\r\n"+player.HP.ToString()+"\r\n"+player.STR.ToString()+"\r\n"+player.DEF.ToString()+"\r\n"+player.LUCK.ToString()+"\r\n"+player.AGI.ToString()+"\r\n"+player.MP.ToString(); ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void OnClickAddButton()
    {   
        SqliteDatabase sqlDB = new SqliteDatabase("character.db");
        string getintRowQuery = "select count(*) from status";
        DataTable dataTable = sqlDB.ExecuteQuery(getintRowQuery);
        int rowint = (int)dataTable.Rows[0]["count(*)"];
        
        if(rowint < 10){
        Debug.Log(player.PlayerName+","+player.JOB+","+player.HP+","+player.STR+","+player.DEF+","+player.LUCK+","+player.AGI+","+player.MP);
        //string query = "insert into status values('"+player.playername.ToString()+"', '"+player.job.ToString()+"', "+player.hp.ToString()+", "+player.str.ToString()+","+player.def.ToString()+","+player.luck.ToString()+","+player.agi.ToString()+","+player.mp.ToString()+")";
        //string query = "insert into status values('a','b',1,2,3,4,5,5)";
        string query = "insert into status values('"+player.PlayerName.ToString()+"', '"+player.JOB.ToString()+"', "+player.HP.ToString()+", "+player.STR.ToString()+","+player.DEF.ToString()+","+player.LUCK.ToString()+","+player.AGI.ToString()+","+player.MP.ToString()+")";
        sqlDB.ExecuteNonQuery(query);
        
        SceneManager.LoadScene("MakeChara");
        }
    }
}

}