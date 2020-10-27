using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography;
using System.Text;
using System;
using BattleScene;
using SQLManager;
using System.Linq;

namespace BattleScene.Chara
{
    
public class Player 
{
    TextManager textmanager;

    public string PlayerName { get; set; }

    public string JOB { get; set; }

    public int HP { get; set; }

    public int FirstHP { get; set; }

    public int STR { get; set; }

    public int DEF { get; set; }
    
    public int LUCK { get; set; }
    
    public int AGI { get; set; }

    public int FirstMP { get; set; }
    
    public int MP { get; set; }
    

    public string Abnormality { get; set; }
    
    public int Team { get; set; }

    public bool AttackFinished { get; set; }

    public bool isLive { get; set; }

    public  Player(object usename){
        SQLDate sqlDate = new SQLDate();
        SQLPlayer sqlplayer = new SQLPlayer();
        sqlplayer = sqlDate.getSQLPlayer(usename.ToString());

        PlayerName = sqlplayer.PlayerName;
        JOB = sqlplayer.JOB;
        HP = sqlplayer.HP;
        STR = sqlplayer.STR;
        DEF = sqlplayer.DEF;
        LUCK = sqlplayer.LUCK;
        AGI = sqlplayer.AGI;
        MP = sqlplayer.MP;
        FirstHP = sqlplayer.HP;
        FirstMP = sqlplayer.MP;
        AttackFinished = false;
        isLive = true;
        textmanager = GameObject.Find("battletext").GetComponent<TextManager>();
    }

    public virtual void Attack(Player defender,int turnNumber){
        int damage = calcDamage(defender);
        textmanager.battleLog(this.PlayerName+"の攻撃 ➡ "+defender.PlayerName+"に"+damage+"のダメージ");
        defender.damage(damage);
        this.AttackFinished = true;
    }

    public virtual int calcDamage(Player target)
    {
        int damage;
    	if(this.LUCK <= UnityEngine.Random.Range(0f,100f)){
    		damage = this.STR;
    		return damage;
    	}
        damage = this.STR - target.DEF;
        if (damage < 0)
        {
               damage = 0;
        }
    	return damage;
    }

    public void damage(int damage){
        this.HP = this.HP - damage;
        this.downJudge();
    }

    public bool isParise(){
        if(this.Abnormality != "parise"){
            return false;
        }
        if(UnityEngine.Random.Range(0f,5f) == 0){
            return true;
        }else{
            return false;
        }
    }

    public void playerstatusText(GameObject statuspanel){
        Text nametext = statuspanel.GetComponentsInChildren<Text>().First();
        Text statustext = statuspanel.GetComponentsInChildren<Text>().Last();
        nametext.text = $"{this.PlayerName}\r\n{this.JOB}";
        statustext.text = $"HP  {this.HP}/{this.FirstHP}\r\nMP  {this.MP}/{this.FirstMP}";

        if(this.Abnormality=="parise"){
            statustext.text = statustext.text.ToString()+"\r\n麻痺";
        }else if(this.Abnormality=="poison"){
            statustext.text = statustext.text.ToString()+"\r\n毒";
        }
        
        if(this.HP <= 0){
            nametext.color = new Color(1, 0, 0, 1);
            statustext.color = new Color(1, 0, 0, 1);
        }
    }

    public void poisonDamage(){
        if(this.isLive == false){
            return;
        }
        
        if(this.Abnormality == "poison"){
            this.damage(20);
            textmanager.battleLog(this.PlayerName+"は毒によるダメージを受けた");
        }            
        this.downJudge();
    }

    public void downJudge(){
        if(this.HP <= 0){
            textmanager.battleLog(this.PlayerName+"は倒れた");
            this.isLive = false;
            this.AttackFinished = true;
        }
    }
    
}

}
