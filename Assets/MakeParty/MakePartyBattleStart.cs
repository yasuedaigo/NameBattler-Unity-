using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MakeParty
{
    

public class MakePartyBattleStart : MonoBehaviour
{
    public static List<int> playerintlist = new List<int>();
    public static List<Toggle> togglelist = new List<Toggle>();
    public Text messagetext;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<10;i++){
            togglelist.Add(GameObject.Find(i.ToString()));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pushBattleStart(){
        playerintlist.Clear();
        
        foreach (var playertoggle in togglelist)
        {
            if(playertoggle.isOn == true){
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