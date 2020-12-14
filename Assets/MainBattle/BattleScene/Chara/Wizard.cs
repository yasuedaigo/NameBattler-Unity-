using System.Collections;
using System.Collections.Generic;
using BattleScene;
using BattleScene.Magic;
using SQLManager;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace BattleScene.Chara
{
    public class Wizard : Player
    {
        TextManager textmanager;

        List<Magics> useAbleMagic = new List<Magics>(){Magics.Fire,Magics.Thunder}; 

        public Wizard(PlayerDTO playerDTO) :
            base(playerDTO)
        {
            textmanager =
                GameObject.Find("battletext").GetComponent<TextManager>();
        }

        public override void Attack(Player defender, int turnNumber)
        {
            int damage = calcDamage(defender);
            if (base.isFreez())
            {
                textmanager.battleLog($"{base.PlayerName}は麻痺した");
                base.AttackFinished = true;
                return;
            }
            this.wizardAttack(defender, turnNumber);
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
            int magicsNumber = useAbleMagic.Count;
            int selectMagicInt = UnityEngine.Random.Range(0,magicsNumber);
            string selectMagicName = useAbleMagic[selectMagicInt].ToString();
            Type selectMagicType = Type.GetType("BattleScene.Magic."+selectMagicName);
            IMagic selectMagic = (IMagic)Activator.CreateInstance(selectMagicType);
            return selectMagic;
            
        }
    }
}
