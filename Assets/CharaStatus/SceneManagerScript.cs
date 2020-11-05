using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CharaStatus
{
    

public class SceneManagerScript : MonoBehaviour
{
    public void backSceneAllChara(){
        SceneManager.LoadScene("AllChara");
    }
}

}