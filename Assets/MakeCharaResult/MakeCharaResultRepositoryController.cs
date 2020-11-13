using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MakeChara;
using AllChara;
using SQLManager;
using System.Linq;

namespace MakeCharaResult{


public class MakeCharaResultRepositoryController : MonoBehaviour
{
    MakePlayerManager makePlayerManager;
    IFRepository ifRepository;

    void Start()
    {
        makePlayerManager = this.GetComponent<MakePlayerManager>();
        ifRepository = new CharacterRepository();
    }

    public bool canAddCharaNumber(){
        return ifRepository.canAddCharaNumber();
    }

    public bool canAddCharaName(string usename){
        return ifRepository.canAddCharaName(usename);
    }

    public void addmyTeamData(PlayerDTO playerDTO){
        ifRepository.addmyTeamData(playerDTO);
    }
}

}
