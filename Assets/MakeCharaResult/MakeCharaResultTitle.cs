using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MakeCharaResultTitle : MonoBehaviour
{
    public void OnClickBackButton()
{
    SceneManager.LoadScene("Title");
}
}
