using System.Collections;
using System.Collections.Generic;
using BattleScene;
using BattleScene.Chara;
using UnityEngine;

namespace BattleScene.Tactics
{
    public interface ITactics
    {
        Player target(Party party, Player player);
    }
}
