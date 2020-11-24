using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Makeparty
{
    public class SceneManagerScript : MonoBehaviour
    {
        public void onLoadTitle()
        {
            SceneManager.LoadScene("Title");
        }
    }
}
