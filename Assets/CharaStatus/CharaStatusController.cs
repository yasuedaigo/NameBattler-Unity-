using System.Collections;
using System.Collections.Generic;
using AllChara;
using SQLManager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CharaStatus
{
    public class CharaStatusController : MonoBehaviour
    {
        IRepository repo;

        void Start()
        {
            repo = new CharacterRepository();
        }

        public void deleteChara()
        {
            int rowIdOfSelectedChara = AllChara.AllCharaViewManager.selectedCharaNum;
            repo.deletemyTeamPlayer (rowIdOfSelectedChara);
            SceneManager.LoadScene("AllChara");
        }

        public int countmyTeamTableRows()
        {
            return repo.countmyTeamTableRows();
        }

        public PlayerDTO getmyTeamPlayerDTO(int playerRowId)
        {
            return repo.getmyTeamPlayerDTO(playerRowId);
        }
    }
}
