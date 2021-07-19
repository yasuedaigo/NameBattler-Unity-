using System.Collections;
using System.Collections.Generic;
using BattleScene;
using SQLManager;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.Chara
{
    public class Ninja : Player
    {
        TextManager textmanager;

        public Ninja(PlayerDTO playerDTO) : base(playerDTO)
        {
            textmanager = GameObject.Find("battletext").GetComponent<TextManager>();
        }

        public override void Attack(Player defender, int turnNumber)
        {
            int damage = calcDamage(defender);
            if (turnNumber == 1)
            {
                damage = base.STR;
            }
            else if (defender.isFighter())
            {
                int stockDEF = defender.DEF;
                defender.DEF = stockDEF / 2;
                damage = calcDamage(defender);
                defender.DEF = stockDEF;
            }
            textmanager
                .battleLog($"{this.PlayerName}の攻撃 ➡ {defender.PlayerName}に{damage}のダメージ");
            defender.damage (damage);
            base.AttackFinished = true;
        }
    }
}
