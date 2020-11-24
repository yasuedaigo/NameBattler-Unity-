using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MakeCharaResult
{
    public class SceneManagerScript : MonoBehaviour
    {
        public void onLoadAllChara()
        {
            SceneManager.LoadScene("AllChara");
        }

        public void onLoadMakeChara()
        {
            SceneManager.LoadScene("MakeChara");
        }
    }
}
