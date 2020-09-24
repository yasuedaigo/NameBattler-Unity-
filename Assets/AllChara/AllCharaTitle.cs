using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllCharaTitle : MonoBehaviour
{
    public void OnClickStartButton()
{
    SceneManager.LoadScene("Title");
}
}
