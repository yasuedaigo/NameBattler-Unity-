using System.Collections;
using System.Collections.Generic;
using BattleScene;
using BattleScene.Chara;
using UnityEngine;

namespace BattleScene.Magic
{
    public abstract class BaseMagic : IMagic
    {
        public int DownMP { get; set; }
        
        public TextManager textmanager = GameObject.Find("battletext").GetComponent<TextManager>();

        public abstract void Use(Player attacker, Player defender);

        public bool canUse(Player player)
        {
            if (player.MP >= DownMP) return true;
            return false;
        }
    }
}
