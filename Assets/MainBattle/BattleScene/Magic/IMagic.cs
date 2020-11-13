using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleScene.Chara;
using BattleScene;


namespace BattleScene.Magic
{

public interface IMagic
{
    void Use(Player attacker,Player defender);
}

}