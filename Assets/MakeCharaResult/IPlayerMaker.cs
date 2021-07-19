using System.Collections;
using System.Collections.Generic;
using SQLManager;
using UnityEngine;

namespace MakeCharaResult
{
    public interface IPlayerMaker
    {
        PlayerDTO makePlayerDTO(string usename);
    }
}
