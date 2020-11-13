using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleScene;
using BattleScene.Chara;

namespace BattleScene.Magic{

public class Parise : IMagic
{
    TextManager textmanager = GameObject.Find("battletext").GetComponent<TextManager>();

    public void Use(Player attacker, Player defender){
        defender.Abnormality = Abnormalitys.Parise;
        textmanager.battleLog($"{attacker.PlayerName}のパライズ！ ➡ {defender.PlayerName}は麻痺した");
        attacker.AttackFinished = true;
    }

}

}