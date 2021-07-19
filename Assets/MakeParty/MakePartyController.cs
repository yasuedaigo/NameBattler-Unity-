using System.Collections;
using System.Collections.Generic;
using SQLManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MakeParty
{
    public class MakePartyController : MonoBehaviour
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
