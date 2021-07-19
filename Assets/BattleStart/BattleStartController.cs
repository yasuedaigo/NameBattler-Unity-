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
    public class BattleStartController : MonoBehaviour
    {
        public static List<PlayerDTO> enemyPlayerDTOList;
        public static List<PlayerDTO> myTeamPlayerDTOList;
        IRepository repo;

        void Start()
        {
            repo = new CharacterRepository();
            enemyPlayerDTOList = new List<PlayerDTO>();
            myTeamPlayerDTOList = new List<PlayerDTO>();
        }

        public List<PlayerDTO> makeEnemyDTOList()
        {
            enemyPlayerDTOList.Clear();
            int enemyId;
            List<int> enemyIdList = new List<int>();
            for (int i = 0; i < MakePartyViewManager.CHARA_NUMBER_OF_PARTY; i++)
            {
                do
                {
                    enemyId = UnityEngine.Random.Range(0, repo.countEnemyTableRows());
                }
                while (enemyIdList.Contains(enemyId));
                enemyIdList.Add (enemyId);
            }

            foreach (int id in enemyIdList)
            {
                PlayerDTO playerDTO = repo.getEnemyPlayerDTO(id);
                enemyPlayerDTOList.Add (playerDTO);
            }
            return enemyPlayerDTOList;
        }

        public List<PlayerDTO> makeMyTeamDTOList(List<int> myTeamIdList)
        {
            foreach (int id in myTeamIdList)
            {
                PlayerDTO playerDTO = repo.getmyTeamPlayerDTO(id);
                myTeamPlayerDTOList.Add (playerDTO);
            }
            return myTeamPlayerDTOList;
        }

        public int countEnemyTableRows()
        {
            return repo.countEnemyTableRows();
        }
    }
}
