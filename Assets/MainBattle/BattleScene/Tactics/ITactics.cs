﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleScene.Chara;
using BattleScene;


namespace BattleScene.Tactics
{

public interface ITactics
{
    int target(List<Player> party,Player player);
}

}