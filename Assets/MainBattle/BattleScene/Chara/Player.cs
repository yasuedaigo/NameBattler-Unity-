using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BattleScene;
using BattleScene.Magic;
using BattleScene.Magic;
using SQLManager;
using UnityEngine;
using UnityEngine.UI;
using BattleScene.Chara;

namespace BattleScene.Chara
{
    public class Player
    {
        public TextManager textmanager;
        public const int POISON_DAMAGE = 20;
        public const int PARISE_PROBABILITY = 5;

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

        public Teams Team { get; set; }

        public bool AttackFinished { get; set; }

        public Player(PlayerDTO playerDTO)
        {
            PlayerName = playerDTO.PlayerName;
            JOB = (JOBs) Enum.Parse(typeof (JOBs), playerDTO.JOB.ToString());
            HP = playerDTO.HP;
            STR = playerDTO.STR;
            DEF = playerDTO.DEF;
            LUCK = playerDTO.LUCK;
            AGI = playerDTO.AGI;
            MP = playerDTO.MP;
            FirstHP = playerDTO.HP;
            FirstMP = playerDTO.MP;
            AttackFinished = false;
            textmanager =
                GameObject.Find("battletext").GetComponent<TextManager>();
        }

        public virtual void Attack(Player defender, int turnNumber)
        {
            int damage = calcDamage(defender);
            textmanager
                .battleLog($"{this.PlayerName}の攻撃 ➡ {defender.PlayerName}に{damage}のダメージ");
            defender.damage (damage);
            this.AttackFinished = true;
        }

        public virtual int calcDamage(Player target)
        {
            int damage;
            if (this.criticalHit())
            {
                damage = this.STR;
            }
            else
            {
                damage = this.STR - target.DEF;
            }
            if (damage < 0) damage = 0;
            return damage;
        }

        public void damage(int damage)
        {
            this.HP = this.HP - damage;
            this.downJudge();
        }

        public bool criticalHit()
        {
            if (this.LUCK >= UnityEngine.Random.Range(0f, 100f))
            {
                return true;
            }
            return false;
        }

        public bool isFreez()
        {
            bool isParise = this.isParise();
            bool pariseJudge = this.pariseJudge();
            if (isParise && pariseJudge)
            {
                return true;
            }
            return false;
        }

        public void drowStatusText(GameObject statuspanel)
        {
            Text nametext = statuspanel.GetComponentsInChildren<Text>().First();
            Text statustext = statuspanel.GetComponentsInChildren<Text>().Last();
            nametext.text = $"{this.PlayerName}\r\n{this.JOB.GetStringValue()}";
            statustext.text =
                $"HP  {this.HP}/{this.FirstHP}\r\nMP  {this.MP}/{this.FirstMP}";

            if (this.isParise())
            {
                statustext.text =
                    $"{statustext.text.ToString()}\r\n{this.Abnormality.GetStringValue()}";
            }
            else if (this.isPoison())
            {
                statustext.text =
                    $"{statustext.text.ToString()}\r\n{this.Abnormality.GetStringValue()}";
            }

            if (this.isDown())
            {
                nametext.color = new Color(1, 0, 0, 1);
                statustext.color = new Color(1, 0, 0, 1);
            }
        }

        public void poisonDamage()
        {
            if (this.isDown())
            {
                return;
            }

            if (this.isPoison())
            {
                this.poison();
                textmanager.battleLog($"{this.PlayerName}は毒によるダメージを受けた");
            }
            this.downJudge();
        }

        public void poison()
        {
           this.HP = this.HP - POISON_DAMAGE;
        }

        public void downJudge()
        {
            if (this.isDown())
            {
                textmanager.battleLog(this.PlayerName + "は倒れた");
                this.AttackFinished = true;
            }
        }

        public bool isLive()
        {
            if (this.HP <= 0) return false;
            return true;
        }

        public bool isDown()
        {
            return !this.isLive();
        }

        public bool isPoison()
        {
            if (this.Abnormality == Abnormalitys.Poison) return true;
            return false;
        }

        public bool isParise()
        {
            if (this.Abnormality == Abnormalitys.Parise) return true;
            return false;
        }

        public bool isNotParise()
        {
            return !isParise();
        }

        bool pariseJudge()
        {
            if (UnityEngine.Random.Range(0, PARISE_PROBABILITY) == 0)
            {
                return true;
            }
            return false;
        }

        public bool canUseHeal()
        {
            if ((this.isPriest()) && (this.enoughMP(Magics.Heal)))
            {
                return true;
            }
            return false;
        }

        public bool canAttack()
        {
            if (this.AttackFinished)
            {
                return false;
            }
            if (this.isLive())
            {
                return true;
            }
            return false;
        }

        public bool canReceiveAttack(Player attacker)
        {
            if (this.isElseTeam(attacker) && this.isLive())
            {
                return true;
            }
            return false;
        }

        public bool canNotReceiveAttack(Player attacker)
        {
            return !this.canReceiveAttack(attacker);
        }

        public bool canReceiveHeal(Player attacker)
        {
            if (this.isSameTeam(attacker) && this.isLive())
            {
                return true;
            }
            return false;
        }

        public bool isFighter()
        {
            if (this.GetType() == typeof (Fighter))
            {
                return true;
            }
            return false;
        }

        public bool isPriest()
        {
            if (this.GetType() == typeof (Priest))
            {
                return true;
            }
            return false;
        }

        public bool isSameTeam(Player player)
        {
            if (this.Team == player.Team)
            {
                return true;
            }
            return false;
        }

        public bool isSameTeam(Teams team)
        {
            if (this.Team == team)
            {
                return true;
            }
            return false;
        }

        public bool isElseTeam(Player player)
        {
            return !this.isSameTeam(player);
        }

        public bool enoughMP(Magics magic)
        {
            if (this.MP >= (int) magic)
            {
                return true;
            }
            return false;
        }
    }
}
