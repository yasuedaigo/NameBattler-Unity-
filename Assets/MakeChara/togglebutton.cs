using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Togglejob;

public class togglebutton : MonoBehaviour
{
    public GameObject targetobject;
    public Toggle toggle;
    public ToggleManager togglemanager;
    // Start is called before the first frame update
    
    void Start()
    {
        togglemanager = targetobject.GetComponent<ToggleManager>();
        toggle = this.GetComponent<Toggle>();
        if(toggle.isOn == true){
            togglemanager.settgljob(this.name);
            togglemanager.debug();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void test(){
        if(toggle.isOn == true){
            togglemanager.settgljob(this.name);
            togglemanager.debug();
        }
    }
}