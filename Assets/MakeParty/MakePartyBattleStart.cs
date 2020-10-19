using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SQLManager;

namespace MakeParty
{
    

public class MakePartyBattleStart : MonoBehaviour
{
    ContentManager contentmanager;
    public static List<int> playerintlist = new List<int>();
    public List<Toggle> togglelist = new List<Toggle>();
    public Text messagetext;
    SQLDate sqlDate;
    // Start is called before the first frame update
    void Start()
    {
        sqlDate = new SQLDate();
        contentmanager = GameObject.Find("Content").GetComponent<ContentManager>();
        foreach (var toggleobject in contentmanager.objectlist)
        {
            togglelist.Add(toggleobject.GetComponent<Toggle>());
        }
    }


    public void pushBattleStart(){
        playerintlist.Clear();
        
        foreach (var playertoggle in togglelist)
        {
            if(playertoggle.isOn == true && int.Parse(playertoggle.name) < sqlDate.Rowint){
                playerintlist.Add(int.Parse(playertoggle.name));
            }
        }
        if(playerintlist.Count != 3){
            messagetext.text = "プレイヤーが"+playerintlist.Count+"人選ばれています。パーティ人数は３人です";
        }else{
            SceneManager.LoadScene("BattleStart");
        }
    }
}

}