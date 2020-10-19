using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Title
{

public class SceanManager : MonoBehaviour
{
    public void TitleAllChara()
{
    SceneManager.LoadScene("AllChara");
}

public void TitleMakeParty()
{
    SceneManager.LoadScene("MakeParty");
}
}

}
