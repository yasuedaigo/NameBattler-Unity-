﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleAllChara : MonoBehaviour
{
    public void OnClickStartButton()
{
    SceneManager.LoadScene("AllChara");
}
}
