using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using AllChara;

namespace CharaStatus{

public class CharaDelete : MonoBehaviour
{
    int rowid;

    void Start(){
        rowid = ContentManager.charaNum;
    }

    public void onClickDeleteButton(){
        SqliteDatabase sqlDB = new SqliteDatabase("character.db");
        string query = "delete from status where playername = (select playername from status limit 1 offset "+rowid+")";
        sqlDB.ExecuteNonQuery(query);

        SceneManager.LoadScene("AllChara");
    }
}

}
