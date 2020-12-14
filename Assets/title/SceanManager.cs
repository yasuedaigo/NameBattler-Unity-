using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Title
{
    public class SceanManager : MonoBehaviour
    {
        public void onLoadAllChara()
        {
            SceneManager.LoadScene("AllChara");
        }

        public void onLoadMakeParty()
        {
            SceneManager.LoadScene("MakeParty");
        }
    }
}
