using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MakeParty;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SQLManager;
using System.Linq;
using AllChara;

namespace BattleStart{

public class BattleStartRepositoryManager : MonoBehaviour
{
    IFRepository ifRepository;
    public static List<PlayerDTO> enemyPlayerDTOList;
    public static List<PlayerDTO> myteamPlayerDTOList;

    void Start()
    {
        ifRepository = new CharacterRepository();
        enemyPlayerDTOList = new List<PlayerDTO>();
        myteamPlayerDTOList = new List<PlayerDTO>();
    }
    
    
    public List<PlayerDTO> makeEnemyDTOList(){
        enemyPlayerDTOList.Clear();
        int enemyint;
        List<int> enemyintlist = new List<int>();
        for(int i=0; i<3; i++){
            do{
                enemyint = UnityEngine.Random.Range(0,ifRepository.getEnemyRowint());
            }while(enemyintlist.Contains(enemyint));
            enemyintlist.Add(enemyint);
        }

        foreach(int num in enemyintlist){
            PlayerDTO playerDTO = ifRepository.getENEMYPlayerDTO(num);
            enemyPlayerDTOList.Add(playerDTO);
        }
        return enemyPlayerDTOList;
    }

    public List<PlayerDTO> makemyTeamDTOList(List<int> myteamintlist){

        foreach(int num in  myteamintlist)
        {
            PlayerDTO playerDTO = ifRepository.getmyTeamPlayerDTO(num);
            myteamPlayerDTOList.Add(playerDTO);
        }
        return myteamPlayerDTOList;
    }

    public int getEnemyRowint(){
        return ifRepository.getEnemyRowint();
    }
}

}