using System.Collections;
using System.Collections.Generic;
using SQLManager;
using UnityEngine;

namespace AllChara
{
    public class AllCharaController : MonoBehaviour
    {
        IRepository repo;

        void Start()
        {
            repo = new CharacterRepository();
        }
        
        public List<PlayerDTO> getmyTeamAllCharaList()
        {
            return repo.getmyTeamAllCharaList();
        }
        
        public int countmyTeamTableRows()
        {
            return repo.countmyTeamTableRows();
        }
    }
}
