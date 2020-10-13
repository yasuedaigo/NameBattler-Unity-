using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CharaStatus{

public class CharaStatusAllChara : MonoBehaviour
{
    public void OnClickBackButton()
{
    SceneManager.LoadScene("AllChara");
}
    
}

}