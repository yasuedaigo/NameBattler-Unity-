using System.Collections;
using System.Collections.Generic;
using BattleScene;
using BattleScene.Magic;
using SQLManager;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.Chara
{
    public class Priest : Player
    {
        TextManager textmanager;

        public Priest(PlayerDTO playerDTO) :
            base(playerDTO)
        {
            textmanager =
                GameObject.Find("battletext").GetComponent<TextManager>();
        }

        public override void Attack(Player defender, int turnNumber)
        {
            if (base.PariseCheck())
            {
                textmanager.battleLog($"{base.PlayerName}は麻痺した");
            }
            else
            {
                this.priestAttack(defender, turnNumber);
            }
            base.AttackFinished = true;
        }

        public void priestAttack(Player defender, int turnNumber)
        {
            if (turnNumber == 1)
            {
                this.firstTurnAttack(defender, turnNumber);
            }
            else if (defender.Team == base.Team)
            {
                IMagic magic = new Heal();
                this.useMagic(magic, defender, turnNumber);
            }
            else
            {
                base.Attack(defender, turnNumber);
            }
        }

        public void firstTurnAttack(Player defender, int turnNumber)
        {
            IMagic magic;
            if (UnityEngine.Random.Range(0, 2) == 1)
            {
                magic = new Parise();
            }
            else
            {
                magic = new Poison();
            }
            this.useMagic(magic, defender, turnNumber);
        }

        public void useMagic(IMagic magic, Player defender, int turnNumber)
        {
            if (magic.canUse(this))
            {
                magic.Use(this, defender);
            }
            else
            {
                this.Attack(defender, turnNumber);
            }
        }
    }
}
