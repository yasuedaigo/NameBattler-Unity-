using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SQLManager;

namespace MakeParty
{
    

public class MakePartyRepositoryController : MonoBehaviour
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