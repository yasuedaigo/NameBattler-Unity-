using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLManager;

namespace MakeCharaResult
{
    
public interface IFMakePlayer
{
    PlayerDTO makePlayer(string name);
}

}