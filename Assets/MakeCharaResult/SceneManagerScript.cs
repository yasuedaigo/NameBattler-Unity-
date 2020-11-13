using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MakeCharaResult
{
    
public class SceneManagerScript : MonoBehaviour
{
    public void onClickBackAllChara()
    {
        SceneManager.LoadScene("AllChara");
    }

    public void onClickBackMakeChara(){
        SceneManager.LoadScene("MakeChara");
    }

}

}