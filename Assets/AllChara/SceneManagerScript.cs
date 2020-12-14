using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AllChara
{
    public class SceneManagerScript : MonoBehaviour
    {
        public void onLoadTitle()
        {
            SceneManager.LoadScene("Title");
        }

        public void onLoadMakeChara()
        {
            SceneManager.LoadScene("MakeChara");
        }

        public void onLoadCharaStatus()
        {
            string selectedCharaNumStr = this.name;
            AllCharaViewManager.selectedCharaNum = int.Parse(selectedCharaNumStr);
            SceneManager.LoadScene("CharaStatus");
        }
    }
}
