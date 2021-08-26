using System;
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
        List<Magics> priestuseAbleMagics = new List<Magics>(){ Magics.Heal, Magics.Parise, Magics.Poison };
        TextManager textmanager;

        public Priest(PlayerDTO playerDTO) : base(playerDTO)
        {
            textmanager = GameObject.Find("battletext").GetComponent<TextManager>();
        }

        public override void Attack(Player defender, int turnNumber)
        {
            if (base.isFreez())
            {
                textmanager.battleLog($"{base.PlayerName}は麻痺した");
                base.AttackFinished = true;
                return;
            }
            this.priestAttack(defender, turnNumber);
            base.AttackFinished = true;
        }

        public void priestAttack(Player defender, int turnNumber)
        {
            if (turnNumber == 1)
            {
                this.firstTurnAttack(defender, turnNumber);
            }
            else if (defender.canReceiveHeal(this))
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
            IMagic magic = this.choiceMagic();
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
                base.Attack(defender, turnNumber);
            }
        }

        /*public IMagic choiceMagic()
        {
            int magicsNumber = priestuseAbleMagics.Count;
            string selectMagicName;
            do
            {
                Debug.Log(this.priestuseAbleMagics[0]);
                Debug.Log(this.priestuseAbleMagics[1]);
                Debug.Log(this.priestuseAbleMagics[2]);
                int selectMagicInt = UnityEngine.Random.Range(0, magicsNumber);
                selectMagicName = priestuseAbleMagics[selectMagicInt].ToString();
                Debug.Log(selectMagicName);
            }
            while (selectMagicName == "Heal");
            Type selectMagicType =
                Type.GetType("BattleScene.Magic." + selectMagicName);
            IMagic selectMagic =
                (IMagic) Activator.CreateInstance(selectMagicType);
                Debug.Log(selectMagic.ToString());
            return selectMagic;
        }*/
        public IMagic choiceMagic()
        {
            IMagic selectMagic = null;
            int selectMagicInt = UnityEngine.Random.Range(0, 2);
            if(selectMagicInt == 0)
            {
                selectMagic = new Poison();
            }else
            {
                selectMagic = new Parise();
            }
            return selectMagic;
        }
    }
}
