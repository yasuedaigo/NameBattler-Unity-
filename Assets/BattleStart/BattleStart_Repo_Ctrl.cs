using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AllChara;
using MakeParty;
using SQLManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BattleStart
{
    public class BattleStart_Repo_Ctrl : MonoBehaviour
    {
        public static List<PlayerDTO> enemyPlayerDTOList;

        public static List<PlayerDTO> myteamPlayerDTOList;

        IRepository Repo;

        void Start()
        {
            Repo = new CharacterRepository();
            enemyPlayerDTOList = new List<PlayerDTO>();
            myteamPlayerDTOList = new List<PlayerDTO>();
        }

        public List<PlayerDTO> makeEnemyDTOList()
        {
            enemyPlayerDTOList.Clear();
            int enemyint;
            List<int> enemyintlist = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    enemyint =
                        UnityEngine.Random.Range(0, Repo.getEnemyRowint());
                }
                while (enemyintlist.Contains(enemyint));
                enemyintlist.Add (enemyint);
            }

            foreach (int num in enemyintlist)
            {
                PlayerDTO playerDTO = Repo.getENEMYPlayerDTO(num);
                enemyPlayerDTOList.Add (playerDTO);
            }
            return enemyPlayerDTOList;
        }

        public List<PlayerDTO> makemyTeamDTOList(List<int> myteamintlist)
        {
            foreach (int num in myteamintlist)
            {
                PlayerDTO playerDTO = Repo.getmyTeamPlayerDTO(num);
                myteamPlayerDTOList.Add (playerDTO);
            }
            return myteamPlayerDTOList;
        }

        public int getEnemyRowint()
        {
            return Repo.getEnemyRowint();
        }
    }
}
