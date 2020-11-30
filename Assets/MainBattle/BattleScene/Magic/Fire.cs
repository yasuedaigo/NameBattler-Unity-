using System.Collections;
using System.Collections.Generic;
using BattleScene;
using BattleScene.Chara;
using UnityEngine;

namespace BattleScene.Magic
{
    public class Fire : BaseMagic
    {
        Magics magic = Magics.Fire;

        int maxDamage;

        int minDamage;

        public Fire()
        {
            maxDamage = 30;
            minDamage = 10;
            base.DownMP = (int) magic;
        }

        public override void Use(Player attacker, Player defender)
        {
            int calcedDamage =
                UnityEngine.Random.Range(this.minDamage, this.maxDamage + 1);
            textmanager
                .battleLog($"{attacker.PlayerName}のファイア！   {defender.PlayerName}に{calcedDamage}のダメージ");
            attacker.MP = attacker.MP - base.DownMP; //mp消費-20
            defender.damage (calcedDamage);
            attacker.AttackFinished = true;
        }
    }
}
