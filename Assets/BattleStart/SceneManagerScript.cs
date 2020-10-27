using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace BattleStart{

public class SceneManagerScript : MonoBehaviour
{
    public void clickBackButton(){
        SceneManager.LoadScene("MakeParty");
    }

}

}
