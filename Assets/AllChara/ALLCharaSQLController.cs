using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLManager;

namespace AllChara{

public class ALLCharaSQLController : MonoBehaviour
{
    public static int charaNum;
    SQLController sqlContoroller;
    ContentManager contentmanager;

    void Start()
    {
        sqlContoroller = new SQLController();
        contentmanager = GameObject.Find("Content").GetComponent<ContentManager>();
        contentmanager.viewContent(sqlContoroller.getSQLPlayerList(SQLController.TableNames.CHARACTER));
    }

}

}