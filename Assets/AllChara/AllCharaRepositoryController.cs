using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLManager;

namespace AllChara{

public class AllCharaRepositoryController : MonoBehaviour
{
    IFRepository ifRepository;

    void Start()
    {
        ifRepository = new CharacterRepository();
    }

    public List<PlayerDTO> getmyTeamAllCharaList(){
        return ifRepository.getmyTeamAllCharaList();
    }

    public int getmyTeamRowint(){
        return ifRepository.getmyTeamRowint(); 
    }

}

}