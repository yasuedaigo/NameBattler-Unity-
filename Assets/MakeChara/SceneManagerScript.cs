using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MakeChara
{
    public class SceneManagerScript : MonoBehaviour
    {
        public InputFieldManager inputfieldmanager;

        public Text messagetext;

        void Start()
        {
            inputfieldmanager =
                GameObject.Find("InputField").GetComponent<InputFieldManager>();
        }

        public void loadAllChara()
        {
            SceneManager.LoadScene("AllChara");
        }

        public void makeChara()
        {
            SceneManager.LoadScene("MakeCharaResult");
        }
    }
}
