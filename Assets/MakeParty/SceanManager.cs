using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Makeparty
{


public class SceanManager : MonoBehaviour
{
    public void clickBackButton(){
        SceneManager.LoadScene("Title");
    }
}

}
