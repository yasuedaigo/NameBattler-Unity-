using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InputFieldManagernamespace;
using Togglejob;
using System.Security.Cryptography;
using System.Text;
using System;
using BattleScene;

namespace BattleScene.Chara
{
    
public class Player 
{
    TextManager textmanager;

    protected string PlayerName;
    
    public string playername
    {
        set{PlayerName = value;}
        get{return PlayerName;}
    }

    protected string Job;
    
    public string job
    {
        set{Job = value;}
        get{return Job;}
    }
    
    protected int Hp;
    
    public int hp
    {
        set{Hp = value;}
        get{return Hp;}
    }

    public readonly int FirstHp;

    public int firsthp
    {
        get{return FirstHp;}
    }

    protected int STR;
    
    public int str
    {
        set{STR = value;}
        get{return STR;}
    }

    protected int DEF;
    
    public int def
    {
        set{DEF = value;}
        get{return DEF;}
    }

    protected int LUCK;
    
    public int luck
    {
        set{LUCK = value;}
        get{return LUCK;}
    }

    protected int AGI;
    
    public int agi
    {
        set{AGI = value;}
        get{return AGI;}
    }

    protected int MP;
    
    public int mp
    {
        set{MP = value;}
        get{return MP;}
    }

    protected string ABNORMALITY;
    
    public string abnormality
    {
        set{ABNORMALITY = value;}
        get{return ABNORMALITY;}
    }

    protected int TEAM;
    
    public int team
    {
        set{TEAM = value;}
        get{return TEAM;}
    }

    protected bool Attackfinished;
    
    public bool attackfinished
    {
        set{Attackfinished = value;}
        get{return Attackfinished;}
    }

    public  Player(object usename){
        SqliteDatabase sqlDB = new SqliteDatabase("character.db");
        string selectQuery = "select playername,job,hp,str,def,luck,agi,mp from status where playername='"+usename.ToString()+"'";
        DataTable dataTable = sqlDB.ExecuteQuery(selectQuery);

        playername = (string)dataTable.Rows[0]["playername"];
        job = (string)dataTable.Rows[0]["job"];
        hp = (int)dataTable.Rows[0]["hp"];
        str = (int)dataTable.Rows[0]["str"];
        def = (int)dataTable.Rows[0]["def"];
        luck = (int)dataTable.Rows[0]["luck"];
        agi = (int)dataTable.Rows[0]["agi"];
        mp = (int)dataTable.Rows[0]["mp"];
        attackfinished = false;
        textmanager = GameObject.Find("battletext").GetComponent<TextManager>();
    }

    public virtual void Attack(Player defender,int turnNumber){
        int damage = calcDamage(defender);
        textmanager.battleLog(this.playername+"の攻撃 ➡ "+defender.playername+"に"+damage+"のダメージ");
        defender.damage(damage);
        this.attackfinished = true;
    }

    public virtual int calcDamage(Player target)
    {
        int damage;
    	if(this.luck <= UnityEngine.Random.Range(0f,100f)){
    		damage = this.str;
    		return damage;
    	}
        damage = this.str - target.def;
        if (damage < 0)
        {
               damage = 0;
        }
    	return damage;
    }

    public void damage(int damage){
        this.hp = this.hp - damage;
    }

    public bool isParise(){
        if(this.abnormality != "parise"){
            return false;
        }
        if(UnityEngine.Random.Range(0f,5f) == 0){
            return true;
        }else{
            return false;
        }
    }

    public void playerstatusText(Text targettext){
        targettext.text = this.playername+"    "+this.job+"\r\nHP : "+this.hp+"\r\nMp : "+this.mp;
        if(this.abnormality=="parise"){
            targettext.text = targettext.text.ToString()+"\r\n麻痺";
        }else if(this.abnormality=="poison"){
            targettext.text = targettext.text.ToString()+"\r\n毒";
        }
        
        if(this.hp <= 0){
            targettext.color = new Color(1, 0, 0, 1);
        }
    }

}

}
