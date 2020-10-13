using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BattleStart
{

public class BackButton : MonoBehaviour
{
    
    public void clickBackButton(){
        SceneManager.LoadScene("MakeParty");
    }
}

}