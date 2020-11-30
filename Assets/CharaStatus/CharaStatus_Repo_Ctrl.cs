using System.Collections;
using System.Collections.Generic;
using AllChara;
using SQLManager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CharaStatus
{
    public class CharaStatus_Repo_Ctrl : MonoBehaviour
    {
        IRepository Repo;

        StatusView StatusView;

        void Start()
        {
            Repo = new CharacterRepository();
        }

        public void onClickDeleteButton()
        {
            int rowid = AllChara.ContentManager.charaNum;
            Repo.deletemyTeamPlayer (rowid);
            SceneManager.LoadScene("AllChara");
        }

        public int getmyTeamRowint()
        {
            return Repo.getmyTeamRowint();
        }

        public PlayerDTO getmyTeamPlayerDTO(int playerint)
        {
            return Repo.getmyTeamPlayerDTO(playerint);
        }
    }
}
