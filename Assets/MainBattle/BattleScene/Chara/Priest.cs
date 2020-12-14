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
        List<Magics> useAbleMagics = new List<Magics>(){ Magics.Heal, Magics.Parise, Magics.Poison };
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
            IMagic magic = choiceMagic();
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

        public IMagic choiceMagic()
        {
            int magicsNumber = useAbleMagics.Count;
            string selectMagicName;
            do
            {
                int selectMagicInt = UnityEngine.Random.Range(0, magicsNumber);
                selectMagicName = useAbleMagics[selectMagicInt].ToString();
            }
            while (selectMagicName == "Heal");
            Type selectMagicType =
                Type.GetType("BattleScene.Magic." + selectMagicName);
            IMagic selectMagic =
                (IMagic) Activator.CreateInstance(selectMagicType);
            return selectMagic;
        }
    }
}
