using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SQLManager;

namespace MakeParty
{
    

public class MakePartySQLController : MonoBehaviour
{
    ContentManager contentmanager;
    SQLController sqlController;
    
    void Start()
    {
        sqlController = new SQLController();
        contentmanager = GameObject.Find("Content").GetComponent<ContentManager>();
        contentmanager.contentText(sqlController.getSQLPlayerList(SQLController.TableNames.CHARACTER));
    }
}

}