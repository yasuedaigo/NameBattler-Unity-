using System.Collections;
using System.Collections.Generic;
using BattleScene;
using BattleScene.Chara;
using UnityEngine;

namespace BattleScene.Magic
{
    public class Parise : BaseMagic
    {
        Magics magic = Magics.Parise;

        Abnormalitys Effect;

        public Parise()
        {
            Effect = Abnormalitys.Parise;
            base.DownMP = (int) magic;
        }

        public override void Use(Player attacker, Player defender)
        {
            defender.Abnormality = this.Effect;
            attacker.MP = attacker.MP - base.DownMP;
            textmanager
                .battleLog($"{attacker.PlayerName}のパライズ！ ➡ {defender.PlayerName}は{Effect.GetStringValue()}状態になった");
            attacker.AttackFinished = true;
        }
    }
}
