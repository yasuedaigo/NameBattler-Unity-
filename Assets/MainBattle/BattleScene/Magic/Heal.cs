using System.Collections;
using System.Collections.Generic;
using BattleScene;
using BattleScene.Chara;
using UnityEngine;

namespace BattleScene.Magic
{
    public class Heal : BaseMagic
    {
        Magics magic = Magics.Fire;

        int RecoveryPoint;

        public Heal()
        {
            RecoveryPoint = 50;
            base.DownMP = (int) magic;
        }

        public override void Use(Player attacker, Player defender)
        {
            textmanager
                .battleLog($"{attacker.PlayerName}のヒール ➡ {defender.PlayerName}のHPを{this.RecoveryPoint}回復" +
                $"({defender.HP}➡({defender.HP}+{this.RecoveryPoint}))");
            defender.HP = defender.HP + this.RecoveryPoint;
            attacker.MP = attacker.MP - base.DownMP;
            attacker.AttackFinished = true;
        }
    }
}
