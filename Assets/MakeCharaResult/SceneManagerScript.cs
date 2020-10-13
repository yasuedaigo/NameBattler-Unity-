using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MakeCharaResult
{
    
public class SceneManagerScript : MonoBehaviour
{
    public void onClickBackTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void onClickBackButton(){
        SceneManager.LoadScene("MakeChara");
    }

}

}