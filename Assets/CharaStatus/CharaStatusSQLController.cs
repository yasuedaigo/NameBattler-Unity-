using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AllChara;
using SQLManager;

namespace CharaStatus{

public class CharaStatusSQLController : MonoBehaviour
{
    SQLController sqlController;
    CharaStatusText charaStatustext;

    void Start()
    {
        sqlController = new SQLController();
        charaStatustext = GameObject.Find("CharaStatusText").GetComponent<CharaStatusText>();
        if(ALLCharaSQLController.charaNum <= sqlController.getRowint(SQLController.TableNames.CHARACTER)-1){
            SQLPlayer textchara =  sqlController.getSQLPlayer(ALLCharaSQLController.charaNum,SQLController.TableNames.CHARACTER);
            charaStatustext.charastatustext(textchara);
        }
    }

    public void onClickDeleteButton(){
        int rowid = ALLCharaSQLController.charaNum;
        sqlController.deletePlayer(rowid,SQLController.TableNames.CHARACTER);
        SceneManager.LoadScene("AllChara");
    }
}

}
