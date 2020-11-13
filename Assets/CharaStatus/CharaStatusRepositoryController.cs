using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AllChara;
using SQLManager;

namespace CharaStatus{

public class CharaStatusRepositoryController : MonoBehaviour
{
    IFRepository ifRepository;
    CharaStatusText charaStatustext;

    void Start()
    {
        ifRepository = new CharacterRepository();
    }

    public void onClickDeleteButton(){
        int rowid = AllChara.ContentManager.charaNum;
        ifRepository.deletemyTeamPlayer(rowid);
        SceneManager.LoadScene("AllChara");
    }

    public int getmyTeamRowint(){
        return ifRepository.getmyTeamRowint();
    }

    public PlayerDTO getmyTeamPlayerDTO(int playerint){
        return ifRepository.getmyTeamPlayerDTO(playerint);
    }

}

}
