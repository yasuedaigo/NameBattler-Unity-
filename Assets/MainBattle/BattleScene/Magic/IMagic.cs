using System.Collections;
using System.Collections.Generic;
using BattleScene;
using BattleScene.Chara;
using UnityEngine;

namespace BattleScene.Magic
{
    public interface IMagic
    {
        void Use(Player attacker, Player defender);

        bool canUse(Player player);
    }
}
