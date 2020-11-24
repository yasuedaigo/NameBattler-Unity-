using System.Collections;
using System.Collections.Generic;
using BattleScene;
using BattleScene.Chara;
using UnityEngine;

namespace BattleScene.Magic
{
    public class Thunder : BaseMagic
    {
        Magics magic = Magics.Thunder;

        int maxDamage;

        int minDamage;

        public Thunder()
        {
            maxDamage = 30;
            minDamage = 20;
            base.DownMP = (int) magic;
        }

        public override void Use(Player attacker, Player defender)
        {
            int calcDamage =
                UnityEngine.Random.Range(this.minDamage, this.maxDamage + 1);
            textmanager
                .battleLog($"{attacker.PlayerName}のサンダー！   {defender.PlayerName}に{calcDamage}のダメージ");
            attacker.MP = attacker.MP - base.DownMP; 
            defender.damage (calcDamage);
            attacker.AttackFinished = true;
        }
    }
}
