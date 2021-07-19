using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MakeCharaResult;
using MakeCharaResult;
using SQLManager;
using UnityEngine;
using UnityEngine.UI;
using MakeChara;

namespace MakeChara
{

public class JobTogggleScript : MonoBehaviour
{
    public void selectJob()
        {
            GameObject.Find("Content").GetComponent<JobSelectToggleManager>().selectJob();
        }
}

}
