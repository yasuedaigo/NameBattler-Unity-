using System.Collections;
using System.Collections.Generic;
using SQLManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MakeParty
{
    public class MakeParty_Repo_Ctrl : MonoBehaviour
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
