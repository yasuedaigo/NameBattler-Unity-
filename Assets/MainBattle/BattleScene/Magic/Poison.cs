using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleScene;
using BattleScene.Chara;

namespace BattleScene.Magic{

public class Poison : IMagic
{
    TextManager textmanager = GameObject.Find("battletext").GetComponent<TextManager>();

    public void Use(Player attacker, Player defender){
        defender.Abnormality = Abnormalitys.Poison;
        textmanager.battleLog($"{attacker.PlayerName}のポイズン！ ➡ {defender.PlayerName}は毒状態になった");
        attacker.AttackFinished = true;
    }

}

}