using System.Collections;
using System.Collections.Generic;
using BattleScene;
using SQLManager;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.Chara
{
    public class Fighter : Player
    {
        TextManager textmanager;

        public Fighter(PlayerDTO playerDTO) :
            base(playerDTO)
        {
            textmanager =
                GameObject.Find("battletext").GetComponent<TextManager>();
        }

        public override void Attack(Player defender, int turnNumber)
        {
            if (base.isFreez())
            {
                textmanager.battleLog($"{base.PlayerName}は麻痺した");
                base.AttackFinished = true;
                return;
            }
            fighterAttack(defender,turnNumber);
        }
        
        public void fighterAttack(Player defender, int turnNumber){
            int damage = calcDamage(defender);
            textmanager
                    .battleLog($"{this.PlayerName}の攻撃 ➡ {defender.PlayerName}に{damage}のダメージ");
            defender.damage (damage);
            base.AttackFinished = true;
        }
    }
}
