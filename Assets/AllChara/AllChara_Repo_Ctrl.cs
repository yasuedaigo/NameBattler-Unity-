using System.Collections;
using System.Collections.Generic;
using SQLManager;
using UnityEngine;

namespace AllChara
{
    public class AllChara_Repo_Ctrl : MonoBehaviour
    {
        IRepository Repo;

        void Start()
        {
            Repo = new CharacterRepository();
        }

        public List<PlayerDTO> getmyTeamAllCharaList()
        {
            return Repo.getmyTeamAllCharaList();
        }

        public int getmyTeamRowint()
        {
            return Repo.getmyTeamRowint();
        }
    }
}
