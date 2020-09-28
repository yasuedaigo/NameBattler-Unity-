using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputFieldManagernamespace;
using Togglejob;
using UnityEngine.SceneManagement;

public class StartMakeChara : MonoBehaviour
{
    InputFieldManager inputfieldmanager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeChara(){
        if(InputFieldManager.NameCheck() == true){
            Debug.Log(InputFieldManager.GetName());
            SceneManager.LoadScene("MakeCharaResult");
        }
    
}}
