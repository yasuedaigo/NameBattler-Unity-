﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleScene.Chara;
using BattleScene;


namespace BattleScene.Tactics
{

public interface ITactics
{
    Player target(Party party,Player player);
}

}