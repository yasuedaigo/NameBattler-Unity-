using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BattleStart
{
    public class SceneManagerScript : MonoBehaviour
    {
        public void onLoadMakeParty()
        {
            SceneManager.LoadScene("MakeParty");
        }

        public void onLoadMainBattle()
        {
            SceneManager.LoadScene("MainBattle");
        }
    }
}
