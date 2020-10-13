using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MakeChara{


public class SceneManagerScript : MonoBehaviour
{
    public InputFieldManager inputfieldmanager;
    // Start is called before the first frame update
    void Start()
    {
        inputfieldmanager = GameObject.Find("InputField").GetComponent<InputFieldManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void loadAllChara()
{
    SceneManager.LoadScene("AllChara");
}

    public void makeChara(){
        if(inputfieldmanager.NameCheck() == true){
            SceneManager.LoadScene("MakeCharaResult");
        }
    }

}

}
