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

    public JOBs JOB { get; set; }

    public int HP { get; set; }

    public int FirstHP { get; set; }

    public int STR { get; set; }

    public int DEF { get; set; }
    
    public int LUCK { get; set; }
    
    public int AGI { get; set; }

    public int FirstMP { get; set; }
    
    public int MP { get; set; }
    

    public Abnormalitys Abnormality { get; set; }
    
    public int Team { get; set; }

    public bool AttackFinished { get; set; }

    public  Player(PlayerDTO playerDTO){
        PlayerName = playerDTO.PlayerName;
        JOB = (JOBs)Enum.Parse(typeof(JOBs), playerDTO.JOB.ToString());
        HP = playerDTO.HP;
        STR = playerDTO.STR;
        DEF = playerDTO.DEF;
        LUCK = playerDTO.LUCK;
        AGI = playerDTO.AGI;
        MP = playerDTO.MP;
        FirstHP = playerDTO.HP;
        FirstMP = playerDTO.MP;
        AttackFinished = false;
        textmanager = GameObject.Find("battletext").GetComponent<TextManager>();
    }

    public virtual void Attack(Player defender,int turnNumber){
        int damage = calcDamage(defender);
        textmanager.battleLog($"{this.PlayerName}の攻撃 ➡ {defender.PlayerName}に{damage}のダメージ");
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
        if(this.Abnormality != Abnormalitys.Parise){
            return false;
        }
        if(UnityEngine.Random.Range(0f,5f) == 0){
            return true;
        }
        return false;
    }

    public void playerstatusText(GameObject statuspanel){
        Text nametext = statuspanel.GetComponentsInChildren<Text>().First();
        Text statustext = statuspanel.GetComponentsInChildren<Text>().Last();
        nametext.text = $"{this.PlayerName}\r\n{this.JOB.GetStringValue()}";
        statustext.text = $"HP  {this.HP}/{this.FirstHP}\r\nMP  {this.MP}/{this.FirstMP}";

        if(this.Abnormality == Abnormalitys.Parise){
            statustext.text = $"{statustext.text.ToString()}\r\n{this.Abnormality.GetStringValue()}";
        }else if(this.Abnormality == Abnormalitys.Poison){
            statustext.text = $"{statustext.text.ToString()}\r\n{this.Abnormality.GetStringValue()}";
        }
        
        if(this.HP <= 0){
            nametext.color = new Color(1, 0, 0, 1);
            statustext.color = new Color(1, 0, 0, 1);
        }
    }

    public void poisonDamage(){
        if(!this.isLive()){
            return;
        }
        
        if(this.Abnormality == Abnormalitys.Poison){
            this.damage(20);
            textmanager.battleLog($"{this.PlayerName}は毒によるダメージを受けた");
        }            
        this.downJudge();
    }

    public void downJudge(){
        if(!this.isLive()){
            textmanager.battleLog(this.PlayerName+"は倒れた");
            this.AttackFinished = true;
        }
    }

    public bool isLive(){
        if(this.HP <= 0){
            return false;
        }
        return true;
    }
    
}

}
