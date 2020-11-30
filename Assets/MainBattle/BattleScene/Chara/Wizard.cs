using System.Collections;
using System.Collections.Generic;
using BattleScene;
using BattleScene.Magic;
using SQLManager;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.Chara
{
    public class Wizard : Player
    {
        TextManager textmanager;

        public Wizard(PlayerDTO playerDTO) :
            base(playerDTO)
        {
            textmanager =
                GameObject.Find("battletext").GetComponent<TextManager>();
        }

        public override void Attack(Player defender, int turnNumber)
        {
            int damage = calcDamage(defender);
            if (base.PariseCheck())
            {
                textmanager.battleLog($"{base.PlayerName}は麻痺した");
            }
            else
            {
                this.wizardAttack(defender, turnNumber);
            }
            base.AttackFinished = true;
        }

        public void wizardAttack(Player defender, int turnNumber)
        {
            IMagic magic = this.choiceMagic();
            if (magic.canUse(this))
            {
                magic.Use(this, defender);
            }
            else
            {
                base.Attack(defender, turnNumber);
            }
        }

        public IMagic choiceMagic()
        {
            if (UnityEngine.Random.Range(0, 2) == 1)
            {
                return new Fire();
            }
            return new Thunder();
        }
    }
}
